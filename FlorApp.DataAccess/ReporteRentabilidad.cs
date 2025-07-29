namespace FlorApp.DataAccess
{
    /// <summary>
    /// Representa los datos calculados para el reporte de rentabilidad de un producto.
    /// </summary>
    public class ReporteRentabilidad
    {
        public string NombreProducto { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal IngresosTotales { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal GananciaNeta { get; set; }
    }
}
