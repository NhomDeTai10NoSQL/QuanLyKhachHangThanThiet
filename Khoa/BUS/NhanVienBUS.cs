using Khoa.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa.BUS
{
    internal class NhanVienBUS
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

    }
}
