namespace Khoa.GUI
{
    partial class frmKhachHangMoi
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
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.txtSDT = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtTenKh = new Sunny.UI.UITextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.btnThem = new Sunny.UI.UISymbolButton();
            this.btnLamMoi = new Sunny.UI.UISymbolButton();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 4;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.uiTableLayoutPanel1.Controls.Add(this.txtSDT, 3, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.txtTenKh, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.dateTimePicker1, 1, 1);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 2;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(1010, 125);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // txtSDT
            // 
            this.txtSDT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSDT.Location = new System.Drawing.Point(711, 6);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSDT.MinimumSize = new System.Drawing.Size(1, 20);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSDT.ShowText = false;
            this.txtSDT.Size = new System.Drawing.Size(286, 50);
            this.txtSDT.TabIndex = 4;
            this.txtSDT.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSDT.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(3, 62);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(161, 29);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Ngày sinh";
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(508, 0);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(159, 29);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "Số điện thoại";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(184, 29);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Tên khách hàng";
            // 
            // txtTenKh
            // 
            this.txtTenKh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTenKh.Location = new System.Drawing.Point(206, 6);
            this.txtTenKh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTenKh.MinimumSize = new System.Drawing.Size(1, 20);
            this.txtTenKh.Name = "txtTenKh";
            this.txtTenKh.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTenKh.ShowText = false;
            this.txtTenKh.Size = new System.Drawing.Size(294, 50);
            this.txtTenKh.TabIndex = 3;
            this.txtTenKh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTenKh.Watermark = "";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 66);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(294, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // uiTableLayoutPanel2
            // 
            this.uiTableLayoutPanel2.ColumnCount = 2;
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.Controls.Add(this.btnThem, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.btnLamMoi, 1, 0);
            this.uiTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTableLayoutPanel2.Location = new System.Drawing.Point(0, 125);
            this.uiTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.RowCount = 1;
            this.uiTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel2.Size = new System.Drawing.Size(1010, 50);
            this.uiTableLayoutPanel2.TabIndex = 1;
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThem.Location = new System.Drawing.Point(3, 4);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(499, 42);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm khách hàng";
            this.btnThem.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLamMoi.Location = new System.Drawing.Point(508, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLamMoi.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(499, 42);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmKhachHangMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 178);
            this.Controls.Add(this.uiTableLayoutPanel2);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKhachHangMoi";
            this.Text = "frmKhachHangMoi";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITextBox txtSDT;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtTenKh;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UISymbolButton btnThem;
        private Sunny.UI.UISymbolButton btnLamMoi;
    }
}