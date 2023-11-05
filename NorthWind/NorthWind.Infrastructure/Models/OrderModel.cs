

using System;

namespace NorthWind.Infrastructure.Models
{
    public class OrderModel
    {
        public DateTime? RequiredDate { get; set; }
        public DateTime? OrderDate { get; set; }

        public string? ShipName { get; set; }
        public string? ShipAddress { get; internal set; }
        public string? ShipCity { get; internal set; }
        public int OrderID { get; internal set; }
    }
}
