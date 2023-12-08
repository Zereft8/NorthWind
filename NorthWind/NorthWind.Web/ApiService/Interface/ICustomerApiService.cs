using NorthWind.Application.Dtos.Customer;
using NorthWind.Web.Models.Response;
using System.Threading.Tasks;

namespace NorthWind.Web.WebService.Interface
{
    public interface ICustomerApiService
    {
        Task<CustomerListResponse> GetCustomers();
        Task<CustomerDetailResponse> GetCustomer(string id);
        Task<BaseResponse> Update(CustomerDtoUpdate customerDtoUpdate);
        Task<BaseResponse> Save(CustomerDtoAdd customerDtoAdd);
        Task<CustomerDetailResponse> Edit(string id);
    }
}
