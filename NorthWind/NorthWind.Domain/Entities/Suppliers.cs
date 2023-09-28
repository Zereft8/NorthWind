using NorthWind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Domain.Entities
{
    public class Suppliers : Info
    {
        public int SupplierID { get; set; }

        public string? HomePage { get; set;}
    }
}
