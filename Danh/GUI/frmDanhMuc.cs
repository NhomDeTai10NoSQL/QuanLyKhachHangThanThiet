using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Danh.BUS;
using Sunny.UI;
namespace Danh.GUI
{
    public partial class frmDanhMuc : UIPage
    {
        DanhMucBUS danhMucBUS;
        NhaCungCapBUS nhaCungCapBUS;
        public frmDanhMuc()
        {
            InitializeComponent();
            danhMucBUS = new DanhMucBUS();
            nhaCungCapBUS = new NhaCungCapBUS();
            LoadDanhMuc();
            LoadNhaCungCap();
        }

        private void LoadNhaCungCap()
        {
            var bs = nhaCungCapBUS.GetAllNhaCungCap();
            var nhaCungCapList = new List<object>();
            foreach (var doc in bs)
            {

                var nhaCungCap = new
                {
                    MaNhaCungCap = doc["maNhaCungCap"],
                    TenNhaCungCap = doc["tenNhaCungCap"],
                    DiaChi = doc["diaChi"],
                    SoDienThoai = doc["soDienThoai"],
                    Email = doc["email"],
                    NguoiDaiDien = doc["nguoiDaiDien"]
                };
                nhaCungCapList.Add(nhaCungCap);
            }
            dtgNhaCungCap.DataSource = nhaCungCapList;

            dtgNhaCungCap.Columns["tenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
            dtgNhaCungCap.Columns["maNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
            dtgNhaCungCap.Columns["soDienThoai"].HeaderText = "Số Điện Thoại";
            dtgNhaCungCap.Columns["nguoiDaiDien"].HeaderText = "Người Đại Diện";
            dtgNhaCungCap.Columns["email"].HeaderText = "Email";
            dtgNhaCungCap.Columns["diaChi"].HeaderText = "Địa Chỉ";
        }
        private void LoadDanhMuc()
        {
            var bs = danhMucBUS.GetAllDanhMuc();
            var danhMucList = new List<object>();
            foreach (var doc in bs)
            {

                var danhMuc = new
                {
                    MaDanhMuc = doc["maDanhMuc"].AsInt32,
                    TenDanhMuc = doc["tenDanhMuc"],
                    MoTa = doc["moTa"]
                };
                danhMucList.Add(danhMuc);
            }
            dtgDanhMuc.DataSource = danhMucList;

            dtgDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            dtgDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
            dtgDanhMuc.Columns["MoTa"].HeaderText = "Mô tả";
        }

        private void dtgDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDanhMuc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgDanhMuc.SelectedRows[0];

                int maDanhMuc = int.Parse(selectedRow.Cells["maDanhMuc"].Value.ToString());
                string tenDanhMuc = selectedRow.Cells["tenDanhMuc"].Value.ToString();
                string moTa = selectedRow.Cells["moTa"].Value.ToString();

                txtTenDanhMuc.Text = tenDanhMuc;
                rtxtMoTa.Text = moTa;


                long soSP = danhMucBUS.getSoSPTrongDanhMuc(maDanhMuc);

                txtSoSanPham.Text = soSP.ToString();

            }
        }

        private void dtgNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgNhaCungCap.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgNhaCungCap.SelectedRows[0];


                string tenNhaCungCap = selectedRow.Cells["tenNhaCungCap"].Value.ToString();
                string soDienThoai = selectedRow.Cells["soDienThoai"].Value.ToString();
                string diaChi = selectedRow.Cells["diaChi"].Value.ToString();
                string email = selectedRow.Cells["email"].Value.ToString();
                string nguoiDaiDien = selectedRow.Cells["nguoiDaiDien"].Value.ToString();
                txtTenNhaCungCap.Text = tenNhaCungCap;
                txtSoDienThoai.Text = soDienThoai;
                txtDiaChi.Text = diaChi;
                txtEmail.Text = email;
                txtNguoiLienHe.Text = nguoiDaiDien;

            }
        }
    }
}
