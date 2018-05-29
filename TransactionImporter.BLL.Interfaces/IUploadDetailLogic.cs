using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IUploadDetailLogic
    {
        UploadDetail GetUploadDetails(string path);
        void UploadDetails(UploadDetail detail, string path);
        List<UploadDetail> UploadDetailList();
        int GetUploadId();
    }
}
