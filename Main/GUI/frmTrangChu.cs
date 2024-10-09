using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Khoa;
using KimPhuong;
using Danh;
using Danh.GUI;
using Sunny.UI;
using KimPhuong.GUI;
using Main.BUS;
using Khoa.GUI;

namespace Main
{
    public partial class frmTrangChu : UIAsideHeaderMainFrame
    {
        protected string taiKhoan, chucVu;
        public frmTrangChu()
        {
            InitializeComponent();
        }
        public frmTrangChu(string taiKhoan, string chucVu)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;

            this.chucVu = chucVu;
            KiemTraQuyen();

        }
        private void KiemTraQuyen()
        {
            Console.WriteLine(chucVu);
            if (chucVu == "Nhân viên bán hàng")
            {
                int pageIndex = 1000;
                TreeNode root = Aside.CreateNode("QUẢN LÝ KHÁCH HÀNG", 61451, 24, pageIndex);

                pageIndex = 2000;
                root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
                Aside.CreateChildNode(root, AddPage(new frmBanHang(), ++pageIndex));

                Aside.NodeMouseClick += Aside_NodeMouseClick;
            }
            else if (chucVu == "Nhân viên quản lý hàng hóa")
            {
                int pageIndex = 1000;
                TreeNode root = Aside.CreateNode("QUẢN LÝ SẢN PHẨM", 61451, 24, pageIndex);
                Aside.CreateChildNode(root, AddPage(new frmDanhMuc(), ++pageIndex));
                Aside.CreateChildNode(root, AddPage(new frmSanPham(), ++pageIndex));
                Aside.NodeMouseClick += Aside_NodeMouseClick;

                pageIndex = 2000;
                root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
                Aside.CreateChildNode(root, AddPage(new frmDatHangNhaCC(), ++pageIndex));
                Aside.NodeMouseClick += Aside_NodeMouseClick;
            }
            else if (chucVu == "Quản lý")
            {
                int pageIndex = 1000;
                TreeNode root = Aside.CreateNode("QUẢN LÝ SẢN PHẨM", 61451, 24, pageIndex);
                Aside.CreateChildNode(root, AddPage(new frmDanhMuc(), ++pageIndex));
                Aside.CreateChildNode(root, AddPage(new frmSanPham(), ++pageIndex));

                pageIndex = 2000;
                root = Aside.CreateNode("QUẢN LÝ KHÁCH HÀNG", 61451, 24, pageIndex);

                pageIndex = 3000;
                root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
                Aside.CreateChildNode(root, AddPage(new frmBanHang(taiKhoan), ++pageIndex));
                Aside.CreateChildNode(root, AddPage(new frmDatHangNhaCC(), ++pageIndex));

                pageIndex = 7000;
                root = Aside.CreateNode("NHÂN VIÊN", 61451, 24, pageIndex);

                Aside.NodeMouseClick += Aside_NodeMouseClick;
            }
            else
            {
                MessageBox.Show("Chức vụ này không có quyền sử dụng form");
                return;
            }
        }

        private void Aside_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "NHÂN VIÊN")
            {
                var page = new frmNhanVien();
                AddPage(page, 7000);
                SelectPage(7000);
            }
            else if (e.Node.Text == "QUẢN LÝ KHÁCH HÀNG")
            {
                var page = new frmKhachHangThanThiet();
                AddPage(page, 2000);
                SelectPage(2000);
            }
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
