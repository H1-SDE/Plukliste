using Lager.Models;
using Lager_dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;
using static Lager.Models.PluklisteFrontModel;

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
            PluglisteData pluklisteData = new();
            string getPluklistItemsByIdJson = pluklisteData.GetPluklisteItems(id);
            List<PluklistItemsModel> detailList = JsonSerializer.Deserialize<List<PluklistItemsModel>>(getPluklistItemsByIdJson)!;
            foreach(var item in detailList)
            {
                item.Rest = item.Amount - item.Antal;
            }
            dynamic finalModel = new ExpandoObject();
            finalModel.details = detailList;

            string getPluklisteJson = pluklisteData.GetPlukliste(id);
            List<PluklisteFrontModel> pluklisteList = JsonSerializer.Deserialize<List<PluklisteFrontModel>>(getPluklisteJson)!;
            finalModel.plukliste = pluklisteList;
            return View(finalModel);
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
            PluglisteData pluklisteData = new();
            PluklisteFrontModel pluklisteFrontModel = new();
            string getPluklisteByIdJson = pluklisteData.GetPlukliste(id);
            List<PluklisteFrontModel> list = JsonSerializer.Deserialize<List<PluklisteFrontModel>>(getPluklisteByIdJson)!;
            foreach (var item in list)
            {
                pluklisteFrontModel.FakturaNummer = item.FakturaNummer;
                pluklisteFrontModel.Label = item.Label;
                pluklisteFrontModel.Print = item.Print;
                pluklisteFrontModel.KundeID= item.KundeID;
                pluklisteFrontModel.Forsendelse = item.Forsendelse;

            }
            dynamic finalModel = new ExpandoObject();
            finalModel.details = list;

            Kundedata kundeData = new();
            string getCustomerJson = kundeData.GetCustomers();
            List<KundeModel> kundeList = JsonSerializer.Deserialize<List<KundeModel>>(getCustomerJson)!;
            finalModel.customer = kundeList;
            finalModel.kundeId = id;

            return View(finalModel);
        }

        // POST: PluklistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PluklisteFrontModel pluklisteFrontModel)
        {
            try
            {
                PluglisteData pluklisteData = new();
                pluklisteData.UpdateOrdre(id, pluklisteFrontModel.KundeID, pluklisteFrontModel.Forsendelse!, pluklisteFrontModel.Label, pluklisteFrontModel.Print!);
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

        public ActionResult EditKunder(int id)
        {
            KundeController kundeController = new();
            return View(kundeController.Edit(id));
        }
    }
}
