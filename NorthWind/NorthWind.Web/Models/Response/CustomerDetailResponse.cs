﻿namespace NorthWind.Web.Models.Response
{
    public class CustomerDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public CustomerViewResult data { get; set; }
    }
}
