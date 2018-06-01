using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUserRepository
    {
        void UploadFile();
        void CancelUpload();
        void CreateUser(User user);
        void EditUser();
        void DeleteUser();
        User GetUserById(int id);

    }
}
