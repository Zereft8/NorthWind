using NorthWind.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Application.Core
{
    public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);
        ServiceResult Save(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
        ServiceResult Remove(TDtoRemove dtoRemove);

    }
}
