using FlorApp.DataAccess;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FlorApp.Presentation
{
    public partial class ReportesForm : Form
    {
        // Repositorio para acceder a los datos de ventas
        private readonly VentaRepository _ventaRepository;

        public ReportesForm()
        {
            InitializeComponent();

            // Inicializar el repositorio de ventas
            _ventaRepository = new VentaRepository();

            // Registrar eventos para la carga del formulario y el botón de generar reporte
            this.Load += new EventHandler(ReportesForm_Load);
            btnGenerarReporteVentas.Click += new EventHandler(btnGenerarReporteVentas_Click);
        }

        // Evento que se ejecuta al cargar el formulario
        private void ReportesForm_Load(object sender, EventArgs e)
        {
            // Establecer fechas predeterminadas para el reporte (último mes)
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;

            // Generar el reporte inicial automáticamente al cargar el formulario
            btnGenerarReporteVentas_Click(sender, e);
        }

        // Evento que se ejecuta al hacer clic en el botón para generar el reporte de ventas
        private async void btnGenerarReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener las fechas seleccionadas por el usuario
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;

                // Consultar el repositorio para obtener los datos de ventas entre las fechas seleccionadas (async)
                var reporteVentas = await _ventaRepository.ObtenerReporteVentasAsync(fechaInicio, fechaFin);

                // Asignar los datos de ventas al DataGridView correspondiente
                dgvReporteVentas.DataSource = reporteVentas;

                // Agrupar las ventas por producto para calcular los más vendidos
                var masVendidos = reporteVentas
                    .GroupBy(r => r.Producto)
                    .Select(g => new ProductoMasVendido
                    {
                        NombreProducto = g.Key,
                        UnidadesVendidas = g.Sum(i => i.Cantidad),
                        IngresosGenerados = g.Sum(i => i.Total)
                    })
                    .OrderByDescending(p => p.IngresosGenerados) // Ordenar por ingresos descendentes
                    .ToList();

                // Asignar la lista de productos más vendidos a su DataGridView
                dgvMasVendidos.DataSource = masVendidos;

                // Calcular el total vendido sumando los totales de todas las ventas del reporte
                decimal totalVendido = reporteVentas.Sum(v => v.Total);

                // Calcular la ganancia estimada (aquí se usa una simulación del 40% del total vendido)
                decimal gananciaEstimada = totalVendido * 0.40m;

                // Mostrar el total vendido y la ganancia estimada en las etiquetas correspondientes, con formato de moneda
                lblTotalVendido.Text = totalVendido.ToString("C");
                lblGananciaNeta.Text = gananciaEstimada.ToString("C");
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de falla al generar el reporte
                CustomMessageBoxForm.Show($"Error al generar los reportes: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }
    }
}
