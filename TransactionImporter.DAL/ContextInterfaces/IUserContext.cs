using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IUserContext
    {
        void UploadFile();
        void CancelUpload();
        void CreateUser(User user);
        void EditUser();
        void DeleteUser();
    }
}
