﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public interface ICustomerInfoLogic
    {
        CustomerInfo AddCustomer();
    }
}
