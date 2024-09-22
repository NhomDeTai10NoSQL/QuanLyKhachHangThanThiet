using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KimPhuong.DBC;
using MongoDB.Bson;
namespace KimPhuong.DAO
{
    public class SanPhamDAO
    {
        MongoDBConnect dBConnect;
        public SanPhamDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllSanPham()
        {
            return dBConnect.GetAllDocuments("SanPham");
        }
    }
}
