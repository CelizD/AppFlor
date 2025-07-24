using System;

namespace FlorApp.DataAccess
{
    public class ReporteVenta
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
