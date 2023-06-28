using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class Producto
    {
       
        public int IdProd { get; set; }
        public string? Nombre { get; set; }
        public int? IdCat { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual Categoria? IdCatNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();
    }
}
