using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class CustomerInfoLogic:ICustomerInfoLogic
    {
        private ICustomerInfoRepository _Repo;
        public CustomerInfoLogic(ICustomerInfoRepository customerInfoRepo)
        {
            _Repo = customerInfoRepo;
        }

        public void AddCustomer(CustomerInfo customer)
        {
            _Repo.AddCustomer(customer);
        }

        public void AddCustomerList(List<CustomerInfo> customers)
        {
            _Repo.AddCustomerList(customers);
        }
    }
}
