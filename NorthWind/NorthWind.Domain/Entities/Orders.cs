
using NorthWind.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Domain.Entities
{
    public class Orders : BaseEntity
    {
        
        public int OrderID { get; set; }

       
        public DateTime? OrderDate { get; set; }

       
        public DateTime RequiredDate { get; set; }

      
        public string? ShipName { get; set; }

     
        public string? ShipAddress { get; set; }

       
        public string? ShipCity { get; set; }

  
        public string? ShipRegion { get; set; }

   
        public string? ShipPostalCode { get; set; }

      
        public string? ShipCountry { get; set; }
    }
}
