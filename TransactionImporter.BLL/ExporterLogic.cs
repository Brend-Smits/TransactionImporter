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
    public class ExporterLogic : IExporterLogic
    {
        private Application xlApp = new Application();
        private Worksheet xlWorksheet;
        private IExporterRepository _Repo;
        private IImporterExcel importerExcel = new ImporterExcel();
        public ExporterLogic(IExporterRepository _exportRepo)
        {
            _Repo = _exportRepo;
        }

        public ExporterLogic()
        {
        }
        public void DownloadTransactions()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string randomFile = Guid.NewGuid().ToString().Replace("-", "");
                string savePath = $"{folderDialog.SelectedPath}\\{randomFile}.xlsx";
                Workbook xlWorkbook = xlApp.Workbooks.Add();
                xlWorksheet = xlWorkbook.Worksheets.get_Item(1);
                AddTransactions();

                xlWorkbook.SaveAs(savePath, XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                    Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlUserResolution, true,
                    Missing.Value, Missing.Value, Missing.Value);
            }

        }

        private void AddTransactions()
        {
            int row = 2;
            foreach (Transaction trans in _Repo.GetTransaction())
            {

                List<string> transDataToAdd = trans.GetDataForThisExcelFile();
                for (int index = 1; index <= transDataToAdd.Count; index++)
                {
                    string data = transDataToAdd[index - 1];
                    xlWorksheet.Cells[index][row] = data;
                }

                row++;
            }
        }

//        public string GetSelectedPath()
//        {
//            return exportTransaction.GetSelectedPath();
//        }
    }
}