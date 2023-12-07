namespace NorthWind.Web.Models.Response
{
    public class OrderDetailResponse
    {
       
        public bool success { get; set; }
        public string message { get; set; }
        public OrderViewResult data { get; set; }
        
        
    }
}
