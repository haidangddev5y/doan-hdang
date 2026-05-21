namespace QLTC
{
    partial class DanhMuc
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
            this.tbGC = new System.Windows.Forms.TextBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.tbTDM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btChi = new System.Windows.Forms.Button();
            this.btThu = new System.Windows.Forms.Button();
            this.btTC = new System.Windows.Forms.Button();
            this.dgDM = new System.Windows.Forms.DataGridView();
            this.maDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDM)).BeginInit();
            this.SuspendLayout();
            // 
            // tbGC
            // 
            this.tbGC.Location = new System.Drawing.Point(208, 95);
            this.tbGC.Name = "tbGC";
            this.tbGC.Size = new System.Drawing.Size(400, 20);
            this.tbGC.TabIndex = 28;
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Items.AddRange(new object[] {
            ""});
            this.cbLoai.Location = new System.Drawing.Point(118, 94);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(73, 21);
            this.cbLoai.TabIndex = 27;
            // 
            // tbTDM
            // 
            this.tbTDM.Location = new System.Drawing.Point(12, 94);
            this.tbTDM.Name = "tbTDM";
            this.tbTDM.Size = new System.Drawing.Size(100, 20);
            this.tbTDM.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ghi chú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Loại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tên danh mục";
            // 
            // btChi
            // 
            this.btChi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChi.Location = new System.Drawing.Point(177, 161);
            this.btChi.Name = "btChi";
            this.btChi.Size = new System.Drawing.Size(75, 23);
            this.btChi.TabIndex = 22;
            this.btChi.Text = "CHI";
            this.btChi.UseVisualStyleBackColor = true;
            this.btChi.Click += new System.EventHandler(this.btChi_Click);
            // 
            // btThu
            // 
            this.btThu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThu.Location = new System.Drawing.Point(96, 161);
            this.btThu.Name = "btThu";
            this.btThu.Size = new System.Drawing.Size(75, 23);
            this.btThu.TabIndex = 21;
            this.btThu.Text = "THU";
            this.btThu.UseVisualStyleBackColor = true;
            this.btThu.Click += new System.EventHandler(this.btThu_Click);
            // 
            // btTC
            // 
            this.btTC.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTC.Location = new System.Drawing.Point(12, 161);
            this.btTC.Name = "btTC";
            this.btTC.Size = new System.Drawing.Size(75, 23);
            this.btTC.TabIndex = 20;
            this.btTC.Text = "TẤT CẢ";
            this.btTC.UseVisualStyleBackColor = true;
            this.btTC.Click += new System.EventHandler(this.btTC_Click);
            // 
            // dgDM
            // 
            this.dgDM.BackgroundColor = System.Drawing.Color.White;
            this.dgDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDM,
            this.tenDM,
            this.loai,
            this.ghiChu});
            this.dgDM.Location = new System.Drawing.Point(4, 190);
            this.dgDM.Name = "dgDM";
            this.dgDM.Size = new System.Drawing.Size(616, 260);
            this.dgDM.TabIndex = 19;
            this.dgDM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDM_CellClick);
            // 
            // maDM
            // 
            this.maDM.DataPropertyName = "MaDM";
            this.maDM.HeaderText = "Mã ";
            this.maDM.Name = "maDM";
            this.maDM.Width = 50;
            // 
            // tenDM
            // 
            this.tenDM.DataPropertyName = "TenDM";
            this.tenDM.HeaderText = "Tên danh mục";
            this.tenDM.Name = "tenDM";
            this.tenDM.Width = 150;
            // 
            // loai
            // 
            this.loai.DataPropertyName = "loai";
            this.loai.HeaderText = "Loại";
            this.loai.Name = "loai";
            this.loai.Width = 50;
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "GhiChu";
            this.ghiChu.HeaderText = "Ghi chú";
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 320;
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Location = new System.Drawing.Point(529, 128);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(79, 28);
            this.btXoa.TabIndex = 18;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Location = new System.Drawing.Point(438, 129);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(85, 29);
            this.btSua.TabIndex = 17;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(345, 125);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(87, 33);
            this.btThem.TabIndex = 16;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightYellow;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 60);
            this.label1.TabIndex = 15;
            this.label1.Text = "QUẢN LÝ DANH MỤC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.tbGC);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.tbTDM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btChi);
            this.Controls.Add(this.btThu);
            this.Controls.Add(this.btTC);
            this.Controls.Add(this.dgDM);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.label1);
            this.Name = "DanhMuc";
            this.Text = "DanhMuc";
            this.Load += new System.EventHandler(this.DanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbGC;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.TextBox tbTDM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btChi;
        private System.Windows.Forms.Button btThu;
        private System.Windows.Forms.Button btTC;
        private System.Windows.Forms.DataGridView dgDM;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
    }
}