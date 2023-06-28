using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistemaTienda.Dtos
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Pago { get; set; }
        public string? TotalTexto { get; set; }
        public string? FechaRegistro { get; set; }
        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }
    }
}
