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
        public string Ip { get; private set; }
        public string Username { get; private set; }
        public string Uuid { get; private set; }
        public User User;
        public CustomerInfo CustomerInfo { get; private set; }
        public List<Product> Products = new List<Product>();


        public Transaction(string transactionId, string gateway, double amount, string status, string country, string ip, string username, string uuid)
        {
            TransactionId = transactionId;
            Amount = amount;
            Gateway = gateway;
            Status = status;
            Country = country;
            Ip = ip;
            Username = username;
            Uuid = uuid;
//            Date = date;
//            User = user;
        }
    }
}