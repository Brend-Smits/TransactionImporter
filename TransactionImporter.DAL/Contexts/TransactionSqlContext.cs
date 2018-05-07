using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class TransactionSqlContext:ITransactionContext
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
                using (SqlConnection connection = new SqlConnection(Database.GetConnectionString()))
                {
                    using (SqlCommand InsertTransaction =
                        new SqlCommand(
                            "INSERT INTO [Transaction] (@UserId, @TransactionId, @CustomerId, @Gateway, @Amount, @Status, @Date)",
                            connection))
                    {
                        InsertTransaction.Parameters.AddWithValue("UserId", trans.User.Id);
                        InsertTransaction.Parameters.AddWithValue("TransactionId", trans.TransactionId);
                        InsertTransaction.Parameters.AddWithValue("CustomerId", trans.CustomerInfo.Id);
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
            throw new NotImplementedException();
        }
    }
}
