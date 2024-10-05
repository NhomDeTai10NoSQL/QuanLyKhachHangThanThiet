using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimPhuong.BUS;
using Sunny.UI;
namespace KimPhuong.GUI
{
    public partial class frmBanHang : UIPage
    {
        HoaDonBUS hoaDonBUS;
        SanPhamBUS sanPhamBUS;
        DatHangNCCBUS datHangNCCBUS;
        public frmBanHang()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
            sanPhamBUS = new SanPhamBUS();
            datHangNCCBUS = new DatHangNCCBUS();
            LoadHoaDon();
            LoadSanPham();
        }
        private void LoadSanPham()
        {
            var bsonDoc = sanPhamBUS.getAllSanPham();
            var sanPhamList = new List<object>();
            foreach (var document in bsonDoc)
            {
                string maSanPham = document["maSanPham"].AsString;
                int soLuongNhap = TinhSoLuongNhap(maSanPham);
                int soLuongBan = TinhSoLuongBan(maSanPham);
                int soLuongCon = soLuongNhap - soLuongBan;

                var sanPham = new
                {
                    MaSanPham = maSanPham,
                    TenSanPham = document["tenSanPham"].AsString,
                    GiaBan = document["giaBan"].AsInt32,
                    SoLuongCon = soLuongCon
                };
                sanPhamList.Add(sanPham);
            }
            dtgDanhSachSanPham.DataSource = sanPhamList;
            dtgDanhSachSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dtgDanhSachSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dtgDanhSachSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
            dtgDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dtgDanhSachSanPham.Columns["SoLuongCon"].HeaderText = "Số Lượng Còn";
        }
        private int TinhSoLuongNhap(string maSanPham)
        {
            var donDatHangList = datHangNCCBUS.getAllDonDatHang();
            int tongSoLuongNhap = 0;

            foreach (var donDatHang in donDatHangList)
            {
                if (donDatHang["trangThai"].AsString == "Đã hoàn thành")
                {
                    var chiTietList = donDatHang["chiTietDonDatHang"].AsBsonArray;
                    foreach (var chiTiet in chiTietList)
                    {
                        if (chiTiet["maSanPham"].AsString == maSanPham)
                        {
                            tongSoLuongNhap += chiTiet["soLuong"].AsInt32;
                        }
                    }
                }
            }

            return tongSoLuongNhap;
        }

        private int TinhSoLuongBan(string maSanPham)
        {
            var hoaDonList = hoaDonBUS.getAllHoaDon();
            int tongSoLuongBan = 0;

            foreach (var hoaDon in hoaDonList)
            {
                var chiTietList = hoaDon["chiTietHoaDon"].AsBsonArray;
                foreach (var chiTiet in chiTietList)
                {
                    if (chiTiet["maSanPham"].AsString == maSanPham)
                    {
                        tongSoLuongBan += chiTiet["soLuong"].AsInt32;
                    }
                }
            }

            return tongSoLuongBan;
        }
        private void LoadHoaDon()
        {
            var bsonDoc = hoaDonBUS.getAllHoaDon();
            var hoaDonList = new List<object>();

            foreach (var document in bsonDoc)
            {
                var hoaDon = new
                {
                    MaHoaDon = document.Contains("maHoaDon") ? document["maHoaDon"].AsString : string.Empty,
                    NgayLapHoaDon = document.Contains("ngayLapHoaDon") ? document["ngayLapHoaDon"].ToLocalTime().Date : DateTime.MinValue,
                    TongTien = document.Contains("tongTien") ? document["tongTien"].AsInt32 : 0,
                    DiemDaDung = document.Contains("diemDaDung") ? document["diemDaDung"].AsInt32 : 0,
                    DiemTichLuy = document.Contains("diemTichLuy") ? document["diemTichLuy"].AsInt32 : 0,
                    PhuongThucThanhToan = document.Contains("phuongThucThanhToan") ? document["phuongThucThanhToan"].AsString : string.Empty,
                    TenNhanVien = document.Contains("nhanVien") && document["nhanVien"].AsBsonDocument.Contains("tenNhanVien") ? document["nhanVien"]["tenNhanVien"].AsString : string.Empty,
                    TenKhachHang = document.Contains("khachHang") && document["khachHang"].AsBsonDocument.Contains("tenKhachHang") ? document["khachHang"]["tenKhachHang"].AsString : string.Empty,
                    KhuyenMai = document.Contains("khuyenMai") && !document["khuyenMai"].IsBsonNull ? document["khuyenMai"]["maKhuyenMai"].AsString : null
                };

                hoaDonList.Add(hoaDon);
            }

            dtgHoaDon.DataSource = hoaDonList;

            dtgHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            dtgHoaDon.Columns["NgayLapHoaDon"].HeaderText = "Ngày Lập Hóa Đơn";
            dtgHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dtgHoaDon.Columns["DiemDaDung"].HeaderText = "Điểm Đã Dùng";
            dtgHoaDon.Columns["DiemTichLuy"].HeaderText = "Điểm Tích Lũy";
            dtgHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương Thức Thanh Toán";
            dtgHoaDon.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dtgHoaDon.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dtgHoaDon.Columns["KhuyenMai"].HeaderText = "Khuyến Mãi";
        }



        private void frmBanHang_Load(object sender, EventArgs e)
        {

        }

        private void dtgHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgHoaDon.SelectedRows.Count > 0)
            {
                var selectedRow = dtgHoaDon.SelectedRows[0];
                string maHoaDon = selectedRow.Cells["MaHoaDon"].Value.ToString();
                LoadChiTietHoaDon(maHoaDon);

                string ngayLapHoaDonString = selectedRow.Cells["NgayLapHoaDon"].Value?.ToString();
                DateTime ngayLapHoaDon = string.IsNullOrEmpty(ngayLapHoaDonString) ? DateTime.MinValue : Convert.ToDateTime(ngayLapHoaDonString);
                string tongTienString = selectedRow.Cells["TongTien"].Value?.ToString();
                int tongTien = string.IsNullOrEmpty(tongTienString) ? 0 : Convert.ToInt32(tongTienString);
                string diemDaDungString = selectedRow.Cells["DiemDaDung"].Value?.ToString();
                int diemDaDung = string.IsNullOrEmpty(diemDaDungString) ? 0 : Convert.ToInt32(diemDaDungString);
                string diemTichLuyString = selectedRow.Cells["DiemTichLuy"].Value?.ToString();
                string phuongThucThanhToan = selectedRow.Cells["PhuongThucThanhToan"].Value?.ToString() ?? string.Empty;
                string tenNhanVien = selectedRow.Cells["TenNhanVien"].Value?.ToString() ?? string.Empty;
                string tenKhachHang = selectedRow.Cells["TenKhachHang"].Value?.ToString() ?? string.Empty;
                string khuyenMai = selectedRow.Cells["KhuyenMai"].Value?.ToString() ?? string.Empty;

                txtMaHD.Text = maHoaDon;
                txtNgay.Text = ngayLapHoaDon.ToString("dd/MM/yyyy");
                txtTT.Text = tongTien.ToString("N0");
                txtDiemDung.Text = diemDaDung.ToString();
                txtThanhToan.Text = phuongThucThanhToan;
                txtNV.Text = tenNhanVien;
                txtKH.Text = tenKhachHang;
                txtKM.Text = khuyenMai;
            }
        }
        private void LoadChiTietHoaDon(string maHoaDon)
        {
            var hoaDon = hoaDonBUS.getHoaDonByMa(maHoaDon);

            if (hoaDon != null && hoaDon.Contains("chiTietHoaDon"))
            {
                var chiTietList = new List<object>();

                foreach (var chiTiet in hoaDon["chiTietHoaDon"].AsBsonArray)
                {
                    var chiTietHoaDon = new
                    {
                        MaSanPham = chiTiet["maSanPham"].AsString,
                        TenSanPham = chiTiet["tenSanPham"].AsString,
                        SoLuong = chiTiet["soLuong"].AsInt32,
                        DonGia = chiTiet["donGia"].AsInt32,
                        ThanhTien = chiTiet["thanhTien"].AsInt32
                    };

                    chiTietList.Add(chiTietHoaDon);
                }

                dtgChiTietHD.DataSource = chiTietList;

                dtgChiTietHD.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                dtgChiTietHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                dtgChiTietHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                dtgChiTietHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                dtgChiTietHD.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dtgChiTietHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void dtgChiTietHD_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgChiTietHD.SelectedRows.Count > 0)
            {
                var selectedRow = dtgChiTietHD.SelectedRows[0];

                string maSanPham = selectedRow.Cells["MaSanPham"].Value?.ToString() ?? string.Empty;
                string tenSanPham = selectedRow.Cells["TenSanPham"].Value?.ToString() ?? string.Empty;
                string soLuongString = selectedRow.Cells["SoLuong"].Value?.ToString();
                int soLuong = string.IsNullOrEmpty(soLuongString) ? 0 : Convert.ToInt32(soLuongString);
                string donGiaString = selectedRow.Cells["DonGia"].Value?.ToString();
                int donGia = string.IsNullOrEmpty(donGiaString) ? 0 : Convert.ToInt32(donGiaString);
                string thanhTienString = selectedRow.Cells["ThanhTien"].Value?.ToString();
                int thanhTien = string.IsNullOrEmpty(thanhTienString) ? 0 : Convert.ToInt32(thanhTienString);

                txtSanPhamCT.Text = tenSanPham;
                txtSoLuongCT.Text = soLuong.ToString();
                txtDonGiaCT.Text = donGia.ToString("N0");
                txtThanhTienCT.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtSanPhamCT.Text = string.Empty;
                txtSoLuongCT.Text = string.Empty;
                txtDonGiaCT.Text = string.Empty;
                txtThanhTienCT.Text = string.Empty;
            }
        }
    }
}
