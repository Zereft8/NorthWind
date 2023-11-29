using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Domain.Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        [Key, Column(Order = 2)]
        public int SupplierID { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        public string QuantityPerUnit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Categories Category { get; set; }
    }
}
