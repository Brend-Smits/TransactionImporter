using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IContinentFilter
    {
        void FilterContinent(string continent, string path);
    }
}
