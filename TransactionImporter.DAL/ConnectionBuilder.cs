using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.DAL
{
    public class ConnectionBuilder
    {

        public string ConnectionString()
        {
            return "Server = mssql.fhict.local; Database = dbi387545; User Id = dbi387545; Password = V3RiEXQArtZ8;";
        }
    }
}
