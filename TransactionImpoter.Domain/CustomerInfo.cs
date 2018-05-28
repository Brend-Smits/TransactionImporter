using System.Collections.Generic;

namespace TransactionImpoter.Domain
{
    public class CustomerInfo
    {
        public string Uuid { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Ip { get; private set; }
        public string FirstName { get; private set; }
        public string SurName { get; private set; }

        public string Name { get; private set; }
        public string Address { get; private set; }
        private List<Transaction> Transactions = new List<Transaction>();

        public CustomerInfo(string uuid, string email, string name, string address)
        {
            Uuid = uuid;
            Email = email;
            Name = name;
            Address = address;
        }

        public CustomerInfo()
        {
        }

        public List<string> GetDataForThisExcelFile()
        {
            List<string> result = new List<string>
            {
                Uuid,
                Email,
                Name,
                Address
            };

            return result;
        }
    }
}
