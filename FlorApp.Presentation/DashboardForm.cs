using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class DashboardForm : Form
    {
        private readonly Usuario _usuarioActual;
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;

        public DashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository();

            // --- CORRECCIÓN ---
            // Se elimina el evento Activated para evitar redundancia y posibles conflictos.
            // La carga de datos se manejará de forma explícita.
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            AplicarSeguridadPorRol();
            // --- CORRECCIÓN ---
            // Se añade la carga de datos inicial aquí para asegurar que siempre se muestre la información la primera vez.
            await CargarDatosDelDashboardAsync();
        }

        private async Task CargarDatosDelDashboardAsync()
        {
            try
            {
                await Task.WhenAll(
                    CargarDatosDeTarjetasAsync(),
                    CargarAlertasDeInventarioAsync(),
                    CargarGraficoDeVentasAsync()
                );
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Ocurrió un error al cargar los datos del dashboard: {ex.Message}", "Error de Carga", MessageBoxIcon.Error);
            }
        }

        private async Task CargarDatosDeTarjetasAsync()
        {
            var totalVentasHoy = _ventaRepository.ObtenerTotalVentasHoyAsync();
            var totalProductos = _productoRepository.ContarTodosAsync();
            var productosBajoStock = _productoRepository.ObtenerProductosBajoStockAsync();

            await Task.WhenAll(totalVentasHoy, totalProductos, productosBajoStock);

            lblVentasValor.Text = totalVentasHoy.Result.ToString("C");
            lblProductosValor.Text = totalProductos.Result.ToString();
            lblAlertasValor.Text = productosBajoStock.Result.Count.ToString();
        }

        private async Task CargarAlertasDeInventarioAsync()
        {
            var alertas = await _productoRepository.ObtenerProductosBajoStockAsync();

            var alertasFormateadas = alertas
                .Select(p => $"{p.Nombre} (Quedan: {p.Stock} / Mínimo: {p.StockMinimo})")
                .ToList();

            lstAlertas.DataSource = alertasFormateadas;
        }

        private async Task CargarGraficoDeVentasAsync()
        {
            var ventasSemanales = await _ventaRepository.ObtenerVentasUltimos7DiasAsync();

            chartVentas.Series["Ventas"].Points.Clear();

            for (int i = 6; i >= 0; i--)
            {
                DateTime dia = DateTime.Now.Date.AddDays(-i);
                string clave = dia.ToString("dd/MM");
                double total = ventasSemanales.ContainsKey(clave) ? ventasSemanales[clave] : 0;
                chartVentas.Series["Ventas"].Points.AddXY(clave, total);
            }
        }

        private void AplicarSeguridadPorRol()
        {
            this.Text = $"FlorApp - Dashboard (Usuario: {_usuarioActual.NombreUsuario} - Rol: {_usuarioActual.Rol})";

            if (_usuarioActual.Rol != "Administrador")
            {
                btnProveedores.Enabled = false;
                btnReportes.Enabled = false;
                btnConfiguracion.Enabled = false;

                btnProveedores.BackColor = Color.Gray;
                btnReportes.BackColor = Color.Gray;
                btnConfiguracion.BackColor = Color.Gray;
            }
        }

        #region Manejadores de Eventos para Navegación

        private async void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (VentasForm ventasForm = new VentasForm())
            {
                ventasForm.ShowDialog(); // Espera a que se cierre la ventana de ventas
            }
            await CargarDatosDelDashboardAsync(); // Recarga los datos inmediatamente después
        }

        private async void btnPedidos_Click(object sender, EventArgs e)
        {
            using (PedidosForm pedidosForm = new PedidosForm())
            {
                pedidosForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnClientes_Click(object sender, EventArgs e)
        {
            using (ClientesForm clientesForm = new ClientesForm())
            {
                clientesForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnProductos_Click(object sender, EventArgs e)
        {
            using (ProductosForm productosForm = new ProductosForm())
            {
                productosForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnProveedores_Click(object sender, EventArgs e)
        {
            using (ProveedoresForm proveedoresForm = new ProveedoresForm())
            {
                proveedoresForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnInventario_Click(object sender, EventArgs e)
        {
            using (InventarioForm inventarioForm = new InventarioForm())
            {
                inventarioForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnReportes_Click(object sender, EventArgs e)
        {
            using (ReportesForm reportesForm = new ReportesForm())
            {
                reportesForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }

        private async void btnConfiguracion_Click(object sender, EventArgs e)
        {
            using (ConfiguracionForm configForm = new ConfiguracionForm())
            {
                configForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
        }
        #endregion
    }
}
