using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface ICountryContinentLogic
    {
        List<CountryContinent> GetAllCountries();
        CountryContinent GetCountryById(int id);
        void AddCountry(CountryContinent countryContinent);
        void UpdateCountryById(int id, CountryContinent countryContinent);
        void RemoveCountryContinentById(int id);

    }
}