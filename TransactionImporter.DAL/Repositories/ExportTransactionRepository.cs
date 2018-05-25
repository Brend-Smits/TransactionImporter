﻿using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class ExportTransactionRepository:IExportTransactionRepository
    {
        private readonly IExportTransactionContext _exportContext;

        public ExportTransactionRepository(IExportTransactionContext exportContext)
        {
            _exportContext = exportContext;
        }
        public List<Transaction> GetTransaction()
        {
            return _exportContext.GetTransaction();
        }
    }
}
