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
        public List<Transaction> GetTransaction(bool filterEu)
        {
            return exporterContext.GetTransaction(filterEu);
        }

        public List<CustomerInfo> GetCustomers(bool filterEu)
        {
            return exporterContext.GetCustomers(filterEu);
        }
    }
}
