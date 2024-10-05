using KimPhuong.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.DAO
{
    public class DatHangNCCDAO
    {
        MongoDBConnect dBConnect;
        public DatHangNCCDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllDonDatHang()
        {
            return dBConnect.GetAllDocuments("DonDatHangNhaCungCap");
        }
    }
}
