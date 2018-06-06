using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class StatusFilter : ExporterLogic, IStatusfilter
    {
        private IFilterStatusRepository _Repo;
        public StatusFilter(FilterStatusRepository filterStatusRepo)
        {
            _Repo = filterStatusRepo;
        }
        public void FilterStatus(string status, string path, int id)
        {
            List<CustomerInfo> customers = _Repo.GetCustomersFilterStatus(status, id);
            List<Transaction> transactions = _Repo.GetTransactionsFilterStatus(status, id);
            DownloadTransactions(customers, transactions, path);

        }
    }
}