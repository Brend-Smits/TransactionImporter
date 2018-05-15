using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product FindProductById(int id);
    }
}
