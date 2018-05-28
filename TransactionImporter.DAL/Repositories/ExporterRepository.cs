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
        public List<Transaction> GetTransaction()
        {
            return exporterContext.GetTransaction();
        }

        public List<CustomerInfo> GetCustomers()
        {
            return exporterContext.GetCustomers();
        }

        public List<Transaction> GetEuTransaction()
        {
            return exporterContext.GetEuTransaction();
        }

        public List<CustomerInfo> GetEuCustomers()
        {
            return exporterContext.GetEuCustomers();
        }
    }
}
