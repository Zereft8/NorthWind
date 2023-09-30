using NorthWind.Domain.Core;

namespace NorthWind.Domain.Entities
{
    public class Categories : BaseEntity
    {
        public int CategoryID { get; set; } 
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Picture { get; set; }
    }
}
