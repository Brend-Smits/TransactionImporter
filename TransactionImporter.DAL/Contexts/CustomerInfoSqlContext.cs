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
        public CustomerInfo AddCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
