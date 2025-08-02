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
        public int ProveedorId { get; set; }

        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public bool EsKit { get; set; }

        // --- PROPIEDAD CORRECTA PARA LA IMAGEN ---
        public byte[] Foto { get; set; }

        public DateTime FechaRegistro { get; set; }
        public string ColoresDisponibles { get; set; }
    }
}