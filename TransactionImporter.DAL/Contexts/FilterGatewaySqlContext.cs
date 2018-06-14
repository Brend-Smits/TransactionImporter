using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class FilterGatewaySqlContext : UtilityFilterSqlContext, IFilterGatewayContext
    {

        public List<CustomerInfo> GetCustomersFilterGateway(string gateway, int id)
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            List<string> customerUUIDs = new List<string>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    string query =
                        "SELECT [Transaction].CustomerInfoUUID, " +
                        "[Transaction].Status, " +
                        "[TransactionUpload].TransactionId, " +
                        "[TransactionUpload].UploadId " +
                        "FROM [Transaction] " +
                        "INNER JOIN [TransactionUpload] " +
                        "ON [Transaction].TransactionId = TransactionUpload.TransactionId " +
                        "WHERE UploadId = @UploadId " +
                        "AND Gateway = @Gateway";

                    connection.Open();
                    SqlCommand selectUuid = new SqlCommand(query, connection);
                    selectUuid.Parameters.AddWithValue("UploadId", id);
                    selectUuid.Parameters.AddWithValue("Gateway", gateway);
                    

                    return ReadDataAddToListCustomer(customerList, customerUUIDs, selectUuid.ExecuteReader(), connection);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<Transaction> GetTransactionsFilterGateway(string gateway, int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    string query =
                        "SELECT TransactionUpload.TransactionId, " +
                        "TransactionUpload.UploadId, " +
                        "[Transaction].Price, " +
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
                        "AND Gateway = @Gateway";

                    connection.Open();
                    SqlCommand selectTransactions = new SqlCommand(query, connection);
                    selectTransactions.Parameters.AddWithValue("UploadId", id);
                    selectTransactions.Parameters.AddWithValue("Gateway", gateway);
                    return ReadDataAddToListTransaction(transactions, selectTransactions.ExecuteReader());
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