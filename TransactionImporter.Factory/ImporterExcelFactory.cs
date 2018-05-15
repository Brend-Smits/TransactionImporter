using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;

namespace TransactionImporter.Factory
{
    public class ImporterExcelFactory
    {
        public static IImporterExcel CreateLogic()
        {
            return new ImporterExcel();
        }
    }
}
