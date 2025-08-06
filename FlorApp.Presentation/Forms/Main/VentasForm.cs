using FlorApp.DataAccess;
using System;
using FlorApp.Presentation.Forms.Dialogs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlorApp.DataAccess.Models;
using FlorApp.DataAccess.Repositories;
using FlorApp.Presentation.Helpers;


namespace FlorApp.Presentation.Forms.Main
{
    public partial class VentasForm : Form
    {
        private static List<VentaEnEspera> _ventasEnEspera = new List<VentaEnEspera>();

        private readonly Usuario _usuarioActual;
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly ClienteRepository _clienteRepository;
        private BindingList<VentaDetalle> _carrito;
        private decimal _descuentoGeneral = 0;
        private Cliente _clienteSeleccionado = null;
        private decimal _montoInicial = -1;
        private decimal _ventasTotalesDelTurno = 0;
        private ClienteDisplayForm _displayCliente;
        private List<Producto> _listaCompletaProductos;

        public VentasForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _ventaRepository = new VentaRepository(connectionString);
            _clienteRepository = new ClienteRepository(connectionString);

            this.Load += new EventHandler(VentasForm_Load);
            this.FormClosing += new FormClosingEventHandler(VentasForm_FormClosing);
        }

        private async void VentasForm_Load(object sender, EventArgs e)
        {
            InicializarControles();
            await CargarClientesAsync();
            await CargarProductosParaAutocompletar();
            ActualizarEstadoCaja();
            AbrirPantallaCliente();
        }

        private async Task CargarProductosParaAutocompletar()
        {
            try
            {
                _listaCompletaProductos = await _productoRepository.ObtenerTodosAsync();
                var collection = new AutoCompleteStringCollection();
                collection.AddRange(_listaCompletaProductos.Select(p => p.Nombre).ToArray());

                cmbCodigoProducto.AutoCompleteCustomSource = collection;
                cmbCodigoProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCodigoProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar la lista de productos para búsqueda: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void InicializarControles()
        {
            _carrito = new BindingList<VentaDetalle>();
            dgvCarrito.DataSource = _carrito;

            btnAbrirCaja.Click += new EventHandler(btnAbrirCaja_Click);
            btnCerrarCaja.Click += new EventHandler(btnCerrarCaja_Click);
            btnAgregar.Click += (s, e) => AgregarProductoAlCarrito();
            cmbCodigoProducto.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { AgregarProductoAlCarrito(); e.SuppressKeyPress = true; } };
            btnFinalizarVenta.Click += new EventHandler(btnFinalizarVenta_Click);
            cmbCliente.SelectedIndexChanged += new EventHandler(cmbCliente_SelectedIndexChanged);
            btnCanjearPuntos.Click += new EventHandler(btnCanjearPuntos_Click);
            btnPonerEnEspera.Click += new EventHandler(btnPonerEnEspera_Click);
            btnRecuperarVenta.Click += new EventHandler(btnRecuperarVenta_Click);
        }

        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteRepository.ObtenerTodosAsync();
                clientes.Insert(0, new Cliente { Id = 0, Nombre = "Cliente General" });
                cmbCliente.DataSource = clientes;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void LimpiarVentaCompleta()
        {
            _carrito.Clear();
            _descuentoGeneral = 0;
            if (cmbCliente.Items.Count > 0) cmbCliente.SelectedIndex = 0;
            _clienteSeleccionado = null;
            lblPuntosCliente.Text = "Puntos: N/A";
            btnCanjearPuntos.Enabled = false;
            CalcularTotales();
        }

        #region Gestión de Caja
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            using (var form = new AbrirCajaForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _montoInicial = form.MontoInicial;
                    _ventasTotalesDelTurno = 0;
                    ActualizarEstadoCaja();
                }
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            decimal efectivoEsperado = _montoInicial + _ventasTotalesDelTurno;
            string mensaje = $"Resumen del Turno:\n\nMonto Inicial: {_montoInicial:C}\nVentas Totales: {_ventasTotalesDelTurno:C}\n----------------------------------\nEfectivo esperado en caja: {efectivoEsperado:C}\n\n¿Desea cerrar la caja?";

            if (CustomConfirmBoxForm.Show(mensaje, "Cerrar Caja") == DialogResult.Yes)
            {
                _montoInicial = -1;
                ActualizarEstadoCaja();
            }
        }

        private void ActualizarEstadoCaja()
        {
            bool cajaAbierta = _montoInicial != -1;

            pnlProductos.Enabled = cajaAbierta;
            pnlCliente.Enabled = cajaAbierta;
            pnlCarrito.Enabled = cajaAbierta;
            pnlTotales.Enabled = cajaAbierta;
            btnCerrarCaja.Enabled = cajaAbierta;
            btnAbrirCaja.Enabled = !cajaAbierta;

            if (cajaAbierta)
            {
                lblEstadoCaja.Text = $"CAJA ABIERTA (Inicio: {_montoInicial:C})";
                lblEstadoCaja.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                lblEstadoCaja.Text = "CAJA CERRADA";
                lblEstadoCaja.ForeColor = Color.FromArgb(231, 76, 60);
                LimpiarVentaCompleta();
            }
        }
        #endregion

        #region Pantalla de Cliente
        private void AbrirPantallaCliente()
        {
            _displayCliente?.Close();

            _displayCliente = new ClienteDisplayForm();

            if (Screen.AllScreens.Length > 1)
            {
                Screen secondaryScreen = Screen.AllScreens.FirstOrDefault(s => !s.Primary) ?? Screen.AllScreens[0];
                _displayCliente.StartPosition = FormStartPosition.Manual;
                _displayCliente.Left = secondaryScreen.Bounds.Left + 50;
                _displayCliente.Top = secondaryScreen.Bounds.Top + 50;
                // Se elimina la línea que maximiza la ventana para que sea móvil
            }
            else
            {
                _displayCliente.StartPosition = FormStartPosition.CenterScreen;
            }

            _displayCliente.Show();
            ActualizarDisplayCliente();
        }

        private void VentasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _displayCliente?.Close();
        }

        private void ActualizarDisplayCliente()
        {
            if (_displayCliente != null && !_displayCliente.IsDisposed)
            {
                decimal total = _carrito.Sum(item => item.TotalLinea) - _descuentoGeneral;
                _displayCliente.ActualizarVista(_carrito, total);
            }
        }
        #endregion

        #region Lógica de Venta
        private async void AgregarProductoAlCarrito()
        {
            string busqueda = cmbCodigoProducto.Text;
            if (string.IsNullOrWhiteSpace(busqueda)) return;

            var productoEncontrado = _listaCompletaProductos
                .FirstOrDefault(p => p.Nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase) || p.CodigoBarras == busqueda);

            if (productoEncontrado == null)
            {
                productoEncontrado = await _productoRepository.BuscarPorCodigoONombreAsync(busqueda);
            }

            if (productoEncontrado == null)
            {
                CustomMessageBoxForm.Show("Producto no encontrado.", "Error", MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)numCantidad.Value;
            var itemExistente = _carrito.FirstOrDefault(item => item.ProductoId == productoEncontrado.Id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
                itemExistente.TotalLinea = itemExistente.Cantidad * itemExistente.PrecioUnitario;
            }
            else
            {
                _carrito.Add(new VentaDetalle
                {
                    ProductoId = productoEncontrado.Id,
                    NombreProducto = productoEncontrado.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = productoEncontrado.PrecioVenta,
                    TotalLinea = cantidad * productoEncontrado.PrecioVenta
                });
            }

            cmbCodigoProducto.Text = "";
            numCantidad.Value = 1;
            cmbCodigoProducto.Focus();
            dgvCarrito.Refresh();
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = _carrito.Sum(item => item.TotalLinea);
            decimal total = subtotal - _descuentoGeneral;

            lblSubtotalValor.Text = subtotal.ToString("C");
            lblTotalValor.Text = total.ToString("C");
            ActualizarDisplayCliente();
        }

        private async void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("El carrito está vacío.", "Venta Vacía", MessageBoxIcon.Warning);
                return;
            }

            decimal totalVenta = _carrito.Sum(item => item.TotalLinea) - _descuentoGeneral;
            string metodoPago = "Efectivo";

            using (var formCobro = new CobrarForm(totalVenta))
            {
                if (formCobro.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                metodoPago = formCobro.MetodoPagoSeleccionado;
            }

            var venta = new Venta
            {
                Fecha = DateTime.Now,
                Subtotal = _carrito.Sum(item => item.TotalLinea),
                Impuestos = 0,
                Total = totalVenta,
                MetodoPago = metodoPago,
                Cliente = _clienteSeleccionado?.Nombre ?? "Cliente General",
                Vendedor = _usuarioActual.NombreUsuario,
                Detalles = _carrito.ToList()
            };

            try
            {
                await _ventaRepository.GuardarVentaAsync(venta);

                if (_clienteSeleccionado != null)
                {
                    int puntosGanados = (int)(venta.Total / 10);
                    int puntosFinales = _clienteSeleccionado.Puntos + puntosGanados;
                    await _clienteRepository.ActualizarPuntosYTotalGastadoAsync(_clienteSeleccionado.Id, puntosFinales, venta.Total);
                }

                _ventasTotalesDelTurno += venta.Total;
                CustomMessageBoxForm.Show($"Venta por {venta.Total:C} finalizada.", "Éxito", MessageBoxIcon.Information);
                LimpiarVentaCompleta();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Lógica de Lealtad y Espera
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem is Cliente cliente && cliente.Id != 0)
            {
                _clienteSeleccionado = cliente;
                lblPuntosCliente.Text = $"Puntos: {_clienteSeleccionado.Puntos}";
                btnCanjearPuntos.Enabled = true;
            }
            else
            {
                _clienteSeleccionado = null;
                lblPuntosCliente.Text = "Puntos: N/A";
                btnCanjearPuntos.Enabled = false;
            }
        }

        private void btnCanjearPuntos_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null || _clienteSeleccionado.Puntos <= 0)
            {
                CustomMessageBoxForm.Show("Este cliente no tiene puntos para canjear.", "Sin Puntos", MessageBoxIcon.Information);
                return;
            }

            decimal descuentoPorPuntos = _clienteSeleccionado.Puntos * 0.50m;
            _descuentoGeneral += descuentoPorPuntos;

            _clienteSeleccionado.Puntos = 0;
            lblPuntosCliente.Text = "Puntos: 0 (Canjeados)";
            btnCanjearPuntos.Enabled = false;

            CalcularTotales();
            CustomMessageBoxForm.Show($"Se aplicó un descuento de {descuentoPorPuntos:C} por puntos.", "Puntos Canjeados", MessageBoxIcon.Information);
        }

        private void btnPonerEnEspera_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("No hay productos en el carrito para poner en espera.", "Carrito Vacío", MessageBoxIcon.Warning);
                return;
            }

            var ventaEnEspera = new VentaEnEspera
            {
                Carrito = new BindingList<VentaDetalle>(_carrito.ToList()),
                ClienteSeleccionado = _clienteSeleccionado,
                DescuentoGeneral = _descuentoGeneral,
                Fecha = DateTime.Now
            };

            _ventasEnEspera.Add(ventaEnEspera);
            LimpiarVentaCompleta();
            CustomMessageBoxForm.Show("Venta puesta en espera exitosamente.", "Éxito", MessageBoxIcon.Information);
        }

        private void btnRecuperarVenta_Click(object sender, EventArgs e)
        {
            if (_ventasEnEspera.Count == 0)
            {
                CustomMessageBoxForm.Show("No hay ventas en espera para recuperar.", "Sin Ventas", MessageBoxIcon.Information);
                return;
            }

            if (_carrito.Count > 0)
            {
                if (CustomConfirmBoxForm.Show("Tiene una venta en curso. ¿Desea descartarla para recuperar otra?", "Venta en Curso") != DialogResult.Yes)
                {
                    return;
                }
            }

            using (var form = new VentasEsperaForm(_ventasEnEspera))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var ventaRecuperada = form.VentaSeleccionada;
                    if (ventaRecuperada != null)
                    {
                        _carrito.Clear();
                        foreach (var item in ventaRecuperada.Carrito) { _carrito.Add(item); }

                        _clienteSeleccionado = ventaRecuperada.ClienteSeleccionado;
                        _descuentoGeneral = ventaRecuperada.DescuentoGeneral;

                        cmbCliente.SelectedItem = _clienteSeleccionado ?? cmbCliente.Items[0];
                        CalcularTotales();

                        _ventasEnEspera.Remove(ventaRecuperada);
                    }
                }
            }
        }
        #endregion
    }
}
