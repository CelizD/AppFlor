using System;

namespace FlorApp.DataAccess.Models
{
    // Representa una flor registrada en el sistema
    public class Flor
    {
        // Identificador único de la flor
        public int Id { get; set; }

        // Nombre descriptivo de la flor
        public string Nombre { get; set; }

        // Fecha en la que se registró la flor en la base de datos
        public DateTime FechaRegistro { get; set; }
    }
}
