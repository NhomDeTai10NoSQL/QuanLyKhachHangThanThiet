using Danh.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.DAO
{
    internal class DangNhapDAO
    {
        MongoDBConnect dBConnect;
        public DangNhapDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllDangNhap()
        {
            return dBConnect.GetAllDocuments("NhanVien");
        }
    }
}
