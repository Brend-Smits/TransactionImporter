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
                                Convert.ToInt32((dataRow["Id"] != DBNull.Value) ? dataRow["Id"] : 0),
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
        public CountryContinent GetCountryById(int id)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand selectCountry = new SqlCommand("SELECT * FROM [CountryContinent] WHERE (Id) = (@Id)", connection);
                    selectCountry.Parameters.AddWithValue("Id", id);
                    using (SqlDataReader reader = selectCountry.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            CountryContinent countryContinent = new CountryContinent(
                                Convert.ToInt32((dataRow["Id"] != DBNull.Value) ? dataRow["Id"] : 0),
                                (dataRow["Countrycode"].ToString() != "") ? dataRow["Countrycode"].ToString() : "-",
                                (dataRow["Continent"].ToString() != "") ? dataRow["Continent"].ToString() : "-");
                            return countryContinent;
                        }
                    }
                }

                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void AddCountry(CountryContinent countryContinent)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand addCountry =
                        new SqlCommand(
                            "INSERT INTO [CountryContinent] (CountryCode, Continent) VALUES (@CountryCode, @Continent)",
                            connection);
                    addCountry.Parameters.AddWithValue("CountryCode", countryContinent.Country);
                    addCountry.Parameters.AddWithValue("Continent", countryContinent.Continent);
                    addCountry.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void UpdateCountryById(int id, CountryContinent countryContinent)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand updateCountry =
                        new SqlCommand(
                            "UPDATE [CountryContinent] SET CountryCode = @CountryCode, Continent = @Continent WHERE Id = @Id",
                            connection);
                    updateCountry.Parameters.AddWithValue("CountryCode", countryContinent.Country);
                    updateCountry.Parameters.AddWithValue("Continent", countryContinent.Continent);
                    updateCountry.Parameters.AddWithValue("Id", id);
                    updateCountry.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void RemoveCountryContinentById(int id)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                        SqlCommand insertCustomerInfo = new SqlCommand("dbo.RemoveCountryContinentById", connection);
                        insertCustomerInfo.CommandType = CommandType.StoredProcedure;
                        insertCustomerInfo.Parameters.AddWithValue("Id", id);
                        insertCustomerInfo.ExecuteNonQuery();
                    }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}