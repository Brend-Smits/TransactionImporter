using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUploadDetailContext
    {
        void UploadDetails(UploadDetail detail);
        List<UploadDetail> UploadDetailList();
        int GetUploadId();
        UploadDetail GetUploadDetailById(int id);
    }
}
