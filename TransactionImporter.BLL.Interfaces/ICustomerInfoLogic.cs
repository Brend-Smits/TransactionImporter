using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface ICustomerInfoLogic
    {
        void AddCustomer(CustomerInfo customer);
        void AddCustomerList(List<CustomerInfo> customers);
    }
}
