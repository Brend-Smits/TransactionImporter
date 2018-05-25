using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExportTransactionRepository
    {
        List<Transaction> GetTransaction();
    }
}
