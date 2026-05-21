namespace QLTC
{
    partial class ThietLapNganSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbGH = new System.Windows.Forms.TextBox();
            this.cbDMChi = new System.Windows.Forms.ComboBox();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.dgTLNS = new System.Windows.Forms.DataGridView();
            this.maNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSua = new System.Windows.Forms.Button();
            this.btQLNS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTLNS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "THIẾT LẬP NGÂN SÁCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới hạn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Năm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Danh mục chi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tháng";
            // 
            // tbGH
            // 
            this.tbGH.Location = new System.Drawing.Point(83, 128);
            this.tbGH.Name = "tbGH";
            this.tbGH.Size = new System.Drawing.Size(121, 20);
            this.tbGH.TabIndex = 7;
            // 
            // cbDMChi
            // 
            this.cbDMChi.FormattingEnabled = true;
            this.cbDMChi.Location = new System.Drawing.Point(83, 85);
            this.cbDMChi.Name = "cbDMChi";
            this.cbDMChi.Size = new System.Drawing.Size(121, 21);
            this.cbDMChi.TabIndex = 8;
            // 
            // cbThang
            // 
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(295, 85);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(121, 21);
            this.cbThang.TabIndex = 9;
            // 
            // cbNam
            // 
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(295, 127);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(121, 21);
            this.cbNam.TabIndex = 10;
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(245, 170);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 35);
            this.btThem.TabIndex = 11;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Location = new System.Drawing.Point(409, 170);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 35);
            this.btXoa.TabIndex = 12;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // dgTLNS
            // 
            this.dgTLNS.BackgroundColor = System.Drawing.Color.White;
            this.dgTLNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTLNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNS,
            this.danhMuc,
            this.gioiHan,
            this.thang,
            this.nam});
            this.dgTLNS.Location = new System.Drawing.Point(13, 211);
            this.dgTLNS.Name = "dgTLNS";
            this.dgTLNS.Size = new System.Drawing.Size(469, 193);
            this.dgTLNS.TabIndex = 14;
            this.dgTLNS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTLNS_CellClick);
            // 
            // maNS
            // 
            this.maNS.DataPropertyName = "MaNS";
            this.maNS.HeaderText = "Mã";
            this.maNS.Name = "maNS";
            this.maNS.Width = 50;
            // 
            // danhMuc
            // 
            this.danhMuc.DataPropertyName = "danhMuc";
            this.danhMuc.HeaderText = "Danh mục";
            this.danhMuc.Name = "danhMuc";
            this.danhMuc.Width = 115;
            // 
            // gioiHan
            // 
            this.gioiHan.DataPropertyName = "GioiHan";
            this.gioiHan.HeaderText = "Giới Hạn";
            this.gioiHan.Name = "gioiHan";
            this.gioiHan.Width = 120;
            // 
            // thang
            // 
            this.thang.DataPropertyName = "Thang";
            this.thang.HeaderText = "Tháng";
            this.thang.Name = "thang";
            this.thang.Width = 70;
            // 
            // nam
            // 
            this.nam.DataPropertyName = "Nam";
            this.nam.HeaderText = "Năm";
            this.nam.Name = "nam";
            this.nam.Width = 70;
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Location = new System.Drawing.Point(327, 170);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 35);
            this.btSua.TabIndex = 15;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btQLNS
            // 
            this.btQLNS.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btQLNS.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQLNS.ForeColor = System.Drawing.Color.White;
            this.btQLNS.Location = new System.Drawing.Point(13, 170);
            this.btQLNS.Name = "btQLNS";
            this.btQLNS.Size = new System.Drawing.Size(120, 35);
            this.btQLNS.TabIndex = 16;
            this.btQLNS.Text = "Quản lý ngân sách";
            this.btQLNS.UseVisualStyleBackColor = false;
            this.btQLNS.Click += new System.EventHandler(this.btQLNS_Click);
            // 
            // ThietLapNganSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(496, 416);
            this.Controls.Add(this.btQLNS);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.dgTLNS);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.cbDMChi);
            this.Controls.Add(this.tbGH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ThietLapNganSach";
            this.Text = "ThietLapNganSach";
            this.Load += new System.EventHandler(this.ThietLapNganSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTLNS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbGH;
        private System.Windows.Forms.ComboBox cbDMChi;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.DataGridView dgTLNS;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn thang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nam;
        private System.Windows.Forms.Button btQLNS;
    }
}