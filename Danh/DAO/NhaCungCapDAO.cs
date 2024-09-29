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
    internal class NhaCungCapDAO
    {
        MongoDBConnect dBConnect;
        public NhaCungCapDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> GetAllNhaCungCap()
        {
            return dBConnect.GetAllDocuments("NhaCungCap");
        }
    }
}
