using System;
using System.Collections.Generic;

namespace FlorApp.DataAccess
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } // Opcional
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public List<VentaDetalle> Detalles { get; set; }

        public Venta()
        {
            Detalles = new List<VentaDetalle>();
        }
    }
}
