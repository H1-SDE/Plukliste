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
            LagerData lagerData = new();
            string getProductJson = lagerData.GetProduct();
            List<KundeModel> list = JsonSerializer.Deserialize<List<KundeModel>>(getProductJson)!;
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            LagerData lagerData = new();
            LagerModel lagerModel = new();
            string getProductByIdJson = lagerData.GetProduct(id);
            List<LagerModel> list = JsonSerializer.Deserialize<List<LagerModel>>(getProductByIdJson)!;
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
        public ActionResult Create(LagerModel product)
        {
            try
            {
                LagerData lagerData = new();
                var errorTeck = lagerData.AddProduct(product.ProductID!, product.Description!, product.Amount!);
                if (errorTeck != "success")
                {
                    return View(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            LagerData lagerData = new();
            LagerModel lagerModel = new();
            string getProductByIdJson = lagerData.GetProduct(id);
            List<LagerModel> list = JsonSerializer.Deserialize<List<LagerModel>>(getProductByIdJson)!;
            foreach (var item in list)
            {
                lagerModel.ProductID = item.ProductID;
                lagerModel.Description = item.Description;
                lagerModel.Amount = item.Amount;

            }
            return View(lagerModel);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, LagerModel product)
        {
            try
            {
                LagerData lagerData = new();
                lagerData.UpdateProduct(id, product.Description!, product.Amount);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
