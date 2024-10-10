using Khoa.BUS;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Khoa.GUI
{
    public partial class frmNhanVien : UIPage
    {
        DataTable dtNhanVien = new DataTable();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public frmNhanVien()
        {
            InitializeComponent();
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            loadData();
        }

        public void loadData()
        {
            dtNhanVien = nhanVienBUS.getALlNhanVien();
            dgvNhanVien.DataSource = dtNhanVien;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            DialogResult add;
            add = MessageBox.Show("Có muốn thêm nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (add == DialogResult.Yes)
            {
                if(txtTenNV.Text.Length == 0 || txtSDT.Text.Length == 0 || txtChucVu.Text.Length == 0 || txtEmail.Text.Length == 0 || txtTaiKhoan.Text.Length == 0 || txtMatKhau.Text.Length == 0)
                {
                    MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if (nhanVienBUS.KiemTraTrungSDT(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                string gioiTinh = rdoNu.Checked ? "Nữ" : "Nam";

                if (nhanVienBUS.AddNhanVien(txtTenNV.Text, gioiTinh, DateTime.Parse(dtpNgaySinh.Text), txtSDT.Text, txtEmail.Text, txtChucVu.Text, int.Parse(txtMucLuong.Text), txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["tenNhanVien"].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["ngaySinh"].Value.ToString();
                txtSDT.Text = dgvNhanVien.CurrentRow.Cells["soDienThoai"].Value.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["email"].Value.ToString();
                txtChucVu.Text = dgvNhanVien.CurrentRow.Cells["chucVu"].Value.ToString();
                txtMucLuong.Text = dgvNhanVien.CurrentRow.Cells["mucLuong"].Value.ToString();
                txtTaiKhoan.Text = dgvNhanVien.CurrentRow.Cells["taiKhoan"].Value.ToString();
                txtMatKhau.Text = dgvNhanVien.CurrentRow.Cells["matKhau"].Value.ToString();
                string gioiTinh = dgvNhanVien.CurrentRow.Cells["gioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdoNu.Checked = true;
                }
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
            }
        }

        private void uiRadioButtonGroup1_ValueChanged(object sender, int index, string text)
        {

        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(del == DialogResult.Yes)
            {
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["maNhanVien"].Value.ToString();

                if (nhanVienBUS.DeleteNhanVien(maNhanVien))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            DialogResult edit;
            edit = MessageBox.Show("Bạn có muốn cập nhật nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (edit == DialogResult.Yes)
            {
                if (txtTenNV.Text.Length == 0 || txtSDT.Text.Length == 0 || txtChucVu.Text.Length == 0 || txtEmail.Text.Length == 0 || txtTaiKhoan.Text.Length == 0 || txtMatKhau.Text.Length == 0)
                {
                    MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                string maNhanVienHienTai = dgvNhanVien.CurrentRow.Cells["maNhanVien"].Value.ToString();
                string soDienThoaiMoi = txtSDT.Text;

                if (nhanVienBUS.KiemTraTrungSDT(soDienThoaiMoi))
                {
                    var nhanVienTrungSDT = nhanVienBUS.GetNhanVienBySDT(soDienThoaiMoi);

                    if (nhanVienTrungSDT != null && nhanVienTrungSDT["maNhanVien"].ToString() != maNhanVienHienTai)
                    {
                        MessageBox.Show("Số điện thoại bị trùng với nhân viên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                }

                string gioiTinh = rdoNu.Checked ? "Nữ" : "Nam";

                if (nhanVienBUS.UpdateNhanVien(maNhanVienHienTai, txtTenNV.Text, gioiTinh, DateTime.Parse(dtpNgaySinh.Text), soDienThoaiMoi, txtEmail.Text, txtChucVu.Text, int.Parse(txtMucLuong.Text)))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadData();  
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = string.Empty;
            rdoNam.Checked = true;
            txtEmail.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtMucLuong.Text = string.Empty;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.Enabled = true;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
    }
}
