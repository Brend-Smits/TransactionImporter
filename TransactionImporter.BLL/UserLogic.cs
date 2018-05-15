using System;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _Repo;

        public UserLogic(IUserRepository _userRepository)
        {
            _Repo = _userRepository;
        }
        public void CreateUser(User user)
        {
            _Repo.CreateUser(user);
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public void EditUser()
        {
            throw new NotImplementedException();
        }
    }
}
