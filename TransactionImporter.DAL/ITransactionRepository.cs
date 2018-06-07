using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> FilterTransactions();
        void AddTransaction(int uploadId, Transaction trans);
        void AddTransactionList(int uploadId, List<Transaction> transactions);

        IDictionary<string, int> GetTransactionCountPerGateway();
    }
}
