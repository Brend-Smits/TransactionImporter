using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.ContextInterfaces
{
    interface IProductContext
    {
        List<Product> GetAllProducts();
        Product FindProductById(int id);
    }
}
