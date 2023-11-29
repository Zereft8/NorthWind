using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthWind.Web.Controllers
{
    public class CategoriesWithHttpClientController : Controller
    {
        // GET: CategoriesWithHttpClientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoriesWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesWithHttpClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CategoriesWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriesWithHttpClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CategoriesWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesWithHttpClientController/Delete/5
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
