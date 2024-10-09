using Danh.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.BUS
{
    internal class NhapHangBUS
    {
        NhapHangDAO nhapHangDAO;
        public NhapHangBUS() {
            nhapHangDAO = new NhapHangDAO();
        }
        public DataTable getAll()
        {
            return nhapHangDAO.getAll();
        }
        public DataTable getNhapHang()
        {
            return nhapHangDAO.getNhapHang();
        }
        public DataTable getChiTietNhapHang(string maDonDatHang)
        {
            return nhapHangDAO.getChiTietNhapHang(maDonDatHang);
        }
        public bool AddDonNhapHang(string maDatHang, string maNhaCungCap, string tenNhaCungCap, DateTime ngayDatHang)
        {
            return nhapHangDAO.AddDonNhapHang(maDatHang, maNhaCungCap, tenNhaCungCap, ngayDatHang);
        }
        public bool UpdateDonNhapHang(string maDonDatHang, string trangThai)
        {
            return nhapHangDAO.UpdateDonNhapHang(maDonDatHang, trangThai);
        }
        public DataTable SearchDonNhapHang(string key)
        {
            return nhapHangDAO.SearchDonNhapHang(key);
        }
        public bool addChiTietDonNhapHang(string maDonDatHang, string maSanPham, string tenSanPham, int soLuong, int donGia, out string errorMessage)
        {
            return nhapHangDAO.AddChiTietDonNhapHang(maDonDatHang, maSanPham, tenSanPham, soLuong, donGia, out errorMessage);
        }
        public DataTable getAllChiTiet(string maDonDatHang)
        {
            return nhapHangDAO.getAllChiTiet(maDonDatHang);
        }
        public string GetNextMaDonHang()
        {
            return nhapHangDAO.GetNextMaDonHang();
        }
    }
}
