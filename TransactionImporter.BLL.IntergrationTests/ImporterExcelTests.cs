using TransactionImporter.BLL;
using System;
using System.IO;
using System.Reflection;
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
            string path = Path.Combine(Environment.CurrentDirectory, @"Files-Integration-Tests\",
                "ConvertFileNotNeeded.xlsx");
            Console.WriteLine("PATH PATH PATH: " + path);
            // Act
            string returnpath = importerExcel.ConvertFileIfNeeded(path);
            Console.WriteLine("Return path: " + returnpath);

            // Assert
            Assert.AreEqual(returnpath, path);
        }
        [TestMethod]
        public void ConvertFileIfNeeded_ConversionNeeded_ReturnsSameFile()
        {
            ImporterExcel importerExcel = new ImporterExcel();
            string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string path = @"C:\Users\Brend\CloudStation\School\Semester-2\Individueel\VisualStudio\TransactionImporter\TransactionImporter.BLL\bin\Debug\Files-Integration-Tests\ConvertFileNeeded.csv";
            Console.WriteLine("PATH: " + path);
            Console.WriteLine("BASEPATH: " + basePath);
            Console.WriteLine("DEBUG: " + Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            Console.WriteLine("DEBUG: " + Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"\\..\\..\\")));
            Console.WriteLine("DEBUG: " + AppDomain.CurrentDomain.BaseDirectory);

            // Act
            string returnpath = importerExcel.ConvertFileIfNeeded(path);
            Console.WriteLine("Return path: " + returnpath);

            // Assert
            Assert.AreNotEqual(returnpath, path);
        }
    }
}
