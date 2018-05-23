using System.Windows;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUploadFile_Click(object sender, RoutedEventArgs e)
        {
            importerLogic.UploadFile();
            string path = importerLogic.GetPath();
            uploadDetailLogic.UploadDetails(uploadDetailLogic.GetUploadDetails(path), path);
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
            User user = new User("Rubbertjuh", "brend_smits@hotmail.com", "123123", "1998-01-23", "Netherlands");
            userLogic.CreateUser(user);
        }
    }
    }
