using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImporter.BLL.Interfaces;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    class CategoryLogic:ICategoryLogic
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
