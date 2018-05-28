using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly ITransactionContext transactionContext;

        public TransactionRepository(ITransactionContext transactionSqlContext)
        {
            transactionContext = transactionSqlContext;
        }

        public List<Transaction> GetAllTransactions()
        {
            return transactionContext.GetAllTransactions();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public void AddTransaction(int uploadId, Transaction trans)
        {
            transactionContext.AddTransaction(uploadId, trans);
        }

        public void AddTransactionList(int uploadId, List<Transaction> transactions)
        {
            transactionContext.AddTransactionList(uploadId, transactions);
        }
    }
}
