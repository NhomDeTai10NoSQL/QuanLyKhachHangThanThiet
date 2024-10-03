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
using Sunny.UI;
namespace Khoa
{
    public partial class frmKhachHangThanThiet : UIPage
    {
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        DataTable dtKhachHang = new DataTable();
        public frmKhachHangThanThiet()
        {
            InitializeComponent();
            loadData();
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            cboTrangThai.Items.Add("Hoạt động");
            cboTrangThai.Items.Add("Ẩn");
            cboLoaiKH.Items.Add("Bình thường");
            cboLoaiKH.Items.Add("Tiềm năng");
        }
        
        private void frmKhachHangThanThiet_Initialize(object sender, EventArgs e)
        {

        }
        public void loadData()
        {
            dtKhachHang = khachHangBUS.getAllKhachHang();
            dgvKhachHang.DataSource = dtKhachHang;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult add;
            add = MessageBox.Show("Có muốn thêm nhân viên này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (add == DialogResult.Yes)
            {
                if (txtTenKH.Text.Length == 0 || txtSDT.Text.Length == 0)
                {
                    MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if(txtSDT.Text.Length != 10) {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                bool addKhachHang = khachHangBUS.AddKhachHang(txtTenKH.Text, DateTime.Parse(dtpNgaySinh.Text), txtSDT.Text, int.Parse(txtDiem.Text) ,cboTrangThai.Text, cboLoaiKH.Text);
                if(addKhachHang )
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult add;
            add = MessageBox.Show("Có muốn thêm nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (add == DialogResult.Yes)
            {
                if (txtTenKH.Text.Length == 0 || txtSDT.Text.Length == 0)
                {
                    MessageBox.Show("Thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                else if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                string makh = dgvKhachHang.CurrentRow.Cells["Column1"].Value.ToString();
                bool updateKhachHang = khachHangBUS.UpdateKhachHang(makh, txtTenKH.Text, DateTime.Parse(dtpNgaySinh.Text), txtSDT.Text, int.Parse(txtDiem.Text), cboTrangThai.Text, cboLoaiKH.Text);
                if (updateKhachHang)
                {
                    MessageBox.Show("Sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            string makh = dgvKhachHang.CurrentRow.Cells["Column1"].Value.ToString();
            bool updateKhachHang = khachHangBUS.hideKhachHang(makh);
            if (updateKhachHang)
            {
                MessageBox.Show("Ẩn khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                loadData();
            }
            else
            {
                MessageBox.Show("Ẩn khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
        }

      
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiem.Text = "0";
            cboLoaiKH.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                txtTenKH.Text = dgvKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                txtSDT.Text = dgvKhachHang.CurrentRow.Cells["SoDienThoai"].Value.ToString();
                txtDiem.Text = dgvKhachHang.CurrentRow.Cells["DiemTichLuy"].Value.ToString();
                dtpNgaySinh.Text = dgvKhachHang.CurrentRow.Cells["NgaySinh"].Value.ToString();

                string trangThai = dgvKhachHang.CurrentRow.Cells["TrangThai"].Value.ToString();
                int indexTrangThai = cboTrangThai.FindStringExact(trangThai);
                if (indexTrangThai != -1)
                {
                    cboTrangThai.SelectedIndex = indexTrangThai;
                }
                string loaiKhachHang = dgvKhachHang.CurrentRow.Cells["LoaiKhachHang"].Value.ToString();
                int indexLoaiKH = cboLoaiKH.FindStringExact(loaiKhachHang);
                if (indexLoaiKH != -1)
                {
                    cboLoaiKH.SelectedIndex = indexLoaiKH;
                }

            }
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearch.Text.Trim();
                DataTable searchResults = khachHangBUS.SearchKhachHang(searchValue);
                dgvKhachHang.DataSource = searchResults;
                if (searchResults.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            catch {
                loadData();
            }
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            int index = cboLoc.SelectedIndex;
            if(index == 0)
            {
                loadData();
            }
            else if(index == 1)
            {
                btnAn.Visible = false;
                btnHien.Visible = true;
                string value = "Ẩn";
                DataTable dtLocKhachHang = khachHangBUS.locKhachHang(value);
                dgvKhachHang.DataSource = dtLocKhachHang;

            }
            else if (index == 2)
            {
                string value = "Tiềm năng";
                DataTable dtLocKhachHang = khachHangBUS.locKhachHang(value);
                dgvKhachHang.DataSource = dtLocKhachHang;
            }
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            string makh = dgvKhachHang.CurrentRow.Cells["Column1"].Value.ToString();
            bool updateKhachHang = khachHangBUS.showKhachHang(makh);
            if (updateKhachHang)
            {
                MessageBox.Show("Hiện khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                loadData();
            }
            else
            {
                MessageBox.Show("Hiện khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
        }
    }
}
