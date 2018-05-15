using System.Data.SqlClient;

namespace TransactionImporter.DAL
{
    public class Database
    {
        static ConnectionBuilder connectionBuilder = new ConnectionBuilder();
        public static SqlConnection GetConnectionString()
        {
            return connectionBuilder.ConnectionString();
        }
    }
}
