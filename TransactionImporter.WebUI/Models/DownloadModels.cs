using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionImporter.WebUI.Models
{
    public class DownloadModels
    {
        public DownloadModels(string uploadedOn, int uploadId)
        {
            UploadId = uploadId;
            UploadedOn = uploadedOn;
        }

        public int UploadId { get; private set; }
        public string UploadedOn { get; private set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}