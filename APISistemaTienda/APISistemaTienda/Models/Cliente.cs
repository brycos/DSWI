using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class Cliente
    {
        public int IdCli { get; set; }
        public string? NomCli { get; set; }
        public string? ApeCli { get; set; }
        public string? TelCli { get; set; }
        public string? DirCli { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
