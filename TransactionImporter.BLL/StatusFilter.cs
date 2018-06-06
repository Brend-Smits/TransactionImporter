using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class StatusFilter : ExporterLogic, IStatusfilter
    {
        private IExporterRepository _Repo;
        public StatusFilter(IExporterRepository exportRepo)
        {
            _Repo = exportRepo;
        }
        public void FilterStatus(string status, string path, int id)
        {
            List<CustomerInfo> customers = _Repo.GetCustomersFilterStatus(status, id);
            List<Transaction> transactions = _Repo.GetTransactionsFilterStatus(status, id);
            DownloadTransactions(customers, transactions, path);

        }
    }
}