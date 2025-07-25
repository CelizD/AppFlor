using System;
using System.Collections.Generic;

namespace FlorApp.DataAccess
{
    // Representa una venta realizada en el sistema
    public class Venta
    {
        // Identificador único de la venta
        public int Id { get; set; }

        // Fecha y hora en que se realizó la venta
        public DateTime Fecha { get; set; }

        // Nombre del cliente (opcional)
        public string Cliente { get; set; }

        // Monto subtotal antes de impuestos
        public decimal Subtotal { get; set; }

        // Monto de impuestos aplicados
        public decimal Impuestos { get; set; }

        // Total final de la venta (subtotal + impuestos)
        public decimal Total { get; set; }

        // Método de pago utilizado (Ej: "Efectivo", "Tarjeta")
        public string MetodoPago { get; set; }

        // Lista de detalles de la venta (productos vendidos)
        public List<VentaDetalle> Detalles { get; set; }

        // Constructor que inicializa la lista de detalles
        public Venta()
        {
            Detalles = new List<VentaDetalle>();
        }
    }
}
