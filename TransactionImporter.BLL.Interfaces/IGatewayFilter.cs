using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IGatewayFilter
    {
        void FilterGateway(string gateway, string path, int id);
    }
}
