using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface IUploadDetailLogic
    {
        UploadDetail GetUploadDetails(string path);
        void UploadDetails(UploadDetail detail, string path);
        void UploadDetailList();
    }
}
