using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistemaTienda.Dtos
{
    public class ClienteDTO
    {
        public int IdCli { get; set; }
        public string? NomCli { get; set; }
        public string? ApeCli { get; set; }
        public string? TelCli { get; set; }
        public string? DirCli { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }
}
