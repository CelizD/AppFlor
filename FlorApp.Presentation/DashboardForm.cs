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
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            AplicarSeguridadPorRol();
            // Cargar los datos iniciales cuando el formulario se muestra por primera vez
            await CargarDatosDelDashboardAsync();
        }

        private async Task CargarDatosDelDashboardAsync()
        {
            try
            {
                // Ejecutar todas las tareas de carga de datos en paralelo para mayor eficiencia
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
            // Obtener los datos desde la base de datos usando los repositorios
            var totalVentasHoy = _ventaRepository.ObtenerTotalVentasHoyAsync();
            var totalProductos = _productoRepository.ContarTodosAsync();
            var productosBajoStock = _productoRepository.ObtenerProductosBajoStockAsync();

            // Esperar a que todas las tareas terminen
            await Task.WhenAll(totalVentasHoy, totalProductos, productosBajoStock);

            // Actualizar las tarjetas con los resultados
            lblVentasValor.Text = totalVentasHoy.Result.ToString("C");
            lblProductosValor.Text = totalProductos.Result.ToString();
            lblAlertasValor.Text = productosBajoStock.Result.Count.ToString();
        }

        private async Task CargarAlertasDeInventarioAsync()
        {
            var alertas = await _productoRepository.ObtenerProductosBajoStockAsync();
            
            // Formatear la lista de alertas para mostrarla de forma amigable
            var alertasFormateadas = alertas
                .Select(p => $"{p.Nombre} (Quedan: {p.Stock} / Mínimo: {p.StockMinimo})")
                .ToList();

            lstAlertas.DataSource = alertasFormateadas;
        }

        private async Task CargarGraficoDeVentasAsync()
        {
            var ventasSemanales = await _ventaRepository.ObtenerVentasUltimos7DiasAsync();
            chartVentas.Series["Ventas"].Points.Clear();

            // Llenar el gráfico con los datos de los últimos 7 días
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

            // Si el usuario NO es Administrador, desactivamos los botones sensibles
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
            VentasForm ventasForm = new VentasForm(_usuarioActual);
            ventasForm.ShowDialog(); // Espera a que se cierre la ventana
            await CargarDatosDelDashboardAsync(); // Recarga los datos inmediatamente después
        }

        private async void btnPedidos_Click(object sender, EventArgs e)
        {
            PedidosForm pedidosForm = new PedidosForm();
            pedidosForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnProductos_Click(object sender, EventArgs e)
        {
            ProductosForm productosForm = new ProductosForm();
            productosForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresForm proveedoresForm = new ProveedoresForm();
            proveedoresForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnInventario_Click(object sender, EventArgs e)
        {
            InventarioForm inventarioForm = new InventarioForm();
            inventarioForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnReportes_Click(object sender, EventArgs e)
        {
            ReportesForm reportesForm = new ReportesForm();
            reportesForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }

        private async void btnConfiguracion_Click(object sender, EventArgs e)
        {
            ConfiguracionForm configForm = new ConfiguracionForm();
            configForm.ShowDialog();
            await CargarDatosDelDashboardAsync();
        }
        #endregion
    }
}
