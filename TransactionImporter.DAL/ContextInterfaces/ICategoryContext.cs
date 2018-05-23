using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL.ContextInterfaces
{
    interface ICategoryContext
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        List<Product> GetAllProductsByCatId(int id);
    }
}
