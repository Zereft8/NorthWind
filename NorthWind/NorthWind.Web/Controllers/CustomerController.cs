using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Web.Models.Response;

namespace NorthWind.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService customerService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: CustomerWithHttpClientController
        public ActionResult Index()
        {

            CustomerListResponse customerList = new CustomerListResponse();

            using(var client = new HttpClient(this.clientHandler)) 
            {
                using (var response = client.GetAsync("http://localhost:5130/api/Customers/GetCustomers").Result) 
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        customerList = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);

                        if (!customerList.success)
                        {
                            ViewBag.Message = customerList.message;
                            return View();
                        }
                    }
                    else
                    {
                        customerList.message = "Error conectandose al Api.";
                        customerList.success = false;
                        ViewBag.Message = customerList.message;
                    }
                }
            }

            return View(customerList.data);
        }

        // GET: CustomerWithHttpClientController/Details/5
        public ActionResult Details(string id)
        {

            CustomerDetailResponse customerDetail = new CustomerDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5130/api/Customers/GetCustomerById?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);

                        if (!customerDetail.success)
                        {
                            ViewBag.Message = customerDetail.message;
                        }
                    }
                }
            }

            return View(customerDetail.data);
        }

        // GET: CustomerWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerWithHttpClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDtoAdd customerDtoAdd)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5130/api/Customers/SaveCustomer";

                    customerDtoAdd.ChangeDate = DateTime.Now;
                    customerDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: CustomerWithHttpClientController/Edit/5
        public ActionResult Edit(string id)
        {

            CustomerDetailResponse customerDetail = new CustomerDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5130/api/Customers/GetCustomerById?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);

                        if (!customerDetail.success)
                        {
                            ViewBag.Message = customerDetail.message;
                        }
                    }
                }
            }

            return View(customerDetail.data);
        }

        // POST: CustomerWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerDtoUpdate customerDtoUpdate)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5130/api/Customers/UpdateCustomer";

                    customerDtoUpdate.ChangeDate = DateTime.Now;
                    customerDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerDtoUpdate), System.Text.Encoding.UTF8,"application/json");

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

        // GET: CustomerWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerWithHttpClientController/Delete/5
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
