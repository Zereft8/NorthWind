using System;
﻿using NorthWind.Application.Core;

namespace NorthWind.Application.Contracts
{
    public interface ICategoryService : IBaseService<AddCategory , UpdateCategory, DeleteCategory, int>
    {

    }
}