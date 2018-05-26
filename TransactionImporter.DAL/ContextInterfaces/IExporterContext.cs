using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterContext
    {
        List<Transaction> GetTransaction();
        List<CustomerInfo> GetCustomers();
    }
}
