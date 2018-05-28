using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterRepository
    {
        List<Transaction> GetTransaction();
        List<CustomerInfo> GetCustomers();
        List<Transaction> GetEuTransaction();
        List<CustomerInfo> GetEuCustomers();
    }
}
