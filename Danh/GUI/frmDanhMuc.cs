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
using MongoDB.Bson;
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

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            int maDanhMuc = danhMucBUS.GetMaxMaDanhMuc();
            string tenDanhMuc = txtTenDanhMuc.Text;
            string moTa = rtxtMoTa.Text;

            if (danhMucBUS.ThemDanhMuc(maDanhMuc, tenDanhMuc, moTa))
            {
                MessageBox.Show("Thêm danh mục thành công.");
                LoadDanhMuc();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại.");
            }
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            if (dtgDanhMuc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgDanhMuc.SelectedRows[0];
                int maDanhMuc = int.Parse(selectedRow.Cells["maDanhMuc"].Value.ToString());

                if (danhMucBUS.XoaDanhMuc(maDanhMuc))
                {
                    MessageBox.Show("Xóa danh mục thành công.");
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Xóa danh mục thất bại.");
                }
            }
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            if (dtgDanhMuc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgDanhMuc.SelectedRows[0];
                int maDanhMuc = int.Parse(selectedRow.Cells["maDanhMuc"].Value.ToString());
                string tenDanhMuc = txtTenDanhMuc.Text;
                string moTa = rtxtMoTa.Text;

                if (danhMucBUS.SuaDanhMuc(maDanhMuc, tenDanhMuc, moTa))
                {
                    MessageBox.Show("Sửa danh mục thành công.");
                    LoadDanhMuc(); 
                }
                else
                {
                    MessageBox.Show("Sửa danh mục thất bại.");
                }
            }
        }

        private void btnReloadDanhMuc_Click(object sender, EventArgs e)
        {

            LoadDanhMuc();
        }

        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            int maNhaCungCap = nhaCungCapBUS.GetMaxMaNhaCungCap();
            string tenNhaCungCap = txtTenNhaCungCap.Text;
            string sodienthoai = txtSoDienThoai.Text;
            string diachi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string nguoiDaiDien = txtNguoiLienHe.Text;
            

            if (nhaCungCapBUS.ThemNhaCungCap(maNhaCungCap, tenNhaCungCap, sodienthoai, diachi, email, nguoiDaiDien))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công.");
                LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Thêm  nhà cung cấp  thất bại.");
            }

        }

        private void btnXoaNhaCungCap_Click(object sender, EventArgs e)
        {
            if (dtgNhaCungCap.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgNhaCungCap.SelectedRows[0];
                int maNhaCungCap = int.Parse(selectedRow.Cells["maNhaCungCap"].Value.ToString());

                if (nhaCungCapBUS.XoaNhaCungCap(maNhaCungCap))
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công.");
                    LoadNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại.");
                }
            }
        }

        private void btnSuaNhaCungCap_Click(object sender, EventArgs e)
        {
            if (dtgNhaCungCap.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgNhaCungCap.SelectedRows[0];
                int maNhaCungCap = int.Parse(selectedRow.Cells["maNhaCungCap"].Value.ToString());
                string tenNhaCungCap = txtTenNhaCungCap.Text;
                string sodienthoai = txtSoDienThoai.Text;
                string diachi = txtDiaChi.Text;
                string email = txtEmail.Text;
                string nguoiDaiDien = txtNguoiLienHe.Text;

                if (nhaCungCapBUS.SuaNhaCungCap(maNhaCungCap, tenNhaCungCap, sodienthoai, diachi, email, nguoiDaiDien))
                {
                    MessageBox.Show("Sửa nhà cung cấp thành công.");
                    LoadNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Sửa nhà cung cấp thất bại.");
                }
            }
        }

        private void btnReloadNhaCungCap_Click(object sender, EventArgs e)
        {
            LoadNhaCungCap();
        }

        private void btnTimDanhMuc_Click(object sender, EventArgs e)
        {
            string key = txtTimDanhMuc.Text.Trim();
            List<BsonDocument> searchResults = danhMucBUS.searchDanhMuc(key);

            var dmList = new List<object>();
            foreach (var document in searchResults)
            {
                var danhMuc = new
                {
                    MaDanhMuc = document["maDanhMuc"].AsInt32,
                    TenDanhMuc = document["tenDanhMuc"].AsString,
                    MoTa = document["moTa"].AsString
                };
                dmList.Add(danhMuc);
            }

            dtgDanhMuc.DataSource = dmList;

            if (dmList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhMuc();
            }
        }

        private void btnTimNhaCungCap_Click(object sender, EventArgs e)
        {
            string key = txtTimNhaCungCap.Text.Trim();
            List<BsonDocument> searchResults = nhaCungCapBUS.searchNhaCungCap(key);

            var dmList = new List<object>();
            foreach (var document in searchResults)
            {
                var nhaCungCap = new
                {
                    MaNhaCungCap = document["maNhaCungCap"].AsInt32,
                    TenNhaCungCap = document["tenNhaCungCap"].AsString,
                    SoDienThoai = document["soDienThoai"].AsString,
                    DiaChi = document["diaChi"].AsString,
                    Email = document["email"].AsString,
                    NguoiDaiDien = document["nguoiDaiDien"].AsString,
            };
                dmList.Add(nhaCungCap);
            }

            dtgNhaCungCap.DataSource = dmList;

            if (dmList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhaCungCap();
            }
        }
    }
}
