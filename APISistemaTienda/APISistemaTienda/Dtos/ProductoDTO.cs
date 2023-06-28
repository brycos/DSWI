using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistemaTienda.Dtos
{
    public class ProductoDTO
    {
        public int IdProd { get; set; }
        public string? Nombre { get; set; }
        public int? IdCat { get; set; }
        public string? DescripcionCategoria { get; set; }
        public int? Stock { get; set; }
        public string? Precio { get; set; }
        public int? Estado { get; set; }
    }
}
