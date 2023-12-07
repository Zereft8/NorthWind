using System;
﻿using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Categories;

namespace NorthWind.Application.Contracts
{
    public interface ICategoryService : IBaseService<AddCategory , UpdateCategory, DeleteCategory, int>
    {

    }
}