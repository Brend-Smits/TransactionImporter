using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
