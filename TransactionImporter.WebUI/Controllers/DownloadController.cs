using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;
using TransactionImporter.WebUI.Models;
using TransactionImpoter.Domain;

namespace TransactionImporter.WebUI.Controllers
{
    public class DownloadController : Controller
    {
        private IUploadDetailLogic uploadDetailLogic = UploadDetailFactory.CreateLogic();
        private IExporterLogic exporterLogic = new ExporterLogic();
        private IContinentFilter continentFilter = FilterContinentFactory.CreateContinentFilter();
        private IStatusfilter statusFilter = FilterStatusFilter.CreateStatusFilter();
        private IGatewayFilter gatewayFilter = FilterGatewayFactory.CreateGatewayFilter();
        private IUserLogic userLogic = UserFactory.CreateLogic();
        string serverPath = "C:\\Users\\Rubbertjuh\\Desktop\\TransImporter-Exports\\";


        // GET: Download
        public ActionResult Index()
        {
            List<UploadDetail> uploadDetailList = uploadDetailLogic.UploadDetailList();
            foreach (UploadDetail upload in uploadDetailList)
            {
                if (!DownloadModels.ModelDictionary.ContainsKey(upload.UploadId))
                {
                    User user = userLogic.GetUserById(upload.UserId);
                    DownloadModels model = new DownloadModels(upload.UploadId, upload.UserId, user.Username,
                        upload.StartTimeUpload.ToString(), upload.FileName, Convert.ToInt32(upload.FileSize));
                    DownloadModels.ModelDictionary.Add(upload.UploadId, model);
                    DownloadModels.downloadableList.Add(model);
                }
            }

            return View(DownloadModels.downloadableList);
        }


        // GET: Download/Details/5
        public ActionResult Details(int id)
        {
            return PartialView(DownloadModels.ModelDictionary[id]);
        }

        // GET: Download/Details/5
        public ActionResult Download(int id, string continent)
        {
            if (continent == "N/A")
            {
                continentFilter.FilterContinent("N/A", serverPath, id);  
            }
            else
            {
                continentFilter.FilterContinent("EU", serverPath, id);
            }

            return CreateDownload();
        }

        public ActionResult DownloadStatusComplete(int id, string status)
        {
            statusFilter.FilterStatus(status, serverPath, id);
            return CreateDownload();
        }
        public ActionResult DownloadGatewayPaypal(int id, string gateway)
        {
            gatewayFilter.FilterGateway(gateway, serverPath, id);
            return CreateDownload();
        }

        public ActionResult CreateDownload()
        {
            string fileName = exporterLogic.GetDownloadName();
            string combineFileNamePath = serverPath + fileName;
            return File(combineFileNamePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Path.GetFileName(fileName));
        }

        // GET: Download/Delete/5
        public ActionResult Delete(int id)
        {
            UploadDetail detail = uploadDetailLogic.GetUploadDetailById(id);
            User user = userLogic.GetUserById(detail.UserId);
            DownloadModels model = new DownloadModels(detail.UploadId, detail.UserId, user.Username,
                detail.StartTimeUpload.ToString(), detail.FileName, Convert.ToInt32(detail.FileSize));
            return View(model);
        }

        // POST: Download/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DownloadModels.downloadableList.RemoveAll(r => r.UploadId == id);
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