using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UploadDetailSqlContext:IUploadDetailContext
    {
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
