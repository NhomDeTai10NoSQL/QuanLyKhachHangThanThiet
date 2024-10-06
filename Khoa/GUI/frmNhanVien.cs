using Khoa.BUS;
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

namespace Khoa.GUI
{
    public partial class frmNhanVien : UIPage
    {
        DataTable dtNhanVien = new DataTable();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public frmNhanVien()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            dtNhanVien = nhanVienBUS.getALlNhanVien();
            dgvNhanVien.DataSource = dtNhanVien;
        }

    }
}
