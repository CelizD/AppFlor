using System;
using System.Collections.Generic;

namespace FlorApp.DataAccess.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public string Estado { get; set; }
        public decimal TotalCosto { get; set; }
        public List<OrdenCompraDetalle> Detalles { get; set; }

        public OrdenCompra()
        {
            Detalles = new List<OrdenCompraDetalle>();
        }
    }
}
