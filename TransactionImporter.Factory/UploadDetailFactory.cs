using TransactionImporter.BLL;
using TransactionImporter.DAL;
using TransactionImporter.DAL.Repositories;

namespace TransactionImporter.Factory
{
    public class UploadDetailFactory
    {
        public static IUploadDetailLogic CreateLogic()
        {
            return new UploadDetailLogic(new UploadDetailRepository(new UploadDetailSqlContext()));
        }

    }
}
