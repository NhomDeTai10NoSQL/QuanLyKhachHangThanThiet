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
        public bool addChiTietHoaDon(string maHoaDon, List<BsonDocument> chiTietHoaDonList)
        {
            return hoaDonDAO.addChiTietHoaDon(maHoaDon, chiTietHoaDonList);
        }
        public bool addHoaDon(string maHoaDon, DateTime ngayLapHoaDon, string maNhanVien, string tenNhanVien)
        {
            return hoaDonDAO.addHoaDon(maHoaDon, ngayLapHoaDon,maNhanVien, tenNhanVien);
        }
    }
}
