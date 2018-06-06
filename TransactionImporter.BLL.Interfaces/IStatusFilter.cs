using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IStatusfilter
    {
        void FilterStatus(string status, string path, int id);
    }
}
