using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.DAL
{
    // TODO: Initialize database.
    // TODO: Setup tables.
    // TODO: Setup mock data.
    class DbInitialisation
    {
        public DbInitialisation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString().ConnectionString))
                {
                    SqlCommand createUserTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'User') CREATE TABLE User (Id int IDENTITY(1,1) PRIMARY KEY,Username varchar(MAX) NOT NULL,Email varchar(MAX) NOT NULL,Password varchar(MAX) NOT NULL,Birthdate date NOT NULL, Country varchar(MAX) NOT NULL, CreatedAt datetime2 NOT NULL)",
                            connection);
                    SqlCommand createTransactionTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Transaction') CREATE TABLE Transaction (TaskId int,Task varchar(MAX), Deadline date)",
                            connection);
                    SqlCommand createCustomerInfoTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Tasks') CREATE TABLE Tasks (TaskId int,Task varchar(MAX), Deadline date)",
                            connection);
                    SqlCommand createProductTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Tasks') CREATE TABLE Tasks (TaskId int,Task varchar(MAX), Deadline date)",
                            connection);
                    SqlCommand createCategoryTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Tasks') CREATE TABLE Tasks (TaskId int,Task varchar(MAX), Deadline date)",
                            connection);
                    SqlCommand createTransactionProductTable =
                        new SqlCommand(
                            "IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Tasks') CREATE TABLE Tasks (TaskId int,Task varchar(MAX), Deadline date)",
                            connection);
                    connection.Open();
                    createUserTable.ExecuteNonQuery();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public SqlConnection ConnectionString()
        {
            return new SqlConnection("Server=mssql.fhict.local;Database=dbi387545;User Id=dbi387545;Password=V3RiEXQArtZ8;");
        }
    }
}
