namespace FlorApp.DataAccess
{
    // Representa a un proveedor en el sistema
    public class Proveedor
    {
        // Identificador único del proveedor
        public int Id { get; set; }

        // Nombre de la empresa proveedora
        public string NombreEmpresa { get; set; }

        // Nombre de la persona de contacto dentro de la empresa
        public string NombreContacto { get; set; }

        // Número telefónico para contacto
        public string Telefono { get; set; }

        // Correo electrónico del proveedor
        public string Email { get; set; }

        // Dirección física del proveedor
        public string Direccion { get; set; }
    }
}
