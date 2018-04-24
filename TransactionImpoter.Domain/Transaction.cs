using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public string Gateway { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public User User;
        private CustomerInfo CustomerInfo;
        public List<Product> Products = new List<Product>();

        public Transaction(string transactionId, string gateway)
        {
            TransactionId = transactionId;
//            Amount = amount;
            Gateway = gateway;
//            Status = status;
//            Date = date;
//            User = user;
        }
    }
}
