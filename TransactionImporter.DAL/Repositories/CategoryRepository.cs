using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Repositories
{
    class CategoryRepository:ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProductsByCatId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
