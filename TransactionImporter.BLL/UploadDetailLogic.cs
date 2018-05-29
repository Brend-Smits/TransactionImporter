using System;
using System.Collections.Generic;
using System.IO;
using TransactionImporter.BLL.Interfaces;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;
using TransactionImpoter.Domain;

namespace TransactionImporter.BLL
{
    public class UploadDetailLogic : IUploadDetailLogic
    {
        private IUploadDetailRepository _Repo = new UploadDetailRepository();
        private IImporterExcel importer = new ImporterExcel();
        public int UploadId { get; private set; }
        List<UploadDetail> uploadsDetails = new List<UploadDetail>();

        public UploadDetailLogic(IUploadDetailRepository uploadDetailRepository)
        {
            _Repo = uploadDetailRepository;
            UploadId = GetUploadId();


        }
        public UploadDetailLogic() { }

        public UploadDetail GetUploadDetails(string path)
        {
            UploadId++;
            Console.WriteLine("File name is: " + GetFileName(path));
            Console.WriteLine("File Size in Bytes: " + GetFileSize(path));
            return new UploadDetail(UploadId, DateTime.Now, GetFileName(path),  GetFileSize(path).ToString());
        }

        public void UploadDetails(UploadDetail detail, string path)
        {
             _Repo.UploadDetails(GetUploadDetails(path));
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

        public List<UploadDetail> UploadDetailList()
        {
            return _Repo.UploadDetailList();
        }

        public int GetUploadId()
        {
            return _Repo.GetUploadId();
        }
    }
}
