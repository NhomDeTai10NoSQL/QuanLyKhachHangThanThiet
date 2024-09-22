using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
namespace Main
{
    public partial class frmTrangChu : UIAsideHeaderMainFrame
    {
        public frmTrangChu()
        {
            InitializeComponent();
            int pageIndex = 1000;
            TreeNode root = Aside.CreateNode("QUẢN LÝ KHÁCH HÀNG", 61451, 24, pageIndex);

            pageIndex = 2000;
            root = Aside.CreateNode("QUẢN LÝ GIAO DỊCH", 61451, 24, pageIndex);
            
        }
    }
}
