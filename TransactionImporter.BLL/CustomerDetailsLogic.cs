using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class CustomerDetailsLogic:ICustomerDetailsLogic
    {
        private ICustomerDetailsRepository _Repo;
        public CustomerDetailsLogic(ICustomerDetailsRepository _customerDetailsrepo)
        {
            _Repo = _customerDetailsrepo;
        }

        public void AddCustomerDetail(CustomerDetails customerDetail)
        {
            _Repo.AddCustomerDetail(customerDetail);
        }

        public void AddCustomerDetailsList(List<CustomerDetails> customerDetails)
        {
            _Repo.AddCustomerDetailsList(customerDetails);
        }
    }
}
