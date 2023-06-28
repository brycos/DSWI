using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProd { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }

        public virtual Producto? IdProdNavigation { get; set; }
        public virtual Venta? IdVentaNavigation { get; set; }
    }
}
