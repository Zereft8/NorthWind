﻿

using System;

namespace NorthWind.Application.Dtos.Base
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}