using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class ExporterRepository:IExporterRepository
    {
        private readonly IExporterContext exporterContext;

        public ExporterRepository(IExporterContext exporterContext)
        {
            this.exporterContext = exporterContext;
        }

        public List<Transaction> GetTransactionsAllContinents(int id)
        {
            return exporterContext.GetTransactionsAllContinents(id);
        }

        public List<CustomerInfo> GetCustomersAllContinents(int id)
        {
            return exporterContext.GetCustomersAllContinents(id);
        }

        public List<Transaction> GetTransactionFilterContinent(string continent, int id)
        {
            return exporterContext.GetTransactionFilterContinent(continent, id);
        }

        public List<CustomerInfo> GetCustomersFilterContinent(string continent, int id)
        {
            return exporterContext.GetCustomersFilterContinent(continent, id);
        }

        public List<Transaction> GetTransactionsFilterStatus(string status, int id)
        {
            return exporterContext.GetTransactionsFilterStatus(status, id);
        }

        public List<CustomerInfo> GetCustomersFilterStatus(string status, int id)
        {
            return exporterContext.GetCustomersFilterStatus(status, id);
        }

        public List<CustomerInfo> GetCustomersFilterGateway(string gateway, int id)
        {
            return exporterContext.GetCustomersFilterGateway(gateway, id);
        }

        public List<Transaction> GetTransactionsFilterGateway(string gateway, int id)
        {
            return exporterContext.GetTransactionsFilterGateway(gateway, id);
        }
    }
}
