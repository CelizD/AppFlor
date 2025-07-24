namespace FlorApp.DataAccess
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte[] Logo { get; set; } // Cambiado de Image a byte[]
    }
}
