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
        public frmSanPham()
        {
            InitializeComponent();
            sanPhamBUS = new SanPhamBUS();
            LoadSanPham();
        }
        private void LoadSanPham()
        {
            var sanPhamList = sanPhamBUS.GetAllSanPham();

            var displayList = sanPhamList.Select(doc => new
            {
                TenSanPham = doc["TenSanPham"].AsString,
                GiaBan = doc["GiaBan"].ToDouble()
            }).ToList();

            dtgSanPham.DataSource = displayList;

            dtgSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtgSanPham.Columns["GiaBan"].HeaderText = "Giá bán";

            dtgSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }
    }
}
