using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class FilterContinentFactory
    {
        public static IContinentFilter CreateContinentFilter()
        {
            return new ContinentFilter(new FilterContinentRepository(new FilterContinentSqlContext()));
        }

    }
}
