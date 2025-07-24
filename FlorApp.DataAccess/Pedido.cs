using System;

namespace FlorApp.DataAccess
{
    public class Pedido
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Productos { get; set; } // Para simplicidad, usaremos un texto. En un caso real, sería una lista.
        public string MensajeTarjeta { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public string Estado { get; set; } // Ej: "Recibido", "En preparación", "En ruta", "Entregado"
        public string RepartidorAsignado { get; set; }
    }
}

