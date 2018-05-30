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
            throw new System.NotImplementedException();
        }
    }
}