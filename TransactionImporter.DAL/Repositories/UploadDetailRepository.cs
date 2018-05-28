using System;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class UploadDetailRepository : IUploadDetailRepository
    {
        private readonly IUploadDetailContext uploadDetailContext;

        public UploadDetailRepository(IUploadDetailContext userContext)
        {
            uploadDetailContext = userContext;
        }

        public UploadDetailRepository()
        {
        }

        public void UploadDetails(UploadDetail detail)
        {
            uploadDetailContext.UploadDetails(detail);
        }

        public void UploadDetailList()
        {
            throw new NotImplementedException();
        }

        public int GetUploadId()
        {
            IUploadDetailContext uploadDetailContext = new UploadDetailSqlContext();
            return uploadDetailContext.GetUploadId();
        }
    }
}
