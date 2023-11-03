

using NorthWind.Application.Dtos.Base;
using System;

namespace NorthWind.Application.Dtos.Customer
{
    public class CustomerDtoRemove : DtoBase
    {
        public string CustomerID { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public bool Eliminado { get; set; }

    }
}
