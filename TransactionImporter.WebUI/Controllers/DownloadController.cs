using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;
using TransactionImporter.WebUI.Models;
using TransactionImpoter.Domain;

namespace TransactionImporter.WebUI.Controllers
{

    public class DownloadController : Controller
    {
        private IUploadDetailLogic uploadDetailLogic = UploadDetailFactory.CreateLogic();
        private IExporterLogic exporterLogic = ExporterFactory.CreateLogic();
        // GET: Download
        public ActionResult Index()
        {
            List<UploadDetail> uploadDetailList = uploadDetailLogic.UploadDetailList();
            List<DownloadModels> downloadableList = new List<DownloadModels>();
            foreach (UploadDetail upload in uploadDetailList)
            {
                downloadableList.Add(new DownloadModels(upload.StartTimeUpload.ToString(), upload.UploadId));
            }
            return View(downloadableList);
        }

        // GET: Download/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Download/Details/5
        public void Download(int id)
        {
           exporterLogic.DownloadTransactions(true);
        }

        // GET: Download/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Download/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
