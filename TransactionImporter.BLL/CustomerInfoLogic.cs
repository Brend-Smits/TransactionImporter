using System.Collections.Generic;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class CustomerInfoLogic:ICustomerInfoLogic
    {
        private ICustomerInfoRepository _Repo;
        public CustomerInfoLogic(ICustomerInfoRepository _customerInfoRepo)
        {
            _Repo = _customerInfoRepo;
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
