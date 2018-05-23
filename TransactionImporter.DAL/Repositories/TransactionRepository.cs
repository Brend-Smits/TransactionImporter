using System;
using System.Collections.Generic;
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

        public void AddTransaction(int uploadId, Transaction trans)
        {
            _transactionContext.AddTransaction(uploadId, trans);
        }

        public void AddTransactionList(int uploadId, List<Transaction> transactions)
        {
            _transactionContext.AddTransactionList(uploadId, transactions);
        }
    }
}
