using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Contexts
{
    class ProductSqlContext:IProductContext
    {
        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product FindProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
