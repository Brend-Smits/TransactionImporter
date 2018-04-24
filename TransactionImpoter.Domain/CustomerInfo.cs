using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Country { get; set; }
        private List<Transaction> Transactions = new List<Transaction>();

        public CustomerInfo(string email, string username, string ip, string firstName, string surName, string country)
        {
            Email = email;
            Username = username;
            Ip = ip;
            FirstName = firstName;
            SurName = surName;
            Country = country;
        }
    }
}
