using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IProductLogic
    {
        List<Product> GetAllProducts();
        string FindProductById(int id);
    }
}
