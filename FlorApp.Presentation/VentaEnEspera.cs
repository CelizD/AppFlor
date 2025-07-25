using FlorApp.DataAccess;
using System;
using System.ComponentModel;

namespace FlorApp.Presentation
{
    // Clase para representar una venta en proceso o en espera de confirmación
    public class VentaEnEspera
    {
        // Lista enlazada de detalles de la venta (productos en el carrito)
        public BindingList<VentaDetalle> Carrito { get; set; }

        // Cliente seleccionado para la venta
        public Cliente ClienteSeleccionado { get; set; }

        // Descuento aplicado de forma general a la venta
        public decimal DescuentoGeneral { get; set; }

        // Fecha en que se creó o está registrada la venta en espera
        public DateTime Fecha { get; set; }
    }
}
