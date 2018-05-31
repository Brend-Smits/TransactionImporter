using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public interface ICountryContinentContext
    {
        List<CountryContinent> GetAllCountries();
        CountryContinent GetCountryById(int id);
        void AddCountry(CountryContinent countryContinent);
        void UpdateCountryById(int id, CountryContinent countryContinent);

    }
}