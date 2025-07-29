namespace FlorApp.DataAccess
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }
        public int OrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
    }
}
