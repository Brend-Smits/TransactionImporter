using System;
using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class UploadDetail
    {
        public int UploadId { get; private set; }
        public DateTime UploadOn { get; private set; }
        public string URL { get; private set; }
        public List<User> users = new List<User>();

        public UploadDetail(DateTime uploadedOn)
        {
            UploadOn = uploadedOn;
        }
    }
}
