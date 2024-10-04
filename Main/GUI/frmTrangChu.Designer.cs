namespace Main
{
    partial class frmTrangChu
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
            this.lblTaiKhoan = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Controls.Add(this.lblTaiKhoan);
            this.Header.Location = new System.Drawing.Point(306, 35);
            this.Header.Size = new System.Drawing.Size(494, 41);
            // 
            // Aside
            // 
            this.Aside.Size = new System.Drawing.Size(306, 415);
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblTaiKhoan.Location = new System.Drawing.Point(211, 12);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(100, 23);
            this.lblTaiKhoan.TabIndex = 0;
            this.lblTaiKhoan.Text = "uiLabel1";
            // 
            // frmTrangChu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "frmTrangChu";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.Header.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lblTaiKhoan;
    }
}

