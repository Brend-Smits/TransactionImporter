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
        public string UUID { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Ip { get; private set; }
        public string FirstName { get; private set; }
        public string SurName { get; private set; }

        public string Name { get; private set; }
        public string Address { get; private set; }
        private List<Transaction> Transactions = new List<Transaction>();

        public CustomerInfo(string uuid, string email, string username, string name, string ip, string address)
        {
            UUID = uuid;
            Email = email;
            Username = username;
            Name = name;
            Ip = ip;
            Address = address;
        }
    }
}
