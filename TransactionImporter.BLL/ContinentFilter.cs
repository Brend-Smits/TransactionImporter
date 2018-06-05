using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class ContinentFilter : ExporterLogic, IContinentFilter
    {
        private IExporterRepository _Repo;
        public ContinentFilter(IExporterRepository exportRepo)
        {
            _Repo = exportRepo;
        }
        public void FilterContinent(string continent, string path)
        {
            List<CustomerInfo> customers = _Repo.GetCustomersFilterContinent(continent);
            List<Transaction> transactions = _Repo.GetTransactionFilterContinent(continent);
            DownloadTransactions(customers, transactions, path);

        }
    }
}