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
        public void FilterContinent(string continent, string path, int id)
        {
            List<CustomerInfo> customers = new List<CustomerInfo>();
            List<Transaction> transactions = new List<Transaction>();
            if (continent == "N/A")
            {
                customers = _Repo.GetCustomersAllContinents(id);
                transactions = _Repo.GetTransactionsAllContinents(id);
            }
            else
            {
                customers = _Repo.GetCustomersFilterContinent(continent, id);
                transactions = _Repo.GetTransactionFilterContinent(continent, id);
            }
            DownloadTransactions(customers, transactions, path);

        }
    }
}