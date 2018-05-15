using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        List<Product> GetAllProductsByCatId(int id);
    }
}
