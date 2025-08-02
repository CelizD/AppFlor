using FlorApp.DataAccess;
using System;
using System.Configuration; // <-- Línea añadida para ConfigurationManager
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FlorApp.Presentation
{
    public partial class ReportesForm : Form
    {
        private readonly VentaRepository _ventaRepository;

        public ReportesForm()
        {
            InitializeComponent();

            // Leer cadena de conexión desde app.config
            string connectionString = ConfigurationManager.ConnectionStrings["FlorAppDB"].ConnectionString;
            _ventaRepository = new VentaRepository(connectionString);

            this.Load += new EventHandler(ReportesForm_Load);
            btnGenerarReporte.Click += new EventHandler(btnGenerarReporte_Click);
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
            btnGenerarReporte_Click(sender, e);
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                if (fechaInicio > fechaFin)
                {
                    CustomMessageBoxForm.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxIcon.Warning);
                    return;
                }

                var reporteVentasTask = _ventaRepository.ObtenerReporteVentasAsync(fechaInicio, fechaFin);
                var reporteRentabilidadTask = _ventaRepository.ObtenerReporteRentabilidadAsync(fechaInicio, fechaFin);
                var reporteVendedorTask = _ventaRepository.ObtenerReporteVentasPorEmpleadoAsync(fechaInicio, fechaFin);
                var reporteHorasPicoTask = _ventaRepository.ObtenerVentasPorHoraAsync(fechaInicio, fechaFin);
                var reporteVentasDiaTask = _ventaRepository.ObtenerVentasPorDiaSemanaAsync(fechaInicio, fechaFin);

                await Task.WhenAll(reporteVentasTask, reporteRentabilidadTask, reporteVendedorTask, reporteHorasPicoTask, reporteVentasDiaTask);

                var reporteVentas = reporteVentasTask.Result;
                var reporteRentabilidad = reporteRentabilidadTask.Result;
                var reporteVendedor = reporteVendedorTask.Result;
                var reporteHorasPico = reporteHorasPicoTask.Result;
                var reporteVentasDia = reporteVentasDiaTask.Result;

                dgvReporteVentas.DataSource = reporteVentas;
                dgvVentasPorEmpleado.DataSource = reporteVendedor;
                CargarGraficoVentasPorDia(reporteVentasDia);
                CargarGraficoVentasPorHora(reporteHorasPico);

                if (reporteVentas.Any())
                {
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

                    dgvRentabilidad.DataSource = reporteRentabilidad.OrderByDescending(p => p.GananciaNeta).ToList();

                    decimal totalVendido = reporteRentabilidad.Sum(r => r.IngresosTotales);
                    decimal gananciaNeta = reporteRentabilidad.Sum(r => r.GananciaNeta);
                    lblTotalVendido.Text = totalVendido.ToString("C");
                    lblGananciaNeta.Text = gananciaNeta.ToString("C");
                }
                else
                {
                    dgvMasVendidos.DataSource = null;
                    dgvRentabilidad.DataSource = null;
                    dgvVentasPorEmpleado.DataSource = null;
                    lblTotalVendido.Text = "$0.00";
                    lblGananciaNeta.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al generar los reportes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        private void CargarGraficoVentasPorDia(System.Collections.Generic.List<VentasPorDia> datos)
        {
            chartVentasPorDia.Series.Clear();
            var series = new Series("Ventas por Día")
            {
                ChartType = SeriesChartType.Column
            };
            foreach (var item in datos)
            {
                series.Points.AddXY(item.DiaDeLaSemana, item.TotalVendido);
            }
            chartVentasPorDia.Series.Add(series);
        }

        private void CargarGraficoVentasPorHora(System.Collections.Generic.List<VentasPorHora> datos)
        {
            chartVentasPorHora.Series.Clear();
            var series = new Series("Ventas por Hora")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3
            };
            for (int i = 0; i < 24; i++)
            {
                var ventaHora = datos.FirstOrDefault(d => d.Hora == i);
                series.Points.AddXY($"{i:00}:00", ventaHora?.TotalVendido ?? 0);
            }
            chartVentasPorHora.Series.Add(series);
        }
    }
}

