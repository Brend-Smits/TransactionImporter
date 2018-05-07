using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly ITransactionContext _transactionContext;

        public TransactionRepository(ITransactionContext transactionSqlContext)
        {
            _transactionContext = transactionSqlContext;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactionContext.GetAllTransactions();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public void SetupTables()
        {
            DbInitialisation dbInitialisation = new DbInitialisation();
            dbInitialisation.setupTables();
        }
    }
}
