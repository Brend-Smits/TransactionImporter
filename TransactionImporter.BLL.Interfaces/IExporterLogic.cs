namespace TransactionImporter.BLL.Interfaces
{
    public interface IExporterLogic
    {
        void DownloadTransactions(bool filterEu, string path);
        string GetDownloadName();

    }
}
