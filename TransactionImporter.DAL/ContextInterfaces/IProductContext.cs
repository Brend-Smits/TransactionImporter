using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.ContextInterfaces
{
    interface IProductContext
    {
        List<Product> GetAllProducts();
        Product FindProductById(int id);
    }
}
