using System;

namespace FlorApp.DataAccess
{
    // Representa un movimiento realizado en el inventario de productos
    public class MovimientoInventario
    {
        // Identificador único del movimiento en el inventario
        public int Id { get; set; }

        // Identificador del producto al que pertenece el movimiento
        public int ProductoId { get; set; }

        // Nombre del producto (solo para referencia rápida o visualización)
        public string NombreProducto { get; set; }

        // Tipo de movimiento: puede ser "Entrada", "Salida por Venta" o "Ajuste por Merma"
        public string TipoMovimiento { get; set; }

        // Cantidad de unidades que entran o salen del inventario
        public int Cantidad { get; set; }

        // Fecha y hora exacta en la que se registró el movimiento
        public DateTime Fecha { get; set; }

        // Motivo del movimiento (opcional), útil para registrar observaciones en ajustes
        public string Motivo { get; set; }
    }
}
