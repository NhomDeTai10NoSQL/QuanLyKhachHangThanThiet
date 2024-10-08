using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO hoaDonDAO;
        public HoaDonBUS()
        {
            hoaDonDAO = new HoaDonDAO();
        }
        public List<BsonDocument> getAllHoaDon()
        {
            return hoaDonDAO.getAllHoaDon();
        }
        public BsonDocument getHoaDonByMa(string maHoaDon)
        {
            return hoaDonDAO.getHoaDonByMa(maHoaDon);
        }
        public string GetMaxMaHoaDon()
        {
            return hoaDonDAO.GetMaxMaHoaDon();
        }
        public BsonDocument getMaNhanVienByTaiKhoan(string taiKhoan)
        {
            return hoaDonDAO.getMaNhanVienByTaiKhoan(taiKhoan);
        }
        public bool addHoaDon(string maHoaDon, DateTime ngayLapHoaDon, string maNhanVien, string tenNhanVien, int tongTien, int tongPhaiTra)
        {
            return hoaDonDAO.addHoaDon(maHoaDon, ngayLapHoaDon, maNhanVien, tenNhanVien, tongTien, tongPhaiTra);
        }
        public bool kiemTraTrungSanPham(string maHoaDon, string maSanPham)
        {
            return hoaDonDAO.kiemTraTrungSanPham(maHoaDon, maSanPham);
        }
        public bool addChiTietHoaDon(string maHoaDon, string maSanPham, string tenSanPham, int soLuong, int donGia, int thanhTien)
        {
            return hoaDonDAO.addChiTietHoaDon(maHoaDon, maSanPham, tenSanPham, soLuong, donGia, thanhTien);
        }
        public bool updateChiTietHoaDon(string maHoaDon, string maSanPham, int soLuong, int thanhTien)
        {
            return hoaDonDAO.updateChiTietHoaDon(maHoaDon, maSanPham, soLuong, thanhTien);
        }

        public bool updateDiemTichLuy(string soDienThoai, int diemTichLuyMoi, int diemCon)
        {
            return hoaDonDAO.updateDiemTichLuy(soDienThoai, diemTichLuyMoi, diemCon);
        }
        public bool updateHoaDon(string maHoaDon, int tongTien, int diemDaDung, string phuongThucThanhToan, BsonDocument khachHang, int tongPhaiTra)
        {
            return hoaDonDAO.updateHoaDon(maHoaDon, tongTien, diemDaDung, phuongThucThanhToan, khachHang, tongPhaiTra);
        }
        public bool deleteHoaDon(string maHoaDon)
        {
            return hoaDonDAO.deleteHoaDon(maHoaDon);
        }
        public List<BsonDocument> searchHoaDon(string key)
        {
            return hoaDonDAO.searchHoaDon(key);
        }
        public bool updateLoaiKH(string soDienThoai)
        {
            return hoaDonDAO.updateLoaiKH(soDienThoai);
        }
    }
}
