using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IImporterExcel
    {
        void UploadFile();
        void RetrieveData();
        List<Transaction> GetTransactions();
        List<CustomerInfo> GetCustomerInfo();
        string GetPath();

    }
}