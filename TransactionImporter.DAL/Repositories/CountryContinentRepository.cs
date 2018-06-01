using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    public class CountryContinentRepository : ICountryContinentRepository
    {

        private readonly ICountryContinentContext countryContinentContext;

        public CountryContinentRepository(ICountryContinentContext countryContinentContext)
        {
            this.countryContinentContext = countryContinentContext;
        }
        public List<CountryContinent> GetAllCountries()
        {
            return countryContinentContext.GetAllCountries();
        }

        public CountryContinent GetCountryById(int id)
        {
            return countryContinentContext.GetCountryById(id);
        }

        public void AddCountry(CountryContinent countryContinent)
        {
            countryContinentContext.AddCountry(countryContinent);
        }

        public void UpdateCountryById(int id, CountryContinent countryContinent)
        {
            countryContinentContext.UpdateCountryById(id, countryContinent);
        }

        public void RemoveCountryContinentById(int id)
        {
            countryContinentContext.RemoveCountryContinentById(id);
        }
    }
}