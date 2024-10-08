using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public bool addHoaDon(string maHoaDon, DateTime ngayLapHoaDon, string maNhanVien, string tenNhanVien, int tongTien, int tongPhaiTra)
        {
            try
            {
                var hoaDon = new BsonDocument
            {
                { "maHoaDon", maHoaDon },
                { "ngayLapHoaDon", ngayLapHoaDon },
                { "tongTien", tongTien},
                { "diemDaDung", BsonNull.Value },
                { "diemTichLuy", BsonNull.Value },
                { "phuongThucThanhToan", BsonNull.Value },
                { "nhanVien", new BsonDocument { { "maNhanVien", maNhanVien }, { "tenNhanVien", tenNhanVien } } },
                { "khachHang", BsonNull.Value },
                { "tongPhaiTra", tongPhaiTra },
                { "chiTietHoaDon", new BsonArray() }

            };

                dBConnect.InsertDocument("HoaDon", hoaDon);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool kiemTraTrungSanPham(string maHoaDon, string maSanPham)
        {
            var collection = dBConnect.Database.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon),
                Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>("chiTietHoaDon",
                    Builders<BsonDocument>.Filter.Eq("maSanPham", maSanPham))
            );

            var count = collection.CountDocuments(filter);
            return count > 0;
        }
        public bool updateChiTietHoaDon(string maHoaDon, string maSanPham, int soLuong, int thanhTien)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon),
                    Builders<BsonDocument>.Filter.ElemMatch<BsonDocument>("chiTietHoaDon", Builders<BsonDocument>.Filter.Eq("maSanPham", maSanPham))
                );

                var update = Builders<BsonDocument>.Update.Set("chiTietHoaDon.$.soLuong", soLuong)
                                                          .Set("chiTietHoaDon.$.thanhTien", thanhTien);

                var result = dBConnect.UpdateDocument("HoaDon", filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool addChiTietHoaDon(string maHoaDon, string maSanPham, string tenSanPham, int soLuong, int donGia, int thanhTien)
        {
            try
            {
                var collection = dBConnect.Database.GetCollection<BsonDocument>("HoaDon");
                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);

                var newChiTiet = new BsonDocument
        {
            { "maSanPham", maSanPham },
            { "tenSanPham", tenSanPham },
            { "soLuong", soLuong },
            { "donGia", donGia },
            { "thanhTien", thanhTien }
        };

                var update = Builders<BsonDocument>.Update.Push("chiTietHoaDon", newChiTiet);
                var result = dBConnect.UpdateDocument("HoaDon", filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool updateHoaDon(string maHoaDon, int tongTien, int diemDaDung, string phuongThucThanhToan, BsonDocument khachHang, int tongPhaiTra)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
                var update = Builders<BsonDocument>.Update
       .Set("tongTien", tongTien)
       .Set("diemDaDung", diemDaDung)
       .Set("phuongThucThanhToan", phuongThucThanhToan)
       .Set("khachHang", khachHang)
       .Set("tongPhaiTra", tongPhaiTra);

                var result = dBConnect.UpdateDocument("HoaDon", filter, update);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                return false;
            }
        }

        public bool updateDiemTichLuy(string soDienThoai, int diemTichLuyMoi, int diemCon)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", soDienThoai);
                var update = Builders<BsonDocument>.Update
      .Set("DiemTichLuy", diemTichLuyMoi)
      .Set("DiemTichLuyCon", diemCon);
                var result = dBConnect.UpdateDocument("KhachHang", filter, update);
               
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm tích lũy khách hàng: " + ex.Message);
                return false;
            }
        }
        public bool updateLoaiKH(string soDienThoai)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("SoDienThoai", soDienThoai);
                var update = Builders<BsonDocument>.Update
      .Set("LoaiKhachHang", "Thân thiết");
                var result = dBConnect.UpdateDocument("KhachHang", filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại khách hàng: " + ex.Message);
                return false;
            }
        }
        public bool deleteHoaDon(string maHoaDon)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("maHoaDon", maHoaDon);
                var result = dBConnect.DeleteDocument("HoaDon", filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi delete hóa đơn: " + ex.Message);
                return false;
            }
        }

        public List<BsonDocument> searchHoaDon(string key)
        {
            string[] field = { "maHoaDon", "khachHang.maKhachHang", "khachHang.tenKhachHang", "nhanVien.maNhanVien", "nhanVien.tenNhanVien"};
            return dBConnect.SearchDocuments("HoaDon", key, field, "HoaDonSearchIndex");
        }

    }
}
