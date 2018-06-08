using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface ITransactionLogic
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> FilterTransactions();
        List<Transaction> GetTransactions();
        void AddTransaction(Transaction trans);
        void AddTransactionList(List<Transaction> transactions);
        IDictionary<string, int> GetTransactionCountPerGateway();
    }
}
