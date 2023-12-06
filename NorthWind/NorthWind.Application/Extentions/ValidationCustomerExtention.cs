

using Microsoft.Extensions.Configuration;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Application.Exceptions;

namespace NorthWind.Application.Extentions
{
    public static class ValidationCustomerExtention
    {
        public static ServiceResult IsCustomerValid(this CustomerDtoBase customerDto, IConfiguration configuration)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(customerDto.CompanyName))
                throw new CustomerServiceException(configuration["MensajesValidaciones:companyNameRequerido"]);

            if (customerDto.CompanyName.Length > 40)
                throw new CustomerServiceException(configuration["MensajesValidaciones:companyNameLongitud"]);

            if (customerDto.ContactName.Length > 30)
                throw new CustomerServiceException(configuration["MensajesValidaciones:contactNameLongitud"]);

            if (customerDto.ContactTitle.Length > 30)
                throw new CustomerServiceException(configuration["MensajesValidaciones:contactTitleLongitud"]);

            if (customerDto.Address.Length > 60)
                throw new CustomerServiceException(configuration["MensajesValidaciones:addressLongitud"]);

            if (customerDto.City.Length > 15)
                throw new CustomerServiceException(configuration["MensajesValidaciones:cityLongitud"]);

            if (customerDto.Region.Length > 10)
                throw new CustomerServiceException(configuration["MensajesValidaciones:regionLongitud"]);

            if (customerDto.PostalCode.Length > 15)
                throw new CustomerServiceException(configuration["MensajesValidaciones:postalCodeLongitud"]);

            if (customerDto.Country.Length > 15)
                throw new CustomerServiceException(configuration["MensajesValidaciones:countryLongitud"]);

            if (customerDto.Phone.Length > 24)
                throw new CustomerServiceException(configuration["MensajesValidaciones:phoneLongitud"]);

            if (customerDto.Fax.Length > 24)
                throw new CustomerServiceException(configuration["MensajesValidaciones:faxLongitud"]);


            return result;
        }
    }
}
