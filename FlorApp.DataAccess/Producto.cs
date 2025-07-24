using System;
using System.Drawing;

namespace FlorApp.DataAccess
{
    public class Producto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Proveedor { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public Image Foto { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
