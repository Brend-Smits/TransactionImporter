using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface ICategoryLogic
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        List<Product> GetAllProductsByCatId(int id);
    }
}
