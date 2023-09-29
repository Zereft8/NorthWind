using NorthWind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Domain.Entities
{
    public class Supplier : Info
    {
        public int SupplierID { get; set; }

        public string? HomePage { get; set;}
    }
}
