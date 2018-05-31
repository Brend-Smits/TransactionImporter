using System.Collections.Generic;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class CountryContinentLogic : ICountryContinentLogic
    {
        private ICountryContinentRepository _Repo;

        public CountryContinentLogic(ICountryContinentRepository countryContinentRepository)
        {
            _Repo = countryContinentRepository;
        }
        public List<CountryContinent> GetAllCountries()
        {
            return _Repo.GetAllCountries();
        }

        public CountryContinent GetCountryById(int id)
        {
            return _Repo.GetCountryById(id);
        }

        public void AddCountry(CountryContinent countryContinent)
        {
            _Repo.AddCountry(countryContinent);
        }

        public void UpdateCountryById(int id, CountryContinent countryContinent)
        {
            _Repo.UpdateCountryById(id, countryContinent);
        }
    }
}