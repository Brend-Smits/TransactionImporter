using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterContext
    {
        List<Transaction> GetTransactionsAllContinents(int id);
        List<CustomerInfo> GetCustomersAllContinents(int id);
        List<Transaction> GetTransactionFilterContinent(string continent, int id);
        List<CustomerInfo> GetCustomersFilterContinent(string continent, int id);
        List<Transaction> GetTransactionsFilterStatus(string status, int id);
        List<CustomerInfo> GetCustomersFilterStatus(string status, int id);
        List<CustomerInfo> GetCustomersFilterGateway(string gateway, int id);
        List<Transaction> GetTransactionsFilterGateway(string gateway, int id);

    }
}
