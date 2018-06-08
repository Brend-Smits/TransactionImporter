using TransactionImporter.BLL;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TransactionImporter.BLL.IntergrationTests
{
    [TestClass]
    public class ImporterExcelTests
    {
        [TestMethod]
        public void ConvertFileIfNeeded_ConversionNotNeeded_ReturnsSameFile()
        {
            // Arrange
            ImporterExcel importerExcel = new ImporterExcel();
            string randomFileName = Guid.NewGuid().ToString().Replace("-", "");
            string pathnew =
                @"C:\Users\Rubbertjuh\SynologyDrive\School\Semester-2\Individueel\VisualStudio\TransactionImporter\Files-Integration-Tests\" +
                randomFileName + ".xlsx";
            using (FileStream fs = File.Create(pathnew))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }

            // Act
            string returnpath = importerExcel.ConvertFileIfNeeded(pathnew);
            Console.WriteLine("Return path: " + returnpath);

            // Assert
            Assert.AreEqual(returnpath, pathnew);
            File.Delete(pathnew);
        }

        [TestMethod]
        public void ConvertFileIfNeeded_ConversionNeeded_ReturnsSameFile()
        {

            // Arrange
            ImporterExcel importerExcel = new ImporterExcel();
            string randomFileName = Guid.NewGuid().ToString().Replace("-", "");
            string pathnew =
                @"C:\Users\Rubbertjuh\SynologyDrive\School\Semester-2\Individueel\VisualStudio\TransactionImporter\Files-Integration-Tests\" +
                randomFileName + ".csv";
            using (FileStream fs = File.Create(pathnew))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }

            // Act
            string returnpath = importerExcel.ConvertFileIfNeeded(pathnew);

            // Assert
            Assert.AreNotEqual(returnpath, pathnew);
            File.Delete(pathnew);
        }
    }
}