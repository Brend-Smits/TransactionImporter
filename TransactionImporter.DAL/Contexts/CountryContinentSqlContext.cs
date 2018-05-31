using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Contexts
{
    public class CountryContinentSqlContext : ICountryContinentContext
    {
        public List<CountryContinent> GetAllCountries()
        {
            List<CountryContinent> countryContinents = new List<CountryContinent>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand selectCountries = new SqlCommand("SELECT * FROM [CountryContinent]", connection);
                    using (SqlDataReader reader = selectCountries.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            CountryContinent countryContinent = new CountryContinent(
                                (dataRow["Countrycode"].ToString() != "") ? dataRow["Countrycode"].ToString() : "-",
                                (dataRow["Continent"].ToString() != "") ? dataRow["Continent"].ToString() : "-");
                            countryContinents.Add(countryContinent);
                        }
                    }
                }

                return countryContinents;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}