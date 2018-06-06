using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IFilterStatusContext
    {
        List<Transaction> GetTransactionsFilterStatus(string status, int id);
        List<CustomerInfo> GetCustomersFilterStatus(string status, int id);

    }
}
