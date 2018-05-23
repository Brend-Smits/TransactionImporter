using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ICustomerInfoRepository
    {
        void AddCustomer(CustomerInfo customer);
        void AddCustomerList(List<CustomerInfo> customers);
    }
}
