using System;
using System.Collections;
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
        public List<BsonDocument> getAllSanPham()
        {
            return dBConnect.GetAllDocuments("SanPham");
        }
        
        public List<BsonDocument> searchSanPham(string key)
        {

            string[] field = { "tenSanPham", "moTa", "maVach", "xuatXu", "danhMuc.tenDanhMuc", "nhaCungCap.tenNhaCungCap", "baoHanh.maBaoHanh", "baoHanh.ghiChu" };
            return dBConnect.SearchDocuments("SanPham", key, field, "SanPhamSearchIndex");
        }

    }
}
