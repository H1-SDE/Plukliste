using Lager.Models;
using Lager_dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lager.Controllers
{
    public class PluklisteController : Controller
    {
        // GET: PluklistController
        public ActionResult Index()
        {
            PluglisteData pluglistedata = new();
            string getPluklisteJson = pluglistedata.GetPlukliste();
            List<PluklisteFrontModel> list = JsonSerializer.Deserialize<List<PluklisteFrontModel>>(getPluklisteJson)!;
            return View(list);
        }

        // GET: PluklistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PluklistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PluklistController/Create
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

        // GET: PluklistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PluklistController/Edit/5
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

        // GET: PluklistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PluklistController/Delete/5
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
