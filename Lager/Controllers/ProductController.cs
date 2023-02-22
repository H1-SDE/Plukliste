using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lager.Models;
using Lager_dal;
using System.Text.Json;

namespace Lager.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            LagerData lagerData = new LagerData();
            string getProductJson = lagerData.GetProduct();
            List<LagerModel> list = JsonSerializer.Deserialize<List<LagerModel>>(getProductJson)!;
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            LagerData lagerData = new LagerData();
            LagerModel lagerModel = new LagerModel();
            string getProductByIdJson = lagerData.GetProduct(id);
            List<LagerModel> list = JsonSerializer.Deserialize<List<LagerModel>>(getProductByIdJson);
            foreach (var item in list)
            {
                lagerModel.ProductID = item.ProductID;
                lagerModel.Description = item.Description;
                lagerModel.Amount = item.Amount;

            }
            return View(lagerModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
