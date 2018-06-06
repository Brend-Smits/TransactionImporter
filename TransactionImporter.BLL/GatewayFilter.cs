using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class GatewayFilter : ExporterLogic, IGatewayFilter
    {
        private IExporterRepository _Repo;
        public GatewayFilter(IExporterRepository exportRepo)
        {
            _Repo = exportRepo;
        }
        public void FilterGateway(string gateway, string path, int id)
        {
            List<CustomerInfo> customers = _Repo.GetCustomersFilterGateway(gateway, id);
            List<Transaction> transactions = _Repo.GetTransactionsFilterGateway(gateway, id);
            DownloadTransactions(customers, transactions, path);

        }
    }
}