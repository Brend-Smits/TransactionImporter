using System.Windows;
using System.Windows.Controls;
using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.Factory;

namespace TransactionImporter.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ITransactionLogic transactionLogic = TransactionFactory.CreateLogic();
        private IImporterExcel importerLogic = ImporterExcelFactory.CreateLogic();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            importerLogic.UploadFile();
        }

        private void btnRetrieveData_Click(object sender, RoutedEventArgs e)
        {
            importerLogic.RetrieveData();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            foreach (var trans in importerLogic.GetTransactions())
            {
                index++;
                ListBoxItem item = new ListBoxItem();
                item.Content = index + ". " + trans.TransactionId;
                lbTransactions.Items.Add(item);
            }
        }
    }
    }
