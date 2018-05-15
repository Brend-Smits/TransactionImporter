using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    class ProductRepository:IProductRepository
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
