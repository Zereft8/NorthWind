
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Application.Exceptions;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Application.Extentions;

namespace NorthWind.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly ILogger<CustomerService> logger;
        private readonly IConfiguration configuration;

        public CustomerService(ICustomersRepository customersRepository, 
                               ILogger<CustomerService> logger, IConfiguration configuration) 
        {
            this.customersRepository = customersRepository;
            this.logger = logger;
            this.configuration = configuration;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.customersRepository.GetCustomers();
            }
            catch (Exception ex)
            {

                result.Success= false;
                result.Message = $"Error obteniendo los clientes.";
                this.logger.LogError($"{result.Message}", ex.ToString());    

            }

            return result;
        }

        public ServiceResult GetById(string Id)
        {

            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.customersRepository.GetCustomerById(Id);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(CustomerDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Customer customer = new Customer()
                {
                    CustomerID = dtoRemove.CustomerID,
                    Eliminado = dtoRemove.Eliminado,
                    IdUsuarioElimino = dtoRemove.ChangeUser,
                    FechaElimino = dtoRemove.ChangeDate

                };

                this.customersRepository.Remove(customer);

                result.Message = "Cliente eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error removiendo el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(CustomerDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoAdd.IsCustomerValid(this.configuration);

                if (!validresult.Success) 
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }


                Customer customer = new Customer()
                {
                    CompanyName = dtoAdd.CompanyName,
                    ContactName = dtoAdd.ContactName,
                    ContactTitle = dtoAdd.ContactTitle,
                    Address = dtoAdd.Address,
                    City = dtoAdd.City,
                    Region = dtoAdd.Region,
                    PostalCode = dtoAdd.PostalCode,
                    Country = dtoAdd.Country,
                    Phone = dtoAdd.Phone,
                    Fax = dtoAdd.Fax,
                    FechaRegistro = dtoAdd.ChangeDate,
                    IdUsuarioCreacion = dtoAdd.ChangeUser,
                    CustomerID = dtoAdd.CustomerID
                };

                this.customersRepository.Save(customer);

                result.Message = "Cliente guardado satisfactoriamente";
            }
            catch (CustomerServiceException cse)
            {
                result.Success = false;
                result.Message = cse.Message;
                this.logger.LogError($"{result.Message}", cse.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(CustomerDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoUpdate.IsCustomerValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }


                Customer customer = new Customer()
                {
                    CompanyName = dtoUpdate.CompanyName,
                    ContactName = dtoUpdate.ContactName,
                    ContactTitle = dtoUpdate.ContactTitle,
                    Address = dtoUpdate.Address,
                    City = dtoUpdate.City,
                    Region = dtoUpdate.Region,
                    PostalCode = dtoUpdate.PostalCode,
                    Country = dtoUpdate.Country,
                    Phone = dtoUpdate.Phone,
                    Fax = dtoUpdate.Fax,
                    FechaMod = dtoUpdate.ChangeDate,
                    IdUsuarioMod = dtoUpdate.ChangeUser,
                    CustomerID = dtoUpdate.CustomerID
                };

                this.customersRepository.Update(customer);

                result.Message = "Cliente actualizado satisfactoriamente";
            }
            catch (CustomerServiceException cse)
            {
                result.Success = false;
                result.Message = cse.Message;
                this.logger.LogError($"{result.Message}", cse.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
