using Danh.BUS;
using KimPhuong.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using MongoDB.Bson;
using Danh.DAO;

namespace Danh.GUI
{
    public partial class frmDatHangNhaCC : UIPage
    {
        Danh.BUS.NhaCungCapBUS nhaCungCapBUS = new Danh.BUS.NhaCungCapBUS();
        NhapHangBUS nhapHangBUS = new NhapHangBUS();
        SanPhamBUS sanPhamBUS = new SanPhamBUS();
        HoaDonBUS hoaDonBUS = new HoaDonBUS();
        public frmDatHangNhaCC()
        {
            
            InitializeComponent();
            loadDonNhap();
            cbTrangThai.SelectedIndex = 1;
            DateTime ngayDat = DateTime.Now;
            txtNgayDat.Text = ngayDat.ToString("dd/MM/yyyy");
            intUDSoLuong.Value = 1;
        }
        private void loadMaDatHang()
        {
            cbMaDatHang.DataSource = null;
            DataTable ncc = nhapHangBUS.getAll();
            cbMaDatHang.DataSource = ncc;
            cbMaDatHang.ValueMember = "maDonDatHang";
            cbMaDatHang.DisplayMember = "maDonDatHang";
        }



        private void loadNhaCungCap()
        {
            cbNhaCungCap.DataSource = null;
            DataTable ncc = nhaCungCapBUS.GetAll();
            cbNhaCungCap.DataSource = ncc;
            cbNhaCungCap.ValueMember = "MaNhaCungCap";
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";
        }
        private void loadSanPham()
        {
            cbSanPham.DataSource = null;
            DataTable sanPham = sanPhamBUS.getAll();
            cbSanPham.DataSource = sanPham;
            cbSanPham.ValueMember = "MaSanPham";
            cbSanPham.DisplayMember = "TenSanPham";
        }
        private void loadDonNhap()
        {
            DataTable dt = nhapHangBUS.getNhapHang();
            dgvNhapHang.DataSource = dt;
            
        }

        private void frmDatHangNhaCC_Load(object sender, EventArgs e)
        {
            loadMaDatHang();
            loadNhaCungCap();
            loadSanPham();
        }

        private void dgvNhapHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvNhapHang.SelectedRows[0];

                string maDonDat = selectedRow.Cells["maDonDatHang"].Value?.ToString() ?? string.Empty;
                string maNhaCungCap = selectedRow.Cells["tenNhaCungCap"].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(selectedRow.Cells["ngayDatHang"].Value?.ToString(), out DateTime ngayDatHang))
                {
                    txtNgayDat.Text = ngayDatHang.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNgayDat.Text = "Ngày không hợp lệ";
                }

                if (int.TryParse(selectedRow.Cells["tongTien"].Value?.ToString(), out int tongTien))
                {
                    txtTongTien.Text = tongTien.ToString("N0") + " VND";
                }
                else
                {
                    txtTongTien.Text = "0 VND";
                }

                DataTable dtChiTiet = nhapHangBUS.getChiTietNhapHang(maDonDat);
                dtgChiTietNH.DataSource = dtChiTiet;

                string trangThai = selectedRow.Cells["trangThai"].Value?.ToString() ?? string.Empty;

                cbMaDatHang.Text = maDonDat;
                cbNhaCungCap.Text = maNhaCungCap; 
                txtNgayDat.Text = ngayDatHang.ToString("dd/MM/yyyy");
                txtTongTien.Text = tongTien.ToString("N0") + " VND";
                cbTrangThai.Text = trangThai;
            }
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
            string input = txtGiaBan.Text.Replace(",", "").Replace(" VND", "").Trim();

            if (int.TryParse(input, out int giaBan) && giaBan > 0)
            {
                txtGiaBan.Text = giaBan.ToString("N0") + " VND";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaBan.Focus();
                return;
            }
        }
        private void tinhThanhTien()
        {
            if (int.TryParse(txtGiaBan.Text.Replace(",", "").Replace(" VND", "").Trim(), out int giaBan) && intUDSoLuong.Value > 0)
            {
                int soLuong = intUDSoLuong.Value;
                int thanhTien = giaBan * soLuong;

                txtThanhTien.Text = thanhTien.ToString("N0") + " VND";
            }
            else
            {
                txtThanhTien.Text = "0 VND";
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            tinhThanhTien();
        }

        private void intUDSoLuong_ValueChanged(object sender, int value)
        {
            tinhThanhTien();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDatHang = nhapHangBUS.GetNextMaDonHang();
            string maNhaCungCap = cbNhaCungCap.SelectedValue.ToString();
            string tenNhaCungCap = cbNhaCungCap.Text;
            DateTime ngayDatHang = DateTime.Now;

            if (nhapHangBUS.AddDonNhapHang(maDatHang, maNhaCungCap, tenNhaCungCap, ngayDatHang))
            {
                MessageBox.Show("Thêm thành công đơn đặt hàng! Vui lòng thêm chi tiết đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm đơn đặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadDonNhap();
            loadMaDatHang();
            if (dgvNhapHang.Rows.Count > 0)
            {
                int lastRowIndex = dgvNhapHang.Rows.Count - 1;
                dgvNhapHang.Rows[lastRowIndex].Selected = true;
                dgvNhapHang.FirstDisplayedScrollingRowIndex = lastRowIndex; 
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 1; // Cập nhật trạng thái đơn hàng thành "Đã đặt"
            string maDonDat = cbMaDatHang.Text;

            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm sản phẩm vào đơn {maDonDat} này để đặt hàng?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maSanPham = cbSanPham.SelectedValue.ToString();
                string tenSanPham = cbSanPham.Text;
                int soLuong = (int) intUDSoLuong.Value;

                // Lấy giá bán và chuyển đổi thành số
                if (int.TryParse(txtGiaBan.Text.Replace(",", "").Replace(" VND", "").Trim(), out int giaBan))
                {
                    string errorMessage;

                    // Thêm chi tiết đơn đặt hàng
                    if (nhapHangBUS.addChiTietDonNhapHang(maDonDat, maSanPham, tenSanPham, soLuong, giaBan, out errorMessage))
                    {
                        capNhatTongTien(maDonDat);
                        MessageBox.Show("Thêm chi tiết đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            loadDonNhap();
            dtgChiTietNH.DataSource = nhapHangBUS.getAllChiTiet(maDonDat);
            if (dgvNhapHang.Rows.Count > 0)
            {
                int lastRowIndex = dtgChiTietNH.Rows.Count - 1;
                dgvNhapHang.Rows[lastRowIndex].Selected = true;
                dgvNhapHang.FirstDisplayedScrollingRowIndex = lastRowIndex;
            }
        }
       

        // Hàm tính toán và cập nhật tổng tiền cho đơn đặt hàng
        private int capNhatTongTien(string maDonDat)
        {
            // Lấy danh sách chi tiết đơn đặt hàng
            int tongTien = 0;
            DataTable dt = nhapHangBUS.getAllChiTiet(maDonDat);
            foreach (DataRow row in dt.Rows)
            {
                string maSanPham = row["MaSanPham"].ToString();
                int soLuong = (int) row["SoLuong"];
                int donGia = (int) row["DonGia"];
                int thanhTien = (int) row["ThanhTien"];

                tongTien += thanhTien;
            }

            return tongTien;
        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {
            string trangThai = cbTrangThai.Text;
            string maDonDat = cbMaDatHang.SelectedValue.ToString();
            if (MessageBox.Show($"Bạn có chắc chắn muốn sửa trạng thái {trangThai} vào đơn {maDonDat} này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (nhapHangBUS.UpdateDonNhapHang(maDonDat, trangThai))
                {
                    MessageBox.Show("Sửa trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi sửa trạng thái đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            loadDonNhap();
            dtgChiTietNH.DataSource = nhapHangBUS.getAllChiTiet(maDonDat);
        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimHD.Text.Trim()))
            {
                DataTable get = nhapHangBUS.getAll();
                dgvNhapHang.DataSource = get;
            }
            string keyword = txtTimHD.Text.Trim();
            DataTable kq = nhapHangBUS.SearchDonNhapHang(keyword);
            dgvNhapHang.DataSource = kq;
        }

        private void btnReloadDanhMuc_Click(object sender, EventArgs e)
        {
            loadDonNhap();
            string maDonDat = cbMaDatHang.SelectedValue.ToString();
            dtgChiTietNH.DataSource = nhapHangBUS.getAllChiTiet(maDonDat);
        }
    }
}
