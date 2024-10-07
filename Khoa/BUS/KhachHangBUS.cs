using Khoa.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa.BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO khachHangDAO;
        public KhachHangBUS()
        {
            khachHangDAO = new KhachHangDAO();
        }
        public DataTable getAllKhachHang()
        {
            return khachHangDAO.getAllKhachHang();
        }
        public bool AddKhachHang(string tenKhachHang, DateTime ngaySinh, string soDienThoai, int diemTichLuy, string trangThai, string loaiKhachHang)
        {
            return khachHangDAO.AddKhachHang(tenKhachHang, ngaySinh, soDienThoai, diemTichLuy, trangThai, loaiKhachHang);
        }
        public bool UpdateKhachHang(string maKhachHang, string tenkh, DateTime? ngaysinh, string sdt, int diem, string trangthai, string loaiKH)
        {
            return khachHangDAO.UpdateKhachHang(maKhachHang, tenkh, ngaysinh, sdt, diem, trangthai, loaiKH);
        }
        public bool hideKhachHang(string maKhachHang)
        {
            return khachHangDAO.hideKhachHang(maKhachHang);
        }
        public bool showKhachHang(string maKhachHang)
        {
            return khachHangDAO.showKhachHang(maKhachHang);
        }
        public DataTable SearchKhachHang(string searchValue)
        {
            return khachHangDAO.SearchKhachHang(searchValue);
        }
        public DataTable locKhachHang(string searchValue)
        {
            return khachHangDAO.locKhachHang(searchValue);
        }
        public bool DeleteKhachHang(string maKhachHang)
        {
            return khachHangDAO.DeleteKhachHang(maKhachHang);
        }
        public bool KiemTraTrungSDT(string soDienThoai)
        {
            return khachHangDAO.KiemTraTrungSDT(soDienThoai);
        }
        public BsonDocument GetKhachHangBySDT(string soDienThoai)
        {
            return khachHangDAO.GetKhachHangBySDT(soDienThoai);
        }
    }
}
