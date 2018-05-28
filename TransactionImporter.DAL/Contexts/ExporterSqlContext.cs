using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class ExporterSqlContext:IExporterContext
    {
        private int uploadId = 12;
        public List<Transaction> GetTransaction()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                        SqlCommand SelectTransactions = new SqlCommand(
                            "SELECT * FROM [Transaction] WHERE (UploadId) LIKE (@UploadId)",
                            connection);
                    SelectTransactions.Parameters.AddWithValue("UploadId", uploadId);
                    using (SqlDataReader reader = SelectTransactions.ExecuteReader())
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
                    SqlCommand SelectUuid = new SqlCommand("SELECT (CustomerInfoUUID) FROM [Transaction] WHERE (UploadId) LIKE @UploadId", connection);
                    SelectUuid.Parameters.AddWithValue("UploadId", uploadId);
                    using (SqlDataReader uuidReader = SelectUuid.ExecuteReader())
                    {
                        while (uuidReader.Read())
                        {
                            customerUUIDs.Add(uuidReader.GetString(0));
                        }
                        uuidReader.Close();
                    }

                    foreach (string UUID in customerUUIDs)
                    {
                        SqlCommand SelectCustomers = new SqlCommand(
                            "SELECT * FROM [CustomerInfo] WHERE (Uuid) LIKE (@Uuid)",
                            connection);
                        SelectCustomers.Parameters.AddWithValue("Uuid", UUID);
                        using (SqlDataReader customerReader = SelectCustomers.ExecuteReader())
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

        private Transaction CreateTransactionObject(SqlDataReader reader, int i)
        {
            Dictionary<string, string> transactionValues = new Dictionary<string, string>
            {
                {"TransactionId", null},
                {"Gateway", null},
                {"Status", null},
                {"Price", null},
                {"Country", null},
                {"Ip", null},
                {"Username", null},
                {"Uuid", null}
            };

            for (int j = i; j < reader.FieldCount; j++)
            {
                if (transactionValues.ContainsKey(reader.GetName(i)))
                {
                    transactionValues[reader.GetName(i)] = reader.GetString(i);
                    
                }
            }

            return new Transaction(transactionValues["Transaction ID"], transactionValues["Gateway"],
                Convert.ToDouble(transactionValues["Price"]), transactionValues["Status"], transactionValues["Country"],
                transactionValues["Ip"], transactionValues["Username"], transactionValues["Uuid"]);
        }
    }
}
