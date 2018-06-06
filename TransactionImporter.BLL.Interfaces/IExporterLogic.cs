using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IExporterLogic
    {
        void DownloadTransactions(List<CustomerInfo> customerList,List<Transaction> transactionList, string path);
        string GetDownloadName();

    }
}
