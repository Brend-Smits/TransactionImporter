namespace TransactionImporter.BLL.Interfaces
{
    public interface IExporterLogic
    {
        void DownloadTransactions(bool filterEu, string path);
        string GetDownloadName();
        //TODO: Does Delete really fit in the Exporter classes? Perhaps it should be moved into a new class where we manage all data?
        void DeleteDataByUploadId(int id);

    }
}
