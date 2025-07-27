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
            // --- CORRECCIÓN APLICADA AQUÍ ---
            // El nombre del botón se ha corregido para que coincida con el del archivo de diseño.
            btnGenerarReporteVentas.Click += new EventHandler(btnGenerarReporte_Click);
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

                // Cargar el reporte de ventas desde la base de datos con el rango de fechas
                var reporteVentas = await _ventaRepository.ObtenerReporteVentasAsync(fechaInicio, fechaFin);
                dgvReporteVentas.DataSource = reporteVentas;

                // Calcular y mostrar los productos más vendidos basados en el reporte filtrado
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

                    // Calcular y mostrar las ganancias basadas en el reporte filtrado
                    decimal totalVendido = reporteVentas.Sum(v => v.Total);
                    // En un caso real, necesitaríamos el PrecioCosto de cada producto para un cálculo exacto.
                    // Por ahora, simulamos un margen de ganancia del 40%.
                    decimal gananciaEstimada = totalVendido * 0.40m;

                    lblTotalVendido.Text = totalVendido.ToString("C");
                    lblGananciaNeta.Text = gananciaEstimada.ToString("C");
                }
                else
                {
                    // Si no hay ventas, limpiar las tablas y los totales
                    dgvMasVendidos.DataSource = null;
                    lblTotalVendido.Text = "$0.00";
                    lblGananciaNeta.Text = "$0.00";
                }
            }
            catch (Exception ex)
            {
                CustomMessageBoxForm.Show($"Error al generar los reportes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
