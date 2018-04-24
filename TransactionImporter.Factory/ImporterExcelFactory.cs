using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
