using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.ContextInterfaces
{
    public interface ICustomerInfoContext
    {
        void AddCustomer(CustomerInfo customer);
        void AddCustomerList(List<CustomerInfo> customers);
    }
}
