using System;
using System.Collections;

namespace TransactionImporter.WebUI.Models
{
    public class CountryContinentModels
    {
        public CountryContinentModels(string country, string continent)
        {
            Country = country;
            Continent = continent;
        }

        public string Country { get; private set; }
        public string Continent { get; private set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}