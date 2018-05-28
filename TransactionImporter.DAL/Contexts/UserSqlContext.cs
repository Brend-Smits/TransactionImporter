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
                    SqlCommand selectUser = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username LIKE @Username OR Email LIKE @Email", connection);
                    selectUser.Parameters.AddWithValue("Username", user.Username);
                    selectUser.Parameters.AddWithValue("Email", user.Email);
                    int userCount = (int)selectUser.ExecuteScalar();
                    if (userCount == 0)
                    {
                        SqlCommand addUser = new SqlCommand(
                            "INSERT INTO [User] (Username, Email, Password, Birthdate, Country, CreatedAt) VALUES (@Username, @Email, @Password, @Birthdate, @Country, @CreatedAt)",
                            connection);
                        addUser.Parameters.AddWithValue("Username", user.Username);
                        addUser.Parameters.AddWithValue("Email", user.Email);
                        addUser.Parameters.AddWithValue("Password", user.Password);
                        addUser.Parameters.AddWithValue("Birthdate", user.Birthdate);
                        addUser.Parameters.AddWithValue("Country", user.Country);
                        addUser.Parameters.AddWithValue("CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        addUser.ExecuteNonQuery();
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
