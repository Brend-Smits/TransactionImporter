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
    }
}