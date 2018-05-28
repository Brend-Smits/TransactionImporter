using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionSqlContext : ITransactionContext
    {
        public List<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public void AddTransaction(int uploadId, Transaction trans)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    using (SqlCommand insertTransaction =
                        new SqlCommand(
                            "INSERT INTO [Transaction] (@UserId, @TransactionId, @CustomerInfoUUID, @Gateway, @Amount, @Status, @Date)",
                            connection))
                    {
                        insertTransaction.Parameters.AddWithValue("UserId", trans.User.Id);
                        insertTransaction.Parameters.AddWithValue("TransactionId", trans.TransactionId);
                        insertTransaction.Parameters.AddWithValue("CustomerInfoUUID", trans.Uuid);
                        insertTransaction.Parameters.AddWithValue("Gateway", trans.Gateway);
                        insertTransaction.Parameters.AddWithValue("Amount", trans.Amount);
                        insertTransaction.Parameters.AddWithValue("Status", trans.Status);
                        insertTransaction.Parameters.AddWithValue("Date", trans.Date);
                        connection.Open();
                        insertTransaction.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void AddTransactionList(int uploadId, List<Transaction> transactions)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    foreach (Transaction item in transactions)
                    {

                        SqlCommand insertTransaction = new SqlCommand("dbo.AddTransactions", connection);
                        insertTransaction.CommandType = CommandType.StoredProcedure;
                        insertTransaction.Parameters.AddWithValue("UploadId", uploadId);
                        insertTransaction.Parameters.AddWithValue("TransactionId", item.TransactionId);
                        insertTransaction.Parameters.AddWithValue("CustomerInfoUUID", item.Uuid);
                        insertTransaction.Parameters.AddWithValue("Gateway", item.Gateway);
                        insertTransaction.Parameters.AddWithValue("Amount", item.Amount);
                        insertTransaction.Parameters.AddWithValue("Status", item.Status);
                        insertTransaction.Parameters.AddWithValue("Country", item.Country);
                        insertTransaction.Parameters.AddWithValue("Ip", item.Ip);
                        insertTransaction.Parameters.AddWithValue("Username", item.Username);
                        //InsertTransaction.Parameters.AddWithValue("Date", item.Date);
                        Console.WriteLine(insertTransaction.ExecuteNonQuery());
                    }
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