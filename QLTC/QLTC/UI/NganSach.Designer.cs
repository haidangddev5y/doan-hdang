namespace QLTC
{
    partial class NganSach
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.btLoc = new System.Windows.Forms.Button();
            this.dgQLNS = new System.Windows.Forms.DataGridView();
            this.danhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbThu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbChi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTNS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgQLNS)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ NGÂN SÁCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm";
            // 
            // cbThang
            // 
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(13, 122);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(103, 21);
            this.cbThang.TabIndex = 3;
            this.cbThang.SelectedIndexChanged += new System.EventHandler(this.cbThang_SelectedIndexChanged);
            // 
            // cbNam
            // 
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(133, 122);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(137, 21);
            this.cbNam.TabIndex = 4;
            this.cbNam.SelectedIndexChanged += new System.EventHandler(this.cbNam_SelectedIndexChanged);
            // 
            // btLoc
            // 
            this.btLoc.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btLoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoc.ForeColor = System.Drawing.Color.White;
            this.btLoc.Location = new System.Drawing.Point(287, 120);
            this.btLoc.Name = "btLoc";
            this.btLoc.Size = new System.Drawing.Size(75, 34);
            this.btLoc.TabIndex = 5;
            this.btLoc.Text = "LỌC";
            this.btLoc.UseVisualStyleBackColor = false;
            // 
            // dgQLNS
            // 
            this.dgQLNS.BackgroundColor = System.Drawing.Color.White;
            this.dgQLNS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQLNS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.danhMuc,
            this.gioiHan,
            this.chi,
            this.conLai});
            this.dgQLNS.Location = new System.Drawing.Point(13, 160);
            this.dgQLNS.Name = "dgQLNS";
            this.dgQLNS.Size = new System.Drawing.Size(565, 172);
            this.dgQLNS.TabIndex = 6;
            // 
            // danhMuc
            // 
            this.danhMuc.DataPropertyName = "danhMuc";
            this.danhMuc.HeaderText = "Danh mục";
            this.danhMuc.Name = "danhMuc";
            // 
            // gioiHan
            // 
            this.gioiHan.DataPropertyName = "gioiHan";
            this.gioiHan.HeaderText = "Giới hạn";
            this.gioiHan.Name = "gioiHan";
            this.gioiHan.Width = 140;
            // 
            // chi
            // 
            this.chi.DataPropertyName = "Chi";
            this.chi.HeaderText = "Đã chi";
            this.chi.Name = "chi";
            this.chi.Width = 140;
            // 
            // conLai
            // 
            this.conLai.DataPropertyName = "conLai";
            this.conLai.HeaderText = "Còn lại";
            this.conLai.Name = "conLai";
            this.conLai.Width = 140;
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(438, 72);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(140, 34);
            this.btThem.TabIndex = 7;
            this.btThem.Text = "+ Thêm ngân sách";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbThu);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbChi);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbTNS);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(13, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 66);
            this.panel1.TabIndex = 8;
            // 
            // lbThu
            // 
            this.lbThu.AutoSize = true;
            this.lbThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThu.ForeColor = System.Drawing.Color.Lime;
            this.lbThu.Location = new System.Drawing.Point(456, 18);
            this.lbThu.Name = "lbThu";
            this.lbThu.Size = new System.Drawing.Size(0, 19);
            this.lbThu.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(403, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Đã thu:";
            // 
            // lbChi
            // 
            this.lbChi.AutoSize = true;
            this.lbChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChi.ForeColor = System.Drawing.Color.Red;
            this.lbChi.Location = new System.Drawing.Point(283, 18);
            this.lbChi.Name = "lbChi";
            this.lbChi.Size = new System.Drawing.Size(0, 19);
            this.lbChi.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(231, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Đã chi:";
            // 
            // lbTNS
            // 
            this.lbTNS.AutoSize = true;
            this.lbTNS.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTNS.ForeColor = System.Drawing.Color.Lime;
            this.lbTNS.Location = new System.Drawing.Point(116, 18);
            this.lbTNS.Name = "lbTNS";
            this.lbTNS.Size = new System.Drawing.Size(0, 19);
            this.lbTNS.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng ngân sách:";
            // 
            // NganSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(590, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.dgQLNS);
            this.Controls.Add(this.btLoc);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NganSach";
            this.Text = "NganSach";
            this.Load += new System.EventHandler(this.NganSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgQLNS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.Button btLoc;
        private System.Windows.Forms.DataGridView dgQLNS;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTNS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbThu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn chi;
        private System.Windows.Forms.DataGridViewTextBoxColumn conLai;
    }
}