namespace NorthWind.Web.Models.Response
{
    public class CategoryListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<CategoryViewResult> data { get; set; }
    }

    public class CategoryViewResult
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[]? Picture { get; set; }

    }
}
