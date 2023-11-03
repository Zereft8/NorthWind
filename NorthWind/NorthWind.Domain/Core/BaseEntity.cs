using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NorthWind.Domain.Core
{
    public abstract class BaseEntity
    {

        [Key, Column(Order = 0)]
        public int OrderID { get; set; }

        [Key, Column(Order = 1)]
        public string? CustomerID { get; set; }

        [Key, Column(Order = 2)]
        public int EmployeeID { get; set; }

        [Required]

        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequiredDate { get; set; }

        [StringLength(100)]
        public string? ShipName { get; set; }

        [StringLength(100)]
        public string? ShipAddress { get; set; }

        [StringLength(100)]
        public string? ShipCity { get; set; }

        [StringLength(100)]
        public string? ShipRegion { get; set; }

        [StringLength(100)]
        public string? ShipPostalCode { get; set; }

        [StringLength(100)]
        public string? ShipCountry { get; set; }
        
    }
}
