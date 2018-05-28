using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Contexts
{
    public class CustomerInfoSqlContext : ICustomerInfoContext
    {
        public void AddCustomer(CustomerInfo customer)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerList(List<CustomerInfo> customers)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    foreach (CustomerInfo item in customers)
                    {
                        SqlCommand insertCustomerInfo = new SqlCommand("dbo.AddCustomerInfo", connection);
                        insertCustomerInfo.CommandType = CommandType.StoredProcedure;
                        insertCustomerInfo.Parameters.AddWithValue("Uuid", item.Uuid);
                        insertCustomerInfo.Parameters.AddWithValue("Email", item.Email);
                        insertCustomerInfo.Parameters.AddWithValue("FirstName", item.Name);
                        insertCustomerInfo.Parameters.AddWithValue("Address", item.Address);
                        insertCustomerInfo.ExecuteNonQuery();
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