using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class FilterStatusFilter
    {
        public static IStatusfilter CreateStatusFilter()
        {
            return new StatusFilter(new FilterStatusRepository(new FilterStatusSqlContext()));
        }

    }
}
