using System;
using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class UploadDetail
    {
        public int UploadId { get; private set; }
        public DateTime StartTimeUpload { get; private set; }
        public DateTime EndTimeUpload { get; private set; }
        public string FileName { get; private set; }
        public string FileSize { get; private set; }
        public int UserId { get; private set; }
        public List<User> users = new List<User>();

        public UploadDetail(int uploadId, DateTime startTimeUpload, string fileName, string fileSize)
        {
            UploadId = uploadId;
            StartTimeUpload = startTimeUpload;
            FileName = fileName;
            FileSize = fileSize;
        }
        public UploadDetail(int uploadId, int userId, DateTime startTimeUpload, string fileName, string fileSize)
        {
            UploadId = uploadId;
            UserId = userId;
            StartTimeUpload = startTimeUpload;
            FileName = fileName;
            FileSize = fileSize;

        }
    }
}
