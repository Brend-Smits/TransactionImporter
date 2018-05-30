using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ICountryContinentContext
    {
        List<CountryContinent> GetAllCountries();
    }
}