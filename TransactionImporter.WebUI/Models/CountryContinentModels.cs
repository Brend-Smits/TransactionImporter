using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TransactionImporter.WebUI.Models
{
    public class CountryContinentModels
    {
        public CountryContinentModels(string country, string continent)
        {
            Country = country;
            Continent = continent;
        }
        public CountryContinentModels(int id, string country, string continent)
        {
            Id = id;
            Country = country;
            Continent = continent;
        }
        public CountryContinentModels() { }
        public int Id { get;  set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Continent")]
        public string Continent { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}