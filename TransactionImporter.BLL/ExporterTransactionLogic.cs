using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TransactionImporter.BLL.Interfaces;
using TransactionImpoter.Domain;
using Microsoft.Office.Interop.Excel;
using TransactionImporter.DAL;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace TransactionImporter.BLL
{
    public class ExportTransactionLogic : IExportTransaction
    {
        private Application xlApp = new Application();
        private Workbook xlWorkbook;
        private Worksheet xlWorksheet;
        private IExportTransactionRepository _Repo;
        public ExportTransactionLogic(IExportTransactionRepository _exportRepo)
        {
            _Repo = _exportRepo;
        }
        public void DownloadTransactions()
        {
//            xlWorksheet = xlWorkbook.Worksheets.get_Item(1);
            _Repo.GetTransaction();
        }

        public void GetTransactions()
        {

        }
    }
}