namespace NorthWind.Web.Models.Responses
{
    public class SuppliersDetailResponse
    {
            public bool success { get; set; }
            public string message { get; set; }
            public SupplierViewResult data { get; set; }
    }
}
