using FlorApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlorApp.Presentation
{
    public partial class DashboardForm : Form
    {
        // --- PALETA DE COLORES DEL NUEVO DISEÑO ---
        private readonly Color colorPrimario = ColorTranslator.FromHtml("#2E8B57"); // Verde Principal
        private readonly Color colorFondo = ColorTranslator.FromHtml("#F8F9FA");    // Gris Claro
        private readonly Color colorTexto = ColorTranslator.FromHtml("#343A40");     // Gris Oscuro
        private readonly Color colorBorde = ColorTranslator.FromHtml("#DEE2E6");    // Borde Sutil
        private readonly Color colorHover = ColorTranslator.FromHtml("#E9ECEF");     // Hover para botones

        private readonly Usuario _usuarioActual;
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly ClienteRepository _clienteRepository;

        // --- Usamos un diccionario para gestionar las ventanas abiertas ---
        private readonly Dictionary<Type, Form> _openForms = new Dictionary<Type, Form>();

        public DashboardForm(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;

            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _productoRepository = new ProductoRepository(connectionString);
            _ventaRepository = new VentaRepository(connectionString);
            _clienteRepository = new ClienteRepository(connectionString);

            this.Load += DashboardForm_Load;
            this.Activated += DashboardForm_Activated;

            SuscribirEventosNavegacion();
        }

        // --- CORRECCIÓN: La carga de datos principal ahora es asíncrona y se hace aquí ---
        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            AplicarEstilosModernos();
            AplicarSeguridadPorRol();
            // Se cargan todos los datos la primera vez que el formulario es visible.
            await CargarDatosDelDashboardAsync();
        }

        // --- CAMBIO: El evento Activated ahora solo refresca datos rápidos ---
        private async void DashboardForm_Activated(object sender, EventArgs e)
        {
            // Este evento se dispara cada vez que el usuario vuelve al Dashboard.
            // Es ideal para refrescar datos que cambian constantemente, como las ventas del día.
            await CargarDatosDeTarjetasAsync();
        }

        #region Aplicación de Estilos del Nuevo Diseño

        private void AplicarEstilosModernos()
        {
            this.BackColor = colorFondo;
            pnlHeader.BackColor = colorPrimario;
            lblHeader.ForeColor = Color.White;

            AplicarEstiloTarjeta(pnlCardVentas, lblVentasTitulo, lblVentasValor);
            AplicarEstiloTarjeta(pnlCardProductos, lblProductosTitulo, lblProductosValor);
            AplicarEstiloTarjeta(pnlCardAlertas, lblAlertasTitulo, lblAlertasValor, true);

            AplicarEstiloPanel(pnlAccesosDirectos, "Menú Principal");
            AplicarEstiloPanel(pnlAlertasInventario, "Alertas de Inventario");
            AplicarEstiloPanel(pnlEventosClientes, "Próximos Eventos de Clientes");

            var botones = pnlAccesosDirectos.Controls.OfType<Button>();
            foreach (var btn in botones)
            {
                AplicarEstiloBotonNavegacion(btn);
            }

            lstAlertas.BorderStyle = BorderStyle.None;
            lstEventosClientes.BorderStyle = BorderStyle.None;
        }

        private void AplicarEstiloTarjeta(Panel panel, Label lblTitulo, Label lblValor, bool esAlerta = false)
        {
            panel.BackColor = Color.White;
            panel.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, colorBorde, ButtonBorderStyle.Solid);

            lblTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = colorTexto;

            lblValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblValor.ForeColor = esAlerta && lblValor.Text != "0" ? Color.Firebrick : colorPrimario;
        }

        private void AplicarEstiloPanel(Panel panel, string titulo)
        {
            panel.BackColor = Color.White;
            panel.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle, colorBorde, ButtonBorderStyle.Solid);

            Label lblTituloPanel = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = colorTexto,
                AutoSize = false,
                Size = new Size(panel.Width - 20, 30),
                Location = new Point(15, 15),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(lblTituloPanel);
            lblTituloPanel.BringToFront();
        }

        private void AplicarEstiloBotonNavegacion(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White;
            btn.ForeColor = colorTexto;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);

            btn.MouseEnter += (s, e) => btn.BackColor = colorHover;
            btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
        }

        #endregion

        #region Lógica de Carga de Datos y Navegación

        private void SuscribirEventosNavegacion()
        {
            btnNuevaVenta.Click += (s, e) => AbrirFormulario(typeof(VentasForm), _usuarioActual);
            btnPedidos.Click += (s, e) => AbrirFormulario(typeof(PedidosForm));
            btnClientes.Click += (s, e) => AbrirFormulario(typeof(ClientesForm));
            btnProductos.Click += (s, e) => AbrirFormulario(typeof(ProductosForm));
            btnProveedores.Click += (s, e) => AbrirFormulario(typeof(ProveedoresForm));
            btnInventario.Click += (s, e) => AbrirFormulario(typeof(InventarioForm));
            btnCompras.Click += (s, e) => AbrirFormulario(typeof(ComprasForm));
            btnReportes.Click += (s, e) => AbrirFormulario(typeof(ReportesForm));
            btnConfiguracion.Click += (s, e) => AbrirFormulario(typeof(ConfiguracionForm));
            btnKiosco.Click += (s, e) => AbrirFormulario(typeof(KioscoForm));
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
            var totalVentasHoy = await _ventaRepository.ObtenerTotalVentasHoyAsync();
            var totalProductos = await _productoRepository.ContarTodosAsync();
            var productosBajoStock = await _productoRepository.ObtenerProductosBajoStockAsync();

            lblVentasValor.Text = totalVentasHoy.ToString("C");
            lblProductosValor.Text = totalProductos.ToString();
            lblAlertasValor.Text = productosBajoStock.Count.ToString();

            if (productosBajoStock.Count > 0)
            {
                lblAlertasValor.ForeColor = Color.Firebrick;
            }
            else
            {
                lblAlertasValor.ForeColor = colorPrimario;
            }
        }

        private async Task CargarAlertasDeInventarioAsync()
        {
            var alertas = await _productoRepository.ObtenerProductosBajoStockAsync();
            lstAlertas.DataSource = alertas
                .Select(p => $"{p.Nombre} (Quedan: {p.Stock} / Mínimo: {p.StockMinimo})")
                .ToList();
        }

        private async Task CargarGraficoDeVentasAsync()
        {
            var ventasSemanales = await _ventaRepository.ObtenerVentasUltimos7DiasAsync();

            // Verificación de seguridad
            if (chartVentas.Series == null) return;

            chartVentas.Series.Clear();
            chartVentas.ChartAreas[0].BackColor = Color.White;
            chartVentas.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartVentas.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            var seriesVentas = new Series("Ventas")
            {
                ChartType = SeriesChartType.Column,
                Color = colorPrimario,
                Font = new Font("Segoe UI", 8F),
                LabelForeColor = colorTexto
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
            var eventos = await _clienteRepository.ObtenerConFechasEspecialesProximasAsync(7);
            lstEventosClientes.DataSource = eventos
                .Select(c => $"{c.Nombre} - {c.FechaEspecial.Value:dd 'de' MMMM}")
                .ToList();
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
            }
        }

        private void AbrirFormulario(Type formType, params object[] args)
        {
            if (_openForms.ContainsKey(formType) && !_openForms[formType].IsDisposed)
            {
                _openForms[formType].BringToFront();
            }
            else
            {
                Form newInstance = (Form)Activator.CreateInstance(formType, args);
                _openForms[formType] = newInstance;
                newInstance.FormClosed += (s, e) => _openForms.Remove(formType);
                newInstance.Show();
            }
        }

        #endregion
    }
}
