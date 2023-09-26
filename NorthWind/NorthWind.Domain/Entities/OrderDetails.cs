using NorthWind.Domain.Core;

namespace NorthWind.Domain.Entities
{
    internal class OrderDetails : BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

    }
}
