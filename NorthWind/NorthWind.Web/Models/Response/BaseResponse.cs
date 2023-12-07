namespace NorthWind.Web.Models.Response
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public dynamic data { get; set; }
        
    }
}
