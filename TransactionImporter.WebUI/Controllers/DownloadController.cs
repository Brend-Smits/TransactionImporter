using System;
using System.Collections.Generic;
using System.IO;
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

        private IUserLogic userLogic = UserFactory.CreateLogic();
        // GET: Download
        public ActionResult Index()
        {
            List<UploadDetail> uploadDetailList = uploadDetailLogic.UploadDetailList();
            List<DownloadModels> downloadableList = new List<DownloadModels>();
            foreach (UploadDetail upload in uploadDetailList)
            {
                downloadableList.Add(new DownloadModels(upload.UploadId, upload.UserId, upload.StartTimeUpload.ToString(), upload.FileName, Convert.ToInt32(upload.FileSize)));
            }
            return View(downloadableList);
        }

        // GET: Download/Details/5
        public ActionResult Details(int id)
        {
            UploadDetail detail = uploadDetailLogic.GetUploadDetailById(id);
            User user = userLogic.GetUserById(detail.UserId);
            DownloadModels model = new DownloadModels(detail.UploadId, detail.UserId, user.Username, detail.StartTimeUpload.ToString(), detail.FileName, Convert.ToInt32(detail.FileSize));
            return View(model);
        }

        // GET: Download/Details/5
        public ActionResult Download(int id)
        {
            string serverPath = "C:\\Users\\Rubbertjuh\\Desktop\\TransImporter-Exports\\";
            exporterLogic.DownloadTransactions(true, serverPath);
            string fileName = exporterLogic.GetDownloadName();
            string combineFileNamePath = serverPath + fileName;
            return File(combineFileNamePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(fileName));
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
                exporterLogic.DeleteDataByUploadId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
