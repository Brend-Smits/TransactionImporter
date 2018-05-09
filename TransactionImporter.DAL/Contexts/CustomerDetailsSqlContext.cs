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
    public class CustomerDetailsSqlContext : ICustomerDetailsContext
    {

        public void AddCustomerDetail(CustomerDetails customerDetail)
        {
            throw new NotImplementedException();
        }

        public void AddCustomerDetailsList(List<CustomerDetails> customerDetails)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    foreach (CustomerDetails item in customerDetails)
                    {
                        using (SqlCommand InsertCustomerDetails =
                            new SqlCommand(
                                "INSERT INTO [CustomerDetails] (Username, IP) VALUES (@Username, @IP)",
                                connection))
                        {
                            InsertCustomerDetails.Parameters.AddWithValue("Username", item.Username);
                            InsertCustomerDetails.Parameters.AddWithValue("IP", item.Ip);
                            InsertCustomerDetails.ExecuteNonQuery();
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