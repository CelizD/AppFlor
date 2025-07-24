using System;

namespace FlorApp.DataAccess
{
    public class MovimientoInventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string TipoMovimiento { get; set; } // "Entrada", "Salida por Venta", "Ajuste por Merma"
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } // Opcional, para ajustes
    }
}
