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
    public class NhanVienBUS
    {
        NhanVienDAO nhanVienDAO;
        public NhanVienBUS() {
            nhanVienDAO = new NhanVienDAO();
        }

        public DataTable getALlNhanVien ()
        {
            return nhanVienDAO.getALLNhanVien();
        }
        public bool AddNhanVien(string tenNhanVien, string gioiTinh, DateTime ngaySinh, string soDienThoai, string email, string chucVu, int mucLuong, string taiKhoan, string matKhau)
        {
            return nhanVienDAO.AddNhanVien(tenNhanVien, gioiTinh, ngaySinh, soDienThoai, email, chucVu, mucLuong, taiKhoan, matKhau);   
        }
        public bool DeleteNhanVien(string maNhanVien)
        {
            return nhanVienDAO.DeleteNhanVien(maNhanVien);
        }
        public bool UpdateNhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, DateTime? ngaySinh, string soDienThoai, string email, string chucVu, int mucLuong)
        {
            return nhanVienDAO.UpdateNhanVien(maNhanVien, tenNhanVien, gioiTinh,ngaySinh,soDienThoai, email,chucVu, mucLuong);  
        }
        public bool KiemTraTrungSDT(string soDienThoai)
        {
            return nhanVienDAO.KiemTraTrungSDT(soDienThoai);
        }
        public BsonDocument GetNhanVienBySDT(string soDienThoai)
        {
            return nhanVienDAO.GetNhanVienBySDT(soDienThoai);
        }
        public BsonDocument GetNhanVienByTaiKhoan(string taiKhoan)
        {
            return nhanVienDAO.GetNhanVienByTaiKhoan(taiKhoan);
        }
        public bool UpdateMatKhau(string taiKhoan, string matKhau)
        {
            return nhanVienDAO.UpdateMatKhau(taiKhoan, matKhau);
        }
    }
}
