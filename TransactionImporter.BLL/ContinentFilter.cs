namespace TransactionImporter.BLL
{
    public class ContinentFilter : ExporterLogic
    {
        public void FilterContinent(string continent)
        {
            DownloadTransactions(L);
        }
    }
}