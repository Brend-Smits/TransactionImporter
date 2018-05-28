using System;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IUserContext userContext;

        public UserRepository(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public void UploadFile()
        {
            throw new NotImplementedException();
        }

        public void CancelUpload()
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            userContext.CreateUser(user);
        }

        public void EditUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }
    }
}
