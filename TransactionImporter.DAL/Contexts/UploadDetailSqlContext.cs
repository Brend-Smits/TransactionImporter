using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransactionImpoter.Domain;

namespace TransactionImporter.DAL
{
    public class UploadDetailSqlContext:IUploadDetailContext
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

        public void UploadDetailList(List<UploadDetail> details)
        {
            throw new NotImplementedException();
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
    }
}
