using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class GatewayFilter : ExporterLogic, IGatewayFilter
    {
        private IFilterGatewayRepository _Repo;
        public GatewayFilter(IFilterGatewayRepository filterGatewayRepo)
        {
            _Repo = filterGatewayRepo;
        }
        public void FilterGateway(string gateway, string path, int id)
        {
            List<CustomerInfo> customers = _Repo.GetCustomersFilterGateway(gateway, id);
            List<Transaction> transactions = _Repo.GetTransactionsFilterGateway(gateway, id);
            DownloadTransactions(customers, transactions, path);

        }
    }
}