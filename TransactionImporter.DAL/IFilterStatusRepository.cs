using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IFilterStatusRepository
    {
        List<Transaction> GetTransactionsFilterStatus(string status, int id);
        List<CustomerInfo> GetCustomersFilterStatus(string status, int id);
    }
}
