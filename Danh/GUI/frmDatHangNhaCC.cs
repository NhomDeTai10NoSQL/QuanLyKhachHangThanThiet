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
namespace Danh.GUI
{
    public partial class frmDatHangNhaCC : Form
    {
        Danh.BUS.NhaCungCapBUS nhaCungCapBUS = new Danh.BUS.NhaCungCapBUS();
        NhapHangBUS nhapHangBUS = new NhapHangBUS();
        SanPhamBUS sanPhamBUS = new SanPhamBUS();
        public frmDatHangNhaCC()
        {
            InitializeComponent();
            cbTrangThai.SelectedIndex = 1;
            DateTime ngayDat = DateTime.Now;
            txtNgayDat.Text = ngayDat.ToString("dd/MM/yyyy");
        }
        private void loadMaDatHang()
        {
            cbMaDatHang.DataSource = null;
            DataTable dt = nhapHangBUS.getAll();
            cbMaDatHang.DataSource = dt;
            cbMaDatHang.ValueMember = "MaDonDatHang";
            cbMaDatHang.DisplayMember = "MaDonDatHang";
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
            DataTable dt = nhapHangBUS.getAll();
            dtgNhapHang.DataSource = dt;
            if (dtgNhapHang.Columns.Count > 0)
            {
                dtgNhapHang.Columns["MaDonDatHang"].HeaderText = "Mã đơn đặt hàng";
                dtgNhapHang.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
                dtgNhapHang.Columns["TongTien"].HeaderText = "Tổng tiền";
                dtgNhapHang.Columns["NgayDatHang"].HeaderText = "Ngày đặt hàng";
                dtgNhapHang.Columns["TrangThai"].HeaderText = "TrangThai";
            }
        }

        private void frmDatHangNhaCC_Load(object sender, EventArgs e)
        {
            loadMaDatHang();
            loadNhaCungCap();
            loadSanPham();
        }

        private void dtgNhapHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNhapHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgNhapHang.SelectedRows[0];
                string maDonDat = selectedRow.Cells["MaDonDatHang"].Value.ToString();
                string maNhaCungCap = selectedRow.Cells["MaNhaCungCap"].Value.ToString();
                if (DateTime.TryParse(selectedRow.Cells["NgayDatHang"].Value.ToString(), out DateTime ngayDatHang))
                {
                    txtNgayDat.Text = ngayDatHang.ToString("dd/MM/yyyy");
                }
                else
                {

                    txtNgayDat.Text = "Ngày không hợp lệ";
                }

                if (int.TryParse(selectedRow.Cells["TongTien"].Value.ToString(), out int tongTien))
                {
                    txtTongTien.Text = tongTien.ToString("N0") + " VND";
                }
                else
                {
                    txtTongTien.Text = "0 VND";
                }
                string trangThai = selectedRow.Cells["TrangThai"].Value.ToString();

                cbMaDatHang.SelectedValue = maDonDat;
                cbNhaCungCap.SelectedValue = maNhaCungCap;
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
            string maNhaCungCap = cbNhaCungCap.SelectedValue.ToString();
            DateTime ngayDatHang = DateTime.Now;

            if (nhapHangBUS.AddDonNhapHang(maNhaCungCap, ngayDatHang))
            {
                MessageBox.Show("Thêm thành công đơn đặt hàng! Vui lòng thêm chi tiết đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm đơn đặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadDonNhap();
            loadMaDatHang();
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 1;
            string maDonDat = cbMaDatHang.SelectedValue.ToString();
            if (MessageBox.Show($"Bạn có chắc chắn muốn thêm sản phẩm vào đơn {maDonDat} này để đặt hàng?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maSanPham = cbSanPham.SelectedValue.ToString();
                int soLuong = (int)intUDSoLuong.Value;
                if (int.TryParse(txtGiaBan.Text.Replace(",", "").Replace(" VND", "").Trim(), out int giaBan))
                {
                    string errorMessage;
                    if (nhapHangBUS.addChiTietDonNhapHang(maDonDat, maSanPham, soLuong, giaBan, out errorMessage))
                    {
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
                dtgNhapHang.DataSource = get;
            }
            string keyword = txtTimHD.Text.Trim();
            DataTable kq = nhapHangBUS.SearchDonNhapHang(keyword);
            dtgNhapHang.DataSource = kq;
        }

        private void btnReloadDanhMuc_Click(object sender, EventArgs e)
        {
            loadDonNhap();
            string maDonDat = cbMaDatHang.SelectedValue.ToString();
            dtgChiTietNH.DataSource = nhapHangBUS.getAllChiTiet(maDonDat);
        }
    }
}
