

using System;

namespace NorthWind.Application.Dtos.Orders
{
    public class OrderDtoBase : DtoBase
    {


        public DateTime? RequiredDate { get; set; }
        public DateTime? OrderDate { get; set; }



    }
}
