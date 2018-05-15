using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        private string transactionId;
        private string gateway;
        private string OldFilePath;
        Application xlApp = new Application();
        Workbook xlWorkbook;
        Worksheet xlWorksheet;
        private Workbooks wbs;
        private Workbook wb;
        private int rowCount;
        private int columnCount;


        public void UploadFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            Stream myStream;
            openFileDialog1.Filter = "Excel files (*.csv;*.xlsx)|*.csv;*.xlsx";
            openFileDialog1.InitialDirectory = "c:\\";
            if ((openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK))
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                        }

                        OldFilePath = openFileDialog1.FileName;
                        xlWorkbook =
                            xlApp.Workbooks.Open(ConvertFileIfNeeded(), 0,
                                true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0,
                                true, 1, 0);
                        xlWorksheet = xlWorkbook.Worksheets.Item[1] as Worksheet;
                        Console.WriteLine(OldFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private string ConvertFileIfNeeded()
        {
            string NewFilePath;

            if (File.Exists(OldFilePath))
            {
                if (Path.GetExtension(OldFilePath) == ".CSV" || Path.GetExtension(OldFilePath) == ".csv")
                {
                    Application app = new Application();
                    wbs = app.Workbooks;
                    wb = wbs.Open(OldFilePath, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //Change extension in the OldFilePath from CSV to XLSX and ignore case and save it to NewFilePath
                    NewFilePath = Regex.Replace(OldFilePath, ".CSV", ".xlsx", RegexOptions.IgnoreCase);
                    //Save current workbook as new file with new extension.
                    wb.SaveAs(NewFilePath, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    //Close workbook and application.
                    wb.Close();
                    app.Quit();
                    Console.WriteLine("Extension was" + OldFilePath + " and is now: " + NewFilePath);
                    //Delete the old file.
                    File.Delete(OldFilePath);
                    return NewFilePath;
                }

                Console.WriteLine("Conversion was not needed, file is already correct extension");
                return OldFilePath;
            }

            Console.WriteLine("Could not convert file for whatever reason.");
            return Regex.Replace(OldFilePath, ".CSV", ".xlsx", RegexOptions.IgnoreCase);
        }

        public void RetrieveData()
        {
            if (OldFilePath != null)
            {
                ImportExcelIntoDatabase();
            }
            else
            {
                MessageBox.Show("Please select a file!");
            }
        }

        private void ImportExcelIntoDatabase()
        {
            Range usedRange = xlWorksheet.UsedRange;
            for (int row = 2; row < usedRange.Rows.Count; row++)
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
                {"Country", null },
                {"Ip", null},
                {"Username", null },
                {"Uuid", null }
            };

            for (int column = 1; column < usedRange.Columns.Count; column++)
            {
                if (transactionValues.ContainsKey(GetHeaderName(column)))
                {
                    transactionValues[GetHeaderName(column)] = GetCellValue(row, column);
                }

            }

            return new Transaction(transactionValues["Transaction ID"], transactionValues["Gateway"], Convert.ToDouble(transactionValues["Price"]), transactionValues["Status"], transactionValues["Country"], transactionValues["Ip"], transactionValues["Username"], transactionValues["Uuid"]);
        }
        private CustomerInfo CreateCustomerInfoObject(Range usedRange, int row)
        {
            Dictionary<string, string> customerValues = new Dictionary<string, string>
            {
                {"Uuid", null },
                {"Email", null},
                {"Username", null},
                {"Name", null},
                {"Ip", null},
                {"Address", null}

            };

            for (int column = 1; column < usedRange.Columns.Count; column++)
            {
                if (customerValues.ContainsKey(GetHeaderName(column)))
                {
                    customerValues[GetHeaderName(column)] = GetCellValue(row, column);
                }

            }

            return new CustomerInfo(customerValues["Uuid"], customerValues["Email"], customerValues["Username"], customerValues["Name"], customerValues["Ip"], customerValues["Address"]);
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
    }
}