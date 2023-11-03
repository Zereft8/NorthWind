using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Suppliers
{
    public class SupplierDtoUpdate : SupplierDtoBase
    {
        public int SupplierID { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public string? City { get; set; }

    }
}
