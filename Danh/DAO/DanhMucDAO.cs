using Danh.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.DAO
{
    public class DanhMucDAO
    {
        MongoDBConnect dBConnect;
        public DanhMucDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllDanhMuc()
        {
            return dBConnect.GetAllDocuments("DanhMuc");
        }
        public long getSoSPTrongDanhMuc(int ma)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("danhMuc.maDanhMuc", ma);

            return dBConnect.CountDocument("SanPham", filter);
        }
    }
}
