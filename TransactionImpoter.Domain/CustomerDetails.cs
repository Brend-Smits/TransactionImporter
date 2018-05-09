using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TransactionImpoter.Domain
{
    public class CustomerDetails
    {
        public string Username { get; private set; }
        public string Ip { get; private set; }

        public CustomerDetails(string ip, string username)
        {
            Ip = ip;
            Username = username;
        }
    }
}
