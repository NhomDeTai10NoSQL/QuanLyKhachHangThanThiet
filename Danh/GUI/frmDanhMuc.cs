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
        public frmDanhMuc()
        {
            InitializeComponent();
            danhMucBUS = new DanhMucBUS();
            LoadDanhMuc();
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

            dtgDanhMuc.Columns["MaDanhMuc"].HeaderText = "MaDanhMuc";
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
    }
}
