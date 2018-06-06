using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IFilterGatewayContext
    {
        List<CustomerInfo> GetCustomersFilterGateway(string gateway, int id);
        List<Transaction> GetTransactionsFilterGateway(string gateway, int id);

    }
}
