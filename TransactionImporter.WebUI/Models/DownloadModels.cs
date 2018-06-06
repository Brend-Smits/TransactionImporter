using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionImporter.WebUI.Models
{
    public class DownloadModels
    {
        public static IDictionary<int, DownloadModels> ModelDictionary = new Dictionary<int, DownloadModels>();
        public static List<DownloadModels> downloadableList = new List<DownloadModels>();

        public DownloadModels(int uploadId, int userId, string uploadedOn, string fileName, int fileSize)
        {
            UploadId = uploadId;
            UserId = userId;
            UploadedOn = uploadedOn;
            FileName = fileName;
            FileSize = fileSize;
        }
        public DownloadModels(int uploadId, int userId, string username, string uploadedOn, string fileName, int fileSize)
        {
            UploadId = uploadId;
            UserId = userId;
            Username = username;
            UploadedOn = uploadedOn;
            FileName = fileName;
            FileSize = fileSize;
        }
        public DownloadModels() { }

        public int UploadId { get; private set; }
        public string UploadedOn { get; private set; }
        public string FileName { get; private set; }
        public int FileSize { get; private set; }
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}