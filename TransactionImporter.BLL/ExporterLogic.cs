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
                AddHeaders();
                AddTransactions();
                AddCustomers();

                xlWorkbook.SaveAs(savePath, XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                    Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange,
                    XlSaveConflictResolution.xlUserResolution, true,
                    Missing.Value, Missing.Value, Missing.Value);
            }
        }

        private void AddHeaders()
        {
            List<string> headers = new List<string>
            {
                "Transaction ID",
                "Amount",
                "Gateway",
                "Status",
                "Country",
                "Ip",
                "Username",
                "Uuid",
                "Email",
                "Name",
                "Address"
            };
            int col = 1;
            foreach (var header in headers)
            {
                xlWorksheet.Cells[1, col] = header;
                col++;
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

        private void AddCustomers()
        {
            Transaction trans = new Transaction();
            int row = 2;
            foreach (CustomerInfo customer in _Repo.GetCustomers())
            {
                List<string> customerDataToAdd = customer.GetDataForThisExcelFile();
                for (int index = trans.GetDataForThisExcelFile().Count;
                    index < (trans.GetDataForThisExcelFile().Count + customerDataToAdd.Count);
                    index++)
                {
                    string data = customerDataToAdd[index - trans.GetDataForThisExcelFile().Count];
                    xlWorksheet.Cells[index][row] = data;
                }

                row++;
            }
        }
    }
}