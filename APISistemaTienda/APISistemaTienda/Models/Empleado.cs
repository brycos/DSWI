using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class Empleado
    {
        public int IdEmp { get; set; }
        public string? NomEmp { get; set; }
        public string? ApeEmp { get; set; }
        public string? TelEmp { get; set; }
        public string? DirEmp { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
