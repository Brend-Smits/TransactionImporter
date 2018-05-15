using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime Birthdate { get; private set; }
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
