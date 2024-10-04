using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KimPhuong.DBC;
using MongoDB.Bson;
using MongoDB.Driver;

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
        public bool themSanPham(string maSanPham, string tenSanPham, string maVach,
    int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
    int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
    string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            try
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
                return true; 
            }
            catch
            {
                return false; 
            }
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
            return $"SP{nextNumber:D3}";
        }
        public bool xoaSanPham(string maSanPham)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSanPham", maSanPham);
            var result = dBConnect.DeleteDocument("SanPham", filter);
            return result.DeletedCount > 0;
        }

        public bool updateSanPham(string maSanPham, string tenSanPham, string maVach,
    int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
    int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
    string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("maSanPham", maSanPham);

            var update = Builders<BsonDocument>.Update
                .Set("tenSanPham", tenSanPham)
                .Set("maVach", maVach)
                .Set("giaBan", giaBan)
                .Set("ngaySanXuat", ngaySanXuat.Date)
                .Set("xuatXu", xuatXu)
                .Set("moTa", moTa)
                .Set("danhMuc.maDanhMuc", maDanhMuc)
                .Set("danhMuc.tenDanhMuc", tenDanhMuc)
                .Set("nhaCungCap.maNhaCungCap", maNhaCungCap)
                .Set("nhaCungCap.tenNhaCungCap", tenNhaCungCap)
                .Set("baoHanh.maBaoHanh", maBaoHanh)
                .Set("baoHanh.thoiGianBaoHanh", thoiGianBaoHanh);

            var result = dBConnect.UpdateDocument("SanPham", filter, update);
            return result.ModifiedCount > 0; 
        }



    }
}
