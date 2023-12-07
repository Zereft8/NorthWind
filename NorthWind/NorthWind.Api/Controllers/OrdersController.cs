using Microsoft.AspNetCore.Mvc;
using NorthWind.Application.Contracts;
using NorthWind.Application.Dtos.Orders;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var result = this.orderService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetOrder")]
        public IActionResult Get(int OrderID)
        {
            var result = this.orderService.GetById(OrderID);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveOrder")]
        public IActionResult Post([FromBody] OrderDtoAdd ordersAdd)
        {
            var result = this.orderService.Save(ordersAdd);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("UpdateOrder")]
        public IActionResult Put([FromBody] OrderDtoUpdate orderUpdate)
        {
            var result = this.orderService.Update(orderUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("RemoveOrder")]
        public IActionResult Remove([FromBody] OrderDtoRemove orderRemove)
        {
            var result = this.orderService.Remove(orderRemove);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}


