using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.BLL;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Contexts;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class CustomerInfoFactory
    {
        public static ICustomerInfoLogic CreateLogic()
        {
            return new CustomerInfoLogic(new CustomerInfoRepository(new CustomerInfoSqlContext()));
        }


    }
}
