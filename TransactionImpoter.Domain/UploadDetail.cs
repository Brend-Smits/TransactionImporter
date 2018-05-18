using System;
using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class UploadDetail
    {
        public int uploadId { get; private set; }
        public DateTime _startTimeUpload { get; private set; }
        public DateTime _endTimeUpload { get; private set; }
        public string URL { get; private set; }
        public string _fileName { get; private set; }
        public string _fileSize { get; private set; }
        public List<User> users = new List<User>();

        public UploadDetail(DateTime startTimeUpload, DateTime endTimeUpload, string fileName, string fileSize)
        {
            _startTimeUpload = startTimeUpload;
            _endTimeUpload = endTimeUpload;
            _fileName = fileName;
            _fileSize = fileSize;

        }
    }
}
