﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    using (SqlCommand AddUser =
                        new SqlCommand(
                            "INSERT INTO [User] (Username, Email, Password, Birthdate, Country, CreatedAt) VALUES (@Username, @Email, @Password, @Birthdate, @Country, @CreatedAt)",
                            connection))
                    {
                        AddUser.Parameters.AddWithValue("Username", user.Username);
                        AddUser.Parameters.AddWithValue("Email", user.Email);
                        AddUser.Parameters.AddWithValue("Password", user.Password);
                        AddUser.Parameters.AddWithValue("Birthdate", user.Birthdate);
                        AddUser.Parameters.AddWithValue("Country", user.Country);
                        AddUser.Parameters.AddWithValue("CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        connection.Open();
                        AddUser.ExecuteNonQuery();
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
