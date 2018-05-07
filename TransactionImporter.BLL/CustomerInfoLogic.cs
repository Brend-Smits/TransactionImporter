using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public CustomerInfo AddCustomer()  
        {
            throw new NotImplementedException();
        }
    }
}
