﻿using System;
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
        public TransactionLogic(ITransactionRepository _transRepo)
        {
            _Repo = _transRepo;
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
    }
}