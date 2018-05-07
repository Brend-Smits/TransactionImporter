using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface ITransactionLogic
    {
        List<Transaction> GetAllTransactions();
        List<Transaction> FilterTransactions();

        List<Transaction> GetTransactions();

        Transaction AddTransaction();
    }
}
