using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    class UserSqlContext:IUserContext
    {
        DbInitialisation dbInitialisation = new DbInitialisation();
        public void UploadFile()
        {
            dbInitialisation.setupTables();
            throw new NotImplementedException();
        }

        public void CancelUpload()
        {
            throw new NotImplementedException();
        }
    }
}
