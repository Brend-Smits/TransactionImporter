using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ICountryContinentRepository
    {
        List<CountryContinent> GetAllCountries();
    }
}