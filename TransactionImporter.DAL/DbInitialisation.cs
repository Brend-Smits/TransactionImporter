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
            SqlConnection _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString =
                "Server=mssql.fhict.local;Database=dbi387545;User Id=dbi387545;Password=gM4cjm908KksONEaimkxUx";
            _sqlConnection.Open();
        }
    }
}
