using FlorApp.DataAccess;
using System;
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
            _ventaRepository = new VentaRepository();
            this.Load += new EventHandler(ReportesForm_Load);
            btnGenerarReporte.Click += new EventHandler(btnGenerarReporte_Click);
        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            // Establecer fechas predeterminadas (ej. el último mes)
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
            // Generar el reporte inicial al cargar el formulario
            btnGenerarReporte_Click(sender, e);
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // Validar que la fecha de inicio no sea mayor que la fecha de fin
                if (fechaInicio > fechaFin)
                {
                    CustomMessageBoxForm.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxIcon.Warning);
                    return;
                }

                // Ejecutar todas las consultas de reportes en paralelo para mayor eficiencia
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

                // Cargar Pestaña 1: Reporte de Ventas
                dgvReporteVentas.DataSource = reporteVentas;

                // Cargar Pestaña 4: Reporte por Vendedor
                dgvVentasPorEmpleado.DataSource = reporteVendedor;

                // Cargar Pestaña 5: Análisis de Horas Pico
                CargarGraficoVentasPorDia(reporteVentasDia);
                CargarGraficoVentasPorHora(reporteHorasPico);

                if (reporteVentas.Any())
                {
                    // Cargar Pestaña 2: Más Vendidos
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

                    // Cargar Pestaña 3: Rentabilidad
                    dgvRentabilidad.DataSource = reporteRentabilidad.OrderByDescending(p => p.GananciaNeta).ToList();

                    // Cargar Pestaña 6: Resumen de Ganancias
                    decimal totalVendido = reporteRentabilidad.Sum(r => r.IngresosTotales);
                    decimal gananciaNeta = reporteRentabilidad.Sum(r => r.GananciaNeta);
                    lblTotalVendido.Text = totalVendido.ToString("C");
                    lblGananciaNeta.Text = gananciaNeta.ToString("C");
                }
                else
                {
                    // Si no hay ventas, limpiar todas las tablas y los totales
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
            // Rellenar con ceros las horas sin ventas para un gráfico continuo
            for (int i = 0; i < 24; i++)
            {
                var ventaHora = datos.FirstOrDefault(d => d.Hora == i);
                if (ventaHora != null)
                {
                    series.Points.AddXY($"{i:00}:00", ventaHora.TotalVendido);
                }
                else
                {
                    series.Points.AddXY($"{i:00}:00", 0);
                }
            }
            chartVentasPorHora.Series.Add(series);
        }
    }
}
