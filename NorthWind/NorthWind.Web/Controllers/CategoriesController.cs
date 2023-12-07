using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;
using NorthWind.Application.Dtos.Categories;
using NorthWind.Web.Models.Response;

namespace NorthWind.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        // GET: CategoriesController/Create
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            CategoryListResponse categoryList = new CategoryListResponse();

            using (var client = new HttpClient(this.httpClientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5130/api/Categories").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        categoryList = JsonConvert.DeserializeObject<CategoryListResponse>(apiResponse);

                        if (!categoryList.success)
                        {
                            ViewBag.Message = categoryList.message;
                            return View();
                        }
                    }
                    else
                    {
                        categoryList.message = "Error conectandose al Api.";
                        categoryList.success = false;
                        ViewBag.Message = categoryList.message;
                    }
                }
            }

            return View(categoryList.data);
        }

        public ActionResult Details(string id)
        {

            CategoryDetailResponse categoryDetail = new CategoryDetailResponse();


            using (var client = new HttpClient(this.httpClientHandler))
            {

                var url = $"http://localhost:5130/api/Categories/{id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        categoryDetail = JsonConvert.DeserializeObject<CategoryDetailResponse>(apiResponse);

                        if (!categoryDetail.success)
                        {
                            ViewBag.Message = categoryDetail.message;
                        }
                    }
                }
            }

            return View(categoryDetail.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        private byte[] GenerateRandomByteArray()
        {
            Random random = new Random();
            byte[] randomBytes = new byte[1024];
            random.NextBytes(randomBytes);
            return randomBytes;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCategory addCategory)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.httpClientHandler))
                {

                    var url = $"http://localhost:5130/api/Categories/save-category";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(addCategory), System.Text.Encoding.UTF8, "application/json");

                    //addCategory.Picture = GenerateRandomByteArray();


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

            CategoryDetailResponse categoryDetail = new CategoryDetailResponse();


            using (var client = new HttpClient(this.httpClientHandler))
            {

                var url = $"http://localhost:5130/api/Categories/{id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        categoryDetail = JsonConvert.DeserializeObject<CategoryDetailResponse>(apiResponse);

                        if (!categoryDetail.success)
                        {
                            ViewBag.Message = categoryDetail.message;
                        }
                    }
                }
            }

            return View(categoryDetail.data);
        }

        // POST: CustomerWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateCategory updateCategory)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.httpClientHandler))
                {

                    var url = $"http://localhost:5130/api/Categories/update-category/{updateCategory.CategoryID}";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(updateCategory), System.Text.Encoding.UTF8, "application/json");

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

        // POST: CustomerWithHttpClientController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.httpClientHandler))
                {

                    var url = $"http://localhost:5130/api/Categories/{id}";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json");

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
    }
}