using Main.BUS;
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

namespace  Main.GUI
{
    public partial class frmDangNhap : Form
    {
        DangNhapBUS dangNhapBUS;
        public static string taiKhoanDangSuDung;
        public frmDangNhap()
        {
            dangNhapBUS = new DangNhapBUS();
            InitializeComponent();
            txtmatkhau.PasswordChar = '*';
            chkhienmk.CheckedChanged += new EventHandler(chkhienmk_CheckedChanged);
            dangNhapBUS = new DangNhapBUS();
        }

        private void chkhienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhienmk.Checked)
                txtmatkhau.PasswordChar = '\0';
            else
                txtmatkhau.PasswordChar = '*';
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtdangnhap.Text.Trim();
            string matKhau = txtmatkhau.Text.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }


            bool kq = dangNhapBUS.CheckDangNhap(taiKhoan, matKhau);

            if (kq)
            {
                string chucVu = dangNhapBUS.GetChucVu(taiKhoan);

                MessageBox.Show("Đăng nhập thành công.");
                taiKhoanDangSuDung = taiKhoan;
                frmTrangChu mainForm = new frmTrangChu(taiKhoan, chucVu);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác.");
            }
        }
    }
}
    

