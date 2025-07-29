using System;
using System.Drawing;

namespace FlorApp.DataAccess
{
    /// <summary>
    /// Representa un producto en el inventario de la florería.
    /// Puede ser un producto individual o un "Kit" compuesto por otros productos.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto en la base de datos.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Código de barras del producto, para ser usado con un escáner.
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Nombre del producto (ej. "Rosa Roja", "Arreglo Primaveral").
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Categoría a la que pertenece el producto (ej. "Flores Individuales", "Peluches").
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Nombre del proveedor que surte este producto.
        /// </summary>
        public string Proveedor { get; set; }

        /// <summary>
        /// El precio que le cuesta el producto a la tienda.
        /// </summary>
        public decimal PrecioCosto { get; set; }

        /// <summary>
        /// El precio al que se vende el producto al público.
        /// </summary>
        public decimal PrecioVenta { get; set; }

        /// <summary>
        /// La cantidad actual de este producto en el inventario.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// La cantidad mínima de stock antes de que se genere una alerta.
        /// </summary>
        public int StockMinimo { get; set; }

        /// <summary>
        /// La cantidad máxima de stock recomendada para este producto.
        /// </summary>
        public int StockMaximo { get; set; }

        /// <summary>
        /// Indica si este producto es un "Kit" o paquete compuesto por otros productos.
        /// </summary>
        public bool EsKit { get; set; }

        /// <summary>
        /// La imagen del producto. Se guarda como un objeto Image en la aplicación.
        /// </summary>
        public Image Foto { get; set; }

        /// <summary>
        /// La fecha y hora en que el producto fue registrado por primera vez en el sistema.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
    }
}
