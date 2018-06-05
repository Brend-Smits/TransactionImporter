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
    }
}
