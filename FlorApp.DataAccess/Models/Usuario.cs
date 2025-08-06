namespace FlorApp.DataAccess.Models
{
    // Representa un usuario del sistema
    public class Usuario
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Nombre o alias para iniciar sesión
        public string NombreUsuario { get; set; }

        // Contraseña del usuario (debería estar encriptada en un proyecto real)
        public string Contrasena { get; set; }

        // Rol o perfil del usuario (Ej: "Administrador", "Vendedor")
        public string Rol { get; set; }
    }
}
