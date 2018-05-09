using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class CustomerDetailsRepository:ICustomerDetailsRepository
    {

        private readonly ICustomerDetailsContext _customerDetailsContext;

        public CustomerDetailsRepository(ICustomerDetailsContext customerDetailsSqlContext)
        {
            _customerDetailsContext = customerDetailsSqlContext;
        }

        public void AddCustomerDetail(CustomerDetails customerDetail)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerDetailsList(List<CustomerDetails> customerDetails)
        {
            _customerDetailsContext.AddCustomerDetailsList(customerDetails);
        }
    }
}
