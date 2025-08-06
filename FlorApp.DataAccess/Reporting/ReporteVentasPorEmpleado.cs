namespace FlorApp.DataAccess.Reporting
{
    /// <summary>
    /// Representa los datos calculados para el reporte de ventas por empleado.
    /// </summary>
    public class ReporteVentasPorEmpleado
    {
        /// <summary>
        /// El nombre del vendedor que realizó las ventas.
        /// </summary>
        public string Vendedor { get; set; }

        /// <summary>
        /// El número total de ventas individuales que realizó el vendedor en el período seleccionado.
        /// </summary>
        public int CantidadVentas { get; set; }

        /// <summary>
        /// La suma total del dinero generado por las ventas de este empleado.
        /// </summary>
        public decimal TotalVendido { get; set; }
    }
}
