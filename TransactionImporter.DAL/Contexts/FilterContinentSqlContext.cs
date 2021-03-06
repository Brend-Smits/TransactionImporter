﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class FilterContinentSqlContext : UtilityFilterSqlContext, IFilterContinentContext
    {

        public List<Transaction> GetTransactionsAllContinents(int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    string query =
                        "SELECT TransactionUpload.TransactionId, TransactionUpload.UploadId, [Transaction].Amount, [Transaction].Country, [Transaction].CustomerInfoUUID, [Transaction].Date, [Transaction].Discount, [Transaction].Gateway, [Transaction].IP, [Transaction].Status, [Transaction].Username FROM [TransactionUpload] INNER JOIN [Transaction] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = @UploadId";

                    connection.Open();
                    SqlCommand selectTransactions = new SqlCommand(query, connection);
                    selectTransactions.Parameters.AddWithValue("UploadId", id);
                    return ReadDataAddToListTransaction(transactions, selectTransactions.ExecuteReader());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<CustomerInfo> GetCustomersAllContinents(int id)
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            List<string> customerUUIDs = new List<string>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    string query =
                        "SELECT [Transaction].CustomerInfoUUID, [TransactionUpload].TransactionId, [TransactionUpload].UploadId FROM [Transaction] INNER JOIN [TransactionUpload] ON [Transaction].TransactionId = TransactionUpload.TransactionId WHERE UploadId = @UploadId";

                    connection.Open();
                    SqlCommand selectUuid = new SqlCommand(query, connection);
                    selectUuid.Parameters.AddWithValue("UploadId", id);
                    return ReadDataAddToListCustomer(customerList, customerUUIDs, selectUuid.ExecuteReader(), connection);
                }
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
                    return ReadDataAddToListTransaction(transactions, selectTransactions.ExecuteReader());
                }
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
                    return ReadDataAddToListCustomer(customerList, customerUUIDs, selectUuid.ExecuteReader(), connection);
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