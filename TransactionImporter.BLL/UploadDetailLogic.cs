using System;
using System.Collections.Generic;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class UploadDetailLogic : IUploadDetailLogic
    {
        private IUploadDetailRepository _Repo;
        List<UploadDetail> _details = new List<UploadDetail>();

        public UploadDetailLogic(IUploadDetailRepository _uploadDetailRepository)
        {
            _Repo = _uploadDetailRepository;
        }


        public void GetUploadDetails()
        {
            throw new NotImplementedException();
        }

        public void UploadDetail()
        {
            throw new NotImplementedException();
        }

        public void UploadDetails()
        {
            throw new NotImplementedException();
        }
    }
}
