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
                    SqlCommand AddUploadDetails = new SqlCommand(
                        "INSERT INTO [UploadDetail] (UploadId, StartTimeUpload, Filename, Filesize, UserId) VALUES (@UploadId, @StartTimeUpload, @Filename, @Filesize, @UserId)",
                        connection);
                    AddUploadDetails.Parameters.AddWithValue("UploadId", detail._uploadId);
                    AddUploadDetails.Parameters.AddWithValue("StartTimeUpload", detail._startTimeUpload);
                    AddUploadDetails.Parameters.AddWithValue("Filename", detail._fileName);
                    AddUploadDetails.Parameters.AddWithValue("Filesize", detail._fileSize);
                    AddUploadDetails.Parameters.AddWithValue("UserId", 1);
                    AddUploadDetails.ExecuteNonQuery();
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
                    SqlCommand SelectMaxUploadId = new SqlCommand(
                        "SELECT ISNULL(MAX(UploadId), 0) FROM [UploadDetail]", connection);
                    return Convert.ToInt32(SelectMaxUploadId.ExecuteScalar());
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
