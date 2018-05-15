using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionSqlContext : ITransactionContext
    {
        // TODO: Implement GetAllTransactions() in SQL Context
        public List<Transaction> GetAllTransactions()
        {
            // SELECT * FROM Transaction
            throw new NotImplementedException();
        }

        public List<Transaction> FilterTransactions()
        {
            throw new NotImplementedException();
        }

        public void AddTransaction(Transaction trans)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    using (SqlCommand InsertTransaction =
                        new SqlCommand(
                            "INSERT INTO [Transaction] (@UserId, @TransactionId, @CustomerInfoUUID, @Gateway, @Amount, @Status, @Date)",
                            connection))
                    {
                        InsertTransaction.Parameters.AddWithValue("UserId", trans.User.Id);
                        InsertTransaction.Parameters.AddWithValue("TransactionId", trans.TransactionId);
                        InsertTransaction.Parameters.AddWithValue("CustomerInfoUUID", trans.Uuid);
                        InsertTransaction.Parameters.AddWithValue("Gateway", trans.Gateway);
                        InsertTransaction.Parameters.AddWithValue("Amount", trans.Amount);
                        InsertTransaction.Parameters.AddWithValue("Status", trans.Status);
                        InsertTransaction.Parameters.AddWithValue("Date", trans.Date);
                        connection.Open();
                        InsertTransaction.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void AddTransactionList(List<Transaction> transactions)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    foreach (Transaction item in transactions)
                    {
                        bool doesTransactionIdExist = false;
                        SqlCommand SelectUuid = new SqlCommand("SELECT COUNT(*) FROM [Transaction] WHERE TransactionId LIKE @TransactionId", connection);
                        
                            SelectUuid.Parameters.AddWithValue("TransactionId", item.TransactionId);
                            int userCount = (int)SelectUuid.ExecuteScalar();
                            if (userCount > 0)
                            {
                                doesTransactionIdExist = true;
                            }
                        
                        if (doesTransactionIdExist)
                        {
                            continue;
                        }
                        SqlCommand InsertTransaction = new SqlCommand("INSERT INTO [Transaction] (UserId, TransactionId, CustomerInfoUUID, Gateway, Status, Country, Ip, Username) VALUES (@UserId, @TransactionId, @CustomerInfoUUID, @Gateway, @Status, @Country, @Ip, @Username)", connection);
                            InsertTransaction.Parameters.AddWithValue("UserId", 1);
                            InsertTransaction.Parameters.AddWithValue("TransactionId", item.TransactionId);
                            InsertTransaction.Parameters.AddWithValue("CustomerInfoUUID", item.Uuid);
                            InsertTransaction.Parameters.AddWithValue("Gateway", item.Gateway);
                            InsertTransaction.Parameters.AddWithValue("Amount", item.Amount);
                            InsertTransaction.Parameters.AddWithValue("Status", item.Status);
                            InsertTransaction.Parameters.AddWithValue("Country", item.Country);
                            InsertTransaction.Parameters.AddWithValue("Ip", item.Ip);
                            InsertTransaction.Parameters.AddWithValue("Username", item.Username);
                            //InsertTransaction.Parameters.AddWithValue("Date", item.Date);
                            InsertTransaction.ExecuteNonQuery();
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