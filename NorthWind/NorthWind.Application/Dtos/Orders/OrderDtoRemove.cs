using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Orders
{
    public class OrderDtoRemove : DtoBase
    {
        public int OrderID { get; set; }

        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
