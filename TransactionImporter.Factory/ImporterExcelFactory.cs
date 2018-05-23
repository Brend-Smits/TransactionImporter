using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;

namespace TransactionImporter.Factory
{
    public class ImporterExcelFactory
    {
        public static IExportTransaction CreateLogic()
        {
            return new ImporterExcel();
        }
    }
}
