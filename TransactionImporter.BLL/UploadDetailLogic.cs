using System;
using System.Collections.Generic;
using System.IO;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class UploadDetailLogic : IUploadDetailLogic
    {
        private IUploadDetailRepository _Repo;
        private IImporterExcel _importer = new ImporterExcel();
        List<UploadDetail> uploadsDetails = new List<UploadDetail>();

        public UploadDetailLogic(IUploadDetailRepository _uploadDetailRepository)
        {
            _Repo = _uploadDetailRepository;
        }


        public UploadDetail GetUploadDetails(string path)
        {
            
            Console.WriteLine("File name is: " + GetFileName(path));
            Console.WriteLine("File Size in Bytes: " + GetFileSize(path));
            return new UploadDetail(DateTime.Now, DateTime.Now.AddHours(2), GetFileSize(path).ToString(), GetFileName(path));
        }

        private Int64 GetFileSize(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            var size = fileInfo.Length;
            return size;
        }

        private string GetFileName(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            return fileInfo.Name;
        }

        public void UploadDetailList()
        {
            throw new NotImplementedException();
        }

        public void UploadDetails(string path)
        {
            _Repo.UploadDetails(GetUploadDetails(path));
        }
    }
}
