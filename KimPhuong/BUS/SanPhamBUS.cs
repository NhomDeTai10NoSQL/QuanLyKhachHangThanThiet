using KimPhuong.DAO;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimPhuong.BUS
{
    public class SanPhamBUS
    {
        SanPhamDAO sanPhamDAO;
        public SanPhamBUS()
        {
            sanPhamDAO = new SanPhamDAO();
        }
        public List<BsonDocument> getAllSanPham()
        {
            return sanPhamDAO.getAllSanPham();
        }
        public List<BsonDocument> searchSanPham(string key)
        {
            return sanPhamDAO.searchSanPham(key);
        }
        public void themSanPham(string maSanPham, string tenSanPham, string maVach,
        int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
        int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
        string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            sanPhamDAO.themSanPham(maSanPham, tenSanPham, maVach, giaBan, ngaySanXuat.Date, xuatXu, moTa, maDanhMuc, tenDanhMuc, maNhaCungCap,tenNhaCungCap,maBaoHanh, thoiGianBaoHanh);
        }

        public string GetNextMaSanPham()
        {
            return sanPhamDAO.GetNextMaSanPham();
        }
    }
}
