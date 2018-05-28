using System;
using System.Collections.Generic;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class CustomerInfoRepository:ICustomerInfoRepository
    {

        private readonly ICustomerInfoContext customerInfoContext;

        public CustomerInfoRepository(ICustomerInfoContext customerInfoSqlContext)
        {
            customerInfoContext = customerInfoSqlContext;
        }

        public void AddCustomer(CustomerInfo customer)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerList(List<CustomerInfo> customers)
        {
            customerInfoContext.AddCustomerList(customers);
        }
    }
}
