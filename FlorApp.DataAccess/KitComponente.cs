namespace FlorApp.DataAccess
{
    /// <summary>
    /// Representa la relación entre un producto "Kit" y uno de sus productos "Componente".
    /// </summary>
    public class KitComponente
    {
        /// <summary>
        /// Identificador único de la relación en la base de datos.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// El ID del producto que actúa como el Kit o paquete.
        /// </summary>
        public int KitProductoId { get; set; }

        /// <summary>
        /// El ID del producto que forma parte del kit.
        /// </summary>
        public int ComponenteProductoId { get; set; }

        /// <summary>
        /// El nombre del producto componente (usado para mostrar en tablas).
        /// </summary>
        public string NombreComponente { get; set; }

        /// <summary>
        /// La cantidad de unidades de este componente que se necesitan para armar un kit.
        /// </summary>
        public int Cantidad { get; set; }
    }
}
