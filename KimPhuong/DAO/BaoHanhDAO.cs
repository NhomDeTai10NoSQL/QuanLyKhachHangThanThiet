using KimPhuong.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DAO
{
    public class BaoHanhDAO
    {
        MongoDBConnect dBConnect;
        public BaoHanhDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllBaoHanh()
        {
            return dBConnect.GetAllDocuments("BaoHanh");
        }
    }
}
