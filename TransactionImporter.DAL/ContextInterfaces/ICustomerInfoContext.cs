using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.ContextInterfaces
{
    public interface ICustomerInfoContext
    {
        void AddCustomer(CustomerInfo customer);
        void AddCustomerList(List<CustomerInfo> customers);
    }
}
