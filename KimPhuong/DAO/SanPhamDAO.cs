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
        public void themSanPham(string maSanPham, string tenSanPham, string maVach,
        int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
        int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
        string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            var document = new BsonDocument
        {
            { "maSanPham", maSanPham },
            { "tenSanPham", tenSanPham },
            { "maVach", maVach },
            { "giaBan", giaBan },
            { "ngaySanXuat", ngaySanXuat.Date },
            { "xuatXu", xuatXu },
            { "moTa", moTa },
            { "danhMuc", new BsonDocument
                {
                    { "maDanhMuc", maDanhMuc },
                    { "tenDanhMuc", tenDanhMuc }
                }
            },
            { "nhaCungCap", new BsonDocument
                {
                    { "maNhaCungCap", maNhaCungCap },
                    { "tenNhaCungCap", tenNhaCungCap }
                }
            },
            { "baoHanh", new BsonDocument
                {
                    { "maBaoHanh", maBaoHanh },
                    { "thoiGianBaoHanh", thoiGianBaoHanh }
                }
            }
        };

            dBConnect.InsertDocument("SanPham", document);
        }

        public string GetNextMaSanPham()
        {
            var maxDoc = dBConnect.GetMaxDocument("SanPham", "maSanPham");
            if (maxDoc == null)
            {
                return "SP001";
            }

            string currentMax = maxDoc["maSanPham"].AsString;
           
            string numberPart = currentMax.Substring(2); 
            int nextNumber = int.Parse(numberPart) + 1;

            // Format số thành chuỗi 5 chữ số, thêm các số 0 ở đầu nếu cần
            return $"SP{nextNumber:D3}";
        }
    }
}
