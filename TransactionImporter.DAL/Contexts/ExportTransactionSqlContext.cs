using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class ExportTransactionSqlContext:IExportTransactionContext
    {
        //TODO: Create Transaction objects from the reader data.
        public List<Transaction> GetTransaction()
        {
            List<Transaction> columnData = new List<Transaction>();
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
                        while (reader.Read())
                        {
                            for (int i = 0; i < (reader.FieldCount - 1); i++)
                            {
                                if (reader.IsDBNull(i))
                                {
                                    continue;
                                }

                                columnData.Add(CreateTransactionObject(reader, i));
                                Console.WriteLine(reader.GetName(i));
                                Console.WriteLine(reader.GetString(i));
                            }
//                            columnData.Add(reader.GetString(0));
                        }
                    }
                }
                return columnData;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
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
            
                if (transactionValues.ContainsKey(reader.GetName(i)))
                {
                    transactionValues[reader.GetName(i)] = reader.GetString(i);
                }

            return new Transaction(transactionValues["Transaction ID"], transactionValues["Gateway"],
                Convert.ToDouble(transactionValues["Price"]), transactionValues["Status"], transactionValues["Country"],
                transactionValues["Ip"], transactionValues["Username"], transactionValues["Uuid"]);
        }
    }
}
