using FlorApp.DataAccess;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class VentasForm : Form
    {
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private BindingList<VentaDetalle> _carrito;

        private decimal _montoInicial = -1;
        private decimal _ventasTotalesDelTurno = 0;

        public VentasForm()
        {
            InitializeComponent();
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository();
            InicializarControles();
            ActualizarEstadoCaja();
        }

        private void InicializarControles()
        {
            _carrito = new BindingList<VentaDetalle>();
            dgvCarrito.DataSource = _carrito;

            btnAbrirCaja.Click += new EventHandler(btnAbrirCaja_Click);
            btnCerrarCaja.Click += new EventHandler(btnCerrarCaja_Click);
            btnAgregar.Click += (s, e) => AgregarProductoAlCarrito();
            txtCodigoProducto.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { AgregarProductoAlCarrito(); e.SuppressKeyPress = true; } };
            btnFinalizarVenta.Click += new EventHandler(btnFinalizarVenta_Click);
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

            // --- MEJORA APLICADA AQUÍ ---
            // Usamos el nuevo ConfirmBox personalizado
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
                _carrito.Clear();
                CalcularTotales();
            }
        }
        #endregion

        #region Lógica de Venta
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

            txtCodigoProducto.Clear();
            numCantidad.Value = 1;
            txtCodigoProducto.Focus();
            dgvCarrito.Refresh();
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = _carrito.Sum(item => item.TotalLinea);
            decimal total = subtotal;
            lblSubtotalValor.Text = subtotal.ToString("C");
            lblTotalValor.Text = total.ToString("C");
        }

        private async void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Count == 0)
            {
                CustomMessageBoxForm.Show("El carrito está vacío.", "Venta Vacía", MessageBoxIcon.Warning);
                return;
            }

            decimal totalVenta = _carrito.Sum(item => item.TotalLinea);
            string metodoPago;

            using (var formCobro = new CobrarForm(totalVenta))
            {
                if (formCobro.ShowDialog() == DialogResult.OK)
                {
                    metodoPago = formCobro.MetodoPagoSeleccionado;
                }
                else
                {
                    return; // El usuario canceló el cobro
                }
            }

            var venta = new Venta
            {
                Fecha = DateTime.Now,
                Subtotal = totalVenta,
                Impuestos = 0,
                Total = totalVenta,
                MetodoPago = metodoPago,
                Detalles = _carrito.ToList()
            };

            try
            {
                await _ventaRepository.GuardarVentaAsync(venta);

                _ventasTotalesDelTurno += venta.Total;
                CustomMessageBoxForm.Show($"Venta por {venta.Total:C} finalizada exitosamente.", "Éxito", MessageBoxIcon.Information);

                _carrito.Clear();
                CalcularTotales();
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
