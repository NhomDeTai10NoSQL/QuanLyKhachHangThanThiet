﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimPhuong.BUS;
using MongoDB.Bson;
using Sunny.UI;
using Sunny.UI.Win32;
using Khoa.GUI;
using MongoDB.Driver;

namespace KimPhuong.GUI
{
    public partial class frmBanHang : UIPage
    {
        public string soDienThoaiKH;
        protected string taiKhoan;
        HoaDonBUS hoaDonBUS;
        SanPhamBUS sanPhamBUS;
        DatHangNCCBUS datHangNCCBUS;
        KhachHangBUS khachHangBUS;
        public frmBanHang()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
            sanPhamBUS = new SanPhamBUS();
            datHangNCCBUS = new DatHangNCCBUS();
            khachHangBUS = new KhachHangBUS();
            loadHoaDon();
            loadSanPham();
        }
        public frmBanHang(string taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            hoaDonBUS = new HoaDonBUS();
            sanPhamBUS = new SanPhamBUS();
            datHangNCCBUS = new DatHangNCCBUS();
            khachHangBUS = new KhachHangBUS();
            loadHoaDon();
            loadSanPham();
            intSoLuongThem.Value = 1;
            dtgGioHang.RowsAdded += dtgGioHang_RowsAdded;
            dtgGioHang.RowsRemoved += dtgGioHang_RowsRemoved;
        }
        private void loadSanPham()
        {
            var bsonDoc = sanPhamBUS.getAllSanPham();
            var sanPhamList = new List<object>();
            foreach (var document in bsonDoc)
            {
                string maSanPham = document["maSanPham"].AsString;
                int soLuongNhap = tinhSoLuongNhap(maSanPham);
                int soLuongBan = tinhSoLuongBan(maSanPham);
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

        private int tinhSoLuongNhap(string maSanPham)
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

        private int tinhSoLuongBan(string maSanPham)
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
        private void loadHoaDon()
        {
            try
            {
                var bsonDoc = hoaDonBUS.getAllHoaDon();
                var hoaDonList = new List<object>();
                foreach (var document in bsonDoc)
                {
                    var hoaDon = new
                    {
                        MaHoaDon = document.Contains("maHoaDon") ? document["maHoaDon"].AsString : string.Empty,
                        NgayLapHoaDon = document.Contains("ngayLapHoaDon") && !document["ngayLapHoaDon"].IsBsonNull
                            ? document["ngayLapHoaDon"].ToLocalTime().Date
                            : (DateTime?) null,
                        TongTien = document.Contains("tongTien") && !document["tongTien"].IsBsonNull
                            ? document["tongTien"].AsInt32
                            : (int?) null,
                        TenNhanVien = document.Contains("nhanVien") && document["nhanVien"].AsBsonDocument.Contains("tenNhanVien")
                            ? document["nhanVien"]["tenNhanVien"].AsString
                            : string.Empty,
                        TenKhachHang = document.Contains("khachHang") && !document["khachHang"].IsBsonNull && document["khachHang"].AsBsonDocument.Contains("tenKhachHang")
                            ? document["khachHang"]["tenKhachHang"].AsString
                            : string.Empty,
                        DiemDaDung = document.Contains("diemDaDung") && !document["diemDaDung"].IsBsonNull
                            ? document["diemDaDung"].AsInt32
                            : (int?) null,
                        PhuongThucThanhToan = document.Contains("phuongThucThanhToan") && !document["phuongThucThanhToan"].IsBsonNull
                            ? document["phuongThucThanhToan"].AsString
                            : string.Empty,
                        TongPhaiTra = document.Contains("tongPhaiTra") && !document["tongPhaiTra"].IsBsonNull
                            ? document["tongPhaiTra"].AsInt32
                            : (int?) 0,

                    };
                    hoaDonList.Add(hoaDon);
                }
                dtgHoaDon.DataSource = hoaDonList;
                dtgHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dtgHoaDon.Columns["NgayLapHoaDon"].HeaderText = "Ngày Lập Hóa Đơn";
                dtgHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dtgHoaDon.Columns["TongPhaiTra"].HeaderText = "Tổng Phải Trả";
                dtgHoaDon.Columns["DiemDaDung"].HeaderText = "Điểm Đã Dùng";
                dtgHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương Thức Thanh Toán";
                dtgHoaDon.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                dtgHoaDon.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";

                dtgHoaDon.Columns["NgayLapHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dtgHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dtgHoaDon.Columns["TongPhaiTra"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmBanHang_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadHoaDon();
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
                string tongPhaiTraString = selectedRow.Cells["TongPhaiTra"].Value?.ToString();
                int tongTien = string.IsNullOrEmpty(tongTienString) ? 0 : Convert.ToInt32(tongTienString);
                int tongPhaiTra = string.IsNullOrEmpty(tongPhaiTraString) ? 0 : Convert.ToInt32(tongPhaiTraString);
                string diemDaDungString = selectedRow.Cells["DiemDaDung"].Value?.ToString();
                int diemDaDung = string.IsNullOrEmpty(diemDaDungString) ? 0 : Convert.ToInt32(diemDaDungString);
                string phuongThucThanhToan = selectedRow.Cells["PhuongThucThanhToan"].Value?.ToString() ?? string.Empty;
                string tenNhanVien = selectedRow.Cells["TenNhanVien"].Value?.ToString() ?? string.Empty;
                string tenKhachHang = selectedRow.Cells["TenKhachHang"].Value?.ToString() ?? string.Empty;


                txtMaHD.Text = maHoaDon;
                txtNgay.Text = ngayLapHoaDon.ToString("dd/MM/yyyy");
                txtTT.Text = tongTien.ToString("N0");
                txtDiemDung.Text = diemDaDung.ToString();
                txtThanhToan.Text = phuongThucThanhToan;
                txtNV.Text = tenNhanVien;
                txtKH.Text = tenKhachHang;
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

                if (hoaDon.Contains("chiTietHoaDon") && hoaDon["chiTietHoaDon"].IsBsonArray && hoaDon["chiTietHoaDon"].AsBsonArray.Count != 0)
                {
                    dtgChiTietHD.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                    dtgChiTietHD.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dtgChiTietHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dtgChiTietHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dtgChiTietHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                    dtgChiTietHD.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dtgChiTietHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
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

        private void btnTimSanPham_Click(object sender, EventArgs e)
        {
            string key = txtTimSanPham.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<BsonDocument> searchResults = sanPhamBUS.searchSanPham(key);
            var sanPhamList = new List<object>();
            foreach (var document in searchResults)
            {
                string maSanPham = document["maSanPham"].AsString;
                int soLuongNhap = tinhSoLuongNhap(maSanPham);
                int soLuongBan = tinhSoLuongBan(maSanPham);
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

            if (sanPhamList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadSanPham();
            }
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            btnThemVaoGioHang.Enabled = btnXoaSanPhamKhoiGio.Enabled = btnThanhToan.Enabled =
                btnTimKhachHang.Enabled = btnDungDiemTichLuy.Enabled = true;
            lblSDT.Enabled = lblDiemTichLuy.Enabled = lblHoTenKH.Enabled = true;
            txtSoDienThoai.Enabled = true;
            cbPhuongThucThanhToan.Enabled = true;
            btnLuuTam.Enabled = true;
            btnTaoDon.Enabled = false;
            lapHoaDonMoi();
            intSoLuongThem.Enabled = true;
            loadHoaDon();
        }
        private void lapHoaDonMoi()
        {
            var maHoaDon = hoaDonBUS.GetMaxMaHoaDon();
            txtMaHoaDon.Text = maHoaDon.ToString();
            var nhanVienList = hoaDonBUS.getMaNhanVienByTaiKhoan(taiKhoan);
            string maNhanVien = nhanVienList["maNhanVien"].AsString;
            string tenNhanVien = nhanVienList["tenNhanVien"].AsString;
            DateTime ngayMua = DateTime.Now;
            bool kq = hoaDonBUS.addHoaDon(maHoaDon, ngayMua, maNhanVien, tenNhanVien, 0, 0);
            if (kq)
            {
                MessageBox.Show("Đã lập một hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi lập một hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (dtgGioHang.Columns.Count == 0)
            {
                dtgGioHang.Columns.Add("MaSanPham", "Mã Sản Phẩm");
                dtgGioHang.Columns.Add("TenSanPham", "Tên Sản Phẩm");
                dtgGioHang.Columns.Add("SoLuong", "Số Lượng");
                dtgGioHang.Columns.Add("DonGia", "Đơn Giá");
                dtgGioHang.Columns.Add("ThanhTien", "Thành Tiền");

                dtgGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dtgGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            string tenSanPham = txtSanPham.Text;
            var sanPham = sanPhamBUS.getMaSPByTenSP(tenSanPham);
            string maSanPham = sanPham["maSanPham"].AsString;

            int soLuongThem = (int) intSoLuongThem.Value;

            string giaBanText = txtGiaBan.Text.Replace(",", "").Trim();
            if (!int.TryParse(giaBanText, out int donGia))
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtgDanhSachSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgDanhSachSanPham.SelectedRows[0];
                if (!int.TryParse(selectedRow.Cells["SoLuongCon"].Value.ToString(), out int soLuongCon))
                {
                    MessageBox.Show("Số lượng còn lại không hợp lệ. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool daCo = false;
                foreach (DataGridViewRow row in dtgGioHang.Rows)
                {
                    if (row.Cells["TenSanPham"].Value.ToString() == tenSanPham)
                    {
                        daCo = true;
                        int soLuongTrongGio = (int) row.Cells["SoLuong"].Value;

                        if (soLuongTrongGio + soLuongThem > soLuongCon)
                        {
                            MessageBox.Show($"Bạn đã thêm {soLuongTrongGio} sản phẩm này vào giỏ hàng.\nSản phẩm này chỉ còn {soLuongCon} sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        row.Cells["SoLuong"].Value = soLuongTrongGio + soLuongThem;
                        row.Cells["ThanhTien"].Value = (soLuongTrongGio + soLuongThem) * donGia;
                        break;
                    }
                }

                if (!daCo)
                {
                    if (soLuongThem <= soLuongCon)
                    {
                        int thanhTien = soLuongThem * donGia;
                        dtgGioHang.Rows.Add(maSanPham, tenSanPham, soLuongThem, donGia, thanhTien);
                    }
                    else
                    {
                        MessageBox.Show($"Sản phẩm chỉ còn {soLuongCon} sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Chưa nhập số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string sdt = txtSoDienThoai.Text.Trim();
                var KhachHang = khachHangBUS.getKHBySDT(sdt);
                if (KhachHang == null)
                {
                    DialogResult kq = MessageBox.Show("Khách hàng chưa có thông tin.\n Bạn có muốn thêm khách hàng mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (kq == DialogResult.Yes)
                    {
                        frmKhachHangMoi khachHangMoi = new frmKhachHangMoi();
                        khachHangMoi.SoDienThoai = txtSoDienThoai.Text.Trim();
                        khachHangMoi.Show();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    string tenKhachHang = KhachHang["TenKhachHang"].AsString;
                    int diemTichLuy = KhachHang["DiemTichLuyCon"].AsInt32;

                    txtHoTenKhachHang.Text = tenKhachHang;
                    txtDiemTichLuy.Text = diemTichLuy.ToString();
                }

            }
        }

        private void btnDungDiemTichLuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Chưa có thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDiemTichLuy.Text == "0")
            {
                MessageBox.Show("Khách hàng chưa có điểm tích lũy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập điểm tích lũy muốn sử dụng vào ô SỬ DỤNG ĐIỂM TÍCH LŨY bên dưới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDungDiemTichLuy.Enabled = true;

            }
            if (txtDungDiemTichLuy.Enabled)
            {
                btnDungDiemTichLuy.Selected = true;
            }
        }

        private void btnLuuTam_Click(object sender, EventArgs e)
        {
            lapChiTietHoaDonTam();
            loadHoaDon();
            clearGioHang();
        }
        private void lapChiTietHoaDonTam()
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            foreach (DataGridViewRow row in dtgGioHang.Rows)
            {
                if (!row.IsNewRow)
                {
                    string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    string tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int donGia = Convert.ToInt32(row.Cells["DonGia"].Value);
                    int thanhTien = Convert.ToInt32(row.Cells["ThanhTien"].Value);

                    bool sanPhamDaTonTai = hoaDonBUS.kiemTraTrungSanPham(maHoaDon, maSanPham);

                    bool kqChiTiet;
                    if (sanPhamDaTonTai)
                    {
                        kqChiTiet = hoaDonBUS.updateChiTietHoaDon(maHoaDon, maSanPham, soLuong, thanhTien);
                    }
                    else
                    {
                        kqChiTiet = hoaDonBUS.addChiTietHoaDon(maHoaDon, maSanPham, tenSanPham, soLuong, donGia, thanhTien);
                    }

                    if (!kqChiTiet)
                    {
                        MessageBox.Show("Có lỗi khi cập nhật chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dtgDanhSachSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDanhSachSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgDanhSachSanPham.SelectedRows[0];
                string maSanPham = selectedRow.Cells["MaSanPham"].Value.ToString();
                int giaBan = int.Parse(selectedRow.Cells["GiaBan"].Value.ToString());
                txtGiaBan.Text = giaBan.ToString("N0");
                string tenSanPham = selectedRow.Cells["TenSanPham"].Value.ToString();
                txtSanPham.Text = tenSanPham;
                int soLuongCon = int.Parse(selectedRow.Cells["SoLuongCon"].Value.ToString());
                intSoLuongThem.Maximum = soLuongCon;

            }
        }
        private void clearGioHang()
        {
            dtgGioHang.Rows.Clear();

            btnThemVaoGioHang.Enabled = btnXoaSanPhamKhoiGio.Enabled = btnThanhToan.Enabled =
               btnTimKhachHang.Enabled = btnDungDiemTichLuy.Enabled = btnThanhToan.Enabled = false;

            lblDiemTichLuy.Enabled = lblHoTenKH.Enabled = lblSDT.Enabled = false;

            txtDungDiemTichLuy.Enabled =
              txtSoDienThoai.Enabled = txtTongTien.Enabled = false;

            cbPhuongThucThanhToan.Enabled = false;

            btnLuuTam.Enabled = false;

            txtDungDiemTichLuy.Text =
           txtDiemTichLuy.Text = cbPhuongThucThanhToan.Text =
            txtSoDienThoai.Text = txtTongTien.Text = txtHoTenKhachHang.Text = txtMaHoaDon.Text = "";

            txtTongTien.Text = txtTongPhaiTra.Text = txtDungDiemTichLuy.Text = "0";

            btnTaoDon.Selected = false;

            btnTaoDon.Enabled = true;

            loadSanPham();
        }

        private void dtgGioHang_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            tinhtongTien();
            tinhTongPhaiTra();
        }
        private void tinhtongTien()
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dtgGioHang.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["ThanhTien"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["ThanhTien"].Value.ToString(), out int thanhTien))
                    {
                        tongTien += thanhTien;
                    }
                }
            }
            txtTongTien.Text = tongTien.ToString("N0");

        }

        private void tinhTongPhaiTra()
        {
            int tongPhaiTra = 0;
            if (!string.IsNullOrEmpty(txtDungDiemTichLuy.Text))
            {
                if (int.TryParse(txtTongTien.Text.Replace(",", "").Trim(), out int tongTien) &&
                    int.TryParse(txtDungDiemTichLuy.Text.Replace(",", "").Trim(), out int diemTichLuy))
                {
                    tongPhaiTra = tongTien - diemTichLuy;
                    if (tongPhaiTra < 0)
                    {
                        tongPhaiTra = 0;
                    }
                }
            }
            txtTongPhaiTra.Text = tongPhaiTra.ToString("N0");
        }

        private void dtgGioHang_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            tinhtongTien();
            tinhTongPhaiTra();
        }

        private void dtgGioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            tinhtongTien();
            tinhTongPhaiTra();
        }

        private void btnXoaSanPhamKhoiGio_Click(object sender, EventArgs e)
        {
            if (dtgGioHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgGioHang.SelectedRows[0];
                string sanPham = selectedRow.Cells["TenSanPham"].Value.ToString();

                DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {sanPham} khỏi giỏ hàng?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtgGioHang.SelectedRows)
                    {
                        dtgGioHang.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtTimSanPham.Text = "";
            loadSanPham();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtgGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống. Vui lòng thêm sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtHoTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(cbPhuongThucThanhToan.Text))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDon = txtMaHoaDon.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            int tongTien = int.Parse(txtTongTien.Text.Replace(",", "").Trim());

            int tienDiem = int.Parse(txtDungDiemTichLuy.Text.Replace(",", "").Trim());
            int diemDaDung = (int) (tienDiem / 1000);

            int tongPhaiTra = int.Parse(txtTongPhaiTra.Text.Replace(",", "").Trim());
            string phuongThucThanhToan = cbPhuongThucThanhToan.Text;
            BsonDocument khachHangDoc = null;

            foreach (DataGridViewRow row in dtgGioHang.Rows)
            {
                if (!row.IsNewRow)
                {
                    string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    string tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    int donGia = Convert.ToInt32(row.Cells["DonGia"].Value);
                    int thanhTien = Convert.ToInt32(row.Cells["ThanhTien"].Value);

                    bool kqChiTiet = hoaDonBUS.addChiTietHoaDon(maHoaDon, maSanPham, tenSanPham, soLuong, donGia, thanhTien);
                    if (!kqChiTiet)
                    {
                        MessageBox.Show($"Có lỗi khi thêm chi tiết hóa đơn cho sản phẩm {tenSanPham}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (!string.IsNullOrEmpty(soDienThoai))
            {
                var khachHang = khachHangBUS.getKHBySDT(soDienThoai);
                if (khachHang != null)
                {
                    string maKhachHang = khachHang["MaKhachHang"].AsString;
                    string tenKhachHang = khachHang["TenKhachHang"].AsString;
                    int diemTichLuyDB = khachHang["DiemTichLuy"].AsInt32;
                    khachHangDoc = new BsonDocument
            {
                { "maKhachHang", maKhachHang },
                { "tenKhachHang", tenKhachHang }
            };


                    int diemTichLuyHienTai = int.Parse(txtDiemTichLuy.Text);
                    int diemTichLuyCon = diemTichLuyHienTai + (tongTien / 100000);
                    int diemTichLuyMoi = diemTichLuyDB + (tongTien / 100000);
                    bool kqCapNhatKH = hoaDonBUS.updateDiemTichLuy(soDienThoai, diemTichLuyMoi, diemTichLuyCon);
                    if (diemTichLuyMoi >= 200)
                    {
                        bool kqCapNhatLoaiKH = hoaDonBUS.updateLoaiKH(soDienThoai);
                        if (!kqCapNhatLoaiKH)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật loại khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    if (!kqCapNhatKH)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật điểm tích lũy khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }


            bool kqCapNhat = hoaDonBUS.updateHoaDon(maHoaDon, tongTien, diemDaDung, phuongThucThanhToan, khachHangDoc, tongPhaiTra);
            if (kqCapNhat)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadHoaDon();
                clearGioHang();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thanh toán. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDungDiemTichLuy_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtDungDiemTichLuy.Text.Trim(), out int dungDiem) && int.TryParse(txtDiemTichLuy.Text.Trim(), out int diemtichLuy))
            {
                if (dungDiem > diemtichLuy)
                {
                    MessageBox.Show("Khách hàng không đủ điểm tích lũy để dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dungDiem > 200)
                {
                    MessageBox.Show("Chỉ được dùng tối đa 200 điểm cho 1 đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dungDiem % 10 != 0)
                {
                    MessageBox.Show("Dùng điểm chia hết cho 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    diemtichLuy -= dungDiem;
                    txtDiemTichLuy.Text = diemtichLuy.ToString();
                    int quyDoiTien = dungDiem * 1000;
                    txtDungDiemTichLuy.Text = quyDoiTien.ToString("N0");
                    txtDungDiemTichLuy.Enabled = false;
                    btnDungDiemTichLuy.Selected = false;
                }
            }
        }

        private void txtDungDiemTichLuy_TextChanged(object sender, EventArgs e)
        {
            tinhTongPhaiTra();
        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {
            if (dtgHoaDon.SelectedRows.Count > 0)
            {
                string maHoaDon = txtMaHD.Text.Trim();
                var hoaDon = hoaDonBUS.getHoaDonByMa(maHoaDon);

                if (hoaDon != null && hoaDon["tongTien"].AsInt32 == 0)
                {
                    tabBanHang.SelectedTab = tabBan;
                    txtMaHoaDon.Text = maHoaDon;
                    loadForm();
                    ChuyenChiTietHoaDonSangGioHang(maHoaDon);

                    btnThemVaoGioHang.Enabled = btnXoaSanPhamKhoiGio.Enabled = btnThanhToan.Enabled =
                        btnTimKhachHang.Enabled = btnDungDiemTichLuy.Enabled = true;
                    lblSDT.Enabled = lblDiemTichLuy.Enabled = lblHoTenKH.Enabled = true;
                    txtSoDienThoai.Enabled = true;
                    cbPhuongThucThanhToan.Enabled = true;
                    btnLuuTam.Enabled = true;
                    btnTaoDon.Enabled = false;
                    intSoLuongThem.Enabled = true;

                    MessageBox.Show("Bạn đang chỉnh sửa đơn hàng " + maHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể sửa hóa đơn đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ChuyenChiTietHoaDonSangGioHang(string maHoaDon)
        {
            if (dtgGioHang.Columns.Count == 0)
            {
                dtgGioHang.Columns.Add("MaSanPham", "Mã Sản Phẩm");
                dtgGioHang.Columns.Add("TenSanPham", "Tên Sản Phẩm");
                dtgGioHang.Columns.Add("SoLuong", "Số Lượng");
                dtgGioHang.Columns.Add("DonGia", "Đơn Giá");
                dtgGioHang.Columns.Add("ThanhTien", "Thành Tiền");

                dtgGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dtgGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            var hoaDon = hoaDonBUS.getHoaDonByMa(maHoaDon);
            if (hoaDon != null && hoaDon.Contains("chiTietHoaDon"))
            {
                dtgGioHang.Rows.Clear();

                foreach (var chiTiet in hoaDon["chiTietHoaDon"].AsBsonArray)
                {
                    string maSanPham = chiTiet["maSanPham"].AsString;
                    string tenSanPham = chiTiet["tenSanPham"].AsString;
                    int soLuong = chiTiet["soLuong"].AsInt32;
                    int donGia = chiTiet["donGia"].AsInt32;
                    int thanhTien = chiTiet["thanhTien"].AsInt32;

                    dtgGioHang.Rows.Add(maSanPham, tenSanPham, soLuong, donGia, thanhTien);
                }

                tinhtongTien();
                tinhTongPhaiTra();
            }
        }

        private void loadForm()
        {
            txtSoDienThoai.Text = "";
            txtHoTenKhachHang.Text = "";
            txtDiemTichLuy.Text = "0";
            txtDungDiemTichLuy.Text = "0";
            cbPhuongThucThanhToan.SelectedIndex = -1;
        }

        private void btnXoaDonHang_Click(object sender, EventArgs e)
        {
            if (dtgHoaDon.SelectedRows.Count > 0)
            {
                string maHoaDon = txtMaHD.Text.Trim();
                var hoaDon = hoaDonBUS.getHoaDonByMa(maHoaDon);

                if (hoaDon != null)
                {
                    if (hoaDon.Contains("tongTien") && hoaDon["tongTien"].AsInt32 != 0)
                    {
                        MessageBox.Show("Không thể xóa đơn hàng đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng {maHoaDon}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        bool kqXoa = hoaDonBUS.deleteHoaDon(maHoaDon);
                        if (kqXoa)
                        {
                            MessageBox.Show("Đã xóa đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadHoaDon();
                            clearForm();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa đơn hàng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void clearForm()
        {
            txtMaHD.Text = "";
            txtNgay.Text = "";
            txtTT.Text = "";
            txtDiemDung.Text = "";
            txtThanhToan.Text = "";
            txtNV.Text = "";
            txtKH.Text = "";
            dtgChiTietHD.DataSource = null;
            txtSanPhamCT.Text = "";
            txtSoLuongCT.Text = "";
            txtDonGiaCT.Text = "";
            txtThanhTienCT.Text = "";
        }

        private void btnReloadDanhMuc_Click(object sender, EventArgs e)
        {
            txtTimHD.Text = string.Empty;
            loadHoaDon();
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            string searchKey = txtTimHD.Text.Trim();
            if (string.IsNullOrEmpty(searchKey))
            {
                MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<BsonDocument> searchResults = hoaDonBUS.searchHoaDon(searchKey);

            if (searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hoaDonList = new List<object>();
            foreach (var document in searchResults)
            {
                var hoaDon = new
                {
                    MaHoaDon = document.Contains("maHoaDon") ? document["maHoaDon"].AsString : string.Empty,
                    NgayLapHoaDon = document.Contains("ngayLapHoaDon") && !document["ngayLapHoaDon"].IsBsonNull
                        ? document["ngayLapHoaDon"].ToLocalTime()
                        : (DateTime?) null,
                    TongTien = document.Contains("tongTien") && !document["tongTien"].IsBsonNull
                        ? document["tongTien"].AsInt32
                        : (int?) null,
                    TenNhanVien = document.Contains("nhanVien") && document["nhanVien"].AsBsonDocument.Contains("tenNhanVien")
                        ? document["nhanVien"]["tenNhanVien"].AsString
                        : string.Empty,
                    TenKhachHang = document.Contains("khachHang") && !document["khachHang"].IsBsonNull && document["khachHang"].AsBsonDocument.Contains("tenKhachHang")
                        ? document["khachHang"]["tenKhachHang"].AsString
                        : string.Empty,
                    DiemDaDung = document.Contains("diemDaDung") && !document["diemDaDung"].IsBsonNull
                        ? document["diemDaDung"].AsInt32
                        : (int?) null,
                    PhuongThucThanhToan = document.Contains("phuongThucThanhToan") && !document["phuongThucThanhToan"].IsBsonNull
                        ? document["phuongThucThanhToan"].AsString
                        : string.Empty,
                    TongPhaiTra = document.Contains("tongPhaiTra") && !document["tongPhaiTra"].IsBsonNull
                        ? document["tongPhaiTra"].AsInt32
                        : (int?) null,
                };
                hoaDonList.Add(hoaDon);
            }

            dtgHoaDon.DataSource = hoaDonList;
            dtgHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            dtgHoaDon.Columns["NgayLapHoaDon"].HeaderText = "Ngày Lập Hóa Đơn";
            dtgHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dtgHoaDon.Columns["TongPhaiTra"].HeaderText = "Tổng Phải Trả";
            dtgHoaDon.Columns["DiemDaDung"].HeaderText = "Điểm Đã Dùng";
            dtgHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương Thức Thanh Toán";
            dtgHoaDon.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dtgHoaDon.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";

            dtgHoaDon.Columns["NgayLapHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dtgHoaDon.Columns["TongPhaiTra"].DefaultCellStyle.Format = "N0";
        }
    }
}
