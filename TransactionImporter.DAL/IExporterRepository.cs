using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterRepository
    {
        List<Transaction> GetTransaction(bool filterEu);
        List<CustomerInfo> GetCustomers(bool filterEu);
        List<Transaction> GetTransactionFilterContinent(string continent, int id);
        List<CustomerInfo> GetCustomersFilterContinent(string continent, int id);

    }
}
