namespace QLTC
{
    partial class QLGiaoDich
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.cbVi = new System.Windows.Forms.ComboBox();
            this.btLoc = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.dgGD = new System.Windows.Forms.DataGridView();
            this.ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgGD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LawnGreen;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(774, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIAO DỊCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(564, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ví:";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(15, 141);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 5;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(221, 141);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // cbLoai
            // 
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(440, 141);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(121, 21);
            this.cbLoai.TabIndex = 7;
            // 
            // cbVi
            // 
            this.cbVi.FormattingEnabled = true;
            this.cbVi.Location = new System.Drawing.Point(567, 141);
            this.cbVi.Name = "cbVi";
            this.cbVi.Size = new System.Drawing.Size(121, 21);
            this.cbVi.TabIndex = 8;
            // 
            // btLoc
            // 
            this.btLoc.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btLoc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoc.ForeColor = System.Drawing.Color.White;
            this.btLoc.Location = new System.Drawing.Point(695, 137);
            this.btLoc.Name = "btLoc";
            this.btLoc.Size = new System.Drawing.Size(75, 25);
            this.btLoc.TabIndex = 9;
            this.btLoc.Text = "Lọc";
            this.btLoc.UseVisualStyleBackColor = false;
            this.btLoc.Click += new System.EventHandler(this.btLoc_Click);
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.ForeColor = System.Drawing.Color.White;
            this.btThem.Location = new System.Drawing.Point(633, 96);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(137, 35);
            this.btThem.TabIndex = 10;
            this.btThem.Text = "+ Thêm giao dịch";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // dgGD
            // 
            this.dgGD.BackgroundColor = System.Drawing.Color.White;
            this.dgGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ngay,
            this.noiDung,
            this.loai,
            this.danhMuc,
            this.vi,
            this.soTien});
            this.dgGD.Location = new System.Drawing.Point(13, 183);
            this.dgGD.Name = "dgGD";
            this.dgGD.Size = new System.Drawing.Size(749, 208);
            this.dgGD.TabIndex = 11;
            // 
            // ngay
            // 
            this.ngay.DataPropertyName = "Ngay";
            this.ngay.HeaderText = "Ngày";
            this.ngay.Name = "ngay";
            // 
            // noiDung
            // 
            this.noiDung.DataPropertyName = "NoiDung";
            this.noiDung.HeaderText = "Nội dung";
            this.noiDung.Name = "noiDung";
            this.noiDung.Width = 200;
            // 
            // loai
            // 
            this.loai.DataPropertyName = "Loai";
            this.loai.HeaderText = "Loại";
            this.loai.Name = "loai";
            // 
            // danhMuc
            // 
            this.danhMuc.DataPropertyName = "danhMuc";
            this.danhMuc.HeaderText = "Danh mục";
            this.danhMuc.Name = "danhMuc";
            // 
            // vi
            // 
            this.vi.DataPropertyName = "vi";
            this.vi.HeaderText = "Ví";
            this.vi.Name = "vi";
            // 
            // soTien
            // 
            this.soTien.DataPropertyName = "SoTien";
            this.soTien.HeaderText = "Số tiền";
            this.soTien.Name = "soTien";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lbTC);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbTT);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(15, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 60);
            this.panel1.TabIndex = 12;
            // 
            // lbTC
            // 
            this.lbTC.AutoSize = true;
            this.lbTC.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTC.ForeColor = System.Drawing.Color.Red;
            this.lbTC.Location = new System.Drawing.Point(525, 17);
            this.lbTC.Name = "lbTC";
            this.lbTC.Size = new System.Drawing.Size(0, 24);
            this.lbTC.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(432, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 22);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tổng chi:";
            // 
            // lbTT
            // 
            this.lbTT.AutoSize = true;
            this.lbTT.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTT.ForeColor = System.Drawing.Color.Lime;
            this.lbTT.Location = new System.Drawing.Point(163, 17);
            this.lbTT.Name = "lbTT";
            this.lbTT.Size = new System.Drawing.Size(0, 24);
            this.lbTT.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng thu:";
            // 
            // QLGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(774, 464);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgGD);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.btLoc);
            this.Controls.Add(this.cbVi);
            this.Controls.Add(this.cbLoai);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QLGiaoDich";
            this.Text = "QLGiaoDich";
            this.Load += new System.EventHandler(this.QLGiaoDich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.ComboBox cbVi;
        private System.Windows.Forms.Button btLoc;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.DataGridView dgGD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn noiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn vi;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTien;
    }
}