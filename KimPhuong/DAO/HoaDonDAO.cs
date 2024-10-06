using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KimPhuong.DBC;
using MongoDB.Bson;
using MongoDB.Driver;
namespace KimPhuong.DAO
{
    public class HoaDonDAO
    {
        MongoDBConnect dBConnect;
        public HoaDonDAO()
        {
            dBConnect = new MongoDBConnect();
        }
        public List<BsonDocument> getAllHoaDon()
        {
            return dBConnect.GetAllDocuments("HoaDon");
        }
        public BsonDocument getHoaDonByMa(string maHoaDon)
        {
            var collection = dBConnect.Database.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
            var hoaDon = collection.Find(filter).FirstOrDefault();
            return hoaDon; 
        }
        public string GetMaxMaHoaDon()
        {
            var maxDoc = dBConnect.GetMaxDocument("HoaDon", "maHoaDon");
            if (maxDoc == null)
            {
                return "HD001";
            }

            string currentMax = maxDoc["maHoaDon"].AsString;

            string numberPart = currentMax.Substring(2);
            int nextNumber = int.Parse(numberPart) + 1;
            return $"HD{nextNumber:D3}";
        }

        public BsonDocument getMaNhanVienByTaiKhoan(string taiKhoan)
        {
            var collection = dBConnect.Database.GetCollection<BsonDocument>("NhanVien");
            var filter = Builders<BsonDocument>.Filter.Eq("taiKhoan", taiKhoan);
            var nhanVien = collection.Find(filter).FirstOrDefault();
            return nhanVien; 
        }
        public bool addHoaDon(string maHoaDon, DateTime ngayLapHoaDon, string maNhanVien, string tenNhanVien)
        {
            try
            {
                var hoaDon = new BsonDocument
            {
                { "maHoaDon", maHoaDon },
                { "ngayLapHoaDon", ngayLapHoaDon },
                { "tongTien", BsonNull.Value },
                { "diemDaDung", BsonNull.Value },
                { "diemTichLuy", BsonNull.Value },
                { "phuongThucThanhToan", BsonNull.Value },
                { "nhanVien", new BsonDocument { { "maNhanVien", maNhanVien }, { "tenNhanVien", tenNhanVien } } },
                { "khachHang", BsonNull.Value },
                { "khuyenMai", BsonNull.Value },
                { "chiTietHoaDon", new BsonArray() }
                
            };

                dBConnect.InsertDocument("HoaDon", hoaDon);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool addChiTietHoaDon(string maHoaDon, List<BsonDocument> chiTietHoaDonList)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
                var update = Builders<BsonDocument>.Update.PushEach("chiTietHoaDon", chiTietHoaDonList);

                dBConnect.UpdateDocument("HoaDon",filter, update);
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }


    }
}
