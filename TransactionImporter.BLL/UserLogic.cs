using System;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _Repo;

        public UserLogic(IUserRepository userRepository)
        {
            _Repo = userRepository;
        }
        public void CreateUser(User user)
        {
            _Repo.CreateUser(user);
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _Repo.GetUserById(id);
        }

        public void EditUser()
        {
            throw new NotImplementedException();
        }
    }
}
