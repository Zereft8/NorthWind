namespace NorthWind.Api.Models.Modules.Order
{
    public class GetOrderModel
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
         public string? ShipName { get; set; }
        public string? ShipAddress{ get; set; }
        public string? ShipCity { get; set; }
    }
}
