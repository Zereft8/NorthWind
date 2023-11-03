using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Suppliers
{
    public class SupplierDtoRemove
    {
        public int SupplierID { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }
    }
}
