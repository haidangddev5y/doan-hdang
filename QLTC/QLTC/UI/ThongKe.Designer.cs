namespace QLTC
{
    partial class ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.btTK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cDanhMuc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cThoiGian = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbCL = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbTC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cThoiGian)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(626, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỐNG KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm:";
            // 
            // cbThang
            // 
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(59, 96);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(121, 21);
            this.cbThang.TabIndex = 3;
            // 
            // cbNam
            // 
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(254, 96);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(121, 21);
            this.cbNam.TabIndex = 4;
            // 
            // btTK
            // 
            this.btTK.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTK.ForeColor = System.Drawing.Color.White;
            this.btTK.Location = new System.Drawing.Point(396, 93);
            this.btTK.Name = "btTK";
            this.btTK.Size = new System.Drawing.Size(95, 36);
            this.btTK.TabIndex = 5;
            this.btTK.Text = "Thống kê";
            this.btTK.UseVisualStyleBackColor = false;
            this.btTK.Click += new System.EventHandler(this.btTK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cDanhMuc);
            this.panel1.Controls.Add(this.cThoiGian);
            this.panel1.Location = new System.Drawing.Point(15, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 234);
            this.panel1.TabIndex = 6;
            // 
            // cDanhMuc
            // 
            chartArea1.Name = "ChartArea1";
            this.cDanhMuc.ChartAreas.Add(chartArea1);
            this.cDanhMuc.Dock = System.Windows.Forms.DockStyle.Right;
            legend1.Name = "Legend1";
            this.cDanhMuc.Legends.Add(legend1);
            this.cDanhMuc.Location = new System.Drawing.Point(299, 0);
            this.cDanhMuc.Name = "cDanhMuc";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Chi";
            this.cDanhMuc.Series.Add(series1);
            this.cDanhMuc.Size = new System.Drawing.Size(300, 234);
            this.cDanhMuc.TabIndex = 1;
            this.cDanhMuc.Text = "chart2";
            // 
            // cThoiGian
            // 
            chartArea2.AxisX.Title = "Ngày";
            chartArea2.AxisY.Title = "Số tiền";
            chartArea2.Name = "ChartArea1";
            this.cThoiGian.ChartAreas.Add(chartArea2);
            this.cThoiGian.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.cThoiGian.Legends.Add(legend2);
            this.cThoiGian.Location = new System.Drawing.Point(0, 0);
            this.cThoiGian.Name = "cThoiGian";
            series2.BorderColor = System.Drawing.Color.White;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.MarkerBorderWidth = 3;
            series2.Name = "Thu";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.MarkerBorderWidth = 3;
            series3.Name = "Chi";
            this.cThoiGian.Series.Add(series2);
            this.cThoiGian.Series.Add(series3);
            this.cThoiGian.Size = new System.Drawing.Size(300, 234);
            this.cThoiGian.TabIndex = 0;
            this.cThoiGian.Text = "chart1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thu chi theo thời gian";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Chi theo danh mục";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Cyan;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(15, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(599, 105);
            this.panel2.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbCL);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(420, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(176, 76);
            this.panel5.TabIndex = 2;
            // 
            // lbCL
            // 
            this.lbCL.AutoSize = true;
            this.lbCL.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCL.ForeColor = System.Drawing.Color.Blue;
            this.lbCL.Location = new System.Drawing.Point(25, 37);
            this.lbCL.Name = "lbCL";
            this.lbCL.Size = new System.Drawing.Size(0, 24);
            this.lbCL.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(42, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Chênh lệch";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbTC);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(204, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 76);
            this.panel4.TabIndex = 1;
            // 
            // lbTC
            // 
            this.lbTC.AutoSize = true;
            this.lbTC.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTC.ForeColor = System.Drawing.Color.Red;
            this.lbTC.Location = new System.Drawing.Point(33, 37);
            this.lbTC.Name = "lbTC";
            this.lbTC.Size = new System.Drawing.Size(0, 24);
            this.lbTC.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tổng chi";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbTT);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(5, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 76);
            this.panel3.TabIndex = 0;
            // 
            // lbTT
            // 
            this.lbTT.AutoSize = true;
            this.lbTT.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTT.ForeColor = System.Drawing.Color.Lime;
            this.lbTT.Location = new System.Drawing.Point(35, 37);
            this.lbTT.Name = "lbTT";
            this.lbTT.Size = new System.Drawing.Size(0, 24);
            this.lbTT.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng thu";
            // 
            // btExcel
            // 
            this.btExcel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btExcel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcel.ForeColor = System.Drawing.Color.White;
            this.btExcel.Location = new System.Drawing.Point(497, 93);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(95, 36);
            this.btExcel.TabIndex = 10;
            this.btExcel.Text = "Xuất Excel";
            this.btExcel.UseVisualStyleBackColor = false;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(626, 532);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btTK);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThongKe";
            this.Text = "BaoCao";
            this.Load += new System.EventHandler(this.BaoCao_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cThoiGian)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.ComboBox cbNam;
        private System.Windows.Forms.Button btTK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart cThoiGian;
        private System.Windows.Forms.DataVisualization.Charting.Chart cDanhMuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbCL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbTC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btExcel;
    }
}