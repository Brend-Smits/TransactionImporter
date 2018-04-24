using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.BLL;
using TransactionImporter.DAL;

namespace TransactionImporter.Factory
{
    public class TransactionFactory
    {
        public static ITransactionLogic CreateLogic()
        {
            return new TransactionLogic(new TransactionRepository(new TransactionSqlContext()));
        }


    }
}
