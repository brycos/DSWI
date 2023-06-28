using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdCat { get; set; }
        public string? Nombre { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
