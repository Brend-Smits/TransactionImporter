using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TransactionImporter.BLL.Interfaces;
using TransactionImpoter.Domain;
using Microsoft.Office.Interop.Excel;
using TransactionImporter.DAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TransactionImporter.BLL
{
    public class ExportTransactionLogic : IExportTransaction
    {
        private Application xlApp = new Application();
        private Worksheet xlWorksheet;
        private IExportTransactionRepository _Repo;
        private IImporterExcel importerExcel = new ImporterExcel();
        public ExportTransactionLogic(IExportTransactionRepository _exportRepo)
        {
            _Repo = _exportRepo;
        }

        public ExportTransactionLogic()
        {
        }
        public void DownloadTransactions()
        {
                string randomFile = Guid.NewGuid().ToString().Replace("-", "");
                string savePath = $"\\{randomFile}.xlsx";
                Workbook xlWorkbook = xlApp.Workbooks.Add();
                xlWorksheet = xlWorkbook.Worksheets.get_Item(1);

                int row = 2;
                foreach (Transaction trans in _Repo.GetTransaction())
                {
                    Console.WriteLine(trans.Amount);
                    Console.WriteLine(trans.TransactionId);

                    List<string> dataToAdd = trans.GetDataForThisExcelFile();
                    for (int index = 1; index <= dataToAdd.Count; index++)
                    {
                        string data = dataToAdd[index - 1];
                        xlWorksheet.Cells[index][row] = data;
                    }

                    row++;
                }

                xlWorkbook.SaveAs(savePath, XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                    Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlUserResolution, true,
                    Missing.Value, Missing.Value, Missing.Value);

        }

//        public string GetSelectedPath()
//        {
//            return exportTransaction.GetSelectedPath();
//        }
    }
}