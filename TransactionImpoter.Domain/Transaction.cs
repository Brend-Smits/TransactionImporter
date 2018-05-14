using System;
using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class Transaction
    {
        public string TransactionId { get; private set; }
        public double Amount { get; private set; }
        public string Gateway { get; private set; }
        public string Status { get; private set; }
        public DateTime Date { get; private set; }
        public string Country { get; private set; }
        public string IP { get; private set; }
        public string Username { get; private set; }
        public User User;
        public CustomerInfo CustomerInfo { get; private set; }
        public List<Product> Products = new List<Product>();


        public Transaction(string transactionId, string gateway, double amount, string status, string country, string ip, string username)
        {
            TransactionId = transactionId;
            Amount = amount;
            Gateway = gateway;
            Status = status;
            Country = country;
            IP = ip;
            Username = username;
//            Date = date;
//            User = user;
        }
    }
}