using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class ExportTransactionFactory
    {
        public static IExportTransaction CreateLogic()
        {
            return new ExportTransactionLogic(new ExportTransactionRepository(new ExportTransactionSqlContext()));
        }

    }
}
