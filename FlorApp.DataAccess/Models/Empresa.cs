namespace FlorApp.DataAccess.Models
{
    public class Empresa
    {
        // Identificador único de la empresa
        public int Id { get; set; }

        // Nombre de la empresa
        public string Nombre { get; set; }

        // Dirección física de la empresa
        public string Direccion { get; set; }

        // Número telefónico de contacto
        public string Telefono { get; set; }

        // Logo de la empresa almacenado como arreglo de bytes (ideal para bases de datos)
        public byte[] Logo { get; set; }
    }
}
