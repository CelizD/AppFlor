namespace FlorApp.DataAccess
{
    // Representa un detalle o línea individual dentro de una venta
    public class VentaDetalle
    {
        // Identificador único del detalle
        public int Id { get; set; }

        // Identificador de la venta a la que pertenece este detalle
        public int VentaId { get; set; }

        // Identificador del producto vendido
        public int ProductoId { get; set; }

        // Nombre del producto vendido (para fácil visualización)
        public string NombreProducto { get; set; }

        // Cantidad de unidades vendidas de este producto
        public int Cantidad { get; set; }

        // Precio unitario aplicado en la venta
        public decimal PrecioUnitario { get; set; }

        // Total de la línea (Cantidad * PrecioUnitario)
        public decimal TotalLinea { get; set; }
    }
}
