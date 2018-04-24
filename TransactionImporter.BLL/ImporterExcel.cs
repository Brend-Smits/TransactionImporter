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
        public List<Transaction> transactions = new List<Transaction>();
        private string transactionId;
        private string gateway;
        private string OldFilePath;
        Application xlApp = new Application();
        Workbook xlWorkbook;
        Worksheet xlWorksheet;
        private Workbooks wbs;
        private Workbook wb;




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
                List<string> header = new List<string>
                {
                    "Transaction Id"
                };
                foreach (var item in header)
                {
                    RetrieveColumnByHeader(xlWorksheet, item);
                }
            }
            else
            {
                MessageBox.Show("Please select a file!");
            }
        }

        //Method returns all values which are below the specified columns
        public List<string>[] RetrieveColumnByHeader(Worksheet sheet, string FindWhat)
        {
            if (OldFilePath != null)
            {

                Range rngHeader = sheet.Rows[1] as Range;

                int rowCount = sheet.UsedRange.Rows.Count;
                int columnCount = sheet.UsedRange.Columns.Count;
                int index = 0;

                Range rngResult = null;
                string FirstAddress = null;

                List<string>[] columnValue = new List<string>[columnCount];

                rngResult = rngHeader.Find(What: FindWhat, LookIn: XlFindLookIn.xlValues,
                    LookAt: XlLookAt.xlPart, SearchOrder: XlSearchOrder.xlByColumns);

                if (rngResult != null)
                {
                    FirstAddress = rngResult.Address;
                    Range cRng = null;
                    do
                    {
                        columnValue[index] = new List<string>();
                        for (int i = 1; i <= rowCount; i++)
                        {
                            cRng = sheet.Cells[i, rngResult.Column] as Range;
                            if (cRng.Value != null)
                            {
                                string transactionId = cRng.Value.ToString();
                                Transaction trans = new Transaction(transactionId);
                                //Add the value of the row (i) from Column (rngResult) to the List string array columnValue on Index (index)
                                columnValue[index].Add(cRng.Value.ToString());
                                Console.WriteLine((i + " ") + cRng.Value.ToString());
                                transactions.Add(trans);
                            }
                        }
                        //If there are more collumns which matched the string search, they will also need handling. It will receive a new index and also be saved in the array.
                        index++;
                        rngResult = rngHeader.FindNext(rngResult);
                    } while (rngResult != null && rngResult.Address != FirstAddress);
                }

                Array.Resize(ref columnValue, index);

                return columnValue;
            }
            MessageBox.Show("Please select a file!");
            return null;

        }

        public List<Transaction> GetTransactions()
        {

            return transactions;
        }

    }
}
