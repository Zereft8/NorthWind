﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Dtos.Orders
{
    public class OrderDtoGet
    {
        public DateTime? RequiredDate { get; set; }
        public DateTime? OrderDate { get; set; }

        public  string? ShipName { get; set; }
        public string? ShipAddress { get; internal set; }
        public string? ShipCity { get; internal set; }
        public int OrderID { get; internal set; }
    }
}