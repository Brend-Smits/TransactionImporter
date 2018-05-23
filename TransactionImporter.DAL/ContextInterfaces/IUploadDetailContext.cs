using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUploadDetailContext
    {
        void UploadDetails(UploadDetail detail);
        void UploadDetailList(List<UploadDetail> details);
        int GetUploadId();
    }
}
