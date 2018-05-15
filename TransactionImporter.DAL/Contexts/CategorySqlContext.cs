using System;
using System.Collections.Generic;
using TransactionImporter.DAL.ContextInterfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.Contexts
{
    class CategorySqlContext:ICategoryContext
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
