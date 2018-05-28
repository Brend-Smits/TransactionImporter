using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class UserFactory
    {
        public static IUserLogic CreateLogic()
        {
            return new UserLogic(new UserRepository(new UserSqlContext()));
        }

    }
}
