using FlorApp.DataAccess;
using FlorApp.Presentation;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlorApp.Presentation
{
    public partial class DashboardForm : Form
    {
        private readonly Usuario _usuarioActual;
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly ClienteRepository _clienteRepository;

        private VentasForm _ventasForm;
        private PedidosForm _pedidosForm;
        private ClientesForm _clientesForm;
        private ProductosForm _productosForm;
        private ProveedoresForm _proveedoresForm;
        private InventarioForm _inventarioForm;
        private ComprasForm _comprasForm;
        private ReportesForm _reportesForm;
        private ConfiguracionForm _configuracionForm;
        private KioscoForm _kioscoForm;

        public DashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _ventaRepository = new VentaRepository(connectionString);
            _clienteRepository = new ClienteRepository(connectionString);

            this.Activated += new EventHandler(DashboardForm_Activated);
            btnNuevaVenta.Click += new EventHandler(btnNuevaVenta_Click);
            btnPedidos.Click += new EventHandler(btnPedidos_Click);
            btnClientes.Click += new EventHandler(btnClientes_Click);
            btnProductos.Click += new EventHandler(btnProductos_Click);
            btnProveedores.Click += new EventHandler(btnProveedores_Click);
            btnInventario.Click += new EventHandler(btnInventario_Click);
            btnReportes.Click += new EventHandler(this.btnReportes_Click);
            btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            btnKiosco.Click += new System.EventHandler(this.btnKiosco_Click);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            AplicarSeguridadPorRol();
        }

        private async void DashboardForm_Activated(object sender, EventArgs e)
        {
            await CargarDatosDelDashboardAsync();
        }

        private async Task CargarDatosDelDashboardAsync()
        {
            try
            {
                await Task.WhenAll(
                    CargarDatosDeTarjetasAsync(),
                    CargarAlertasDeInventarioAsync(),
                    CargarGraficoDeVentasAsync(),
                    CargarEventosClientesAsync()
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

            chartVentas.Series.Clear();

            var seriesVentas = new Series("Ventas")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(46, 139, 87)
            };

            for (int i = 6; i >= 0; i--)
            {
                DateTime dia = DateTime.Now.Date.AddDays(-i);
                string clave = dia.ToString("dd/MM");
                double total = ventasSemanales.ContainsKey(clave) ? ventasSemanales[clave] : 0;
                seriesVentas.Points.AddXY(clave, total);
            }

            chartVentas.Series.Add(seriesVentas);
            chartVentas.Legends[0].Enabled = false;
        }

        private async Task CargarEventosClientesAsync()
        {
            var eventosFormateados = new List<string>();
            try
            {
                var eventos = await _clienteRepository.ObtenerConFechasEspecialesProximasAsync(7);
                eventosFormateados = eventos
                    .Select(c => $"{c.Nombre} - {c.FechaEspecial.Value:dd 'de' MMMM}")
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar eventos de clientes: {ex.Message}");
            }
            lstEventosClientes.DataSource = eventosFormateados;
        }

        private void AplicarSeguridadPorRol()
        {
            this.Text = $"FlorApp - Dashboard (Usuario: {_usuarioActual.NombreUsuario} - Rol: {_usuarioActual.Rol})";

            if (_usuarioActual.Rol != "Administrador")
            {
                btnProveedores.Enabled = false;
                btnReportes.Enabled = false;
                btnConfiguracion.Enabled = false;
                btnCompras.Enabled = false;

                btnProveedores.BackColor = Color.Gray;
                btnReportes.BackColor = Color.Gray;
                btnConfiguracion.BackColor = Color.Gray;
                btnCompras.BackColor = Color.Gray;
            }
        }

        #region Manejadores de Eventos para Navegación
        private Form AbrirOReutilizarFormulario(Form formInstance, Type formType, params object[] constructorArgs)
        {
            if (formInstance == null || formInstance.IsDisposed)
            {
                formInstance = (Form)Activator.CreateInstance(formType, constructorArgs);
                formInstance.Show();
            }
            else
            {
                formInstance.BringToFront();
            }
            return formInstance;
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            _ventasForm = (VentasForm)AbrirOReutilizarFormulario(_ventasForm, typeof(VentasForm), _usuarioActual);
            _ventasForm.FormClosed += (s, args) => _ventasForm = null;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            _pedidosForm = (PedidosForm)AbrirOReutilizarFormulario(_pedidosForm, typeof(PedidosForm));
            _pedidosForm.FormClosed += (s, args) => _pedidosForm = null;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            _clientesForm = (ClientesForm)AbrirOReutilizarFormulario(_clientesForm, typeof(ClientesForm));
            _clientesForm.FormClosed += (s, args) => _clientesForm = null;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            _productosForm = (ProductosForm)AbrirOReutilizarFormulario(_productosForm, typeof(ProductosForm));
            _productosForm.FormClosed += (s, args) => _productosForm = null;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            _proveedoresForm = (ProveedoresForm)AbrirOReutilizarFormulario(_proveedoresForm, typeof(ProveedoresForm));
            _proveedoresForm.FormClosed += (s, args) => _proveedoresForm = null;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            _inventarioForm = (InventarioForm)AbrirOReutilizarFormulario(_inventarioForm, typeof(InventarioForm));
            _inventarioForm.FormClosed += (s, args) => _inventarioForm = null;
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            _comprasForm = (ComprasForm)AbrirOReutilizarFormulario(_comprasForm, typeof(ComprasForm));
            _comprasForm.FormClosed += (s, args) => _comprasForm = null;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            _reportesForm = (ReportesForm)AbrirOReutilizarFormulario(_reportesForm, typeof(ReportesForm));
            _reportesForm.FormClosed += (s, args) => _reportesForm = null;
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            _configuracionForm = (ConfiguracionForm)AbrirOReutilizarFormulario(_configuracionForm, typeof(ConfiguracionForm));
            _configuracionForm.FormClosed += (s, args) => _configuracionForm = null;
        }

        private void btnKiosco_Click(object sender, EventArgs e)
        {
            _kioscoForm = (KioscoForm)AbrirOReutilizarFormulario(_kioscoForm, typeof(KioscoForm));
            _kioscoForm.FormClosed += (s, args) => _kioscoForm = null;
        }
        #endregion

        private void btnTestConexion_Click(object sender, EventArgs e)
        {
            ///
        }
    }
}