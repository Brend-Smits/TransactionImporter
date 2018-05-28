using System;
using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class TransactionLogic : ITransactionLogic
    {
        private ITransactionRepository _Repo;
        private IImporterExcel _importer = new ImporterExcel();
        private IUploadDetailLogic detailLogic = new UploadDetailLogic();
        public TransactionLogic(ITransactionRepository transRepo)
        {
            _Repo = transRepo;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _Repo.GetAllTransactions();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactions()
        {
            return _importer.GetTransactions();
        }

        public void AddTransaction(Transaction trans)
        {
            _Repo.AddTransaction(detailLogic.GetUploadId(), trans);
        }

        public void AddTransactionList(List<Transaction> transactions)
        {
            _Repo.AddTransactionList(detailLogic.GetUploadId(), transactions);
        }
    }
}
