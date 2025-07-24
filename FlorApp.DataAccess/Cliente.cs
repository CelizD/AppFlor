using System;

namespace FlorApp.DataAccess
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime? FechaEspecial { get; set; } // Permite valores nulos
        public int Puntos { get; set; }

        // --- NUEVOS CAMPOS ---
        public string TipoMembresia { get; set; }
        public decimal TotalGastado { get; set; }
        // ---------------------
    }
}
