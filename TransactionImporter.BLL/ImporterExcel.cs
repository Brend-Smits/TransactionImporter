using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TransactionImporter.BLL.Interfaces;
using TransactionImpoter.Domain;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TransactionImporter.BLL
{
    public class ImporterExcel : IImporterExcel
    {
        private List<Transaction> transactions = new List<Transaction>();
        private List<CustomerInfo> customers = new List<CustomerInfo>();
        private string filePath;
        private Workbook xlWorkbook;
        private Worksheet xlWorksheet;

        public string UploadFile(string path)
        {
            try
            {
                Application xlApp = new Application();
                filePath = ConvertFileIfNeeded(xlApp, path);
                xlWorkbook = xlApp.Workbooks.Open(filePath, 0, true, 5, "", "", true,
                    XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorksheet = xlWorkbook.Worksheets.Item[1] as Worksheet;
                return filePath;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + exception.Message);
            }

            return path;
        }

        public string ChangeFileExtension(Application xlApp, string path, string extReplaceMe, string extReplaceWith)
        {
            xlWorkbook = xlApp.Workbooks.Open(path);
            string tempFilePath = Regex.Replace(path, extReplaceMe, extReplaceWith, RegexOptions.IgnoreCase);
            xlWorkbook.SaveAs(tempFilePath, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            xlWorkbook.Close(0);
            return tempFilePath;
        }

        public string ConvertFileIfNeeded(Application xlApp, string path)
        {
            if (File.Exists(path))
            {
                if (Path.GetExtension(path) == ".CSV" || Path.GetExtension(path) == ".csv")
                {
                    string tempFilePath = ChangeFileExtension(xlApp, path, ".CSV", ".xlsx");
                    Console.WriteLine("Extension was" + path + " and is now: " + tempFilePath);
                    xlApp.Quit();
                    return tempFilePath;
                }
            }
            else
            {
                throw new FileNotFoundException("File in specified path can not be found, try a different path.");
            }

            Console.WriteLine("Conversion was not possible, file is not CSV extension or is already XLSX");
            return path;
        }

        public void RetrieveData()
        {
            if (filePath != null)
            {
                ReadExcelAndFillList();
            }
            else
            {
                MessageBox.Show("Please select a file!");
            }
        }

        private void ReadExcelAndFillList()
        {
            Range usedRange = xlWorksheet.UsedRange;
            for (int row = 2; row <= usedRange.Rows.Count; row++)
            {
                customers.Add(CreateCustomerInfoObject(usedRange, row));
                transactions.Add(CreateTransactionObject(usedRange, row));
            }
        }

        private Transaction CreateTransactionObject(Range usedRange, int row)
        {
            Dictionary<string, string> transactionValues = new Dictionary<string, string>
            {
                {"Transaction ID", null},
                {"Gateway", null},
                {"Status", null},
                {"Price", null},
                {"Country", null},
                {"Ip", null},
                {"Username", null},
                {"Uuid", null}
            };

            for (int column = 1; column < usedRange.Columns.Count; column++)
            {
                if (transactionValues.ContainsKey(GetHeaderName(column)))
                {
                    transactionValues[GetHeaderName(column)] = GetCellValue(row, column);
                }
            }

            return new Transaction(transactionValues["Transaction ID"], transactionValues["Gateway"],
                Convert.ToDouble(transactionValues["Price"]), transactionValues["Status"], transactionValues["Country"],
                transactionValues["Ip"], transactionValues["Username"], transactionValues["Uuid"]);
        }

        private CustomerInfo CreateCustomerInfoObject(Range usedRange, int row)
        {
            Dictionary<string, string> customerValues = new Dictionary<string, string>
            {
                {"Uuid", null},
                {"Email", null},
                {"Name", null},
                {"Address", null}
            };

            for (int column = 1; column < usedRange.Columns.Count; column++)
            {
                if (customerValues.ContainsKey(GetHeaderName(column)))
                {
                    customerValues[GetHeaderName(column)] = GetCellValue(row, column);
                }
            }

            return new CustomerInfo(customerValues["Uuid"], customerValues["Email"],
                customerValues["Name"], customerValues["Address"]);
        }

        private string GetCellValue(int row, int column)
        {
            Range usedRange = xlWorksheet.UsedRange;
            if (usedRange.Cells[row, column].Value2 == null)
            {
                return "";
            }

            return usedRange.Cells[row, column].Value2.ToString();
        }

        private string GetHeaderName(int column)
        {
            Range result = xlWorksheet.Cells[1, column] as Range;
            return result.Value2.ToString();
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        public List<CustomerInfo> GetCustomerInfo()
        {
            return customers;
        }

        public string GetPath()
        {
            return filePath;
        }

        public void ExitExcelProcesses()
        {
            Process[] excelProcesses = Process.GetProcessesByName("Excel");
            foreach (var process in excelProcesses)
            {
                process.Close();
            }
        }
    }
}