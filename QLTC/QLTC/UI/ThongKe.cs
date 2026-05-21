using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLTC
{
    public partial class ThongKe : Form
    {
        private readonly ThongKeBUS bus = new ThongKeBUS();
        private readonly int maTk;

        public ThongKe(int _maTK)
        {
            InitializeComponent();
            maTk = _maTK;
        }

        #region       // ===================== FORM LOAD =====================
        private void BaoCao_Load(object sender, EventArgs e)
        {
            ThietLapForm();
            LoadComboBox();
            ThietLapButton();
            ThietLapBieuDo();

            LoadBaoCaoTatCa();
        }
        #endregion

        #region        // ===================== SETUP GIAO DIỆN =====================
        private void ThietLapForm()
        {
            Text = "Báo cáo tài chính";
            BackColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadComboBox()
        {
            cbThang.Items.Clear();
            cbNam.Items.Clear();

            for (int i = 1; i <= 12; i++)
                cbThang.Items.Add(i);

            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
                cbNam.Items.Add(i);

            cbThang.SelectedItem = DateTime.Now.Month;
            cbNam.SelectedItem = DateTime.Now.Year;
        }

        private void ThietLapButton()
        {
            btTK.BackColor = Color.RoyalBlue;
            btTK.ForeColor = Color.White;
            btTK.FlatStyle = FlatStyle.Flat;
        }

        private void ThietLapBieuDo()
        {
            SetupChartThoiGian();
            SetupChartDanhMuc();
        }

        private void SetupChartThoiGian()
        {
            cThoiGian.Series.Clear();
            cThoiGian.ChartAreas.Clear();
            cThoiGian.Legends.Clear();

            ChartArea area = new ChartArea("ChartArea1");
            area.AxisX.Title = "Thời gian";
            area.AxisY.Title = "Số tiền";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            cThoiGian.ChartAreas.Add(area);

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Top;
            cThoiGian.Legends.Add(legend);

            cThoiGian.Series.Add(TaoSeriesDuong("Thu"));
            cThoiGian.Series.Add(TaoSeriesDuong("Chi"));
        }

        private Series TaoSeriesDuong(string tenSeries)
        {
            return new Series(tenSeries)
            {
                ChartType = SeriesChartType.Line,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                BorderWidth = 2,
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            };
        }

        private void SetupChartDanhMuc()
        {
            cDanhMuc.Series.Clear();
            cDanhMuc.ChartAreas.Clear();
            cDanhMuc.Legends.Clear();

            cDanhMuc.ChartAreas.Add(new ChartArea("ChartArea1"));

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Right;
            cDanhMuc.Legends.Add(legend);

            Series s = new Series("Chi")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}",
                LegendText = "#VALX",
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            };

            cDanhMuc.Series.Add(s);
        }
        #endregion

        #region        // ===================== LOAD BÁO CÁO =====================
        private void LoadBaoCaoTatCa()
        {
            VeChartThoiGian_All();
            VeChartDanhMuc_All();
            TinhTong_All();
        }

        private void LoadBaoCaoTheoThangNam()
        {
            if (!LayThangNam(out int thang, out int nam))
                return;

            VeChartThoiGian(thang, nam);
            VeChartDanhMuc(thang, nam);
            TinhTong(thang, nam);
        }

        private bool LayThangNam(out int thang, out int nam)
        {
            thang = 0;
            nam = 0;

            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tháng và năm!");
                return false;
            }

            thang = Convert.ToInt32(cbThang.SelectedItem);
            nam = Convert.ToInt32(cbNam.SelectedItem);
            return true;
        }
        #endregion

        #region        // ===================== BIỂU ĐỒ THỜI GIAN =====================
        private void VeChartThoiGian(int thang, int nam)
        {
            DataTable dt = bus.ThongKeTheoNgay(thang, nam, maTk);
            DoDuLieuVaoChartThoiGian(dt, "Ngay");
        }

        private void VeChartThoiGian_All()
        {
            DataTable dt = bus.ThongKeTheoNgay_All(maTk);
            DoDuLieuVaoChartThoiGian(dt, "ThangNam");
        }

        private void DoDuLieuVaoChartThoiGian(DataTable dt, string cotTrucX)
        {
            Series seriesThu = cThoiGian.Series["Thu"];
            Series seriesChi = cThoiGian.Series["Chi"];

            seriesThu.Points.Clear();
            seriesChi.Points.Clear();

            foreach (DataRow row in dt.Rows)
            {
                seriesThu.Points.AddXY(row[cotTrucX], LayGiaTriSo(row, "Thu"));
                seriesChi.Points.AddXY(row[cotTrucX], LayGiaTriSo(row, "Chi"));
            }
        }
        #endregion

        #region        // ===================== BIỂU ĐỒ DANH MỤC =====================
        private void VeChartDanhMuc(int thang, int nam)
        {
            DataTable dt = bus.ThongKeDanhMuc(thang, nam, maTk);
            DoDuLieuVaoChartDanhMuc(dt);
        }

        private void VeChartDanhMuc_All()
        {
            DataTable dt = bus.ThongKeDanhMuc_All(maTk);
            DoDuLieuVaoChartDanhMuc(dt);
        }

        private void DoDuLieuVaoChartDanhMuc(DataTable dt)
        {
            Series s = cDanhMuc.Series["Chi"];
            s.Points.Clear();

            if (dt.Rows.Count == 0)
            {
                HienThiChartDanhMucRong(s);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string tenDM = row["TenDM"].ToString();
                double tongChi = LayGiaTriSo(row, "TongChi");

                int index = s.Points.AddXY(tenDM, tongChi);

                // Hiển thị % thay vì số tiền
                s.Points[index].Label = "#PERCENT{P0}";
                s.Points[index].LegendText = tenDM + " - #PERCENT{P0}";
                s.Points[index].ToolTip = tenDM + ": " + tongChi.ToString("N0") + " đ";
            }
        }

        private void HienThiChartDanhMucRong(Series s)
        {
            s.Points.Clear();
            int index = s.Points.AddXY("Chưa có dữ liệu", 1);

            s.Points[index].Label = "0%";
            s.Points[index].LegendText = "Chưa có dữ liệu";
            s.Points[index].ToolTip = "Chưa có dữ liệu";
        }
        #endregion

        #region        // ===================== TÍNH TỔNG =====================

        private void TinhTong(int thang, int nam)
        {
            DataTable dt = bus.TongThuChi(thang, nam, maTk);
            HienThiTongThuChi(dt);
        }

        private void TinhTong_All()
        {
            DataTable dt = bus.TongThuChi_All(maTk);
            HienThiTongThuChi(dt);
        }

        private void HienThiTongThuChi(DataTable dt)
        {
            double thu = 0;
            double chi = 0;

            if (dt.Rows.Count > 0)
            {
                thu = LayGiaTriSo(dt.Rows[0], "TongThu");
                chi = LayGiaTriSo(dt.Rows[0], "TongChi");
            }

            lbTT.Text = DinhDangTien(thu);
            lbTC.Text = DinhDangTien(chi);
            lbCL.Text = DinhDangTien(thu - chi);
        }
        #endregion

        #region        // ===================== HÀM DÙNG CHUNG =====================
        private double LayGiaTriSo(DataRow row, string tenCot)
        {
            if (!row.Table.Columns.Contains(tenCot))
                return 0;

            if (row[tenCot] == DBNull.Value)
                return 0;

            return Convert.ToDouble(row[tenCot]);
        }

        private string DinhDangTien(double soTien)
        {
            return soTien.ToString("N0") + " đ";
        }
        #endregion

        #region        // ===================== SỰ KIỆN =====================
        private void btTK_Click(object sender, EventArgs e)
        {
            LoadBaoCaoTheoThangNam();
        }
        #endregion
    }
}