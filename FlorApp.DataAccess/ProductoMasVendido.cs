namespace FlorApp.DataAccess
{
    // Representa un producto con sus estadísticas de ventas
    public class ProductoMasVendido
    {
        // Nombre del producto más vendido
        public string NombreProducto { get; set; }

        // Cantidad total de unidades vendidas de ese producto
        public int UnidadesVendidas { get; set; }

        // Total de ingresos generados por la venta de este producto
        public decimal IngresosGenerados { get; set; }
    }
}
