using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
