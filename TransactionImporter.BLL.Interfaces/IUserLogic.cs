using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IUserLogic
    {
        void CreateUser(User user);
        void EditUser();
        void DeleteUser();
    }
}
