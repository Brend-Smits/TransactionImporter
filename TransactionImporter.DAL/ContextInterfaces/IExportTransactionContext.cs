using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExportTransactionContext
    {
        List<Transaction> GetTransaction();
    }
}
