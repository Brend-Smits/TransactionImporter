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


        public void GetUploadDetails()
        {
            Console.WriteLine("File Size in Bytes: " + GetFileSize(_importer.GetPath()));
        }

        private Int64 GetFileSize(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            var size = fileInfo.Length;
            return size;
        }

        public void UploadDetail()
        {
            throw new NotImplementedException();
        }

        public void UploadDetails()
        {
            throw new NotImplementedException();
        }
    }
}
