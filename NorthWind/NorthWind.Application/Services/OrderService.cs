using Microsoft.Extensions.Logging;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Orders;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;
using System;

namespace NorthWind.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly ILogger<OrderService> logger;

        public OrderService(IOrdersRepository ordersRepository, ILogger<OrderService> logger)
        {
            this.ordersRepository = ordersRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.ordersRepository.GetOrders();
            }
            catch (Exception ex)
            {
                HandleError(result, ex);
            }
            return result;
        }

        public ServiceResult GetById(int OrderID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (OrderID <= 0)
                {
                    result.Success = false;
                    result.Message = "OrderID debe ser un número positivo.";
                    return result;
                }

                result.Data = this.ordersRepository.GetOrderById(OrderID);
            }
            catch (Exception ex)
            {
                HandleError(result, ex);
            }
            return result;
        }

        public ServiceResult Remove(OrderDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                ValidateDtoRemove(dtoRemove);

                Orders orders = new Orders()
                {
                    OrderID = dtoRemove.OrderID,
                    Eliminado = dtoRemove.Eliminado,
                    IdUsuarioElimino = dtoRemove.IdUsuarioElimino,
                    FechaElimino = dtoRemove.FechaElimino,
                };

                this.ordersRepository.Remove(orders);
                result.Message = "La orden fue removida correctamente";
            }
            catch (Exception ex)
            {
                HandleError(result, ex);
            }

            return result;
        }

        public ServiceResult Save(OrderDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                ValidateDtoAdd(dtoAdd);

                Orders orders = new Orders()
                {
                    RequiredDate = (DateTime)dtoAdd.RequiredDate,
                    OrderDate = dtoAdd.OrderDate
                };

                this.ordersRepository.Save(orders);

                result.Message = "La orden fue guardada correctamente";
            }
            catch (Exception ex)
            {
                HandleError(result, ex);
            }

            return result;
        }

        public ServiceResult Update(OrderDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                ValidateDtoUpdate(dtoUpdate);

                Orders orders = new Orders()
                {
                    RequiredDate = (DateTime)dtoUpdate.RequiredDate,
                    // Otros campos...
                };

                this.ordersRepository.Update(orders);

                result.Message = "La orden fue actualizada correctamente";
            }
            catch (Exception ex)
            {
                HandleError(result, ex);
            }

            return result;
        }

        private void HandleError(ServiceResult result, Exception ex)
        {
            result.Success = false;
            result.Message = $"Error obteniendo las ordenes.";
            this.logger.LogError($"{result.Message}", ex.ToString());
        }

        private void ValidateDtoRemove(OrderDtoRemove dtoRemove)
        {
            if (dtoRemove == null)
            {
                throw new ApplicationException("El objeto dtoRemove no puede ser nulo.");
            }

            if (dtoRemove.OrderID <= 0)
            {
                throw new ApplicationException("OrderID debe ser un número positivo.");
            }

            
        }

        private void ValidateDtoAdd(OrderDtoAdd dtoAdd)
        {
            if (dtoAdd == null)
            {
                throw new ApplicationException("El objeto dtoAdd no puede ser nulo.");
            }

            
        }

        private void ValidateDtoUpdate(OrderDtoUpdate dtoUpdate)
        {
            if (dtoUpdate == null)
            {
                throw new ApplicationException("El objeto dtoUpdate no puede ser nulo.");
            }

           
        }
    }
}
