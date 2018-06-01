using System;
using System.Data;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UserSqlContext : IUserContext
    {
        public void UploadFile()
        {
            throw new NotImplementedException();
        }

        public void CancelUpload()
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand addUser = new SqlCommand("dbo.AddUser", connection);
                    addUser.CommandType = CommandType.StoredProcedure;
                    addUser.Parameters.AddWithValue("Username", user.Username);
                    addUser.Parameters.AddWithValue("Email", user.Email);
                    addUser.Parameters.AddWithValue("Password", user.Password);
                    addUser.Parameters.AddWithValue("Birthdate", user.Birthdate);
                    addUser.Parameters.AddWithValue("Country", user.Country);
                    addUser.Parameters.AddWithValue("CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    addUser.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void EditUser()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            try
            {
            using (SqlConnection connection = Database.GetConnectionString())
            {
                connection.Open();
                SqlCommand selectUserById =
                    new SqlCommand("SELECT * FROM [User] WHERE (UserId) = (@UserId)", connection);
                selectUserById.Parameters.AddWithValue("UserId", id);
                selectUserById.ExecuteNonQuery();
                using (SqlDataReader reader = selectUserById.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        User user = new User(
                            (dataRow["Username"].ToString() != "") ? dataRow["Username"].ToString() : "-",
                            (dataRow["Email"].ToString() != "") ? dataRow["Email"].ToString() : "-",
                            (dataRow["Birthdate"].ToString() != "") ? dataRow["Birthdate"].ToString() : "-",
                            (dataRow["Country"].ToString() != "") ? dataRow["Country"].ToString() : "-");
                        return user;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}

}