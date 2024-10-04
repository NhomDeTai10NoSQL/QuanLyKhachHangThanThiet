using Main.DBC;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.DAO
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
        public bool CheckDangNhap(string username, string password)
        {
            var danhSachDangNhap = GetAllDangNhap();
            return danhSachDangNhap.Any(doc => doc["taiKhoan"] == username && doc["matKhau"] == password);
        }
    }
}
