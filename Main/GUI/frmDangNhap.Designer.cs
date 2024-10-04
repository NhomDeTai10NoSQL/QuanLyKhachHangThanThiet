namespace Main.GUI
{
    partial class frmDangNhap
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.chkhienmk = new Sunny.UI.UICheckBox();
            this.btndangnhap = new Sunny.UI.UIButton();
            this.txtmatkhau = new Sunny.UI.UITextBox();
            this.lblmatkhau = new Sunny.UI.UILabel();
            this.txtdangnhap = new Sunny.UI.UITextBox();
            this.lbltendangnhap = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.uiPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.uiPanel1.Controls.Add(this.chkhienmk);
            this.uiPanel1.Controls.Add(this.btndangnhap);
            this.uiPanel1.Controls.Add(this.txtmatkhau);
            this.uiPanel1.Controls.Add(this.lblmatkhau);
            this.uiPanel1.Controls.Add(this.txtdangnhap);
            this.uiPanel1.Controls.Add(this.lbltendangnhap);
            this.uiPanel1.Controls.Add(this.uiLabel2);
            this.uiPanel1.Controls.Add(this.uiLabel1);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(225, 55);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 25;
            this.uiPanel1.RectColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Size = new System.Drawing.Size(350, 341);
            this.uiPanel1.TabIndex = 3;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkhienmk
            // 
            this.chkhienmk.CheckBoxColor = System.Drawing.Color.Gray;
            this.chkhienmk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkhienmk.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkhienmk.ForeColor = System.Drawing.Color.DarkGray;
            this.chkhienmk.Location = new System.Drawing.Point(195, 245);
            this.chkhienmk.MinimumSize = new System.Drawing.Size(1, 1);
            this.chkhienmk.Name = "chkhienmk";
            this.chkhienmk.Size = new System.Drawing.Size(129, 29);
            this.chkhienmk.TabIndex = 7;
            this.chkhienmk.Text = "Hiện mật khẩu";
            this.chkhienmk.CheckedChanged += new System.EventHandler(this.chkhienmk_CheckedChanged);
            // 
            // btndangnhap
            // 
            this.btndangnhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndangnhap.FillColor = System.Drawing.Color.DarkCyan;
            this.btndangnhap.FillColor2 = System.Drawing.Color.Green;
            this.btndangnhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangnhap.Location = new System.Drawing.Point(24, 280);
            this.btndangnhap.MinimumSize = new System.Drawing.Size(1, 1);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Radius = 25;
            this.btndangnhap.RectColor = System.Drawing.Color.Transparent;
            this.btndangnhap.Size = new System.Drawing.Size(300, 35);
            this.btndangnhap.TabIndex = 6;
            this.btndangnhap.Text = "Đăng nhập";
            this.btndangnhap.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btndangnhap.Click += new System.EventHandler(this.btndangnhap_Click);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmatkhau.DoubleValue = 123D;
            this.txtmatkhau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtmatkhau.ForeColor = System.Drawing.Color.White;
            this.txtmatkhau.IntValue = 123;
            this.txtmatkhau.Location = new System.Drawing.Point(24, 202);
            this.txtmatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtmatkhau.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Padding = new System.Windows.Forms.Padding(5);
            this.txtmatkhau.Radius = 20;
            this.txtmatkhau.RectColor = System.Drawing.Color.Black;
            this.txtmatkhau.ShowText = false;
            this.txtmatkhau.Size = new System.Drawing.Size(300, 35);
            this.txtmatkhau.TabIndex = 5;
            this.txtmatkhau.Text = "123";
            this.txtmatkhau.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtmatkhau.Watermark = "";
            // 
            // lblmatkhau
            // 
            this.lblmatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lblmatkhau.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmatkhau.ForeColor = System.Drawing.Color.DarkGray;
            this.lblmatkhau.Location = new System.Drawing.Point(20, 180);
            this.lblmatkhau.Name = "lblmatkhau";
            this.lblmatkhau.Size = new System.Drawing.Size(89, 27);
            this.lblmatkhau.TabIndex = 4;
            this.lblmatkhau.Text = "Mật khẩu :";
            // 
            // txtdangnhap
            // 
            this.txtdangnhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdangnhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtdangnhap.ForeColor = System.Drawing.Color.White;
            this.txtdangnhap.Location = new System.Drawing.Point(24, 124);
            this.txtdangnhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdangnhap.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtdangnhap.Name = "txtdangnhap";
            this.txtdangnhap.Padding = new System.Windows.Forms.Padding(5);
            this.txtdangnhap.Radius = 20;
            this.txtdangnhap.RectColor = System.Drawing.Color.Black;
            this.txtdangnhap.ShowText = false;
            this.txtdangnhap.Size = new System.Drawing.Size(300, 35);
            this.txtdangnhap.TabIndex = 3;
            this.txtdangnhap.Text = "nv001";
            this.txtdangnhap.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdangnhap.Watermark = "";
            // 
            // lbltendangnhap
            // 
            this.lbltendangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lbltendangnhap.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltendangnhap.ForeColor = System.Drawing.Color.DarkGray;
            this.lbltendangnhap.Location = new System.Drawing.Point(20, 92);
            this.lbltendangnhap.Name = "lbltendangnhap";
            this.lbltendangnhap.Size = new System.Drawing.Size(133, 27);
            this.lbltendangnhap.TabIndex = 2;
            this.lbltendangnhap.Text = "Tên đăng nhập :";
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.uiLabel2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel2.ForeColor = System.Drawing.Color.DarkGray;
            this.uiLabel2.Location = new System.Drawing.Point(42, 48);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(253, 27);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "Chúng tôi rất vui khi bạn trở lại";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.uiLabel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(99, 16);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(159, 28);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "XIN CHÀO!";
            // 
            // frmDangNhap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Main.Properties.Resources._461368804_1092443572884094_997600193836192374_n;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiPanel1);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UICheckBox chkhienmk;
        private Sunny.UI.UIButton btndangnhap;
        private Sunny.UI.UITextBox txtmatkhau;
        private Sunny.UI.UILabel lblmatkhau;
        private Sunny.UI.UITextBox txtdangnhap;
        private Sunny.UI.UILabel lbltendangnhap;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
    }
}