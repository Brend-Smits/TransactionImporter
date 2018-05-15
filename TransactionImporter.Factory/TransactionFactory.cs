using TransactionImporter.BLL;
using TransactionImporter.DAL;

namespace TransactionImporter.Factory
{
    public class TransactionFactory
    {
        public static ITransactionLogic CreateLogic()
        {
            return new TransactionLogic(new TransactionRepository(new TransactionSqlContext()));
        }


    }
}
