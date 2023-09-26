
namespace NorthWind.Domain.Core
{
    public abstract class Person : Info
    {

        public string CompanyName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }



    }
}
