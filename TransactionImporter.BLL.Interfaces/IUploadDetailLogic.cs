using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface IUploadDetailLogic
    {
        UploadDetail GetUploadDetails(string path);
        void UploadDetails();
        void UploadDetailList();
    }
}
