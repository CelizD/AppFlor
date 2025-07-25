using System;
using System.Drawing;

namespace FlorApp.DataAccess
{
    // Representa un producto registrado en el sistema de inventario
    public class Producto
    {
        // Identificador único del producto
        public int Id { get; set; }

        // Código de barras asociado al producto
        public string CodigoBarras { get; set; }

        // Nombre del producto
        public string Nombre { get; set; }

        // Descripción detallada del producto (contenido, presentación, etc.)
        public string Descripcion { get; set; }

        // Categoría a la que pertenece el producto (ej. "Flores", "Accesorios", etc.)
        public string Categoria { get; set; }

        // Nombre del proveedor que suministra este producto
        public string Proveedor { get; set; }

        // Precio al que se compró el producto (precio de costo)
        public decimal PrecioCosto { get; set; }

        // Precio al que se venderá el producto (precio final)
        public decimal PrecioVenta { get; set; }

        // Existencias actuales del producto en inventario
        public int Stock { get; set; }

        // Cantidad mínima de stock permitida antes de generar alertas o reabastecimiento
        public int StockMinimo { get; set; }

        // Límite máximo de unidades permitidas en inventario
        public int StockMaximo { get; set; }

        // Imagen del producto (usada para visualización en el sistema)
        public Image Foto { get; set; }

        // Fecha en la que se registró el producto en el sistema
        public DateTime FechaRegistro { get; set; }
    }
}
