using System;
using System.Collections.Generic;
using System.Reflection;
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
        private Worksheet xlWorksheet;
        private IExporterRepository _Repo;
        private IImporterExcel importerExcel = new ImporterExcel();

        public string randomFileName { get; private set; }

        public ExporterLogic(IExporterRepository exportRepo)
        {
            _Repo = exportRepo;
        }

        public ExporterLogic() {}

        public void DownloadTransactions(List<CustomerInfo> customerList,List<Transaction> transactionList, string path)
        {
            Application xlApp = new Application();
            randomFileName = Guid.NewGuid().ToString().Replace("-", "");
            string savePath = $"{path}{randomFileName}.xlsx";
            Workbook xlWorkbook = xlApp.Workbooks.Add();
            xlWorksheet = xlWorkbook.Worksheets.get_Item(1);
            AddHeaders();
            AddTransactions(transactionList);
            AddCustomers(customerList);

            xlWorkbook.SaveAs(savePath, XlFileFormat.xlOpenXMLWorkbook, Missing.Value,
                Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange,
                XlSaveConflictResolution.xlUserResolution, true,
                Missing.Value, Missing.Value, Missing.Value);
            xlWorkbook.Close(0);
            xlApp.Quit();
        }

        public string GetDownloadName()
        {
            return randomFileName + ".xlsx";
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

        private void AddTransactions(List<Transaction> transactionList)
        {
            List<Transaction> transactions = transactionList;
            int row = 2;
            foreach (Transaction trans in transactions)
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

        private void AddCustomers(List<CustomerInfo> customerList)
        {
            List<CustomerInfo> customers = customerList;
            Transaction trans = new Transaction();
            int row = 2;
            foreach (CustomerInfo customer in customers)
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