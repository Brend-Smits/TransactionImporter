using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUploadDetailRepository
    {
        void UploadDetails(UploadDetail detail);
        void UploadDetailList();
        int GetUploadId();
    }
}
