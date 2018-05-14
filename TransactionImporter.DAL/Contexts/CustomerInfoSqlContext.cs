using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        using (SqlCommand InsertCustomerInfo =
                            new SqlCommand(
                                "INSERT INTO [CustomerInfo] (UUID, Email, FirstName, Address) VALUES (@UUID, @Email, @FirstName, @Address)",
                                connection))
                        {
                            InsertCustomerInfo.Parameters.AddWithValue("UUID", item.UUID);
                            InsertCustomerInfo.Parameters.AddWithValue("Email", item.Email);
                            InsertCustomerInfo.Parameters.AddWithValue("FirstName", item.Name);
                            InsertCustomerInfo.Parameters.AddWithValue("Address", item.Address);
                            InsertCustomerInfo.ExecuteNonQuery();
                        }
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