
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using NorthWind.Application.Contracts;
using NorthWind.Application.Dtos.Orders;
using NorthWind.Web.Models.Response;


namespace NorthWind.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private HttpMessageHandler clientHandle;

        public OrderController(IOrderService orderService)

        {
            this.orderService = orderService;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            OrderListResponse orderList = new OrderListResponse();

            using (var client = new HttpClient(this.clientHandle))
            {
                using (var response = client.GetAsync("http://localhost:5130/api/Orders/GetOrder").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        orderList = JsonConvert.DeserializeObject<OrderListResponse>(apiResponse);

                        if (!orderList.success)
                        {
                            ViewBag.Message = orderList.message;

                            return View();

                        }
                    }
                    else
                    {
                        orderList.message = "Error conectandose a la api";
                        orderList.success = false;
                        ViewBag.Message = orderList.message;


                    }
                }
            }
            return View(orderList.data);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {

            OrderDetailResponse  orderDetail = new OrderDetailResponse();

            using (var client = new HttpClient(this.clientHandle))
            {
                var url = $"http://localhost:5130/api/Orders/GetOrder?{id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        orderDetail = JsonConvert.DeserializeObject<OrderDetailResponse>(apiResponse);

                       
                }
            }
           
        }
            var result = this.orderService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }
            return View(orderDetail.data);
    }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDtoAdd orderDtoAdd)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandle))
                {

                    var url = $"http://localhost:5130/api/Orders/SaveOrder";

                    orderDtoAdd.OrderDate = DateTime.Now;
                    orderDtoAdd.RequiredDate = DateTime.Now;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(orderDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al Api.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderDtoUpdate orderDtoUpdate)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandle))
                {

                    var url = $"http://localhost:5130/api/Orders/UpdateOrder";

                    orderDtoUpdate.OrderDate = DateTime.Now;
                    orderDtoUpdate.RequiredDate = DateTime.Now;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(orderDtoUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }


        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
