

namespace NorthWind.Application.Core
{
    public interface IBaseServices <TDtoAdd, TDtoUpdate, TdtoRemove> 
    {
        ServiceResult GetAll();
        ServiceResult GetById(int OrderID);
        ServiceResult Save(TDtoAdd dtoAdd);
        ServiceResult Update(TDtoUpdate dtoUpdate);
        ServiceResult Remove(TdtoRemove dtoRemove);


    }
}
