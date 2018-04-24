using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Transaction> Transactions = new List<Transaction>();

        public User(string username, string email, string password, DateTime birthdate)
        {
            Birthdate = birthdate;
            Email = email;
            Password = password;
            Username = username;
        }
    }
}
