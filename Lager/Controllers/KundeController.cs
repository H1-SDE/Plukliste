using Lager.Models;
using Lager_dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lager.Controllers
{
    public class KundeController : Controller
    {
        // GET: KunderController
        public ActionResult Index()
        {
            LagerData lagerData = new();
            string getProductJson = lagerData.GetProduct();
            List<LagerModel> list = JsonSerializer.Deserialize<List<LagerModel>>(getProductJson)!;
            return View(list);
        }

        // GET: KunderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KunderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KunderController/Create
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

        // GET: KunderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KunderController/Edit/5
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

        // GET: KunderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KunderController/Delete/5
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
