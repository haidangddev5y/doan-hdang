namespace QLTC
{
    partial class QLTaiKhoan
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
            this.dgTK = new System.Windows.Forms.DataGridView();
            this.maTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btTC = new System.Windows.Forms.Button();
            this.btTK = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.cbVT = new System.Windows.Forms.ComboBox();
            this.tbMK = new System.Windows.Forms.TextBox();
            this.tbTK = new System.Windows.Forms.TextBox();
            this.tbTDN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTK)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTK
            // 
            this.dgTK.BackgroundColor = System.Drawing.Color.White;
            this.dgTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maTK,
            this.tenDN,
            this.matKhau,
            this.vaiTro});
            this.dgTK.Location = new System.Drawing.Point(374, 81);
            this.dgTK.Name = "dgTK";
            this.dgTK.Size = new System.Drawing.Size(444, 373);
            this.dgTK.TabIndex = 48;
            this.dgTK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTK_CellClick);
            // 
            // maTK
            // 
            this.maTK.DataPropertyName = "MaTK";
            this.maTK.HeaderText = "Mã";
            this.maTK.Name = "maTK";
            this.maTK.Width = 50;
            // 
            // tenDN
            // 
            this.tenDN.DataPropertyName = "TenDangNhap";
            this.tenDN.HeaderText = "Tên đăng nhập";
            this.tenDN.Name = "tenDN";
            this.tenDN.Width = 125;
            // 
            // matKhau
            // 
            this.matKhau.DataPropertyName = "MatKhau";
            this.matKhau.HeaderText = "Mật khẩu";
            this.matKhau.Name = "matKhau";
            this.matKhau.Width = 125;
            // 
            // vaiTro
            // 
            this.vaiTro.DataPropertyName = "VaiTro";
            this.vaiTro.HeaderText = "Vai Trò";
            this.vaiTro.Name = "vaiTro";
            // 
            // btTC
            // 
            this.btTC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTC.Location = new System.Drawing.Point(12, 12);
            this.btTC.Name = "btTC";
            this.btTC.Size = new System.Drawing.Size(95, 31);
            this.btTC.TabIndex = 47;
            this.btTC.Text = "Trang chủ";
            this.btTC.UseVisualStyleBackColor = true;
            this.btTC.Click += new System.EventHandler(this.btTC_Click);
            // 
            // btTK
            // 
            this.btTK.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTK.ForeColor = System.Drawing.Color.White;
            this.btTK.Location = new System.Drawing.Point(240, 245);
            this.btTK.Name = "btTK";
            this.btTK.Size = new System.Drawing.Size(53, 29);
            this.btTK.TabIndex = 45;
            this.btTK.Text = "Tìm";
            this.btTK.UseVisualStyleBackColor = false;
            this.btTK.Click += new System.EventHandler(this.btTK_Click);
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Location = new System.Drawing.Point(139, 323);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(95, 32);
            this.btSua.TabIndex = 44;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Location = new System.Drawing.Point(268, 323);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(84, 32);
            this.btXoa.TabIndex = 43;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(12, 323);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(84, 32);
            this.btThem.TabIndex = 42;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // cbVT
            // 
            this.cbVT.FormattingEnabled = true;
            this.cbVT.Location = new System.Drawing.Point(102, 195);
            this.cbVT.Name = "cbVT";
            this.cbVT.Size = new System.Drawing.Size(132, 21);
            this.cbVT.TabIndex = 41;
            // 
            // tbMK
            // 
            this.tbMK.Location = new System.Drawing.Point(102, 142);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(132, 20);
            this.tbMK.TabIndex = 40;
            // 
            // tbTK
            // 
            this.tbTK.Location = new System.Drawing.Point(102, 254);
            this.tbTK.Name = "tbTK";
            this.tbTK.Size = new System.Drawing.Size(132, 20);
            this.tbTK.TabIndex = 39;
            // 
            // tbTDN
            // 
            this.tbTDN.Location = new System.Drawing.Point(102, 96);
            this.tbTDN.Name = "tbTDN";
            this.tbTDN.Size = new System.Drawing.Size(132, 20);
            this.tbTDN.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Tìm kiếm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Vai trò:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 55);
            this.label1.TabIndex = 33;
            this.label1.Text = "QUẢN LÝ TÀI KHOẢN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QLTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(820, 460);
            this.Controls.Add(this.dgTK);
            this.Controls.Add(this.btTC);
            this.Controls.Add(this.btTK);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cbVT);
            this.Controls.Add(this.tbMK);
            this.Controls.Add(this.tbTK);
            this.Controls.Add(this.tbTDN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QLTaiKhoan";
            this.Text = "QLTaiKhoan";
            this.Load += new System.EventHandler(this.QLTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTK;
        private System.Windows.Forms.Button btTC;
        private System.Windows.Forms.Button btTK;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.ComboBox cbVT;
        private System.Windows.Forms.TextBox tbMK;
        private System.Windows.Forms.TextBox tbTK;
        private System.Windows.Forms.TextBox tbTDN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn matKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn vaiTro;
    }
}