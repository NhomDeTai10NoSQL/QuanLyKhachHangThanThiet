namespace Khoa.GUI
{
    partial class frmNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.txtTenNV = new Sunny.UI.UITextBox();
            this.txtSDT = new Sunny.UI.UITextBox();
            this.txtEmail = new Sunny.UI.UITextBox();
            this.txtChucVu = new Sunny.UI.UITextBox();
            this.txtMucLuong = new Sunny.UI.UITextBox();
            this.txtTaiKhoan = new Sunny.UI.UITextBox();
            this.txtMatKhau = new Sunny.UI.UITextBox();
            this.uiRadioButtonGroup1 = new Sunny.UI.UIRadioButtonGroup();
            this.rdoNam = new Sunny.UI.UIRadioButton();
            this.rdoNu = new Sunny.UI.UIRadioButton();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.btnThemNV = new Sunny.UI.UISymbolButton();
            this.btnSuaNV = new Sunny.UI.UISymbolButton();
            this.btnXoaNV = new Sunny.UI.UISymbolButton();
            this.btnLamMoi = new Sunny.UI.UISymbolButton();
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel4 = new Sunny.UI.UITableLayoutPanel();
            this.dgvNhanVien = new Sunny.UI.UIDataGridView();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mucLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiRadioButtonGroup1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.uiTableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 4;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.Controls.Add(this.txtMatKhau, 3, 4);
            this.uiTableLayoutPanel1.Controls.Add(this.txtChucVu, 3, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.txtMucLuong, 3, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.txtEmail, 3, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel9, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel7, 2, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel6, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 2, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel8, 2, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel4, 2, 4);
            this.uiTableLayoutPanel1.Controls.Add(this.txtTenNV, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.txtSDT, 1, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.txtTaiKhoan, 3, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiRadioButtonGroup1, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.dtpNgaySinh, 1, 2);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 5;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1179, 297);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(164, 34);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Tên nhân viên";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(591, 118);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(164, 34);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "Mức lương";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(591, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(164, 34);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "Email";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(591, 236);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(164, 34);
            this.uiLabel4.TabIndex = 4;
            this.uiLabel4.Text = "Mật khẩu";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(3, 59);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(164, 34);
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "Giới tính";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(3, 177);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(164, 34);
            this.uiLabel6.TabIndex = 6;
            this.uiLabel6.Text = "Số điện thoại";
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel7.Location = new System.Drawing.Point(591, 59);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(164, 34);
            this.uiLabel7.TabIndex = 7;
            this.uiLabel7.Text = "Chức vụ";
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel8.Location = new System.Drawing.Point(591, 177);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(164, 34);
            this.uiLabel8.TabIndex = 8;
            this.uiLabel8.Text = "Tài khoản";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel9.Location = new System.Drawing.Point(3, 118);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(164, 34);
            this.uiLabel9.TabIndex = 9;
            this.uiLabel9.Text = "Ngày sinh";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenNV.Location = new System.Drawing.Point(239, 5);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenNV.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Padding = new System.Windows.Forms.Padding(5);
            this.txtTenNV.ShowText = false;
            this.txtTenNV.Size = new System.Drawing.Size(345, 49);
            this.txtTenNV.TabIndex = 10;
            this.txtTenNV.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenNV.Watermark = "";
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(239, 182);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Padding = new System.Windows.Forms.Padding(5);
            this.txtSDT.ShowText = false;
            this.txtSDT.Size = new System.Drawing.Size(345, 49);
            this.txtSDT.TabIndex = 12;
            this.txtSDT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSDT.Watermark = "";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEmail.Location = new System.Drawing.Point(827, 5);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(5);
            this.txtEmail.ShowText = false;
            this.txtEmail.Size = new System.Drawing.Size(348, 49);
            this.txtEmail.TabIndex = 13;
            this.txtEmail.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEmail.Watermark = "";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtChucVu.Location = new System.Drawing.Point(827, 64);
            this.txtChucVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChucVu.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Padding = new System.Windows.Forms.Padding(5);
            this.txtChucVu.ShowText = false;
            this.txtChucVu.Size = new System.Drawing.Size(348, 49);
            this.txtChucVu.TabIndex = 13;
            this.txtChucVu.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtChucVu.Watermark = "";
            // 
            // txtMucLuong
            // 
            this.txtMucLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMucLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMucLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMucLuong.Location = new System.Drawing.Point(827, 123);
            this.txtMucLuong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMucLuong.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMucLuong.Name = "txtMucLuong";
            this.txtMucLuong.Padding = new System.Windows.Forms.Padding(5);
            this.txtMucLuong.ShowText = false;
            this.txtMucLuong.Size = new System.Drawing.Size(348, 49);
            this.txtMucLuong.TabIndex = 14;
            this.txtMucLuong.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMucLuong.Watermark = "";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTaiKhoan.Location = new System.Drawing.Point(827, 182);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTaiKhoan.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Padding = new System.Windows.Forms.Padding(5);
            this.txtTaiKhoan.ShowText = false;
            this.txtTaiKhoan.Size = new System.Drawing.Size(348, 49);
            this.txtTaiKhoan.TabIndex = 15;
            this.txtTaiKhoan.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTaiKhoan.Watermark = "";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMatKhau.Location = new System.Drawing.Point(827, 241);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMatKhau.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Padding = new System.Windows.Forms.Padding(5);
            this.txtMatKhau.ShowText = false;
            this.txtMatKhau.Size = new System.Drawing.Size(348, 51);
            this.txtMatKhau.TabIndex = 13;
            this.txtMatKhau.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMatKhau.Watermark = "";
            // 
            // uiRadioButtonGroup1
            // 
            this.uiRadioButtonGroup1.Controls.Add(this.rdoNu);
            this.uiRadioButtonGroup1.Controls.Add(this.rdoNam);
            this.uiRadioButtonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRadioButtonGroup1.FillColor = System.Drawing.SystemColors.Control;
            this.uiRadioButtonGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiRadioButtonGroup1.Location = new System.Drawing.Point(239, 64);
            this.uiRadioButtonGroup1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiRadioButtonGroup1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonGroup1.Name = "uiRadioButtonGroup1";
            this.uiRadioButtonGroup1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiRadioButtonGroup1.RadioButtonColor = System.Drawing.SystemColors.Control;
            this.uiRadioButtonGroup1.RectColor = System.Drawing.SystemColors.Control;
            this.uiRadioButtonGroup1.RectDisableColor = System.Drawing.SystemColors.Control;
            this.uiRadioButtonGroup1.Size = new System.Drawing.Size(345, 49);
            this.uiRadioButtonGroup1.TabIndex = 16;
            this.uiRadioButtonGroup1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdoNam
            // 
            this.rdoNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoNam.Location = new System.Drawing.Point(3, 19);
            this.rdoNam.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(150, 29);
            this.rdoNam.TabIndex = 0;
            this.rdoNam.Text = "Nam";
            // 
            // rdoNu
            // 
            this.rdoNu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoNu.Location = new System.Drawing.Point(192, 19);
            this.rdoNu.MinimumSize = new System.Drawing.Size(1, 1);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(150, 29);
            this.rdoNu.TabIndex = 1;
            this.rdoNu.Text = "Nữ";
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 4;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel2.Controls.Add(this.btnLamMoi, 3, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.btnXoaNV, 2, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.btnSuaNV, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.btnThemNV, 0, 0);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(0, 297);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 1;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(1179, 55);
            this.uiTableLayoutPanel2.TabIndex = 1;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThemNV.Location = new System.Drawing.Point(3, 3);
            this.btnThemNV.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(288, 49);
            this.btnThemNV.Symbol = 61525;
            this.btnThemNV.TabIndex = 0;
            this.btnThemNV.Text = "Thêm nhân viên";
            this.btnThemNV.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSuaNV.Location = new System.Drawing.Point(297, 3);
            this.btnSuaNV.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(288, 49);
            this.btnSuaNV.Symbol = 61508;
            this.btnSuaNV.TabIndex = 1;
            this.btnSuaNV.Text = "Sửa nhân viên";
            this.btnSuaNV.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnXoaNV
            // 
            this.btnXoaNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXoaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoaNV.Location = new System.Drawing.Point(591, 3);
            this.btnXoaNV.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnXoaNV.Name = "btnXoaNV";
            this.btnXoaNV.Size = new System.Drawing.Size(288, 49);
            this.btnXoaNV.Symbol = 61460;
            this.btnXoaNV.TabIndex = 2;
            this.btnXoaNV.Text = "Xóa nhân viên ";
            this.btnXoaNV.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(885, 3);
            this.btnLamMoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(291, 49);
            this.btnLamMoi.Symbol = 61473;
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiTableLayoutPanel3
            // 
            this.uiTableLayoutPanel3.ColumnCount = 1;
            this.uiTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel3.Location = new System.Drawing.Point(0, 352);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.RowCount = 1;
            this.uiTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel3.Size = new System.Drawing.Size(1179, 55);
            this.uiTableLayoutPanel3.TabIndex = 2;
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // uiTableLayoutPanel4
            // 
            this.uiTableLayoutPanel4.ColumnCount = 1;
            this.uiTableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel4.Controls.Add(this.dgvNhanVien, 0, 0);
            this.uiTableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel4.Location = new System.Drawing.Point(0, 407);
            this.uiTableLayoutPanel4.Name = "uiTableLayoutPanel4";
            this.uiTableLayoutPanel4.RowCount = 1;
            this.uiTableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel4.Size = new System.Drawing.Size(1179, 220);
            this.uiTableLayoutPanel4.TabIndex = 3;
            this.uiTableLayoutPanel4.TagString = null;
            // 
            // dgvNhanVien
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNhanVien.ColumnHeadersHeight = 32;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNhanVien,
            this.tenNhanVien,
            this.gioTinh,
            this.ngaySinh,
            this.soDienThoai,
            this.email,
            this.chucVu,
            this.mucLuong,
            this.taiKhoan,
            this.matKhau});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.EnableHeadersVisualStyles = false;
            this.dgvNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgvNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvNhanVien.Location = new System.Drawing.Point(3, 3);
            this.dgvNhanVien.Name = "dgvNhanVien";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNhanVien.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgvNhanVien.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.SelectedIndex = -1;
            this.dgvNhanVien.Size = new System.Drawing.Size(1173, 214);
            this.dgvNhanVien.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvNhanVien.TabIndex = 0;
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "maNhanVien";
            this.maNhanVien.HeaderText = "Mã nhân viên";
            this.maNhanVien.MinimumWidth = 6;
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.Width = 158;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "tenNhanVien";
            this.tenNhanVien.HeaderText = "Tên nhân viên";
            this.tenNhanVien.MinimumWidth = 6;
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.Width = 165;
            // 
            // gioTinh
            // 
            this.gioTinh.DataPropertyName = "gioTinh";
            this.gioTinh.HeaderText = "Giới tính";
            this.gioTinh.MinimumWidth = 6;
            this.gioTinh.Name = "gioTinh";
            this.gioTinh.Width = 110;
            // 
            // ngaySinh
            // 
            this.ngaySinh.DataPropertyName = "ngaySinh ";
            this.ngaySinh.HeaderText = "Ngày sinh";
            this.ngaySinh.MinimumWidth = 6;
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.Width = 127;
            // 
            // soDienThoai
            // 
            this.soDienThoai.DataPropertyName = "soDienThoai";
            this.soDienThoai.HeaderText = "Số điện thoại";
            this.soDienThoai.MinimumWidth = 6;
            this.soDienThoai.Name = "soDienThoai";
            this.soDienThoai.Width = 154;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.Width = 88;
            // 
            // chucVu
            // 
            this.chucVu.DataPropertyName = "chucVu";
            this.chucVu.HeaderText = "Chức vụ";
            this.chucVu.MinimumWidth = 6;
            this.chucVu.Name = "chucVu";
            this.chucVu.Width = 113;
            // 
            // mucLuong
            // 
            this.mucLuong.DataPropertyName = "mucLuong";
            this.mucLuong.HeaderText = "Mức lương";
            this.mucLuong.MinimumWidth = 6;
            this.mucLuong.Name = "mucLuong";
            this.mucLuong.Width = 131;
            // 
            // taiKhoan
            // 
            this.taiKhoan.DataPropertyName = "taiKhoan";
            this.taiKhoan.HeaderText = "Tài khoản";
            this.taiKhoan.MinimumWidth = 6;
            this.taiKhoan.Name = "taiKhoan";
            this.taiKhoan.Width = 127;
            // 
            // matKhau
            // 
            this.matKhau.DataPropertyName = "matKhau";
            this.matKhau.HeaderText = "Mật khẩu";
            this.matKhau.MinimumWidth = 6;
            this.matKhau.Name = "matKhau";
            this.matKhau.Width = 121;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(238, 121);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(346, 22);
            this.dtpNgaySinh.TabIndex = 17;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 705);
            this.Controls.Add(this.uiTableLayoutPanel4);
            this.Controls.Add(this.uiTableLayoutPanel3);
            this.Controls.Add(this.uiTableLayoutPanel2);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Name = "frmNhanVien";
            this.Text = "frmNhanVien";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiRadioButtonGroup1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.uiTableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITextBox txtMatKhau;
        private Sunny.UI.UITextBox txtChucVu;
        private Sunny.UI.UITextBox txtMucLuong;
        private Sunny.UI.UITextBox txtEmail;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txtTenNV;
        private Sunny.UI.UITextBox txtSDT;
        private Sunny.UI.UITextBox txtTaiKhoan;
        private Sunny.UI.UIRadioButtonGroup uiRadioButtonGroup1;
        private Sunny.UI.UIRadioButton rdoNu;
        private Sunny.UI.UIRadioButton rdoNam;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UISymbolButton btnLamMoi;
        private Sunny.UI.UISymbolButton btnXoaNV;
        private Sunny.UI.UISymbolButton btnSuaNV;
        private Sunny.UI.UISymbolButton btnThemNV;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel3;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel4;
        private Sunny.UI.UIDataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn chucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn mucLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn taiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn matKhau;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
    }
}