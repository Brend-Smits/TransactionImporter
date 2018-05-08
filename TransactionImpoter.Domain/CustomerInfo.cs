using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Ip { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        private List<Transaction> Transactions = new List<Transaction>();

        public CustomerInfo(string email, string username, string name, string ip, string country, string address)
        {
            Email = email;
            Username = username;
            Name = name;
            Ip = ip;
            Country = country;
            Address = address;
        }
    }
}
