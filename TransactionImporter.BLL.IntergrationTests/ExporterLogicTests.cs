using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Tests
{
    [TestClass]
    public class ExporterLogicTests
    {
        [TestMethod()]
        public void DownloadTransactionsTest_ProvidedLists_ReturnsCorrectCountInFile()
        {
            // Arrange
            ExporterLogic exporterLogic = new ExporterLogic();
            List<CustomerInfo> customerInfos = new List<CustomerInfo>()
            {
                new CustomerInfo("adwr14212esad", "test@gmail.com", "Rubbertjuh", "nba"),
                new CustomerInfo("951rjsaj", "test2@gmail.com", "Rubbertjuh2", "nba2"),
                new CustomerInfo("haqddwr1421sad", "test3@gmail.com", "Rubbertjuh3", "nba3"),
                new CustomerInfo("fai8efds", "test4@gmail.com", "Rubbertjuh4", "nba4"),
            };
            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction("1", "paypal", 0.00, "Complete", "NA", "90.21.23.1", "AwesomeSauce", "adwr14212esad"),
                new Transaction("2", "paypal2", 0.02, "Complete2", "NA", "90.21.23.2", "AwesomeSauce2", "951rjsaj"),
                new Transaction("3", "paypal3", 0.03, "Complete3", "NA", "90.21.23.3", "AwesomeSauce3",
                    "haqddwr1421sad"),
                new Transaction("4", "paypal4", 0.04, "Complete4", "NA", "90.21.23.4", "AwesomeSauce4", "fai8efds"),
            };
            int originalCustomerCount = customerInfos.Count;
            string path =
                @"C:\Users\Rubbertjuh\SynologyDrive\School\Semester-2\Individueel\VisualStudio\TransactionImporter\Files-Integration-Tests\";
            Application xlApp = new Application();
            Workbook xlWorkbook;
            Worksheet xlWorksheet;

            //Act
            exporterLogic.DownloadTransactions(customerInfos, transactions, path);
            string fileName = exporterLogic.GetDownloadName();
            xlWorkbook = xlApp.Workbooks.Open(Path.Combine(path + fileName), 0, true, 5, "", "", true,
                XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorksheet = xlWorkbook.Worksheets.Item[1] as Worksheet;

            //Assert
            Assert.AreEqual(xlWorksheet.UsedRange.Rows.Count - 1, originalCustomerCount);

            //Cleanup
            xlWorkbook.Close(0);
            xlApp.Quit();
        }
    }
}