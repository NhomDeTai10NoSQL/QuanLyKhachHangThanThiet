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
        public bool ThemSanPham(string tenSanPham, string maVach, string moTa, DateTime ngaySanXuat,
                                string xuatXu, double giaBan, string maBaoHanh, string maDanhMuc, string maNhaCungCap)
        {
            try
            {
                var sanPham = new BsonDocument
                {
                    { "tenSanPham", tenSanPham },
                    { "maVach", maVach },
                    { "moTa", moTa },
                    { "ngaySanXuat", ngaySanXuat },
                    { "xuatXu", xuatXu },
                    { "giaBan", giaBan },
                    { "maBaoHanh", maBaoHanh },
                    { "maDanhMuc", maDanhMuc },
                    { "maNhaCungCap", maNhaCungCap }
                };

                dBConnect.InsertDocument("SanPham", sanPham);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm sản phẩm: {ex.Message}");
                return false;
            }
        }
        public List<BsonDocument> searchSanPham(string key)
        {

            string[] field = { "tenSanPham", "moTa", "maVach", "xuatXu", "danhMuc.tenDanhMuc", "nhaCungCap.tenNhaCungCap", "baoHanh.maBaoHanh", "baoHanh.ghiChu" };
            return dBConnect.SearchDocuments("SanPham", key, field, "SanPhamSearchIndex");
        }

    }
}
