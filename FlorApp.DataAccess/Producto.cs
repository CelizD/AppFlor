using System;
using System.Drawing;

namespace FlorApp.DataAccess
{
    public class Producto
    {
        // ID único del producto
        public int Id { get; set; }

        // Código de barras (para escáner)
        public string CodigoBarras { get; set; }

        // Nombre del producto
        public string Nombre { get; set; }

        // Descripción del producto
        public string Descripcion { get; set; }

        // Categoría (ej. Flores, Peluches, etc.)
        public string Categoria { get; set; }

        // Nombre del proveedor
        public string Proveedor { get; set; }

        // Precio de compra para la florería
        public decimal PrecioCosto { get; set; }

        // Precio de venta al público
        public decimal PrecioVenta { get; set; }

        // Cantidad disponible en inventario
        public int Stock { get; set; }

        // Stock mínimo antes de generar alerta
        public int StockMinimo { get; set; }

        // Stock máximo recomendado
        public int StockMaximo { get; set; }

        // Indica si es un kit (conjunto de productos)
        public bool EsKit { get; set; }

        // Imagen del producto
        public Image Foto { get; set; }

        // Fecha de registro del producto
        public DateTime FechaRegistro { get; set; }
    }
}
