﻿using System;
using System.Collections.Generic;

namespace APISistemaTienda.Models
{
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }
        public string? Url { get; set; }
    }
}
