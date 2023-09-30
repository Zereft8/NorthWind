using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWind.Domain.Entities;
using NorthWind.Infrastructure.Context;
using NorthWind.Infrastructure.Interfaces;
using NorthWind.Infrastructure.Repositories;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetatilsController : ControllerBase
    {
        private readonly IOrderDetailsRepository orderDetailsRepository;

        // GET: CategoriesController/Create
        public OrderDetatilsController(IOrderDetailsRepository orderDetailsRepository)
        {
            this.orderDetailsRepository = orderDetailsRepository;
        }

        [HttpGet]
        public List<OrderDetails> Get()
        {

            var orderDetails = this.orderDetailsRepository.GetEntities();
            return orderDetails;
        }

        [HttpGet("{id}")]
        public OrderDetails Get(int id)
        {
            var orderDetail = this.orderDetailsRepository.GetEntity(id);
            return orderDetail;
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create(IFormCollection collection)
        {

        }
        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Edit(int id, IFormCollection collection)
        {

        }

        // GET: CategoriesController/Delete/5
        public void Delete(int id)
        {

        }
    }
}
