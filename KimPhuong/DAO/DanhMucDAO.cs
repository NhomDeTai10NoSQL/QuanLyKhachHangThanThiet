using KimPhuong.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DAO
{
    public class DanhMucDAO
    {
        MongoDBConnect dBConnect;
        public DanhMucDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllDanhMuc()
        {
            return dBConnect.GetAllDocuments("DanhMuc");
        }
    }
}
