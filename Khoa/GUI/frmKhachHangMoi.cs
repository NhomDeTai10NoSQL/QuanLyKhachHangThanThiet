using Khoa.BUS;
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
    public partial class frmKhachHangMoi : Form
    {
        KhachHangBUS khachHangBUS =  new KhachHangBUS();
        public frmKhachHangMoi()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(khachHangBUS.AddKhachHang(txtTenKh.Text, DateTime.Parse(dateTimePicker1.Text), txtSDT.Text, 0, "Hoạt động", "Bình thường"))
            {
                MessageBox.Show("Thêm khách hàng mới thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã sảy ra lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKh.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }
    }
}
