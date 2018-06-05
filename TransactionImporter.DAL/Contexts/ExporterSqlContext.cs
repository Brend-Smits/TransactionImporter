using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class ExporterSqlContext : IExporterContext
    {
        private int uploadId = 22;
        public List<Transaction> GetTransaction(bool filerEu)
        {
            string query;
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    if (filerEu)
                    {
                        //TODO: Make stored procedure
                        query =
                            "SELECT TransactionUpload.TransactionId, TransactionUpload.UploadId, [Transaction].Amount, [Transaction].Country, [Transaction].CustomerInfoUUID, [Transaction].Date, [Transaction].Discount, [Transaction].Gateway, [Transaction].IP, [Transaction].Status, [Transaction].Username FROM [TransactionUpload] INNER JOIN [Transaction] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = 8 AND [Country] IN(SELECT[CountryCode] FROM[CountryContinent] WHERE[Continent] = 'EU')";
                    }
                    else
                    {
                        //TODO: Make stored procedure
                        query =
                            "SELECT TransactionUpload.TransactionId, TransactionUpload.UploadId, [Transaction].Amount, [Transaction].Country, [Transaction].CustomerInfoUUID, [Transaction].Date, [Transaction].Discount, [Transaction].Gateway, [Transaction].IP, [Transaction].Status, [Transaction].Username FROM [TransactionUpload] INNER JOIN [Transaction] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = 8";
                    }

                    connection.Open();
                    SqlCommand selectTransactions = new SqlCommand(query, connection);
                    selectTransactions.Parameters.AddWithValue("UploadId", uploadId);
                    using (SqlDataReader reader = selectTransactions.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Transaction trans = new Transaction(
                                (dataRow["TransactionId"].ToString() != "") ? dataRow["TransactionId"].ToString() : "-",
                                (dataRow["Gateway"].ToString() != "") ? dataRow["Gateway"].ToString() : "-",
                                Convert.ToDouble((dataRow["Amount"] != DBNull.Value) ? dataRow["Amount"] : 0),
                                (dataRow["Status"].ToString() != "") ? dataRow["Status"].ToString() : "-",
                                (dataRow["Country"].ToString() != "") ? dataRow["Country"].ToString() : "-",
                                (dataRow["Ip"].ToString() != "") ? dataRow["Ip"].ToString() : "-",
                                (dataRow["Username"].ToString() != "") ? dataRow["Username"].ToString() : "-",
                                (dataRow["CustomerInfoUUID"].ToString() != "")
                                    ? dataRow["CustomerInfoUUID"].ToString()
                                    : "-");
                            transactions.Add(trans);
                        }
                    }
                }

                return transactions;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<CustomerInfo> GetCustomers(bool filterEu)
        {
            string query;
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            List<string> customerUUIDs = new List<string>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    if (filterEu)
                    {
                        query =
                            "SELECT [Transaction].CustomerInfoUUID, [TransactionUpload].TransactionId, [TransactionUpload].UploadId FROM [Transaction] INNER JOIN [TransactionUpload] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = 8 AND [Country] IN(SELECT[CountryCode] FROM[CountryContinent] WHERE[Continent] = 'EU')";
                    }
                    else
                    {
                        query =
                            "SELECT [Transaction].CustomerInfoUUID, [TransactionUpload].TransactionId, [TransactionUpload].UploadId FROM [Transaction] INNER JOIN [TransactionUpload] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = 8";
                    }

                    connection.Open();
                    SqlCommand selectUuid = new SqlCommand(query, connection);
                    selectUuid.Parameters.AddWithValue("UploadId", uploadId);
                    using (SqlDataReader uuidReader = selectUuid.ExecuteReader())
                    {
                        while (uuidReader.Read())
                        {
                            customerUUIDs.Add(uuidReader.GetString(0));
                        }

                        uuidReader.Close();
                    }

                    foreach (string uuid in customerUUIDs)
                    {
                        SqlCommand selectCustomers = new SqlCommand(
                            "SELECT * FROM [CustomerInfo] WHERE (Uuid) LIKE (@Uuid)",
                            connection);
                        selectCustomers.Parameters.AddWithValue("Uuid", uuid);
                        using (SqlDataReader customerReader = selectCustomers.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(customerReader);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                CustomerInfo customer = new CustomerInfo(
                                    (dataRow["Uuid"].ToString() != "") ? dataRow["Uuid"].ToString() : "-",
                                    (dataRow["Email"].ToString() != "") ? dataRow["Email"].ToString() : "-",
                                    (dataRow["FirstName"].ToString() != "") ? dataRow["FirstName"].ToString() : "-",
                                    (dataRow["Address"].ToString() != "") ? dataRow["Address"].ToString() : "-");
                                customerList.Add(customer);
                            }
                        }
                    }
                }

                return customerList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<Transaction> GetTransactionFilterContinent(string continent, int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    //TODO: Make stored procedure
                    string query =
                        "SELECT TransactionUpload.TransactionId, " +
                        "TransactionUpload.UploadId, " +
                        "[Transaction].Amount, " +
                        "[Transaction].Country, " +
                        "[Transaction].CustomerInfoUUID, " +
                        "[Transaction].Date, " +
                        "[Transaction].Discount, " +
                        "[Transaction].Gateway, " +
                        "[Transaction].IP, " +
                        "[Transaction].Status, " +
                        "[Transaction].Username " +
                        "FROM [TransactionUpload] " +
                        "INNER JOIN [Transaction] " +
                        "ON [Transaction].TransactionId = TransactionUpload.TransactionId " +
                        "WHERE UploadId = @UploadId " +
                        "AND [Country] IN (SELECT[CountryCode] FROM [CountryContinent] WHERE [Continent] = @Continent)";

                    connection.Open();
                    SqlCommand selectTransactions = new SqlCommand(query, connection);
                    selectTransactions.Parameters.AddWithValue("UploadId", id);
                    selectTransactions.Parameters.AddWithValue("Continent", continent);
                    using (SqlDataReader reader = selectTransactions.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Transaction trans = new Transaction(
                                (dataRow["TransactionId"].ToString() != "") ? dataRow["TransactionId"].ToString() : "-",
                                (dataRow["Gateway"].ToString() != "") ? dataRow["Gateway"].ToString() : "-",
                                Convert.ToDouble((dataRow["Amount"] != DBNull.Value) ? dataRow["Amount"] : 0),
                                (dataRow["Status"].ToString() != "") ? dataRow["Status"].ToString() : "-",
                                (dataRow["Country"].ToString() != "") ? dataRow["Country"].ToString() : "-",
                                (dataRow["Ip"].ToString() != "") ? dataRow["Ip"].ToString() : "-",
                                (dataRow["Username"].ToString() != "") ? dataRow["Username"].ToString() : "-",
                                (dataRow["CustomerInfoUUID"].ToString() != "")
                                    ? dataRow["CustomerInfoUUID"].ToString()
                                    : "-");
                            transactions.Add(trans);
                        }
                    }
                }

                return transactions;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<CustomerInfo> GetCustomersFilterContinent(string continent, int id)
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            List<string> customerUUIDs = new List<string>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                        string query =
                            "SELECT [Transaction].CustomerInfoUUID, " +
                            "[TransactionUpload].TransactionId, " +
                            "[TransactionUpload].UploadId " +
                            "FROM [Transaction] " +
                            "INNER JOIN [TransactionUpload] " +
                            "ON [Transaction].TransactionId = TransactionUpload.TransactionId " +
                            "WHERE UploadId = @UploadId " +
                            "AND [Country] IN(SELECT[CountryCode] FROM [CountryContinent] WHERE [Continent] = @Continent)";

                    connection.Open();
                    SqlCommand selectUuid = new SqlCommand(query, connection);
                    selectUuid.Parameters.AddWithValue("UploadId", id);
                    selectUuid.Parameters.AddWithValue("Continent", continent);
                    using (SqlDataReader uuidReader = selectUuid.ExecuteReader())
                    {
                        while (uuidReader.Read())
                        {
                            customerUUIDs.Add(uuidReader.GetString(0));
                        }

                        uuidReader.Close();
                    }

                    foreach (string uuid in customerUUIDs)
                    {
                        SqlCommand selectCustomers = new SqlCommand(
                            "SELECT * FROM [CustomerInfo] WHERE (Uuid) LIKE (@Uuid)",
                            connection);
                        selectCustomers.Parameters.AddWithValue("Uuid", uuid);
                        using (SqlDataReader customerReader = selectCustomers.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(customerReader);
                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                CustomerInfo customer = new CustomerInfo(
                                    (dataRow["Uuid"].ToString() != "") ? dataRow["Uuid"].ToString() : "-",
                                    (dataRow["Email"].ToString() != "") ? dataRow["Email"].ToString() : "-",
                                    (dataRow["FirstName"].ToString() != "") ? dataRow["FirstName"].ToString() : "-",
                                    (dataRow["Address"].ToString() != "") ? dataRow["Address"].ToString() : "-");
                                customerList.Add(customer);
                            }
                        }
                    }
                }

                return customerList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}