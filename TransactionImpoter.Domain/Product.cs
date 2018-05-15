using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int StoreProductId { get; private set; }
        public List<Transaction> Transactions = new List<Transaction>();
        public Category Category;
        public Product(string name, int storeProductId)
        {
            Name = name;
            StoreProductId = storeProductId;
        }
    }
}
