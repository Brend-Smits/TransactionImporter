using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class ExporterFactory
    {
        public static IExporterLogic CreateLogic()
        {
            return new ExporterLogic(new ExporterRepository(new ExporterSqlContext()));
        }

        public static IContinentFilter CreateContinentFilter()
        {
            return new ContinentFilter(new ExporterRepository(new ExporterSqlContext()));
        }

    }
}
