namespace FlorApp.DataAccess
{
    public class KitComponente
    {
        // ID único del componente en la tabla
        public int Id { get; set; }

        // ID del producto que representa el kit principal
        public int KitProductoId { get; set; }

        // ID del producto que actúa como componente del kit
        public int ComponenteProductoId { get; set; }

        // Nombre del componente (para mostrar en la interfaz)
        public string NombreComponente { get; set; }

        // Cantidad de este componente dentro del kit
        public int Cantidad { get; set; }
    }
}
