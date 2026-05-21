namespace QLTC
{
    partial class ViTien
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
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTV = new System.Windows.Forms.TextBox();
            this.tbSD = new System.Windows.Forms.TextBox();
            this.tbGC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSD = new System.Windows.Forms.Label();
            this.dgVT = new System.Windows.Forms.DataGridView();
            this.maVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgVT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ VÍ TIỀN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(271, 108);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 37);
            this.btThem.TabIndex = 1;
            this.btThem.Text = "Thêm ví";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.ForeColor = System.Drawing.Color.White;
            this.btSua.Location = new System.Drawing.Point(352, 108);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 38);
            this.btSua.TabIndex = 2;
            this.btSua.Text = "Sửa ví";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.White;
            this.btXoa.Location = new System.Drawing.Point(438, 108);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 38);
            this.btXoa.TabIndex = 3;
            this.btXoa.Text = "Xóa ví";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng số dư:";
            // 
            // tbTV
            // 
            this.tbTV.Location = new System.Drawing.Point(21, 82);
            this.tbTV.Name = "tbTV";
            this.tbTV.Size = new System.Drawing.Size(100, 20);
            this.tbTV.TabIndex = 7;
            // 
            // tbSD
            // 
            this.tbSD.Location = new System.Drawing.Point(145, 82);
            this.tbSD.Name = "tbSD";
            this.tbSD.Size = new System.Drawing.Size(100, 20);
            this.tbSD.TabIndex = 8;
            // 
            // tbGC
            // 
            this.tbGC.Location = new System.Drawing.Point(271, 82);
            this.tbGC.Name = "tbGC";
            this.tbGC.Size = new System.Drawing.Size(242, 20);
            this.tbGC.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên ví:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số dư:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(268, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ghi chú:";
            // 
            // lbSD
            // 
            this.lbSD.AutoSize = true;
            this.lbSD.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSD.ForeColor = System.Drawing.Color.Lime;
            this.lbSD.Location = new System.Drawing.Point(133, 339);
            this.lbSD.Name = "lbSD";
            this.lbSD.Size = new System.Drawing.Size(0, 24);
            this.lbSD.TabIndex = 14;
            // 
            // dgVT
            // 
            this.dgVT.BackgroundColor = System.Drawing.Color.White;
            this.dgVT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maVi,
            this.tenVi,
            this.soDu,
            this.ghiChu});
            this.dgVT.Location = new System.Drawing.Point(5, 152);
            this.dgVT.Name = "dgVT";
            this.dgVT.Size = new System.Drawing.Size(508, 184);
            this.dgVT.TabIndex = 15;
            this.dgVT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVT_CellClick);
            // 
            // maVi
            // 
            this.maVi.DataPropertyName = "MaVi";
            this.maVi.HeaderText = "Mã";
            this.maVi.Name = "maVi";
            this.maVi.Width = 50;
            // 
            // tenVi
            // 
            this.tenVi.DataPropertyName = "TenVi";
            this.tenVi.HeaderText = "Tên ví";
            this.tenVi.Name = "tenVi";
            this.tenVi.Width = 115;
            // 
            // soDu
            // 
            this.soDu.DataPropertyName = "SoDu";
            this.soDu.HeaderText = "Số dư";
            this.soDu.Name = "soDu";
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "GhiChu";
            this.ghiChu.HeaderText = "Ghi chú";
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 200;
            // 
            // ViTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(522, 372);
            this.Controls.Add(this.dgVT);
            this.Controls.Add(this.lbSD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGC);
            this.Controls.Add(this.tbSD);
            this.Controls.Add(this.tbTV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.label1);
            this.Name = "ViTien";
            this.Text = "Ví Tiền";
            this.Load += new System.EventHandler(this.ViTien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTV;
        private System.Windows.Forms.TextBox tbSD;
        private System.Windows.Forms.TextBox tbGC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbSD;
        private System.Windows.Forms.DataGridView dgVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn maVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
    }
}