namespace FlorApp.DataAccess
{
    /// <summary>
    /// Representa a un proveedor en el sistema.
    /// </summary>
    public class Proveedor
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}