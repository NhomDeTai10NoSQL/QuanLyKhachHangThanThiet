using System;
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
        public List<BsonDocument> GetAllSanPham()
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
                    { "TenSanPham", tenSanPham },
                    { "MaVach", maVach },
                    { "MoTa", moTa },
                    { "NgaySanXuat", ngaySanXuat },
                    { "XuatXu", xuatXu },
                    { "GiaBan", giaBan },
                    { "MaBaoHanh", maBaoHanh },
                    { "MaDanhMuc", maDanhMuc },
                    { "MaNhaCungCap", maNhaCungCap }
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

    }
}
