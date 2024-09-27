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

        }
    }
}
