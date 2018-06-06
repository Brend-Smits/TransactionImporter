using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IFilterContinentContext
    {
        List<Transaction> GetTransactionsAllContinents(int id);
        List<CustomerInfo> GetCustomersAllContinents(int id);
        List<Transaction> GetTransactionFilterContinent(string continent, int id);
        List<CustomerInfo> GetCustomersFilterContinent(string continent, int id);

    }
}
