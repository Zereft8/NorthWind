using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Suppliers
{
    public class SupplierDtoAdd : SupplierDtoBase
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
