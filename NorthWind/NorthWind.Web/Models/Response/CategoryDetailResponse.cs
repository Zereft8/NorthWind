
namespace NorthWind.Web.Models.Response
{
    public class CategoryDetailResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public CategoryViewResult data { get; set; }
    }
}
