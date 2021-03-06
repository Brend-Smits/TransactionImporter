﻿using System.IO;
using System.Windows;
using System.Windows.Forms;
using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;
using TransactionImpoter.Domain;

namespace TransactionImporter.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ITransactionLogic transactionLogic = TransactionFactory.CreateLogic();
        private IImporterExcel importerLogic = ImporterExcelFactory.CreateLogic();
        private ICustomerInfoLogic customerInfoLogic = CustomerInfoFactory.CreateLogic();
        private IUserLogic userLogic = UserFactory.CreateLogic();
        private IUploadDetailLogic uploadDetailLogic = UploadDetailFactory.CreateLogic();
        private IExporterLogic exporterLogic = new ExporterLogic();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = OpenMyFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                fileDialog.OpenFile();
                string newPath = importerLogic.UploadFile(filePath);
                uploadDetailLogic.UploadDetails(uploadDetailLogic.GetUploadDetails(newPath), newPath);
            }
        }

        private void btnRetrieveData_Click(object sender, RoutedEventArgs e)
        {
            importerLogic.RetrieveData();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            customerInfoLogic.AddCustomerList(importerLogic.GetCustomerInfo());
            transactionLogic.AddTransactionList(importerLogic.GetTransactions());
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("Rubbertjuh2", "brend_smits2@hotmail.com", "1231232", "1998-01-23", "Netherlands");
            userLogic.CreateUser(user);
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderDialog.SelectedPath;
            }
        }

        private void btnDownloadEU_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderDialog.SelectedPath;
            }
        }
        public OpenFileDialog OpenMyFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Excel files (*.csv;*.xlsx)|*.csv;*.xlsx",
                InitialDirectory = "c:\\"
            };
            return fileDialog;
        }
    }
    }
