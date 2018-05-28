using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class ExporterSqlContext:IExporterContext
    {
        private int uploadId = 14;
        public List<Transaction> GetTransaction()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                        SqlCommand selectTransactions = new SqlCommand(
                            "SELECT * FROM [Transaction] WHERE (UploadId) LIKE (@UploadId)",
                            connection);
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
                                (dataRow["CustomerInfoUUID"].ToString() != "") ? dataRow["CustomerInfoUUID"].ToString() : "-");
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

        public List<CustomerInfo> GetCustomers()
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            List<string> customerUUIDs = new List<string>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand selectUuid = new SqlCommand("SELECT (CustomerInfoUUID) FROM [Transaction] WHERE (UploadId) LIKE @UploadId", connection);
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
    }
}
