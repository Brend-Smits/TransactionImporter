using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface IUserLogic
    {
        void CreateUser(User user);
        void EditUser();
        void DeleteUser();
    }
}
