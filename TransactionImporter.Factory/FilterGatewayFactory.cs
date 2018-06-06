using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class FilterGatewayFactory
    {
        public static IGatewayFilter CreateGatewayFilter()
        {
            return new GatewayFilter(new FilterGatewayRepository(new FilterGatewaySqlContext()));
        }

    }
}
