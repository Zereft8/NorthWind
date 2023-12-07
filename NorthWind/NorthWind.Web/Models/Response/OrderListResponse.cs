namespace NorthWind.Web.Models.Response
{
    public class OrderListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List <OrderViewResult> data { get; set; }
    }
    public class OrderViewResult
    {
      

        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }


        public DateTime RequiredDate { get; set; }


        public string? ShipName { get; set; }


        public string? ShipAddress { get; set; }


        public string? ShipCity { get; set; }


        
    }
}
