using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUploadDetailRepository
    {
        void UploadDetail(UploadDetail detail);
        void UploadDetails(List<UploadDetail> details);
    }
}
