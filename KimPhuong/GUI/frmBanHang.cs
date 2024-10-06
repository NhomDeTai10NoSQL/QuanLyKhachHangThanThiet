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
using MongoDB.Bson;
using Sunny.UI;
using Sunny.UI.Win32;
namespace KimPhuong.GUI
{
    public partial class frmBanHang : UIPage
    {
        protected string taiKhoan;
        HoaDonBUS hoaDonBUS;
        SanPhamBUS sanPhamBUS;
        DatHangNCCBUS datHangNCCBUS;
        public frmBanHang()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
            sanPhamBUS = new SanPhamBUS();
            datHangNCCBUS = new DatHangNCCBUS();
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
            loadHoaDon();
            loadSanPham();
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
                            ? document["ngayLapHoaDon"].ToLocalTime()
                            : (DateTime?) null,
                        TongTien = document.Contains("tongTien") && !document["tongTien"].IsBsonNull
                            ? document["tongTien"].AsInt32
                            : (int?) null,
                        DiemDaDung = document.Contains("diemDaDung") && !document["diemDaDung"].IsBsonNull
                            ? document["diemDaDung"].AsInt32
                            : (int?) null,
                        DiemTichLuy = document.Contains("diemTichLuy") && !document["diemTichLuy"].IsBsonNull
                            ? document["diemTichLuy"].AsInt32
                            : (int?) null,
                        PhuongThucThanhToan = document.Contains("phuongThucThanhToan") && !document["phuongThucThanhToan"].IsBsonNull
                            ? document["phuongThucThanhToan"].AsString
                            : string.Empty,
                        TenNhanVien = document.Contains("nhanVien") && document["nhanVien"].AsBsonDocument.Contains("tenNhanVien")
                            ? document["nhanVien"]["tenNhanVien"].AsString
                            : string.Empty,
                        TenKhachHang = document.Contains("khachHang") && !document["khachHang"].IsBsonNull && document["khachHang"].AsBsonDocument.Contains("tenKhachHang")
                            ? document["khachHang"]["tenKhachHang"].AsString
                            : string.Empty,
                        KhuyenMai = document.Contains("khuyenMai") && !document["khuyenMai"].IsBsonNull && document["khuyenMai"].AsBsonDocument.Contains("maKhuyenMai")
                            ? document["khuyenMai"]["maKhuyenMai"].AsString
                            : string.Empty
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

                dtgHoaDon.Columns["NgayLapHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
                btnTimKhachHang.Enabled = btnDungDiemTichLuy.Enabled = btnThanhToan.Enabled = true;
            lblSDT.Enabled = lblDiemTichLuy.Enabled = lblHoTenKH.Enabled = lblMaKhuyenMai.Enabled = true;
            cbMaKhuyenMai.Enabled = txtSoDienThoai.Enabled = true;
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
            bool kq = hoaDonBUS.addHoaDon(maHoaDon, ngayMua, maNhanVien, tenNhanVien);
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
            string tenSanPham = txtSanPham.Text;
            var sanPham = sanPhamBUS.getMaSPByTenSP(tenSanPham);
            string maSanPham = sanPham["maSanPham"].AsString;

            int soLuongThem = (int) intSoLuongThem.Value;

            string giaBanText = txtGiaBan.Text.Replace("VND", "").Replace(",", "").Trim();
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
    }
}
