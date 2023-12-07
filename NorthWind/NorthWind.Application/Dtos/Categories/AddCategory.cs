using Microsoft.AspNetCore.Http;
using System;
namespace NorthWind.Application.Dtos.Categories
{
    public class AddCategory
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[]? Picture { get; set; }

    }

}