namespace FlorApp.DataAccess
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; } // En un proyecto real, esto debería estar encriptado
        public string Rol { get; set; } // Ej: "Administrador", "Vendedor"
    }
}
