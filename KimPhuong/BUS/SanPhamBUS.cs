using KimPhuong.DAO;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable getAll()
        {
            return sanPhamDAO.getAll();
        }
        public List<BsonDocument> searchSanPham(string key)
        {
            return sanPhamDAO.searchSanPham(key);
        }
        public bool themSanPham(string maSanPham, string tenSanPham, string maVach,
        int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
        int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
        string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            return sanPhamDAO.themSanPham(maSanPham, tenSanPham, maVach, giaBan, ngaySanXuat.Date, xuatXu, moTa, maDanhMuc, tenDanhMuc, maNhaCungCap,tenNhaCungCap,maBaoHanh, thoiGianBaoHanh);
        }

        public string GetNextMaSanPham()
        {
            return sanPhamDAO.GetNextMaSanPham();
        }
        public bool xoaSanPham(string maSanPham)
        {
            return sanPhamDAO.xoaSanPham(maSanPham);
        }
        public bool suaSanPham(string maSanPham, string tenSanPham, string maVach,
   int giaBan, DateTime ngaySanXuat, string xuatXu, string moTa,
   int maDanhMuc, string tenDanhMuc, int maNhaCungCap,
   string tenNhaCungCap, string maBaoHanh, int thoiGianBaoHanh)
        {
            return sanPhamDAO.updateSanPham(maSanPham, tenSanPham, maVach, giaBan, ngaySanXuat, xuatXu, moTa, maDanhMuc, tenDanhMuc, maNhaCungCap, tenNhaCungCap, maBaoHanh, thoiGianBaoHanh);
        }
        public BsonDocument getMaSPByTenSP(string tensp)
        {
            return sanPhamDAO.getMaSPByTenSP(tensp);
        }
    }
}
