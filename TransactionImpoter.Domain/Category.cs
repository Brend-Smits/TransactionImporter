using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int StoreCategoryId { get; private set; }
        public List<Product> Products = new List<Product>();

        public Category(string name, int storeCategoryId)
        {
            Name = name;
            StoreCategoryId = StoreCategoryId;
        }
    }
}
