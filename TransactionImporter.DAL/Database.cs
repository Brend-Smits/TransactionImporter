using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.DAL
{
    public class Database
    {
        static ConnectionBuilder connectionBuilder = new ConnectionBuilder();
        public static string GetConnectionString()
        {
            return connectionBuilder.ConnectionString();
        }
    }
}
