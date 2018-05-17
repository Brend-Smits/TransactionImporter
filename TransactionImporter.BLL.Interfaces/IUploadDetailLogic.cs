using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface IUploadDetailLogic
    {
        void GetUploadDetails(string path);
        void UploadDetail();
        void UploadDetails();
    }
}
