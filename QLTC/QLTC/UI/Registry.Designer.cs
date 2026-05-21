namespace QLTC
{
    partial class Registry
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
            this.lbDK = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTDN = new System.Windows.Forms.TextBox();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.tbNLMK = new System.Windows.Forms.TextBox();
            this.btHUY = new System.Windows.Forms.Button();
            this.btDK = new System.Windows.Forms.Button();
            this.cbHTMK = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDK
            // 
            this.lbDK.BackColor = System.Drawing.Color.LightBlue;
            this.lbDK.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDK.Location = new System.Drawing.Point(3, 0);
            this.lbDK.Name = "lbDK";
            this.lbDK.Size = new System.Drawing.Size(282, 77);
            this.lbDK.TabIndex = 0;
            this.lbDK.Text = "ĐĂNG KÝ";
            this.lbDK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightBlue;
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightBlue;
            this.label4.Location = new System.Drawing.Point(3, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhập lại mật khẩu:";
            // 
            // tbTDN
            // 
            this.tbTDN.Location = new System.Drawing.Point(105, 80);
            this.tbTDN.Name = "tbTDN";
            this.tbTDN.Size = new System.Drawing.Size(180, 20);
            this.tbTDN.TabIndex = 4;
            // 
            // tbMK
            // 
            this.tbMK.Location = new System.Drawing.Point(105, 106);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(180, 20);
            this.tbMK.TabIndex = 5;
            this.tbMK.UseSystemPasswordChar = true;
            // 
            // tbNLMK
            // 
            this.tbNLMK.Location = new System.Drawing.Point(105, 133);
            this.tbNLMK.Name = "tbNLMK";
            this.tbNLMK.Size = new System.Drawing.Size(180, 20);
            this.tbNLMK.TabIndex = 6;
            this.tbNLMK.UseSystemPasswordChar = true;
            // 
            // btHUY
            // 
            this.btHUY.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btHUY.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHUY.ForeColor = System.Drawing.Color.White;
            this.btHUY.Location = new System.Drawing.Point(87, 181);
            this.btHUY.Name = "btHUY";
            this.btHUY.Size = new System.Drawing.Size(78, 31);
            this.btHUY.TabIndex = 7;
            this.btHUY.Text = "Hủy";
            this.btHUY.UseVisualStyleBackColor = false;
            this.btHUY.Click += new System.EventHandler(this.btHUY_Click);
            // 
            // btDK
            // 
            this.btDK.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btDK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDK.ForeColor = System.Drawing.Color.White;
            this.btDK.Location = new System.Drawing.Point(202, 181);
            this.btDK.Name = "btDK";
            this.btDK.Size = new System.Drawing.Size(76, 31);
            this.btDK.TabIndex = 8;
            this.btDK.Text = "Đăng ký";
            this.btDK.UseVisualStyleBackColor = false;
            this.btDK.Click += new System.EventHandler(this.btDK_Click);
            // 
            // cbHTMK
            // 
            this.cbHTMK.AutoSize = true;
            this.cbHTMK.Location = new System.Drawing.Point(87, 159);
            this.cbHTMK.Name = "cbHTMK";
            this.cbHTMK.Size = new System.Drawing.Size(109, 17);
            this.cbHTMK.TabIndex = 9;
            this.cbHTMK.Text = "Hiển thị mật khẩu";
            this.cbHTMK.UseVisualStyleBackColor = true;
            this.cbHTMK.CheckedChanged += new System.EventHandler(this.cbHTMK_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::QLTC.Properties.Resources.qlct_login;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 288);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.tbTDN);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbHTMK);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbMK);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btDK);
            this.panel2.Controls.Add(this.lbDK);
            this.panel2.Controls.Add(this.tbNLMK);
            this.panel2.Controls.Add(this.btHUY);
            this.panel2.Location = new System.Drawing.Point(139, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 291);
            this.panel2.TabIndex = 11;
            // 
            // Registry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 285);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Registry";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTDN;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.TextBox tbNLMK;
        private System.Windows.Forms.Button btHUY;
        private System.Windows.Forms.Button btDK;
        private System.Windows.Forms.CheckBox cbHTMK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}