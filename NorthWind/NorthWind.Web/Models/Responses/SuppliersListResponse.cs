namespace NorthWind.Web.Models.Responses
{

    public class SupplierListResponse 
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<SupplierViewResult> data { get; set; }
    }

    public class SupplierViewResult 
    {
        public int supplierID { get; set; }
        public string? companyName { get; set; }
        public string? contactName { get; set; }
        public string? contactTitle { get; set; }
        public string? address { get; set; }
        public string? country { get; set; }
        public string? phone { get; set; }
    }
}

