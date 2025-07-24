using FlorApp.DataAccess;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ReportesForm : Form
    {
        private readonly VentaRepository _ventaRepository;

        public ReportesForm()
        {
            InitializeComponent();
            _ventaRepository = new VentaRepository();
            this.Load += new EventHandler(ReportesForm_Load);
            btnGenerarReporteVentas.Click += new EventHandler(btnGenerarReporteVentas_Click);
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            // Establecer fechas predeterminadas (ej. el último mes)
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
            // Generar el reporte inicial al cargar
            btnGenerarReporteVentas_Click(sender, e);
        }

        private async void btnGenerarReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // Cargar el reporte de ventas
                var reporteVentas = await _ventaRepository.ObtenerReporteVentasAsync(fechaInicio, fechaFin);
                dgvReporteVentas.DataSource = reporteVentas;

                // Calcular y mostrar los productos más vendidos
                var masVendidos = reporteVentas
                    .GroupBy(r => r.Producto)
                    .Select(g => new ProductoMasVendido
                    {
                        NombreProducto = g.Key,
                        UnidadesVendidas = g.Sum(i => i.Cantidad),
                        IngresosGenerados = g.Sum(i => i.Total)
                    })
                    .OrderByDescending(p => p.IngresosGenerados)
                    .ToList();
                dgvMasVendidos.DataSource = masVendidos;

                // Calcular y mostrar las ganancias (simulado, requiere PrecioCosto)
                decimal totalVendido = reporteVentas.Sum(v => v.Total);
                decimal gananciaEstimada = totalVendido * 0.40m; // Simulación
                lblTotalVendido.Text = totalVendido.ToString("C");
                lblGananciaNeta.Text = gananciaEstimada.ToString("C");
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al generar los reportes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
