using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class FilterStatusRepository:IFilterStatusRepository
    {
        private readonly IFilterStatusContext filterStatusContext;

        public FilterStatusRepository(IFilterStatusContext filterStatusContext)
        {
            this.filterStatusContext = filterStatusContext;
        }

        public List<CustomerInfo> GetCustomersFilterStatus(string status, int id)
        {
            return filterStatusContext.GetCustomersFilterStatus(status, id);
        }

        public List<Transaction> GetTransactionsFilterStatus(string status, int id)
        {
            return filterStatusContext.GetTransactionsFilterStatus(status, id);
        }
    }
}
