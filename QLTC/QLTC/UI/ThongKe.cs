using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using System.IO;

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

        #region // ================= XUẤT EXCEL ===================

        private void btExcel_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }

        private void XuatExcel()
        {
            if (!LayThangNam(out int thang, out int nam))
                return;

            try
            {
                DataTable dtTong = bus.TongThuChi(thang, nam, maTk);
                DataTable dtTheoNgay = bus.ThongKeTheoNgay(thang, nam, maTk);
                DataTable dtDanhMuc = bus.ThongKeDanhMuc(thang, nam, maTk);

                if (KhongCoDuLieuXuat(dtTheoNgay, dtDanhMuc))
                {
                    MessageBox.Show("Không có dữ liệu để xuất Excel!");
                    return;
                }

                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Lưu báo cáo thống kê",
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = $"BaoCaoThongKe_{thang}_{nam}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (save.ShowDialog() != DialogResult.OK)
                    return;

                if (!KiemTraFileDangMo(save.FileName))
                    return;

                using (XLWorkbook workbook = new XLWorkbook())
                {
                    TaoSheetTongHop(workbook, dtTong, thang, nam);
                    TaoSheetDataTable(workbook, dtTheoNgay, "TheoNgay", "THỐNG KÊ THU CHI THEO NGÀY");
                    TaoSheetDataTable(workbook, dtDanhMuc, "DanhMuc", "THỐNG KÊ CHI THEO DANH MỤC");

                    workbook.SaveAs(save.FileName);
                }

                MessageBox.Show("Xuất Excel thành công!\nBạn có thể mở file bằng WPS Spreadsheet.");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền ghi file. Vui lòng chọn thư mục khác!");
            }
            catch (IOException)
            {
                MessageBox.Show("Không thể ghi file. Có thể file đang được mở bằng WPS!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private bool KhongCoDuLieuXuat(DataTable dtTheoNgay, DataTable dtDanhMuc)
        {
            bool khongCoTheoNgay = dtTheoNgay == null || dtTheoNgay.Rows.Count == 0;
            bool khongCoDanhMuc = dtDanhMuc == null || dtDanhMuc.Rows.Count == 0;

            return khongCoTheoNgay && khongCoDanhMuc;
        }

        private bool KiemTraFileDangMo(string fileName)
        {
            if (!File.Exists(fileName))
                return true;

            try
            {
                using (File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                }

                return true;
            }
            catch
            {
                MessageBox.Show("File đang được mở. Hãy đóng file trong WPS rồi thử lại!");
                return false;
            }
        }

        #region SHEET TỔNG HỢP

        private void TaoSheetTongHop(XLWorkbook workbook, DataTable dt, int thang, int nam)
        {
            IXLWorksheet ws = workbook.Worksheets.Add("TongHop");

            double tongThu = 0;
            double tongChi = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                tongThu = LayGiaTriSo(dt.Rows[0], "TongThu");
                tongChi = LayGiaTriSo(dt.Rows[0], "TongChi");
            }

            double chenhLech = tongThu - tongChi;

            ws.Cell("A1").Value = "BÁO CÁO THỐNG KÊ THU CHI";
            ws.Range("A1:B1").Merge();

            ws.Cell("A2").Value = $"Tháng {thang}/{nam}";
            ws.Range("A2:B2").Merge();

            ws.Cell("A3").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
            ws.Range("A3:B3").Merge();

            ws.Cell("A5").Value = "Chỉ tiêu";
            ws.Cell("B5").Value = "Giá trị (VNĐ)";

            ws.Cell("A6").Value = "Tổng thu";
            ws.Cell("B6").Value = tongThu;

            ws.Cell("A7").Value = "Tổng chi";
            ws.Cell("B7").Value = tongChi;

            ws.Cell("A8").Value = "Chênh lệch";
            ws.Cell("B8").Value = chenhLech;

            TrangTriTieuDe(ws, 1, 2);
            TrangTriBang(ws.Range("A5:B8"));

            ws.Range("B6:B8").Style.NumberFormat.Format = "#,##0";

            ws.Cell("A10").Value = "Nhận xét";
            ws.Cell("B10").Value = TaoNhanXet(tongThu, tongChi);

            TrangTriBang(ws.Range("A10:B10"));

            ws.SheetView.FreezeRows(5);
            TuDongCanCot(ws);
        }

        private string TaoNhanXet(double tongThu, double tongChi)
        {
            if (tongThu == 0 && tongChi == 0)
                return "Chưa có dữ liệu thu chi trong kỳ thống kê.";

            if (tongThu > tongChi)
                return "Tình hình tài chính tích cực.";

            if (tongThu < tongChi)
                return "Cần kiểm soát chi tiêu tốt hơn.";

            return "Tổng thu và tổng chi đang cân bằng.";
        }

        #endregion

        #region SHEET DATATABLE

        private void TaoSheetDataTable(XLWorkbook workbook, DataTable dt, string tenSheet, string tieuDe)
        {
            IXLWorksheet ws = workbook.Worksheets.Add(tenSheet);

            int soCot = dt == null || dt.Columns.Count == 0 ? 1 : dt.Columns.Count;

            ws.Cell(1, 1).Value = tieuDe;
            ws.Range(1, 1, 1, soCot).Merge();

            TrangTriTieuDe(ws, 1, soCot);

            if (dt == null || dt.Rows.Count == 0)
            {
                ws.Cell(3, 1).Value = "Không có dữ liệu";
                TuDongCanCot(ws);
                return;
            }

            for (int c = 0; c < dt.Columns.Count; c++)
            {
                ws.Cell(3, c + 1).Value = DoiTenCot(dt.Columns[c].ColumnName);
            }

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    GanGiaTriCell(ws.Cell(r + 4, c + 1), dt.Rows[r][c]);
                }
            }

            IXLRange range = ws.Range(3, 1, dt.Rows.Count + 3, dt.Columns.Count);

            TrangTriBang(range);
            FormatCotTien(ws, dt);

            ws.SheetView.FreezeRows(3);
            TuDongCanCot(ws);
        }

        private void GanGiaTriCell(IXLCell cell, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                cell.Value = "";
                return;
            }

            if (value is int || value is long || value is decimal || value is double || value is float)
            {
                cell.SetValue(Convert.ToDouble(value));
                return;
            }

            if (value is DateTime)
            {
                cell.SetValue(Convert.ToDateTime(value));
                cell.Style.DateFormat.Format = "dd/MM/yyyy";
                return;
            }

            cell.SetValue(value.ToString());
        }

        private string DoiTenCot(string tenCot)
        {
            switch (tenCot)
            {
                case "Ngay":
                    return "Ngày";

                case "ThangNam":
                    return "Tháng/Năm";

                case "Thu":
                    return "Tổng thu (VNĐ)";

                case "Chi":
                    return "Tổng chi (VNĐ)";

                case "TenDM":
                    return "Danh mục";

                case "TongChi":
                    return "Tổng chi (VNĐ)";

                default:
                    return tenCot;
            }
        }

        #endregion

        #region ĐỊNH DẠNG EXCEL

        private void TrangTriTieuDe(IXLWorksheet ws, int dong, int soCot)
        {
            IXLRange title = ws.Range(dong, 1, dong, soCot);

            title.Style.Font.Bold = true;
            title.Style.Font.FontSize = 16;
            title.Style.Font.FontColor = XLColor.White;
            title.Style.Fill.BackgroundColor = XLColor.FromHtml("#1F4E79");
            title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            title.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            ws.Row(dong).Height = 30;
        }

        private void TrangTriBang(IXLRange range)
        {
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            range.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            IXLRangeRow header = range.FirstRow();

            header.Style.Font.Bold = true;
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Fill.BackgroundColor = XLColor.FromHtml("#2C3E50");
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        private void FormatCotTien(IXLWorksheet ws, DataTable dt)
        {
            for (int c = 0; c < dt.Columns.Count; c++)
            {
                string tenCot = dt.Columns[c].ColumnName.ToLower();

                if (tenCot.Contains("thu") ||
                    tenCot.Contains("chi") ||
                    tenCot.Contains("tong") ||
                    tenCot.Contains("sotien"))
                {
                    ws.Column(c + 1).Style.NumberFormat.Format = "#,##0";
                }
            }
        }

        private void TuDongCanCot(IXLWorksheet ws)
        {
            ws.ColumnsUsed().AdjustToContents();

            foreach (IXLColumn col in ws.ColumnsUsed())
            {
                if (col.Width > 45)
                    col.Width = 45;
            }
        }

        #endregion

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