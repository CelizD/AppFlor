using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class VentasForm : Form
    {
        // Lista estática para almacenar ventas en espera mientras la aplicación esté abierta
        private static List<VentaEnEspera> _ventasEnEspera = new List<VentaEnEspera>();

        // Usuario actualmente logueado
        private readonly Usuario _usuarioActual;

        // Repositorios para acceder a datos de productos, ventas y clientes
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly ClienteRepository _clienteRepository;

        // Lista enlazada que representa el carrito de la venta actual
        private BindingList<VentaDetalle> _carrito;

        // Descuento aplicado a la venta
        private decimal _descuentoGeneral = 0;

        // Cliente seleccionado para la venta actual
        private Cliente _clienteSeleccionado = null;

        // Monto inicial con el que se abre la caja
        private decimal _montoInicial = -1;

        // Total de ventas acumuladas en el turno actual
        private decimal _ventasTotalesDelTurno = 0;

        public VentasForm(Usuario usuario)
        {
            InitializeComponent();

            // Asignar usuario actual y crear instancias de repositorios
            _usuarioActual = usuario;
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository();
            _clienteRepository = new ClienteRepository();

            // Asociar evento Load para inicializar controles y cargar datos
            this.Load += new EventHandler(VentasForm_Load);
        }

        // Evento que se ejecuta al cargar el formulario
        private async void VentasForm_Load(object sender, EventArgs e)
        {
            InicializarControles();          // Configurar controles y eventos
            await CargarClientesAsync();     // Cargar lista de clientes en el combo
            ActualizarEstadoCaja();          // Actualizar UI según estado de caja
        }

        // Inicializa controles y asigna eventos
        private void InicializarControles()
        {
            // Crear BindingList para carrito y asignarla al DataGridView
            _carrito = new BindingList<VentaDetalle>();
            dgvCarrito.DataSource = _carrito;

            // Asociar eventos a botones y controles
            btnAbrirCaja.Click += new EventHandler(btnAbrirCaja_Click);
            btnCerrarCaja.Click += new EventHandler(btnCerrarCaja_Click);
            btnAgregar.Click += (s, e) => AgregarProductoAlCarrito();
            txtCodigoProducto.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    AgregarProductoAlCarrito();
                    e.SuppressKeyPress = true; // Evita sonido al presionar Enter
                }
            };
            btnFinalizarVenta.Click += new EventHandler(btnFinalizarVenta_Click);
            cmbCliente.SelectedIndexChanged += new EventHandler(cmbCliente_SelectedIndexChanged);
            btnCanjearPuntos.Click += new EventHandler(btnCanjearPuntos_Click);
            btnPonerEnEspera.Click += new EventHandler(btnPonerEnEspera_Click);
            btnRecuperarVenta.Click += new EventHandler(btnRecuperarVenta_Click);
        }

        // Carga la lista de clientes de forma asíncrona
        private async Task CargarClientesAsync()
        {
            try
            {
                var clientes = await _clienteRepository.ObtenerTodosAsync();

                // Insertar opción para cliente general al inicio
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

        // Limpia todo lo relacionado a la venta actual (carrito, cliente, descuentos)
        private void LimpiarVentaCompleta()
        {
            _carrito.Clear();
            _descuentoGeneral = 0;

            // Seleccionar cliente general si hay clientes cargados
            if (cmbCliente.Items.Count > 0)
                cmbCliente.SelectedIndex = 0;

            _clienteSeleccionado = null;
            lblPuntosCliente.Text = "Puntos: N/A";
            btnCanjearPuntos.Enabled = false;

            CalcularTotales(); // Actualizar totales a cero
        }

        #region Gestión de Caja

        // Abrir caja: solicita monto inicial y habilita controles
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

        // Cerrar caja: muestra resumen y bloquea controles si confirma
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

        // Actualiza el estado de la UI según si la caja está abierta o cerrada
        private void ActualizarEstadoCaja()
        {
            bool cajaAbierta = _montoInicial != -1;

            // Habilitar o deshabilitar paneles según estado de caja
            pnlProductos.Enabled = cajaAbierta;
            pnlCliente.Enabled = cajaAbierta;
            pnlCarrito.Enabled = cajaAbierta;
            pnlTotales.Enabled = cajaAbierta;
            btnCerrarCaja.Enabled = cajaAbierta;
            btnAbrirCaja.Enabled = !cajaAbierta;

            // Actualizar etiqueta con estado de caja y color
            if (cajaAbierta)
            {
                lblEstadoCaja.Text = $"CAJA ABIERTA (Inicio: {_montoInicial:C})";
                lblEstadoCaja.ForeColor = Color.FromArgb(46, 204, 113); // Verde
            }
            else
            {
                lblEstadoCaja.Text = "CAJA CERRADA";
                lblEstadoCaja.ForeColor = Color.FromArgb(231, 76, 60); // Rojo
                LimpiarVentaCompleta(); // Limpiar al cerrar caja
            }
        }
        #endregion

        #region Lógica de Ventas en Espera

        // Guardar la venta actual en la lista de ventas en espera
        private void btnPonerEnEspera_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("No hay productos en el carrito para poner en espera.", "Carrito Vacío", MessageBoxIcon.Warning);
                return;
            }

            var ventaEnEspera = new VentaEnEspera
            {
                Carrito = new BindingList<VentaDetalle>(_carrito.ToList()), // Copia del carrito actual
                ClienteSeleccionado = _clienteSeleccionado,
                DescuentoGeneral = _descuentoGeneral,
                Fecha = DateTime.Now
            };

            _ventasEnEspera.Add(ventaEnEspera); // Agregar a la lista estática
            LimpiarVentaCompleta();              // Limpiar UI
            CustomMessageBoxForm.Show("Venta puesta en espera exitosamente.", "Éxito", MessageBoxIcon.Information);
        }

        // Recuperar una venta que se había puesto en espera
        private void btnRecuperarVenta_Click(object sender, EventArgs e)
        {
            if (_ventasEnEspera.Count == 0)
            {
                CustomMessageBoxForm.Show("No hay ventas en espera para recuperar.", "Sin Ventas", MessageBoxIcon.Information);
                return;
            }

            if (_carrito.Count > 0)
            {
                // Confirmar si desea descartar la venta actual para recuperar otra
                if (CustomConfirmBoxForm.Show("Tiene una venta en curso. ¿Desea descartarla para recuperar otra?", "Venta en Curso") != DialogResult.Yes)
                {
                    return;
                }
            }

            // Mostrar formulario con lista de ventas en espera
            using (var form = new VentasEsperaForm(_ventasEnEspera))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var ventaRecuperada = form.VentaSeleccionada;
                    if (ventaRecuperada != null)
                    {
                        // Reemplazar carrito y cliente por la venta recuperada
                        _carrito.Clear();
                        foreach (var item in ventaRecuperada.Carrito)
                        {
                            _carrito.Add(item);
                        }

                        _clienteSeleccionado = ventaRecuperada.ClienteSeleccionado;
                        _descuentoGeneral = ventaRecuperada.DescuentoGeneral;

                        cmbCliente.SelectedItem = _clienteSeleccionado ?? cmbCliente.Items[0];
                        CalcularTotales();

                        _ventasEnEspera.Remove(ventaRecuperada); // Remover de lista
                    }
                }
            }
        }
        #endregion

        #region Lógica de Venta Principal

        // Cuando cambia el cliente seleccionado en el combo
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedItem is Cliente cliente && cliente.Id != 0)
            {
                _clienteSeleccionado = cliente;
                lblPuntosCliente.Text = $"Puntos: {_clienteSeleccionado.Puntos}";
                btnCanjearPuntos.Enabled = true; // Habilitar canje de puntos
            }
            else
            {
                _clienteSeleccionado = null;
                lblPuntosCliente.Text = "Puntos: N/A";
                btnCanjearPuntos.Enabled = false;
            }
        }

        // Agrega un producto al carrito, buscando por código o nombre
        private async void AgregarProductoAlCarrito()
        {
            string busqueda = txtCodigoProducto.Text;
            if (string.IsNullOrWhiteSpace(busqueda)) return;

            var productoEncontrado = await _productoRepository.BuscarPorCodigoONombreAsync(busqueda);

            if (productoEncontrado == null)
            {
                CustomMessageBoxForm.Show("Producto no encontrado.", "Error", MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)numCantidad.Value;

            // Verificar si el producto ya está en el carrito
            var itemExistente = _carrito.FirstOrDefault(item => item.ProductoId == productoEncontrado.Id);

            if (itemExistente != null)
            {
                // Si existe, actualizar cantidad y total
                itemExistente.Cantidad += cantidad;
                itemExistente.TotalLinea = itemExistente.Cantidad * itemExistente.PrecioUnitario;
            }
            else
            {
                // Si no existe, agregar nuevo item
                _carrito.Add(new VentaDetalle
                {
                    ProductoId = productoEncontrado.Id,
                    NombreProducto = productoEncontrado.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = productoEncontrado.PrecioVenta,
                    TotalLinea = cantidad * productoEncontrado.PrecioVenta
                });
            }

            // Limpiar y enfocar textbox para nuevo código
            txtCodigoProducto.Clear();
            numCantidad.Value = 1;
            txtCodigoProducto.Focus();
            dgvCarrito.Refresh();
            CalcularTotales();
        }

        // Calcula subtotal y total considerando descuento general
        private void CalcularTotales()
        {
            decimal subtotal = _carrito.Sum(item => item.TotalLinea);
            decimal total = subtotal - _descuentoGeneral;

            lblSubtotalValor.Text = subtotal.ToString("C");
            lblTotalValor.Text = total.ToString("C");
        }

        // Finaliza la venta: guarda datos, actualiza puntos y resetea UI
        private async void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("El carrito está vacío.", "Venta Vacía", MessageBoxIcon.Warning);
                return;
            }

            decimal totalVenta = _carrito.Sum(item => item.TotalLinea) - _descuentoGeneral;
            string metodoPago = "Efectivo";

            // Mostrar formulario para seleccionar método de pago
            using (var formCobro = new CobrarForm(totalVenta))
            {
                if (formCobro.ShowDialog() == DialogResult.OK)
                {
                    metodoPago = formCobro.MetodoPagoSeleccionado;
                }
                else
                {
                    // Si canceló cobro, salir sin guardar
                    return;
                }
            }

            // Crear objeto venta con datos actuales
            var venta = new Venta
            {
                Fecha = DateTime.Now,
                Subtotal = _carrito.Sum(item => item.TotalLinea),
                Impuestos = 0,
                Total = totalVenta,
                MetodoPago = metodoPago,
                Cliente = _clienteSeleccionado?.Nombre ?? "Cliente General",
                Detalles = _carrito.ToList()
            };

            try
            {
                // Guardar venta en base de datos
                await _ventaRepository.GuardarVentaAsync(venta);

                // Si hay cliente, actualizar puntos y total gastado
                if (_clienteSeleccionado != null)
                {
                    int puntosGanados = (int)(venta.Total / 10);
                    int puntosFinales = _clienteSeleccionado.Puntos + puntosGanados;
                    await _clienteRepository.ActualizarPuntosYTotalGastadoAsync(_clienteSeleccionado.Id, puntosFinales, venta.Total);
                }

                // Acumular ventas del turno y mostrar mensaje de éxito
                _ventasTotalesDelTurno += venta.Total;
                CustomMessageBoxForm.Show($"Venta por {venta.Total:C} finalizada.", "Éxito", MessageBoxIcon.Information);

                // Limpiar la venta para nueva operación
                LimpiarVentaCompleta();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        // Canjear puntos del cliente para aplicar descuento
        private void btnCanjearPuntos_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null || _clienteSeleccionado.Puntos <= 0)
            {
                CustomMessageBoxForm.Show("Este cliente no tiene puntos para canjear.", "Sin Puntos", MessageBoxIcon.Information);
                return;
            }

            // Calcular descuento por puntos (ejemplo: $0.50 por punto)
            decimal descuentoPorPuntos = _clienteSeleccionado.Puntos * 0.50m;
            _descuentoGeneral += descuentoPorPuntos;

            // Resetear puntos del cliente tras canje
            _clienteSeleccionado.Puntos = 0;
            lblPuntosCliente.Text = "Puntos: 0 (Canjeados)";
            btnCanjearPuntos.Enabled = false;

            CalcularTotales(); // Actualizar totales con descuento
            CustomMessageBoxForm.Show($"Se aplicó un descuento de {descuentoPorPuntos:C} por puntos.", "Puntos Canjeados", MessageBoxIcon.Information);
        }

        #endregion
    }
}
