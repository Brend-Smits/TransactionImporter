using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionImporter.WebUI.Models
{
    public class HomeModels
    {
        public HomeModels(string gateway, int transCount)
        {
            Gateway = gateway;
            TransactionCount = transCount;
        }
        public int TransactionCount { get; private set; }
        public string Gateway { get; private set; }
    }
}