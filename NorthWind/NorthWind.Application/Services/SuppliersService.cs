using Microsoft.Extensions.Logging;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Base;
using NorthWind.Application.Dtos.Suppliers;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NorthWind.Application.Services
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository suppliersRepository;
        private readonly ILogger<SuppliersService> logger;

        public SuppliersService(ISuppliersRepository suppliersRepository, 
                                ILogger<SuppliersService> logger)
        {
            this.suppliersRepository = suppliersRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = suppliersRepository.GetSuppliers();     
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo los suplidores.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult() ;
            try
            {
                result.Data = this.suppliersRepository.GetSupplierBySupplierID(Id);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo el suplidor.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;  
        }

        public ServiceResult Remove(SupplierDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Supplier supplier = new Supplier()
                {
                    SupplierID = dtoRemove.SupplierID,
                    Eliminado = dtoRemove.Eliminado,
                    FechaElimino = dtoRemove.FechaElimino,
                };
                this.suppliersRepository.Remove(supplier);
                result.Message = "El suplidor fue removido correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error removiendo el suplidor.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;  
        }

        public ServiceResult Save(SupplierDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Supplier supplier = new Supplier()
                {
                    CompanyName = dtoAdd.CompanyName,
                    ContactName = dtoAdd.ContactName,
                    ContactTitle = dtoAdd.ContactTitle,
                    Address = dtoAdd.Address,
                    FechaRegistro = dtoAdd.FechaRegistro,
                    IdUsuarioCreacion = dtoAdd.IdUsuarioCreacion,
                    Country = dtoAdd.Country,
                    Phone = dtoAdd.Phone
                };
                this.suppliersRepository.Save(supplier);
                result.Message = "El suplidor fue agregado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error agregando el suplidor.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Update(SupplierDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                Supplier supplier = new Supplier()
                {
                    SupplierID = dtoUpdate.SupplierID,
                    CompanyName = dtoUpdate.CompanyName,
                    Address = dtoUpdate.Address,
                    Country = dtoUpdate.Country,
                    ContactName = dtoUpdate.ContactName,
                    City = dtoUpdate.City,
                    Phone = dtoUpdate.Phone,
                    FechaMod = dtoUpdate.FechaMod,
                    IdUsuarioMod = dtoUpdate.IdUsuarioMod
                };
                this.suppliersRepository.Update(supplier);
                result.Message = "El suplidor fue actualizado correctamente.";
            }
                
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando el suplidor.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

    }
}
