using System;
using System.Collections.Generic;
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
                        bool doesUuidExist = false;
                        SqlCommand selectUuid = new SqlCommand("SELECT COUNT(*) FROM [CustomerInfo] WHERE uuid LIKE @Uuid", connection);
                        
                            selectUuid.Parameters.AddWithValue("Uuid", item.Uuid);
                            int userCount = (int)selectUuid.ExecuteScalar();
                            if (userCount > 0)
                            {
                                doesUuidExist = true;
                            }
                        
                        if (doesUuidExist)
                        {
                            continue;
                        }
                        SqlCommand insertCustomerInfo = new SqlCommand("INSERT INTO [CustomerInfo] (Uuid, Email, FirstName, Address) VALUES (@Uuid, @Email, @FirstName, @Address)", connection);
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