using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Khoa.BUS;
using MongoDB.Bson;
using Sunny.UI;
namespace Main.GUI
{
    public partial class frmThongTinNhanVien : Form
    {
        Khoa.BUS.NhanVienBUS nhanVienBUS = new Khoa.BUS.NhanVienBUS();
        private string matKhauCu;
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            BsonDocument nhanVien = nhanVienBUS.GetNhanVienByTaiKhoan(frmDangNhap.taiKhoanDangSuDung);
            Console.WriteLine(frmDangNhap.taiKhoanDangSuDung);
            if (nhanVien != null)
            {
                txtMaNV.Text = nhanVien["maNhanVien"].AsString;
                txtTenNV.Text = nhanVien["tenNhanVien"].AsString;
                txtSDT.Text = nhanVien["soDienThoai"].AsString;
                TxtEmail.Text = nhanVien["email"].AsString;
                txtChucVu.Text = nhanVien["chucVu"].AsString;
                txtMucLuong.Text = nhanVien["mucLuong"].ToString();
                txtTaiKhoan.Text = nhanVien["taiKhoan"].ToString();
                matKhauCu = nhanVien["matKhau"].ToString();
                if (nhanVien.Contains("ngaySinh"))
                {
                    DateTime ngaySinh = nhanVien["ngaySinh"].ToUniversalTime();
                    dateTimePicker1.Value = ngaySinh;
                }
                string gioiTinh = nhanVien["gioiTinh"].AsString;
                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdoNu.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên với tài khoản này.");
                return;
            }
        }
        private void uiLabel12_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string gioiTinh = "Nữ";
            if (rdoNam.Checked)
            {
                gioiTinh = "Nam";
            }
            if (nhanVienBUS.UpdateNhanVien(txtMaNV.Text, txtTenNV.Text, gioiTinh, DateTime.Parse(dateTimePicker1.Text), txtSDT.Text, TxtEmail.Text, txtChucVu.Text,int.Parse(txtMucLuong.Text)))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            uiTableLayoutPanel5.Visible = true;
            btnCapNhat.Enabled = false;
            btnDoiMK.Enabled = false;
            btnDangXuat.Enabled = false;
            uiTableLayoutPanel4.Visible = true;
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != matKhauCu)
            {

                MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nhanVienBUS.UpdateMatKhau(txtTaiKhoan.Text, txtMatKhauMoi.Text))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Text = string.Empty;
                txtMatKhauMoi.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {
            uiTableLayoutPanel5.Visible = false;
            btnCapNhat.Enabled = true;
            btnDoiMK.Enabled = true;
            btnDangXuat.Enabled = true;
            uiTableLayoutPanel4.Visible = false;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form main = Application.OpenForms["frmTrangChu"];
                if (main != null)
                {
                    main.Close();
                }
                this.Close();
                Application.Restart();
            }
        }
    }
}
