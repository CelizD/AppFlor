using System;

namespace FlorApp.DataAccess
{
    /// Representa un cliente dentro del sistema FlorApp, conteniendo su información personal, de contacto y de lealtad.
    public class Cliente
    {
        /// Obtiene o establece el identificador único del cliente.
        public int Id { get; set; }

        /// Obtiene o establece el nombre completo del cliente.
        public string Nombre { get; set; }

        /// Obtiene o establece el número de teléfono del cliente.
        public string Telefono { get; set; }

        /// Obtiene o establece la dirección física del cliente.
        public string Direccion { get; set; }

        /// Obtiene o establece la dirección de correo electrónico del cliente.
        public string Email { get; set; }

        /// Obtiene o establece una fecha especial opcional para el cliente, como un cumpleaños o aniversario.
        /// Esta propiedad puede ser nula si no se registra ninguna fecha especial.
        public DateTime? FechaEspecial { get; set; }

        /// Obtiene o establece el total de puntos de lealtad acumulados por el cliente.
        public int Puntos { get; set; }

        /// Obtiene o establece el tipo de membresía que posee el cliente (por ejemplo, Bronce, Plata, Oro).
        public string TipoMembresia { get; set; }

        /// Obtiene o establece la cantidad total de dinero que el cliente ha gastado en el sistema.
        public decimal TotalGastado { get; set; }
    }
}