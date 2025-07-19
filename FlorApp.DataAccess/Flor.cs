using System;

namespace FlorApp.DataAccess
{
    // Esta clase representa el modelo de datos de una flor
    public class Flor
    {
        // Propiedad que almacena el identificador único de la flor
        public int Id { get; set; }

        // Propiedad que almacena el nombre de la flor
        public string Nombre { get; set; }

        // Propiedad que almacena la fecha en que fue registrada la flor
        public DateTime FechaRegistro { get; set; }
    }
}
