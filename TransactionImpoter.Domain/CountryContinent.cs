namespace TransactionImpoter.Domain
{
    public class CountryContinent
    {
        public CountryContinent(string country, string continent)
        {
            Country = country;
            Continent = continent;
        }
        public CountryContinent(int id, string country, string continent)
        {
            Id = id;
            Country = country;
            Continent = continent;
        }
        public CountryContinent() { }
        public int Id { get; private set; }
        public string Country { get; private set; }
        public string Continent { get; private set; }

    }
}