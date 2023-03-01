﻿using Lager.Models;
using Lager_dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;
using static Lager.Models.PluklisteFrontModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

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
            dynamic finalModel = new ExpandoObject();
            foreach (var item in list)
            {
                pluklisteFrontModel.FakturaNummer = item.FakturaNummer;
                pluklisteFrontModel.Label = item.Label;
                pluklisteFrontModel.Print = item.Print;
                pluklisteFrontModel.KundeID = item.KundeID;
                finalModel.kundeId = item.KundeID;
                pluklisteFrontModel.Forsendelse = item.Forsendelse;

            }
            finalModel.details = list;

            Kundedata kundeData = new();
            KundeModel kundeModel = new();
            string getCustomerJson = kundeData.GetCustomers();
            List<KundeModel> kundeList = JsonSerializer.Deserialize<List<KundeModel>>(getCustomerJson)!;
            List<SelectListItem> kundeList1 = new List<SelectListItem>();
            foreach (var item in kundeList)
            {
                kundeList1.Add(new SelectListItem()
                {
                    Text = item.KundeID.ToString(),
                    Value = item.KundeID.ToString()
                });
                kundeModel.KundeID = item.KundeID;
                finalModel.customer = new SelectList(kundeList1, "Value", "Text");
            }
            return View(finalModel);
        }

        // POST: PluklistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection pluklisteFrontModel)
        {
            try
            {
                int kundeId = int.Parse(pluklisteFrontModel["item.KundeID"]!);
                bool label = bool.Parse(pluklisteFrontModel["item.Label"][0]!);
                string forsendelse = pluklisteFrontModel["item.Forsendelse"]!;
                string print = pluklisteFrontModel["item.Print"]!;
                PluglisteData pluklisteData = new();
                pluklisteData.UpdateOrdre(id, kundeId, forsendelse, label, print);
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
