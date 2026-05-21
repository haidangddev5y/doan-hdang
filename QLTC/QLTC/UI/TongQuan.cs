using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLTC
{
    public partial class TongQuan : Form
    {
        private readonly TongQuanBUS bus = new TongQuanBUS();

        private readonly string vaiTro;
        private int maTK;

        public TongQuan(int _maTK, string _vaiTro)
        {
            InitializeComponent();

            maTK = _maTK;
            vaiTro = _vaiTro;
        }

        #region FORM LOAD

        private void TongQuan_Load(object sender, EventArgs e)
        {
            try
            {
                SetupChart();
                PhanQuyenTaiKhoan();
                ReloadTongQuan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        #endregion

        #region LOAD TỔNG QUAN

        private void ReloadTongQuan()
        {
            LoadTongQuan();
            LoadChartChi();
            LoadChartTyLe();
            LoadGiaoDich();
        }

        private void LoadTongQuan()
        {
            DataTable dt = bus.GetTongQuan(maTK);

            if (dt.Rows.Count == 0)
            {
                HienThiTongQuan(0, 0, 0);
                return;
            }

            double tongSoDu = LayGiaTriSo(dt.Rows[0], "TongSoDu");
            double tongThuThang = LayGiaTriSo(dt.Rows[0], "TongThuThang");
            double tongChiThang = LayGiaTriSo(dt.Rows[0], "TongChiThang");

            HienThiTongQuan(tongSoDu, tongThuThang, tongChiThang);
        }

        private void HienThiTongQuan(double tongSoDu, double tongThu, double tongChi)
        {
            lbTSD.Text = DinhDangTien(tongSoDu);
            label7.Text = DinhDangTien(tongThu);
            lbTCTN.Text = DinhDangTien(tongChi);
            lbCL.Text = DinhDangTien(tongThu - tongChi);
        }

        #endregion

        #region THIẾT LẬP BIỂU ĐỒ

        private void SetupChart()
        {
            SetupChartThuChi();
            SetupChartTyLe();
        }

        private void SetupChartThuChi()
        {
            cChi.Series.Clear();
            cChi.ChartAreas.Clear();
            cChi.Legends.Clear();

            ChartArea area = new ChartArea("ChartArea1");
            area.AxisX.Title = "Tháng";
            area.AxisY.Title = "Số tiền";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            cChi.ChartAreas.Add(area);

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Top;
            cChi.Legends.Add(legend);

            cChi.Series.Add(TaoSeriesCot("Thu", Color.Green));
            cChi.Series.Add(TaoSeriesCot("Chi", Color.Red));
        }

        private Series TaoSeriesCot(string tenSeries, Color mau)
        {
            return new Series(tenSeries)
            {
                ChartType = SeriesChartType.Column,
                Color = mau,
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            };
        }

        private void SetupChartTyLe()
        {
            cTyLe.Series.Clear();
            cTyLe.ChartAreas.Clear();
            cTyLe.Legends.Clear();

            cTyLe.ChartAreas.Add(new ChartArea("ChartArea1"));

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Right;
            cTyLe.Legends.Add(legend);

            Series s = new Series("TyLe")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}",
                LegendText = "#VALX - #PERCENT{P0}",
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            };

            cTyLe.Palette = ChartColorPalette.BrightPastel;
            cTyLe.Series.Add(s);
        }

        #endregion

        #region LOAD BIỂU ĐỒ

        private void LoadChartChi()
        {
            DataTable dt = bus.Get6Thang(maTK);

            Series seriesThu = cChi.Series["Thu"];
            Series seriesChi = cChi.Series["Chi"];

            seriesThu.Points.Clear();
            seriesChi.Points.Clear();

            if (dt.Rows.Count == 0)
            {
                seriesThu.Points.AddXY("Chưa có", 0);
                seriesChi.Points.AddXY("Chưa có", 0);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                seriesThu.Points.AddXY(row["Thang"], LayGiaTriSo(row, "Thu"));
                seriesChi.Points.AddXY(row["Thang"], LayGiaTriSo(row, "Chi"));
            }
        }

        private void LoadChartTyLe()
        {
            DataTable dt = bus.GetTyLe(maTK);

            Series s = cTyLe.Series["TyLe"];
            s.Points.Clear();

            if (dt.Rows.Count == 0)
            {
                HienThiChartTyLeRong(s);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                string tenDM = row["TenDM"].ToString();
                double tongChi = LayGiaTriSo(row, "TongChi");

                int index = s.Points.AddXY(tenDM, tongChi);

                s.Points[index].Label = "#PERCENT{P0}";
                s.Points[index].LegendText = tenDM + " - #PERCENT{P0}";
                s.Points[index].ToolTip = tenDM + ": " + DinhDangTien(tongChi);
            }
        }

        private void HienThiChartTyLeRong(Series s)
        {
            s.Points.Clear();

            int index = s.Points.AddXY("Chưa có dữ liệu", 1);

            s.Points[index].Label = "0%";
            s.Points[index].LegendText = "Chưa có dữ liệu";
            s.Points[index].ToolTip = "Chưa có dữ liệu";
        }

        #endregion

        #region LOAD GIAO DỊCH GẦN ĐÂY

        private void LoadGiaoDich()
        {
            DataTable dt = bus.GetGiaoDichGanDay(maTK);

            CauHinhCotGiaoDich();

            dgGD.DataSource = null;
            dgGD.DataSource = dt;

            FormatDataGridView();
        }

        private void CauHinhCotGiaoDich()
        {
            dgGD.AutoGenerateColumns = false;

            ngay.DataPropertyName = "Ngay";
            noiDung.DataPropertyName = "NoiDung";
            loai.DataPropertyName = "Loai";
            danhMuc.DataPropertyName = "danhMuc";
            vi.DataPropertyName = "vi";
            soTien.DataPropertyName = "SoTien";
        }

        private void FormatDataGridView()
        {
            if (dgGD.Columns.Contains("soTien"))
                dgGD.Columns["soTien"].DefaultCellStyle.Format = "N0";

            if (dgGD.Columns.Contains("ngay"))
                dgGD.Columns["ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        #endregion

        #region ĐIỀU HƯỚNG FORM

        private void btDM_Click(object sender, EventArgs e)
        {
            DanhMuc dm = new DanhMuc(maTK);
            dm.ShowDialog();

            ReloadTongQuan();
        }

        private void btVT_Click(object sender, EventArgs e)
        {
            ViTien vt = new ViTien(maTK);
            vt.ShowDialog();

            ReloadTongQuan();
        }

        private void btGD_Click(object sender, EventArgs e)
        {
            GiaoDich gd = new GiaoDich(maTK);
            gd.ShowDialog();

            ReloadTongQuan();
        }

        private void btNS_Click(object sender, EventArgs e)
        {
            ThietLapNganSach tlns = new ThietLapNganSach(maTK);
            tlns.ShowDialog();

            ReloadTongQuan();
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            ThongKe bc = new ThongKe(maTK);
            bc.ShowDialog();

            ReloadTongQuan();
        }

        private void btTK_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan(maTK);
            tk.ShowDialog();

            ReloadTongQuan();
        }

        private void llXTC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QLGiaoDich gd = new QLGiaoDich(maTK);
            gd.ShowDialog();

            ReloadTongQuan();
        }

        #endregion

        #region LÀM MỚI - ĐĂNG XUẤT - PHÂN QUYỀN

        private void btLM_Click(object sender, EventArgs e)
        {
            ReloadTongQuan();
        }

        private void btDX_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            maTK = -1;

            Hide();

            fLogin f = new fLogin();
            f.ShowDialog();

            Close();
        }

        private void btQLTK_Click(object sender, EventArgs e)
        {
            if (!LaAdmin())
            {
                MessageBox.Show("Bạn không có quyền!");
                return;
            }

            QLTaiKhoan f = new QLTaiKhoan();
            f.ShowDialog();

            ReloadTongQuan();
        }

        private void PhanQuyenTaiKhoan()
        {
            bool laAdmin = LaAdmin();

            btQLTK.Visible = laAdmin;
            btQLTK.Enabled = laAdmin;
        }

        private bool LaAdmin()
        {
            return vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region HÀM DÙNG CHUNG

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
    }
}