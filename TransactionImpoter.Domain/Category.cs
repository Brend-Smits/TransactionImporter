using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StoreCategoryId { get; set; }
        public List<Product> Products = new List<Product>();

        public Category(string name, int storeCategoryId)
        {
            Name = name;
            StoreCategoryId = StoreCategoryId;
        }
    }
}
