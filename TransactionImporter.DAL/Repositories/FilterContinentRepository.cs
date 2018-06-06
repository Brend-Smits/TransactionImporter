using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class FilterContinentRepository:IFilterContinentRepository
    {
        private readonly IFilterContinentContext filterContinentContext;

        public FilterContinentRepository(IFilterContinentContext filterContinentContext)
        {
            this.filterContinentContext = filterContinentContext;
        }

        public List<Transaction> GetTransactionsAllContinents(int id)
        {
            return filterContinentContext.GetTransactionsAllContinents(id);
        }

        public List<CustomerInfo> GetCustomersAllContinents(int id)
        {
            return filterContinentContext.GetCustomersAllContinents(id);
        }

        public List<Transaction> GetTransactionFilterContinent(string continent, int id)
        {
            return filterContinentContext.GetTransactionFilterContinent(continent, id);
        }

        public List<CustomerInfo> GetCustomersFilterContinent(string continent, int id)
        {
            return filterContinentContext.GetCustomersFilterContinent(continent, id);
        }
    }
}
