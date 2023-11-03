using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Suppliers
{
    public class SupplierDtoGet
    {
        public int SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
