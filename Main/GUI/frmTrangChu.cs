using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimPhuong;
using Danh;
using Danh.GUI;
using Sunny.UI;
namespace Main
{
    public partial class frmTrangChu : UIAsideHeaderMainFrame
    {
        public string taiKhoan;
        public frmTrangChu()
        {
            InitializeComponent();
            int pageIndex = 1000;
            TreeNode root = Aside.CreateNode("QUẢN LÝ KHÁCH HÀNG", 61451, 24, pageIndex);

            pageIndex = 2000;
            root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
            Aside.CreateChildNode(root, AddPage(new frmSanPham(), ++pageIndex));
            Aside.CreateChildNode(root, AddPage(new frmDanhMuc(), ++pageIndex));

        }
        public frmTrangChu(string taiKhoan)
        {
            InitializeComponent();
            int pageIndex = 1000;
            TreeNode root = Aside.CreateNode("QUẢN LÝ KHÁCH HÀNG", 61451, 24, pageIndex);

            pageIndex = 2000;
            root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
            Aside.CreateChildNode(root, AddPage(new frmDanhMuc(), ++pageIndex));

            this.taiKhoan =  taiKhoan;

            lblTaiKhoan.Text = taiKhoan;

        }
    }
}
