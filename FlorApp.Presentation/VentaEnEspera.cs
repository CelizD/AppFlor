using FlorApp.DataAccess;
using System;
using System.ComponentModel;

namespace FlorApp.Presentation
{
    public class VentaEnEspera
    {
        public BindingList<VentaDetalle> Carrito { get; set; }
        public Cliente ClienteSeleccionado { get; set; }
        public decimal DescuentoGeneral { get; set; }
        public DateTime Fecha { get; set; }
    }
}
