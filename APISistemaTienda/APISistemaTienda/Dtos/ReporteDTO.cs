﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistemaTienda.Dtos
{
    public class ReporteDTO
    {
        public string?  NumeroDocumento { get; set; }
        public string? Pago { get; set; }
        public string? FechaRegistro { get; set; }
        public string? TotalVenta { get; set; }
        public string? Producto { get; set; }
        public int? Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? Total { get; set; }
    }
}
