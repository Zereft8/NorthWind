using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Orders
{
    public abstract class DtoBase
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }

    }
}
