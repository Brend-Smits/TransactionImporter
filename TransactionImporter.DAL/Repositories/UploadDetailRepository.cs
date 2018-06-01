using System;
using System.Collections.Generic;
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

        public List<UploadDetail> UploadDetailList()
        {
            return uploadDetailContext.UploadDetailList();
        }

        public int GetUploadId()
        {
            IUploadDetailContext uploadDetailContext = new UploadDetailSqlContext();
            return uploadDetailContext.GetUploadId();
        }

        public UploadDetail GetUploadDetailById(int id)
        {
            return uploadDetailContext.GetUploadDetailById(id);
        }
    }
}
