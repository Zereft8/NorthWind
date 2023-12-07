using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Orders;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Interfaces;

namespace NorthWind.Application.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IOrdersRepository ordersRepository;
        private readonly ILogger<OrderService> logger;

        public OrderService(IOrdersRepository ordersRepository,
                                   ILogger<OrderService>logger)
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
                result.Success = false;
                result.Message = $"Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int OrderID)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.ordersRepository.GetOrderById(OrderID);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;

        }

        public ServiceResult Remove(OrderDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
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
                result.Success = false;
                result.Message = $"Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }

            return result;
        }

        public ServiceResult Save(OrderDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
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
                result.Success = false;
                result.Message = $"Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }

            return result;
        }

        public ServiceResult Update(OrderDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try

                //Validaciones

            {
                Orders orders = new Orders()
                {
                    RequiredDate = (DateTime)dtoUpdate.RequiredDate,
                  

                };
                this.ordersRepository.Update(orders);

                result.Message = "La orden fue actualizado correctamente";

         }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }

            return result;
        }
    }
}