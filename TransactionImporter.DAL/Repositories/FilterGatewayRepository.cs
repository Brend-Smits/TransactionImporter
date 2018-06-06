using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class FilterGatewayRepository:IFilterGatewayRepository
    {
        private readonly IFilterGatewayContext filterGatewayContext;

        public FilterGatewayRepository(IFilterGatewayContext filterGatewayContext)
        {
            this.filterGatewayContext = filterGatewayContext;
        }

        public List<CustomerInfo> GetCustomersFilterGateway(string gateway, int id)
        {
            return filterGatewayContext.GetCustomersFilterGateway(gateway, id);
        }

        public List<Transaction> GetTransactionsFilterGateway(string gateway, int id)
        {
            return filterGatewayContext.GetTransactionsFilterGateway(gateway, id);
        }
    }
}
