using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UtilityFilterSqlContext
    {

        public List<Transaction> ReadDataAddToListTransaction(List<Transaction> transactions, SqlDataReader reader)
        {
            using (reader)
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Transaction trans = new Transaction(
                        (dataRow["TransactionId"].ToString() != "") ? dataRow["TransactionId"].ToString() : "-",
                        (dataRow["Gateway"].ToString() != "") ? dataRow["Gateway"].ToString() : "-",
                        Convert.ToDouble((dataRow["Price"] != DBNull.Value) ? dataRow["Price"] : 0),
                        (dataRow["Status"].ToString() != "") ? dataRow["Status"].ToString() : "-",
                        (dataRow["Country"].ToString() != "") ? dataRow["Country"].ToString() : "-",
                        (dataRow["Ip"].ToString() != "") ? dataRow["Ip"].ToString() : "-",
                        (dataRow["Username"].ToString() != "") ? dataRow["Username"].ToString() : "-",
                        (dataRow["CustomerInfoUUID"].ToString() != "")
                            ? dataRow["CustomerInfoUUID"].ToString()
                            : "-");
                    transactions.Add(trans);
                }

                return transactions;
            }
        }
        public List<CustomerInfo> ReadDataAddToListCustomer(List<CustomerInfo> customers, List<string> customerUUIDs, SqlDataReader reader, SqlConnection connection)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    customerUUIDs.Add(reader.GetString(0));
                }

                reader.Close();
            }

            foreach (string uuid in customerUUIDs)
            {
                GetUuidAddToCustomerList(connection, uuid, customers);
            }

            return customers;
        }

        public void GetUuidAddToCustomerList(SqlConnection connection, string uuid, List<CustomerInfo> customers)
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
                    customers.Add(customer);
                }
            }
        }
    }
    }