using TransactionImporter.BLL;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Contexts;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class CountryContinent
    {
        public static ICountryContinentLogic CreateLogic()
        {
            return new CountryContinentLogic(new CountryContinentRepository(new CountryContinentSqlContext()));
        }

    }
}
