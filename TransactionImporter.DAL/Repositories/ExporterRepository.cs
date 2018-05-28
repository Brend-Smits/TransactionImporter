using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class ExporterRepository:IExporterRepository
    {
        private readonly IExporterContext _exporterContext;

        public ExporterRepository(IExporterContext exporterContext)
        {
            _exporterContext = exporterContext;
        }
        public List<Transaction> GetTransaction()
        {
            return _exporterContext.GetTransaction();
        }

        public List<CustomerInfo> GetCustomers()
        {
            return _exporterContext.GetCustomers();
        }
    }
}
