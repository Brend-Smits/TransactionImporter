using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Country { get; private set; }
        public string Birthdate { get; private set; }
        public List<Transaction> Transactions = new List<Transaction>();

        public User(string username, string email, string password, string birthdate, string country)
        {
            Username = username;
            Email = email;
            Password = password;
            Birthdate = birthdate;
            Country = country;
        }
    }
}
