namespace Khoa
{
    partial class frmKhachHangThanThiet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txtTenKH = new Sunny.UI.UITextBox();
            this.txtSDT = new Sunny.UI.UITextBox();
            this.txtDiem = new Sunny.UI.UITextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboTrangThai = new Sunny.UI.UIComboBox();
            this.cboLoaiKH = new Sunny.UI.UIComboBox();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.btnThem = new Sunny.UI.UISymbolButton();
            this.btnSua = new Sunny.UI.UISymbolButton();
            this.btnAn = new Sunny.UI.UISymbolButton();
            this.btnLamMoi = new Sunny.UI.UISymbolButton();
            this.dgvKhachHang = new Sunny.UI.UIDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 4;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.Controls.Add(this.txtDiem, 3, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.txtTenKH, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel4, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 2, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel6, 2, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.txtSDT, 1, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.dtpNgaySinh, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.cboTrangThai, 3, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.cboLoaiKH, 3, 2);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 3;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1205, 171);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(166, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Tên khách hàng:";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(3, 57);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(154, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Ngày sinh:";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(605, 57);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(133, 23);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "Trạng thái:";
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(605, 0);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(133, 23);
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "Điểm tích lũy:";
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(3, 114);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(154, 23);
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "Số điện thoại:";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel6.Location = new System.Drawing.Point(605, 114);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(178, 23);
            this.uiLabel6.TabIndex = 5;
            this.uiLabel6.Text = "Loại khách hàng:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenKH.Location = new System.Drawing.Point(245, 5);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenKH.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Padding = new System.Windows.Forms.Padding(5);
            this.txtTenKH.ShowText = false;
            this.txtTenKH.Size = new System.Drawing.Size(353, 47);
            this.txtTenKH.TabIndex = 1;
            this.txtTenKH.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenKH.Watermark = "";
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(245, 119);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSDT.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Padding = new System.Windows.Forms.Padding(5);
            this.txtSDT.ShowText = false;
            this.txtSDT.Size = new System.Drawing.Size(353, 47);
            this.txtSDT.TabIndex = 3;
            this.txtSDT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSDT.Watermark = "";
            // 
            // txtDiem
            // 
            this.txtDiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDiem.Location = new System.Drawing.Point(847, 5);
            this.txtDiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiem.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Padding = new System.Windows.Forms.Padding(5);
            this.txtDiem.ShowText = false;
            this.txtDiem.Size = new System.Drawing.Size(353, 47);
            this.txtDiem.TabIndex = 3;
            this.txtDiem.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDiem.Watermark = "";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(244, 60);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(355, 30);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DataSource = null;
            this.cboTrangThai.FillColor = System.Drawing.Color.White;
            this.cboTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboTrangThai.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboTrangThai.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboTrangThai.Location = new System.Drawing.Point(847, 62);
            this.cboTrangThai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTrangThai.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboTrangThai.Size = new System.Drawing.Size(353, 47);
            this.cboTrangThai.SymbolSize = 24;
            this.cboTrangThai.TabIndex = 7;
            this.cboTrangThai.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboTrangThai.Watermark = "";
            // 
            // cboLoaiKH
            // 
            this.cboLoaiKH.DataSource = null;
            this.cboLoaiKH.FillColor = System.Drawing.Color.White;
            this.cboLoaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboLoaiKH.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cboLoaiKH.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cboLoaiKH.Location = new System.Drawing.Point(847, 119);
            this.cboLoaiKH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboLoaiKH.MinimumSize = new System.Drawing.Size(63, 0);
            this.cboLoaiKH.Name = "cboLoaiKH";
            this.cboLoaiKH.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cboLoaiKH.Size = new System.Drawing.Size(353, 47);
            this.cboLoaiKH.SymbolSize = 24;
            this.cboLoaiKH.TabIndex = 8;
            this.cboLoaiKH.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cboLoaiKH.Watermark = "";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnAn);
            this.uiGroupBox1.Controls.Add(this.btnLamMoi);
            this.uiGroupBox1.Controls.Add(this.btnThem);
            this.uiGroupBox1.Controls.Add(this.btnSua);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 171);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1205, 81);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = "Chức năng";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(144, 35);
            this.btnThem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(207, 35);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm khách hàng";
            this.btnThem.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(376, 35);
            this.btnSua.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(207, 35);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa khách hàng";
            this.btnSua.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnAn
            // 
            this.btnAn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAn.Location = new System.Drawing.Point(610, 35);
            this.btnAn.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(207, 35);
            this.btnAn.TabIndex = 3;
            this.btnAn.Text = "Ẩn khách hàng";
            this.btnAn.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(839, 35);
            this.btnLamMoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(207, 35);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // dgvKhachHang
            // 
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvKhachHang.ColumnHeadersHeight = 32;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhachHang.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvKhachHang.EnableHeadersVisualStyles = false;
            this.dgvKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgvKhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 252);
            this.dgvKhachHang.Name = "dgvKhachHang";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvKhachHang.RowHeadersWidth = 51;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgvKhachHang.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.SelectedIndex = -1;
            this.dgvKhachHang.Size = new System.Drawing.Size(1205, 316);
            this.dgvKhachHang.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dgvKhachHang.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaKhachHang";
            this.Column1.HeaderText = "Mã khách hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 175;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenKhachHang";
            this.Column2.HeaderText = "Tên khách hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 182;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NgaySinh";
            this.Column3.HeaderText = "Ngày sinh";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 127;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SoDienThoai";
            this.Column4.HeaderText = "Số điện thoại";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 154;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DiemTichLuy";
            this.Column5.HeaderText = "Điểm tích lũy";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TrangThai";
            this.Column6.HeaderText = "Trạng thái";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 128;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "LoaiKhachHang";
            this.Column7.HeaderText = "Loại khách hàng";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 184;
            // 
            // frmKhachHangThanThiet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1205, 636);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Name = "frmKhachHangThanThiet";
            this.Text = "frmKhachHangThanThiet";
            this.Initialize += new System.EventHandler(this.frmKhachHangThanThiet_Initialize);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtDiem;
        private Sunny.UI.UITextBox txtTenKH;
        private Sunny.UI.UITextBox txtSDT;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private Sunny.UI.UIComboBox cboTrangThai;
        private Sunny.UI.UIComboBox cboLoaiKH;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UISymbolButton btnAn;
        private Sunny.UI.UISymbolButton btnLamMoi;
        private Sunny.UI.UISymbolButton btnThem;
        private Sunny.UI.UISymbolButton btnSua;
        private Sunny.UI.UIDataGridView dgvKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}