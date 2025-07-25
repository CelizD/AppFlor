using System;

namespace FlorApp.DataAccess
{
    // Representa un pedido realizado por un cliente
    public class Pedido
    {
        // Identificador único del pedido
        public int Id { get; set; }

        // Nombre del cliente que realiza el pedido
        public string NombreCliente { get; set; }

        // Lista de productos solicitados, almacenados como texto
        // En una implementación más robusta, sería una lista de objetos Producto
        public string Productos { get; set; }

        // Mensaje personalizado que va en la tarjeta del arreglo floral
        public string MensajeTarjeta { get; set; }

        // Fecha en la que se debe entregar el pedido
        public DateTime FechaEntrega { get; set; }

        // Dirección exacta donde se entregará el pedido
        public string DireccionEntrega { get; set; }

        // Estado actual del pedido (ej. "Recibido", "En preparación", "En ruta", "Entregado")
        public string Estado { get; set; }

        // Nombre del repartidor asignado a la entrega del pedido
        public string RepartidorAsignado { get; set; }
    }
}
