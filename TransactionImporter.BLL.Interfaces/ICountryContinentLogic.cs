using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface ICountryContinentLogic
    {
        List<CountryContinent> GetAllCountries();
    }
}