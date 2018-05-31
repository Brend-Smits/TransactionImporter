using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface IExporterContext
    {
        List<Transaction> GetTransaction(bool filterEu);
        List<CustomerInfo> GetCustomers(bool filterEu);
        //TODO: Does Delete really fit in the Exporter classes? Perhaps it should be moved into a new class where we manage all data?
        void DeleteDataByUploadId(int id);

    }
}
