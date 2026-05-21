namespace QLTC
{
    partial class fLogin
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
            this.lbDN = new System.Windows.Forms.Label();
            this.lbTDN = new System.Windows.Forms.Label();
            this.lbMK = new System.Windows.Forms.Label();
            this.tbTDN = new System.Windows.Forms.TextBox();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.btDN = new System.Windows.Forms.Button();
            this.cbHTMK = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llDK = new System.Windows.Forms.LinkLabel();
            this.lbCCTK = new System.Windows.Forms.Label();
            this.lbqltccn = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDN
            // 
            this.lbDN.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDN.Location = new System.Drawing.Point(3, 0);
            this.lbDN.Name = "lbDN";
            this.lbDN.Size = new System.Drawing.Size(322, 62);
            this.lbDN.TabIndex = 0;
            this.lbDN.Text = "ĐĂNG NHẬP";
            this.lbDN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTDN
            // 
            this.lbTDN.AutoSize = true;
            this.lbTDN.Location = new System.Drawing.Point(45, 88);
            this.lbTDN.Name = "lbTDN";
            this.lbTDN.Size = new System.Drawing.Size(84, 13);
            this.lbTDN.TabIndex = 1;
            this.lbTDN.Text = "Tên đăng nhập:";
            // 
            // lbMK
            // 
            this.lbMK.AutoSize = true;
            this.lbMK.Location = new System.Drawing.Point(48, 144);
            this.lbMK.Name = "lbMK";
            this.lbMK.Size = new System.Drawing.Size(55, 13);
            this.lbMK.TabIndex = 2;
            this.lbMK.Text = "Mật khẩu:";
            // 
            // tbTDN
            // 
            this.tbTDN.Location = new System.Drawing.Point(48, 104);
            this.tbTDN.Name = "tbTDN";
            this.tbTDN.Size = new System.Drawing.Size(219, 20);
            this.tbTDN.TabIndex = 3;
            // 
            // tbMK
            // 
            this.tbMK.Location = new System.Drawing.Point(48, 160);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(219, 20);
            this.tbMK.TabIndex = 4;
            this.tbMK.UseSystemPasswordChar = true;
            // 
            // btDN
            // 
            this.btDN.BackColor = System.Drawing.Color.White;
            this.btDN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDN.ForeColor = System.Drawing.Color.Black;
            this.btDN.Location = new System.Drawing.Point(51, 209);
            this.btDN.Name = "btDN";
            this.btDN.Size = new System.Drawing.Size(216, 33);
            this.btDN.TabIndex = 6;
            this.btDN.Text = "ĐĂNG NHẬP";
            this.btDN.UseVisualStyleBackColor = false;
            this.btDN.Click += new System.EventHandler(this.btDN_Click);
            // 
            // cbHTMK
            // 
            this.cbHTMK.AutoSize = true;
            this.cbHTMK.Location = new System.Drawing.Point(51, 186);
            this.cbHTMK.Name = "cbHTMK";
            this.cbHTMK.Size = new System.Drawing.Size(109, 17);
            this.cbHTMK.TabIndex = 7;
            this.cbHTMK.Text = "Hiển thị mật khẩu";
            this.cbHTMK.UseVisualStyleBackColor = true;
            this.cbHTMK.CheckedChanged += new System.EventHandler(this.cbHTMK_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.llDK);
            this.panel1.Controls.Add(this.lbCCTK);
            this.panel1.Controls.Add(this.lbqltccn);
            this.panel1.Controls.Add(this.btDN);
            this.panel1.Controls.Add(this.cbHTMK);
            this.panel1.Controls.Add(this.lbDN);
            this.panel1.Controls.Add(this.tbTDN);
            this.panel1.Controls.Add(this.tbMK);
            this.panel1.Controls.Add(this.lbMK);
            this.panel1.Controls.Add(this.lbTDN);
            this.panel1.Location = new System.Drawing.Point(151, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 304);
            this.panel1.TabIndex = 8;
            // 
            // llDK
            // 
            this.llDK.AutoSize = true;
            this.llDK.Location = new System.Drawing.Point(170, 263);
            this.llDK.Name = "llDK";
            this.llDK.Size = new System.Drawing.Size(73, 13);
            this.llDK.TabIndex = 10;
            this.llDK.TabStop = true;
            this.llDK.Text = "Đăng ký ngay";
            this.llDK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDK_LinkClicked);
            // 
            // lbCCTK
            // 
            this.lbCCTK.AutoSize = true;
            this.lbCCTK.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCCTK.Location = new System.Drawing.Point(76, 263);
            this.lbCCTK.Name = "lbCCTK";
            this.lbCCTK.Size = new System.Drawing.Size(97, 14);
            this.lbCCTK.TabIndex = 9;
            this.lbCCTK.Text = "Chưa có tài khoản?";
            // 
            // lbqltccn
            // 
            this.lbqltccn.Location = new System.Drawing.Point(101, 54);
            this.lbqltccn.Name = "lbqltccn";
            this.lbqltccn.Size = new System.Drawing.Size(130, 23);
            this.lbqltccn.TabIndex = 8;
            this.lbqltccn.Text = "Quản lý tài chính cá nhân";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = global::QLTC.Properties.Resources.qlct_login;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(-4, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 304);
            this.panel2.TabIndex = 9;
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(465, 300);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.Text = "Đăng nhập";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDN;
        private System.Windows.Forms.Label lbTDN;
        private System.Windows.Forms.Label lbMK;
        private System.Windows.Forms.TextBox tbTDN;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.Button btDN;
        private System.Windows.Forms.CheckBox cbHTMK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbqltccn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel llDK;
        private System.Windows.Forms.Label lbCCTK;
    }
}

