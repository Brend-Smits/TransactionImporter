namespace TransactionImpoter.Domain
{
    public class CountryContinent
    {
        public CountryContinent(string country, string continent)
        {
            Country = country;
            Continent = continent;
        }

        public string Country { get; private set; }
        public string Continent { get; private set; }

    }
}