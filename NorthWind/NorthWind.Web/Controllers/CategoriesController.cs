using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthWind.Application.Contracts;
using NorthWind.Application.Core;

namespace NorthWind.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        // GET: CategoriesController/Create
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            ServiceResult result = new ServiceResult();

            using (var client = new HttpClient(this.httpClientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5130/api/Categories").Result)

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<ServiceResult>(apiResponse);
                }
            }
            return View(result.Data);
        }
    }
}
