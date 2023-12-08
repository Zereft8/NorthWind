using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthWind.Application.Contracts;
using NorthWind.Application.Dtos.Base;
using NorthWind.Application.Dtos.Suppliers;
using NorthWind.Web.Models.Responses;

namespace NorthWind.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService supplierService;  

        HttpClientHandler clientHandler = new HttpClientHandler();

        public SuppliersController(ISuppliersService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: SuppliersWithHttpClientController
        public ActionResult Index()
        {
            SupplierListResponse suppliersList = new SupplierListResponse();

            using (var client = new HttpClient(clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5130/api/Suppliers/GetSuppliers").Result)

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        suppliersList = JsonConvert.DeserializeObject<SupplierListResponse>(apiResponse);
                    }
            
                if (!suppliersList.success)
                {
                ViewBag.Message = suppliersList.message;
                return View();
                }
        
                    else
                    {
                        suppliersList.message = "Error conectandose al Api.";
                        suppliersList.success = false;
                        ViewBag.Message = suppliersList.message;
                    }
            }
            return View(suppliersList.data);
        }



        // GET: SuppliersWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {

            SuppliersDetailResponse supplierDetail = new SuppliersDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5130/api/Suppliers/GetSupplier?SupplierID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        supplierDetail = JsonConvert.DeserializeObject<SuppliersDetailResponse>(apiResponse);

                        if (!supplierDetail.success)
                        {
                            ViewBag.Message = supplierDetail.message;
                        }
                    }
                }
            }

            return View(supplierDetail.data);
        }


        // GET: SuppliersWithHttpClientController/Create
        public ActionResult Create()
        {
        return View();
        }

        // POST: SuppliersWithHttpClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierDtoAdd supplierDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5130/api/Suppliers/SaveSupplier";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(supplierDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: SuppliersWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {

            SuppliersDetailResponse supplierDetail = new SuppliersDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5130/api/Suppliers/GetSupplierById?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        supplierDetail = JsonConvert.DeserializeObject<SuppliersDetailResponse>(apiResponse);

                        if (!supplierDetail.success)
                        {
                            ViewBag.Message = supplierDetail.message;
                        }
                    }
                }
            }

            return View(supplierDetail.data);
        }
        // POST: SuppliersWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierDtoUpdate supplierDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5130/api/Suppliers/UpdateSupplier";


                    StringContent content = new StringContent(JsonConvert.SerializeObject(supplierDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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

        // GET: SuppliersWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
        return View();
        }

        // POST: SuppliersWithHttpClientController/Delete/5
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

