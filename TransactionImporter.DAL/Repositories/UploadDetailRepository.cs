using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class UploadDetailRepository : IUploadDetailRepository
    {
        private readonly IUploadDetailContext _uploadDetailContext;

        public UploadDetailRepository(IUploadDetailContext userContext)
        {
            _uploadDetailContext = userContext;
        }

        public void UploadDetail(UploadDetail detail)
        {
            throw new NotImplementedException();
        }

        public void UploadDetails(List<UploadDetail> details)
        {
            throw new NotImplementedException();
        }
    }
}
