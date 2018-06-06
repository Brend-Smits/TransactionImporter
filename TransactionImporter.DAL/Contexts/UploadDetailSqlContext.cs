using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UploadDetailSqlContext : IUploadDetailContext
    {
        public void UploadDetails(UploadDetail detail)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand addUploadDetails = new SqlCommand(
                        "INSERT INTO [UploadDetail] (UploadId, StartTimeUpload, Filename, Filesize, UserId) VALUES (@UploadId, @StartTimeUpload, @Filename, @Filesize, @UserId)",
                        connection);
                    addUploadDetails.Parameters.AddWithValue("UploadId", detail.UploadId);
                    addUploadDetails.Parameters.AddWithValue("StartTimeUpload", detail.StartTimeUpload);
                    addUploadDetails.Parameters.AddWithValue("Filename", detail.FileName);
                    addUploadDetails.Parameters.AddWithValue("Filesize", detail.FileSize);
                    addUploadDetails.Parameters.AddWithValue("UserId", 1);
                    addUploadDetails.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public List<UploadDetail> UploadDetailList()
        {
            List<UploadDetail> uploads = new List<UploadDetail>();
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand addUploadDetails = new SqlCommand("SELECT * FROM [UploadDetail]", connection);
                    addUploadDetails.ExecuteNonQuery();
                    using (SqlDataReader reader = addUploadDetails.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            UploadDetail detail = new UploadDetail(
                                Convert.ToInt32((dataRow["UploadId"] != DBNull.Value) ? dataRow["UploadId"] : 0),
                                Convert.ToInt32((dataRow["UserId"] != DBNull.Value) ? dataRow["Userid"] : 0),
                                Convert.ToDateTime((dataRow["StartTimeUpload"] != DBNull.Value)
                                    ? dataRow["StartTimeUpload"]
                                    : DateTime.Now),
                                (dataRow["FileName"].ToString() != "") ? dataRow["FileName"].ToString() : "-",
                                (dataRow["FileSize"].ToString() != "") ? dataRow["FileSize"].ToString() : "-");
                            uploads.Add(detail);
                        }
                    }
                }

                return uploads;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public int GetUploadId()
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand selectMaxUploadId = new SqlCommand(
                        "SELECT ISNULL(MAX(UploadId), 0) FROM [UploadDetail]", connection);
                    return Convert.ToInt32(selectMaxUploadId.ExecuteScalar());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public UploadDetail GetUploadDetailById(int id)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand addUploadDetailById = new SqlCommand("SELECT * FROM [UploadDetail] WHERE (UploadId) = (@UploadId)", connection);
                    addUploadDetailById.Parameters.AddWithValue("UploadId", id);
                    addUploadDetailById.ExecuteNonQuery();
                    using (SqlDataReader reader = addUploadDetailById.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            UploadDetail detail = new UploadDetail(
                                Convert.ToInt32((dataRow["UploadId"] != DBNull.Value) ? dataRow["UploadId"] : 0),
                                Convert.ToInt32((dataRow["UserId"] != DBNull.Value) ? dataRow["Userid"] : 0),
                                Convert.ToDateTime((dataRow["StartTimeUpload"] != DBNull.Value)
                                    ? dataRow["StartTimeUpload"]
                                    : DateTime.Now),
                                (dataRow["FileName"].ToString() != "") ? dataRow["FileName"].ToString() : "-",
                                (dataRow["FileSize"].ToString() != "") ? dataRow["FileSize"].ToString() : "-");
                            return detail;
                        }
                    }
                }

                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        public void DeleteDataByUploadId(int id)
        {
            try
            {
                using (SqlConnection connection = Database.GetConnectionString())
                {
                    connection.Open();
                    SqlCommand insertCustomerInfo = new SqlCommand("dbo.RemoveUploadById", connection);
                    insertCustomerInfo.CommandType = CommandType.StoredProcedure;
                    insertCustomerInfo.Parameters.AddWithValue("UploadId", id);
                    insertCustomerInfo.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}