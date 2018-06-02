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
        string serverPath = "C:\\Users\\Rubbertjuh\\Desktop\\TransImporter-Exports\\";
        // GET: Download
        public ActionResult Index()
        {
            List<UploadDetail> uploadDetailList = uploadDetailLogic.UploadDetailList();
            List<DownloadModels> downloadableList = new List<DownloadModels>();
            foreach (UploadDetail upload in uploadDetailList)
            {
                User user = userLogic.GetUserById(upload.UserId);
                downloadableList.Add(new DownloadModels(upload.UploadId, upload.UserId, user.Username, upload.StartTimeUpload.ToString(), upload.FileName, Convert.ToInt32(upload.FileSize)));
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
        //TODO: Make it cleaner so we don't have duplicate code.
        public ActionResult DownloadEu(int id)
        {
            exporterLogic.DownloadTransactions(true, serverPath);
            string fileName = exporterLogic.GetDownloadName();
            string combineFileNamePath = serverPath + fileName;
            return File(combineFileNamePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(fileName));
        }
        // GET: Download/Details/5
        //TODO: Make it cleaner so we don't have duplicate code.
        public ActionResult DownloadRaw(int id)
        {
            exporterLogic.DownloadTransactions(false, serverPath);
            string fileName = exporterLogic.GetDownloadName();
            string combineFileNamePath = serverPath + fileName;
            return File(combineFileNamePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(fileName));
        }

        // GET: Download/Delete/5
        public ActionResult Delete(int id)
        {
            UploadDetail detail = uploadDetailLogic.GetUploadDetailById(id);
            User user = userLogic.GetUserById(detail.UserId);
            DownloadModels model = new DownloadModels(detail.UploadId, detail.UserId, user.Username, detail.StartTimeUpload.ToString(), detail.FileName, Convert.ToInt32(detail.FileSize));
            return View(model);
        }

        // POST: Download/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                uploadDetailLogic.DeleteDataByUploadId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
