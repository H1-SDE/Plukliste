using Lager.Models;
using Lager_dal;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Lager.Controllers
{
    public class KundeController : Controller
    {
        // GET: KunderController
        public ActionResult Index()
        {
            Kundedata kundeData = new();
            string getCustomerJson = kundeData.GetCustomers();
            List<KundeModel> list = JsonSerializer.Deserialize<List<KundeModel>>(getCustomerJson)!;
            return View(list);
        }

        // GET: KunderController/Details/5
        public ActionResult Details(int id)
        {
            Kundedata kundeData = new();
            KundeModel kundeModel = new();
            string getCustomerByIdJson = kundeData.GetCustomer(id);
            List<KundeModel> list = JsonSerializer.Deserialize<List<KundeModel>>(getCustomerByIdJson)!;
            foreach (var item in list)
            {
                kundeModel.KundeID = item.KundeID;
                kundeModel.Navn = item.Navn;
                kundeModel.Adresse = item.Adresse;

            }
            return View(kundeModel);
        }

        // GET: KunderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KunderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KundeModel kunde)
        {
            try
            {
                Kundedata kundeData = new();
                kundeData.AddCostummer(kunde.Navn!, kunde.Adresse!);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(kunde);
            }
        }

        // GET: KunderController/Edit/5
        public ActionResult Edit(int id)
        {
            Kundedata kundeData = new();
            KundeModel kundeModel = new();
            string getProductByIdJson = kundeData.GetCustomer(id);
            List<KundeModel> list = JsonSerializer.Deserialize<List<KundeModel>>(getProductByIdJson)!;
            foreach (var item in list)
            {
                kundeModel.KundeID = item.KundeID;
                kundeModel.Navn = item.Navn;
                kundeModel.Adresse = item.Adresse;

            }
            return View(kundeModel);
        }

        // POST: KunderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KundeModel kunde)
        {
            try
            {
                Kundedata kundeData = new();
                kundeData.UpdateCostumer(kunde.Navn!, kunde.Adresse, id);
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
