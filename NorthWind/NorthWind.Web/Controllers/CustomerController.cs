using Microsoft.AspNetCore.Mvc;
using NorthWind.Application.Dtos.Customer;
using NorthWind.Web.Models.Response;
using NorthWind.Web.WebService.Interface;

namespace NorthWind.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerApiService customerApi;
        private readonly ILogger<CustomerController> logger;
        private readonly IConfiguration configuration;


        public CustomerController(ICustomerApiService customerApi, 
            ILogger<CustomerController> logger, IConfiguration configuration)
        {
            this.customerApi = customerApi;
            this.logger = logger;
            this.configuration = configuration;

        }



        // GET: CustomerWithHttpClientController
        public async Task<ActionResult> Index()
        {

            CustomerListResponse customerList = new CustomerListResponse();

            customerList = await this.customerApi.GetCustomers();

            if (!customerList.success) 
            {
                return View();
            }

            return View(customerList.data);

        }

        // GET: CustomerWithHttpClientController/Details/5
        public async Task<ActionResult> Details(string id)
        {

            CustomerDetailResponse customerDetailResponse = new CustomerDetailResponse();

            customerDetailResponse = await this.customerApi.GetCustomer(id);

            return View(customerDetailResponse.data);

        }

        // GET: CustomerWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerWithHttpClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerDtoAdd customerDtoAdd)
        {

            BaseResponse baseResponse = new BaseResponse();

            baseResponse = await this.customerApi.Save(customerDtoAdd);

            if (!baseResponse.success)
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: CustomerWithHttpClientController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {

            CustomerDetailResponse customerDetail = new CustomerDetailResponse();

            customerDetail = await this.customerApi.Edit(id);

            return View(customerDetail.data);


        }

        // POST: CustomerWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CustomerDtoUpdate customerDtoUpdate)
        {

            BaseResponse baseResponse = new BaseResponse();

            baseResponse = await this.customerApi.Update(customerDtoUpdate);

            if (!baseResponse.success)
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }

            return RedirectToAction(nameof(Index));

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
