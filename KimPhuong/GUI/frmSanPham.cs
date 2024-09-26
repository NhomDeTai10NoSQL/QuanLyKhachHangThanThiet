using KimPhuong.BUS;
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

namespace KimPhuong
{
    public partial class frmSanPham : UIPage
    {
        SanPhamBUS sanPhamBUS;
        DanhMucBUS danhMucBUS;
        public frmSanPham()
        {
            InitializeComponent();
            sanPhamBUS = new SanPhamBUS();
            danhMucBUS = new DanhMucBUS();
            LoadSanPham();
            LoadDanhMuc();
        }
        private void LoadSanPham()
        {
            var sanPhamList = sanPhamBUS.GetAllSanPham();

            var displayList = sanPhamList.Select(doc => new
            {
                TenSanPham = doc["TenSanPham"],
                MaVach = doc["MaVach"],
                MoTa = doc["MoTa"],
                NgaySanXuat = doc["NgaySanXuat"].ToUniversalTime(),
                XuatXu = doc["XuatXu"],
                GiaBan = doc["GiaBan"].ToDouble(),
                MaBaoHanh = doc["MaBaoHanh"],
                MaDanhMuc = doc["MaDanhMuc"],
                MaNhaCungCap = doc["MaNhaCungCap"]
            }).ToList();

            dtgSanPham.DataSource = displayList;

            dtgSanPham.Columns["MaVach"].HeaderText = "Mã vạch";
            dtgSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dtgSanPham.Columns["NgaySanXuat"].HeaderText = "Ngày sản xuất";
            dtgSanPham.Columns["XuatXu"].HeaderText = "Xuất xứ";
            dtgSanPham.Columns["MaBaoHanh"].HeaderText = "Mã bảo hành";
            dtgSanPham.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            dtgSanPham.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
            dtgSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtgSanPham.Columns["GiaBan"].HeaderText = "Giá bán";

            dtgSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }
        private void LoadDanhMuc()
        {
            var danhMucList = danhMucBUS.GetAllDanhMuc();

            var displayList = danhMucList.Select(doc => new
            {
                MaDanhMuc = doc["MaDanhMuc"],
                TenDanhMuc = doc["TenDanhMuc"],
            }).ToList();

            cbDanhMuc.DataSource = displayList;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";
        }
    }
}
