using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;
using TransactionImporter.WebUI.Models;

namespace TransactionImporter.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITransactionLogic transactionLogic = TransactionFactory.CreateLogic();
        public ActionResult Index()
        {
            IDictionary<string, int> transactionCountGateway = transactionLogic.GetTransactionCountPerGateway();
            List<HomeModels> models = new List<HomeModels>();
            foreach (KeyValuePair<string, int> item in transactionCountGateway)
            {
                HomeModels model = new HomeModels(item.Key, item.Value);
                models.Add(model);
            }
            return View(models);
        }

    }
}