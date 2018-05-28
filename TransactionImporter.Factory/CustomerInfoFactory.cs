using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL.Contexts;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class CustomerInfoFactory
    {
        public static ICustomerInfoLogic CreateLogic()
        {
            return new CustomerInfoLogic(new CustomerInfoRepository(new CustomerInfoSqlContext()));
        }


    }
}
