using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionSqlContext:ITransactionContext
    {
        DbInitialisation dbInitialisation = new DbInitialisation();
        // TODO: Implement GetAllTransactions() in SQL Context
        public List<Transaction> GetAllTransactions()
        {
            dbInitialisation.setupTables();
            // SELECT * FROM Transaction
            throw new NotImplementedException();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public Transaction AddTransaction()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> AddTransactionList()
        {
            throw new NotImplementedException();
        }
    }
}
