using System;
using System.Collections.Generic;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL.Interfaces
{
    public interface IExportTransaction
    {
        void DownloadTransactions();

    }
}
