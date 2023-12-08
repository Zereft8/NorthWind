namespace NorthWind.Web.Models.Response
{
    public class CustomerListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CustomerViewResult> data { get; set; }
    }

    public class CustomerViewResult 
    {
            public string customerID { get; set; }
            public string? companyName { get; set; }
            public string? contactName { get; set; }
            public string? contactTitle { get; set; }
            public string? address { get; set; }
            public string? city { get; set; }
            public string? region { get; set; }
            public string? postalCode { get; set; }
            public string? country { get; set; }
            public string? phone { get; set; }
            public string? fax { get; set; }
            public DateTime fechaRegistro { get; set; }
    }
}
