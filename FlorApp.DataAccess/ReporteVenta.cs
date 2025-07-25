using System;

namespace FlorApp.DataAccess
{
    // Representa un registro de reporte de venta
    public class ReporteVenta
    {
        // Identificador único de la venta
        public int VentaId { get; set; }

        // Fecha en que se realizó la venta
        public DateTime Fecha { get; set; }

        // Nombre del producto vendido
        public string Producto { get; set; }

        // Categoría del producto
        public string Categoria { get; set; }

        // Cantidad de unidades vendidas
        public int Cantidad { get; set; }

        // Precio unitario del producto
        public decimal PrecioUnitario { get; set; }

        // Total generado por la venta (Cantidad * PrecioUnitario)
        public decimal Total { get; set; }
    }
}
