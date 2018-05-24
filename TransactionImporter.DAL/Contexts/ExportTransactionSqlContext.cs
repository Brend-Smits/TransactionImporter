using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class ExportTransactionSqlContext:IExportTransactionContext
    {
        public List<Transaction> GetTransaction()
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                        SqlCommand SelectTransactions = new SqlCommand(
                            "SELECT * FROM [Transaction] WHERE (UploadId) LIKE (@UploadId)",
                            connection);
                    SelectTransactions.Parameters.AddWithValue("UploadId", 12);
                    using (SqlDataReader reader = SelectTransactions.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            Transaction trans = new Transaction(
                                (dataRow["TransactionId"].ToString() != "") ? dataRow["TransactionId"].ToString() : "",
                                (dataRow["Gateway"].ToString() != "") ? dataRow["Gateway"].ToString() : "", 
                                Convert.ToDouble((dataRow["Amount"] != DBNull.Value) ? dataRow["Amount"] : 0), 
                                (dataRow["Status"].ToString() != "") ? dataRow["Status"].ToString() : "", 
                                (dataRow["Country"].ToString() != "") ? dataRow["Country"].ToString() : "", 
                                (dataRow["Ip"].ToString() != "") ? dataRow["Ip"].ToString() : "", 
                                (dataRow["Username"].ToString() != "") ? dataRow["Username"].ToString() : "", 
                                (dataRow["CustomerInfoUUID"].ToString() != "") ? dataRow["CustomerInfoUUID"].ToString() : "");
                            transactions.Add(trans);
                        }
                    }
                }
                return transactions;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static bool HasNull(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                if (table.Rows.OfType<DataRow>().Any(r => r.IsNull(column)))
                    return true;
            }

            return false;
        }

        private Transaction CreateTransactionObject(SqlDataReader reader, int i)
        {
            Dictionary<string, string> transactionValues = new Dictionary<string, string>
            {
                {"TransactionId", null},
                {"Gateway", null},
                {"Status", null},
                {"Price", null},
                {"Country", null},
                {"Ip", null},
                {"Username", null},
                {"Uuid", null}
            };

            for (int j = i; j < reader.FieldCount; j++)
            {
                if (transactionValues.ContainsKey(reader.GetName(i)))
                {
                    transactionValues[reader.GetName(i)] = reader.GetString(i);
                    
                }
            }

            return new Transaction(transactionValues["Transaction ID"], transactionValues["Gateway"],
                Convert.ToDouble(transactionValues["Price"]), transactionValues["Status"], transactionValues["Country"],
                transactionValues["Ip"], transactionValues["Username"], transactionValues["Uuid"]);
        }
    }
}
