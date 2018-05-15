using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ITransactionRepository
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> FilterTransactions();
        void AddTransaction(Transaction trans);
        void AddTransactionList(List<Transaction> transactions);

    }
}
