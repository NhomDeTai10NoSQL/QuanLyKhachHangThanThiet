using KimPhuong.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DAO
{
    public class NhaCungCapDAO
    {
        MongoDBConnect dBConnect;
        public NhaCungCapDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllNhaCungCap()
        {
            return dBConnect.GetAllDocuments("NhaCungCap");
        }
    }
}
