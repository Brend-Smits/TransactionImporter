using System.Collections.Generic;
using System.IO;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IImporterExcel
    {
        string UploadFile(string path, Stream stream);
        void RetrieveData();
        List<Transaction> GetTransactions();
        List<CustomerInfo> GetCustomerInfo();
        string GetPath();

    }
}