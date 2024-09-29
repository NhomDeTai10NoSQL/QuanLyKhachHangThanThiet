﻿using KimPhuong.BUS;
using MongoDB.Bson;
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
using KimPhuong.DTO;
namespace KimPhuong
{
    public partial class frmSanPham : UIPage
    {
        SanPhamBUS sanPhamBUS;
        DanhMucBUS danhMucBUS;
        NhaCungCapBUS nhaCungCapBUS;
        BaoHanhBUS baoHanhBUS;
        public frmSanPham()
        {
            InitializeComponent();
            sanPhamBUS = new SanPhamBUS();
            danhMucBUS = new DanhMucBUS();
            nhaCungCapBUS = new NhaCungCapBUS();
            baoHanhBUS = new BaoHanhBUS();
            LoadSanPham();
            LoadDanhMuc();
            LoadNhaCungCap();
            LoadBaoHanh();
        }
        private void LoadSanPham()
        {
            var bsonDoc = sanPhamBUS.getAllSanPham();
            var sanPhamList = new List<object>();
            foreach (var document in bsonDoc)
            {
                var sanPham = new
                {
                    MaSanPham = document["maSanPham"].AsString,
                    TenSanPham = document["tenSanPham"].AsString,
                    MaVach = document["maVach"].AsString,
                    GiaBan = document["giaBan"].AsInt32,
                    NgaySanXuat = document["ngaySanXuat"].ToUniversalTime(),
                    XuatXu = document["xuatXu"].AsString,
                    MoTa = document["moTa"].AsString,
                    MaDanhMuc = document["danhMuc"]["maDanhMuc"].AsInt32,
                    MaNhaCungCap = document["nhaCungCap"]["maNhaCungCap"].AsInt32,
                    MaBaoHanh = document["baoHanh"]["maBaoHanh"].AsString
                };

                sanPhamList.Add(sanPham);
            }
            dtgSanPham.DataSource = sanPhamList;

            dtgSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dtgSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtgSanPham.Columns["MaVach"].HeaderText = "Mã vạch";
            dtgSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dtgSanPham.Columns["NgaySanXuat"].HeaderText = "Ngày sản xuất";
            dtgSanPham.Columns["XuatXu"].HeaderText = "Xuất xứ";
            dtgSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dtgSanPham.Columns["MaDanhMuc"].HeaderText = "Mã danh mục";
            dtgSanPham.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
            dtgSanPham.Columns["MaBaoHanh"].HeaderText = "Mã bảo hành";

            dtgSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }
        private void LoadDanhMuc()
        {
            var bsonDoc = danhMucBUS.GetAllDanhMuc();
            var danhMucList = new List<object>();
            foreach (var document in bsonDoc)
            {
                var danhMuc = new
                {
                    MaDanhMuc = document["maDanhMuc"].AsInt32,
                    TenDanhMuc = document["tenDanhMuc"].AsString
                };
                danhMucList.Add(danhMuc);
            }

            cbDanhMuc.DataSource = danhMucList;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";
        }
        private void LoadNhaCungCap()
        {
            var bsonDoc = nhaCungCapBUS.getAllNhaCungCap();
            var nhaCungCapList = new List<object>();
            foreach(var document in bsonDoc)
            {
                var nhaCungCap = new
                {
                    MaNhaCungCap = document["maNhaCungCap"].AsInt32,
                    TenNhaCungCap = document["tenNhaCungCap"].AsString
                };
                nhaCungCapList.Add(nhaCungCap);
            }
            cbNhaCungCap.DataSource = nhaCungCapList;
            cbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbNhaCungCap.ValueMember = "MaNhaCungCap";
        }
        private void LoadBaoHanh()
        {
            var bsonDoc = baoHanhBUS.getAllBaoHanh();
            var baoHanhList = new List<object>();
            foreach (var document in bsonDoc)
            {
                var baoHanh = new
                {
                    MaBaoHanh = document["MaBaoHanh"].AsString,
                    ThoiGianBaoHanh = document["ThoiGianBaoHanh"].AsInt32,
                    TGianText = document["ThoiGianBaoHanh"].AsInt32 + " tháng" 
                };
                baoHanhList.Add(baoHanh);
            }
            cbBaoHanh.DataSource = baoHanhList;
            cbBaoHanh.DisplayMember = "TGianText";
            cbBaoHanh.ValueMember = "MaBaoHanh";
        }


        private void btnTimDanhMuc_Click(object sender, EventArgs e)
        {
            string key = txtTimSanPham.Text.Trim();
            List<BsonDocument> searchResults = sanPhamBUS.searchSanPham(key);

            var sanPhamList = new List<object>();
            foreach (var document in searchResults)
            {
                var sanPham = new
                {
                    MaSanPham = document["maSanPham"].AsString,
                    TenSanPham = document["tenSanPham"].AsString,
                    MaVach = document["maVach"].AsString,
                    GiaBan = document["giaBan"].AsInt32,
                    NgaySanXuat = document["ngaySanXuat"].ToUniversalTime(),
                    XuatXu = document["xuatXu"].AsString,
                    MoTa = document["moTa"].AsString,
                    MaDanhMuc = document["danhMuc"]["maDanhMuc"].AsInt32,
                    MaNhaCungCap = document["nhaCungCap"]["maNhaCungCap"].AsInt32,
                    MaBaoHanh = document["baoHanh"]["maBaoHanh"].AsString
                };
                sanPhamList.Add(sanPham);
            }

            dtgSanPham.DataSource = sanPhamList;

            if (sanPhamList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSanPham();
            }
        }

        private void btnReloadSanPham_Click(object sender, EventArgs e)
        {
            txtTimSanPham.Text = string.Empty;
            LoadSanPham();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {

        }

        private void dtgSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgSanPham.SelectedRows[0];
                string maSanPham = selectedRow.Cells["maSanPham"].Value.ToString();
                string maBaoHanh = selectedRow.Cells["maBaoHanh"].Value.ToString();
                string maVach = selectedRow.Cells["maVach"].Value.ToString();
                string tenSanPham = selectedRow.Cells["tenSanPham"].Value.ToString();
                int maDanhMuc = int.Parse(selectedRow.Cells["maDanhMuc"].Value.ToString());
                int maNhaCungCap = int.Parse(selectedRow.Cells["maNhaCungCap"].Value.ToString());
                string moTa = selectedRow.Cells["moTa"].Value.ToString();
                DateTime ngaySanXuat = DateTime.Parse(selectedRow.Cells["ngaySanXuat"].Value.ToString());
                string xuatXu = selectedRow.Cells["xuatXu"].Value.ToString();
                int giaBan = int.Parse(selectedRow.Cells["giaBan"].Value.ToString());

                txtGiaBan.Text = giaBan.ToString("N0") + " VND";
                txtSanPham.Text = tenSanPham;
                txtMaVach.Text = maVach;

                cbBaoHanh.SelectedValue = maBaoHanh;
                cbDanhMuc.SelectedValue = maDanhMuc;
                cbNhaCungCap.SelectedValue = maNhaCungCap;
                dtpNgaySanXuat.Value = ngaySanXuat;
                txtXuatXu.Text = xuatXu;
                rtxtMoTa.Text = moTa;
            }
        }
    }
}
