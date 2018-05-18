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
                    SqlCommand AddUploadTime = new SqlCommand(
                        "INSERT INTO [UploadDetail] (StartTimeUpload, EndTimeUpload, Filename, Filesize) VALUES (@StartTimeUpload, @EndTimeUpload, @Filename, @Filesize)",
                        connection);
                    AddUploadTime.Parameters.AddWithValue("StartTimeUpload", detail._startTimeUpload);
                    AddUploadTime.Parameters.AddWithValue("EndTimeUpload", detail._endTimeUpload);
                    AddUploadTime.Parameters.AddWithValue("Filename", detail._fileName);
                    AddUploadTime.Parameters.AddWithValue("Filesize", detail._fileSize);
                    AddUploadTime.ExecuteNonQuery();

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
    }
}
