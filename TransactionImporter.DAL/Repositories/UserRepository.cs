using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.DAL.Repositories
{
    class UserRepository:IUserRepository
    {
        private readonly IUserContext _userContext;
        public void UploadFile()
        {
            throw new NotImplementedException();
        }

        public void CancelUpload()
        {
            throw new NotImplementedException();
        }
    }
}
