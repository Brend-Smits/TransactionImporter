using System;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UserSqlContext:IUserContext
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
                    SqlCommand SelectUser = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username LIKE @Username OR Email LIKE @Email", connection);
                    SelectUser.Parameters.AddWithValue("Username", user.Username);
                    SelectUser.Parameters.AddWithValue("Email", user.Email);
                    int userCount = (int)SelectUser.ExecuteScalar();
                    if (userCount == 0)
                    {
                        SqlCommand AddUser = new SqlCommand(
                            "INSERT INTO [User] (Username, Email, Password, Birthdate, Country, CreatedAt) VALUES (@Username, @Email, @Password, @Birthdate, @Country, @CreatedAt)",
                            connection);
                        AddUser.Parameters.AddWithValue("Username", user.Username);
                        AddUser.Parameters.AddWithValue("Email", user.Email);
                        AddUser.Parameters.AddWithValue("Password", user.Password);
                        AddUser.Parameters.AddWithValue("Birthdate", user.Birthdate);
                        AddUser.Parameters.AddWithValue("Country", user.Country);
                        AddUser.Parameters.AddWithValue("CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        AddUser.ExecuteNonQuery();
                    } else
                    {
                        Console.WriteLine("User with that Username or Email already exists.");
                    }
                    
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
    }
}
