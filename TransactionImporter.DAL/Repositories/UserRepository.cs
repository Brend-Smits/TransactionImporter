using System;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly IUserContext _userContext;

        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
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
            _userContext.CreateUser(user);
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
