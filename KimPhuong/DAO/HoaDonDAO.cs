using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KimPhuong.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
namespace KimPhuong.DAO
{
    public class HoaDonDAO
    {
        MongoDBConnect dBConnect;
        public HoaDonDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllHoaDon()
        {
            return dBConnect.GetAllDocuments("HoaDon");
        }
        public BsonDocument getHoaDonByMa(string maHoaDon)
        {
            var collection = dBConnect.Database.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
            var hoaDon = collection.Find(filter).FirstOrDefault();
            return hoaDon; 
        }
    }
}
