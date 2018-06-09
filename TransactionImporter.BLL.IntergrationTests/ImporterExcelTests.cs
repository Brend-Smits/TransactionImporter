﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Tests
{
    [TestClass]
    public class ImporterExcelTests
    {
        ImporterExcel importerExcel = new ImporterExcel();

        [TestMethod]
        public void ConvertFileIfNeeded_ConversionNotNeeded_ReturnsSameFile()
        {
            // Arrange
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

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ConvertFileIfNeeded_WrongPath_ReturnsException()
        {
            // Arrange
            string pathnew =
                @"C:\Users\Rubbertjuhiles-Integration-Tests\" + ".csv";
            // Act
            importerExcel.ConvertFileIfNeeded(pathnew);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ConvertFileIfNeeded_WrongPathCheckMessage_ReturnsExceptionWithMessage()
        {
            // Assert
            string pathnew =
                @"C:\Users\Rubbertjuhiles-Integration-Tests\" + ".csv";
            try
            {
                // Act
                importerExcel.ConvertFileIfNeeded(pathnew);
            }
            catch (Exception e)
            {
                Assert.AreEqual("File in specified path can not be found, try a different path.", e.Message);
                throw;
            }

            // Arrange
        }

        [TestMethod]
        public void RetrieveData_CreateObjects_RetrunsBiggerCountInLists()
        {
            List<Transaction> transListPre = importerExcel.GetTransactions();
            List<CustomerInfo> customerListPre = importerExcel.GetCustomerInfo();
            if (transListPre.Count != 0 || customerListPre.Count != 0)
            {
                Assert.Fail("Customer or Transaction list is not 0 initially, but should be.");
            }

            string path =
                @"C:\Users\Rubbertjuh\SynologyDrive\School\Semester-2\Individueel\VisualStudio\TransactionImporter\Files-Integration-Tests\integration.xlsx";
            importerExcel.UploadFile(path);
            importerExcel.RetrieveData();
            List<Transaction> transList = importerExcel.GetTransactions();
            List<CustomerInfo> customerList = importerExcel.GetCustomerInfo();
            bool hasTransCustomerListCountIncreased = false;
            if (transList.Count > 0 && customerList.Count > 0)
            {
                hasTransCustomerListCountIncreased = true;
                ;
            }

            Assert.IsTrue(hasTransCustomerListCountIncreased);
        }
    }
}