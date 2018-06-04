using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterRepository
    {
        List<Transaction> GetTransaction(bool filterEu);
        List<CustomerInfo> GetCustomers(bool filterEu);
        List<Transaction> GetTransactionFilterContinent(string continent);
        List<CustomerInfo> GetCustomersFilterContinent(string continent);

    }
}
