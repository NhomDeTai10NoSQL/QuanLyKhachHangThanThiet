using KimPhuong.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DAO
{
    internal class KhachHangDAO
    {
        MongoDBConnect dBConnect;
        public KhachHangDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllSanPham()
        {
            return dBConnect.GetAllDocuments("KhachHang");

        }
        public BsonDocument getKHBySDT(string sodt)
        {
            var collection = dBConnect.Database.GetCollection<BsonDocument>("KhachHang");
            var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", sodt);
            var kh = collection.Find(filter).FirstOrDefault();
            return kh;
        }
   
    }
}
