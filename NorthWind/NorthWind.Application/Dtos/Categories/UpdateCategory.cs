using System;
namespace NorthWind.Application.Dtos.Categories
{
    public class UpdateCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[]? Picture { get; set; }
    }
}