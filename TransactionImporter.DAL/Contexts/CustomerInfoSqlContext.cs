using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Contexts
{
    class CustomerInfoSqlContext:ICustomerInfoContext
    {
        public CustomerInfo AddCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerInfo> AddCustomerList()
        {
            throw new NotImplementedException();
        }
    }
}
