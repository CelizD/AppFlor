using FlorApp.DataAccess;
using System;
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

        // Constructor recibe el usuario actual para control de acceso y personalización
        public DashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _productoRepository = new ProductoRepository();
            _ventaRepository = new VentaRepository();
        }

        // Evento que se ejecuta al cargar el formulario
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            AplicarSeguridadPorRol();            // Deshabilita botones según rol
            await CargarDatosDelDashboardAsync(); // Carga datos principales del dashboard
        }

        // Carga datos en paralelo para mejorar rendimiento
        private async Task CargarDatosDelDashboardAsync()
        {
            try
            {
                await Task.WhenAll(
                    CargarDatosDeTarjetasAsync(),    // Ventas totales, productos totales, alertas
                    CargarAlertasDeInventarioAsync(),// Lista de productos con bajo stock
                    CargarGraficoDeVentasAsync()     // Gráfica con ventas últimos 7 días
                );
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show(
                    $"Ocurrió un error al cargar los datos del dashboard: {ex.Message}",
                    "Error de Carga",
                    MessageBoxIcon.Error);
            }
        }

        // Carga los valores para las tarjetas informativas del dashboard
        private async Task CargarDatosDeTarjetasAsync()
        {
            var totalVentasHoy = _ventaRepository.ObtenerTotalVentasHoyAsync();
            var totalProductos = _productoRepository.ContarTodosAsync();
            var productosBajoStock = _productoRepository.ObtenerProductosBajoStockAsync();

            // Espera a que todas las tareas terminen
            await Task.WhenAll(totalVentasHoy, totalProductos, productosBajoStock);

            // Actualiza etiquetas con los resultados
            lblVentasValor.Text = totalVentasHoy.Result.ToString("C");
            lblProductosValor.Text = totalProductos.Result.ToString();
            lblAlertasValor.Text = productosBajoStock.Result.Count.ToString();
        }

        // Llena la lista con productos que tienen bajo stock
        private async Task CargarAlertasDeInventarioAsync()
        {
            var alertas = await _productoRepository.ObtenerProductosBajoStockAsync();

            // Forma texto con nombre, stock y mínimo permitido
            var alertasFormateadas = alertas
                .Select(p => $"{p.Nombre} (Quedan: {p.Stock} / Mínimo: {p.StockMinimo})")
                .ToList();

            lstAlertas.DataSource = alertasFormateadas;
        }

        // Llena el gráfico de ventas con datos de los últimos 7 días
        private async Task CargarGraficoDeVentasAsync()
        {
            var ventasSemanales = await _ventaRepository.ObtenerVentasUltimos7DiasAsync();
            chartVentas.Series["Ventas"].Points.Clear();

            // Agrega un punto para cada día, de más antiguo a más reciente
            for (int i = 6; i >= 0; i--)
            {
                DateTime dia = DateTime.Now.Date.AddDays(-i);
                string clave = dia.ToString("dd/MM");
                double total = ventasSemanales.ContainsKey(clave) ? ventasSemanales[clave] : 0;
                chartVentas.Series["Ventas"].Points.AddXY(clave, total);
            }
        }

        // Controla qué botones se habilitan según el rol del usuario
        private void AplicarSeguridadPorRol()
        {
            this.Text = $"FlorApp - Dashboard (Usuario: {_usuarioActual.NombreUsuario} - Rol: {_usuarioActual.Rol})";

            if (_usuarioActual.Rol != "Administrador")
            {
                // Deshabilita botones y cambia su color a gris para usuarios sin permiso
                btnProveedores.Enabled = false;
                btnReportes.Enabled = false;
                btnConfiguracion.Enabled = false;

                btnProveedores.BackColor = Color.Gray;
                btnReportes.BackColor = Color.Gray;
                btnConfiguracion.BackColor = Color.Gray;
            }
        }

        #region Manejadores de Eventos para Navegación

        // Cada botón abre un formulario relacionado y luego recarga el dashboard al cerrarlo

        private async void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            using (VentasForm ventasForm = new VentasForm(_usuarioActual))
            {
                ventasForm.ShowDialog();
            }
            await CargarDatosDelDashboardAsync();
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
