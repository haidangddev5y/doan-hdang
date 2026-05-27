using System;
using System.Data;
using System.Windows.Forms;

namespace QLTC
{
    public partial class QLGiaoDich : Form
    {
        private readonly QLGiaoDichBUS bus = new QLGiaoDichBUS();
        private readonly int maTK;

        private int maGiaoDich = -1;

        public QLGiaoDich(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void QLGiaoDich_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadNgayMacDinh();
            LoadData();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadCombo()
        {
            LoadComboLoai();
            LoadComboVi();
        }

        private void LoadComboLoai()
        {
            cbLoai.DataSource = new[]
            {
                new { Text = "Tất cả", Value = -1 },
                new { Text = "Thu", Value = 1 },
                new { Text = "Chi", Value = 0 }
            };

            cbLoai.DisplayMember = "Text";
            cbLoai.ValueMember = "Value";
            cbLoai.SelectedIndex = 0;
        }

        private void LoadComboVi()
        {
            cbVi.DataSource = bus.LoadVi(maTK);
            cbVi.DisplayMember = "TenVi";
            cbVi.ValueMember = "MaVi";
            cbVi.SelectedIndex = -1;
        }

        private void LoadNgayMacDinh()
        {
            dtStart.Value = DateTime.Now.AddMonths(-1);
            dtEnd.Value = DateTime.Now;
        }

        private void LoadData()
        {
            if (!LayDieuKienLoc(out int loai, out int maVi))
                return;

            try
            {
                DataTable dt = bus.Load(
                    dtStart.Value.Date,
                    dtEnd.Value.Date,
                    loai,
                    maVi,
                    maTK
                );

                HienThiDanhSachGiaoDich(dt);
                TinhTongThuChi(dt);
                ResetChonDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải giao dịch: " + ex.Message);
            }
        }

        private void HienThiDanhSachGiaoDich(DataTable dt)
        {
            dgGD.AutoGenerateColumns = false;
            dgGD.DataSource = null;
            dgGD.DataSource = dt;

            CauHinhCotAn();
            FormatDataGridView();
        }

        private void CauHinhCotAn()
        {
            if (dgGD.Columns.Contains("maGD"))
                dgGD.Columns["maGD"].Visible = false;

            if (dgGD.Columns.Contains("maDM"))
                dgGD.Columns["maDM"].Visible = false;

            if (dgGD.Columns.Contains("maVi"))
                dgGD.Columns["maVi"].Visible = false;

            if (dgGD.Columns.Contains("loaiValue"))
                dgGD.Columns["loaiValue"].Visible = false;
        }

        private void FormatDataGridView()
        {
            if (dgGD.Columns.Contains("soTien"))
                dgGD.Columns["soTien"].DefaultCellStyle.Format = "N0";

            if (dgGD.Columns.Contains("ngay"))
                dgGD.Columns["ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        #endregion

        #region SỰ KIỆN DATAGRIDVIEW

        private void dgGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgGD.Rows[e.RowIndex];

            if (!dgGD.Columns.Contains("maGD"))
            {
                MessageBox.Show("DataGridView chưa có cột maGD!");
                return;
            }

            object value = row.Cells["maGD"].Value;

            if (value == null || value == DBNull.Value)
            {
                maGiaoDich = -1;
                MessageBox.Show("Không lấy được mã giao dịch!");
                return;
            }

            maGiaoDich = Convert.ToInt32(value);
        }

        private bool LayMaGiaoDichDangChon(DataGridViewRow row)
        {
            if (!dgGD.Columns.Contains("maGD"))
            {
                MessageBox.Show("Không tìm thấy cột mã giao dịch. Kiểm tra DataGridView hoặc sp_LoadGiaoDich!");
                return false;
            }

            object value = row.Cells["maGD"].Value;

            if (value == null || value == DBNull.Value)
            {
                maGiaoDich = -1;
                return false;
            }

            maGiaoDich = Convert.ToInt32(value);
            return true;
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTraNgay()
        {
            if (dtStart.Value.Date > dtEnd.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                dtStart.Focus();
                return false;
            }

            return true;
        }

        private bool LayDieuKienLoc(out int loai, out int maVi)
        {
            loai = -1;
            maVi = -1;

            if (cbLoai.SelectedValue != null)
                int.TryParse(cbLoai.SelectedValue.ToString(), out loai);

            if (cbVi.SelectedValue != null)
                int.TryParse(cbVi.SelectedValue.ToString(), out maVi);

            return true;
        }

        private bool KiemTraDaChonGiaoDich(string hanhDong)
        {
            if (maGiaoDich == -1)
            {
                MessageBox.Show($"Chọn giao dịch cần {hanhDong}!");
                return false;
            }

            return true;
        }

        #endregion

        #region TÍNH TỔNG

        private void TinhTongThuChi(DataTable dt)
        {
            decimal tongThu = 0;
            decimal tongChi = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal soTien = LayGiaTriDecimal(row, "SoTien");
                string loai = LayGiaTriChuoi(row, "Loai");

                if (loai.Equals("Thu", StringComparison.OrdinalIgnoreCase))
                    tongThu += soTien;
                else if (loai.Equals("Chi", StringComparison.OrdinalIgnoreCase))
                    tongChi += soTien;
            }

            lbTT.Text = DinhDangTien(tongThu);
            lbTC.Text = DinhDangTien(tongChi);
        }

        #endregion

        #region LỌC - THÊM - XÓA

        private void btLoc_Click(object sender, EventArgs e)
        {
            if (!KiemTraNgay())
                return;

            LoadData();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            GiaoDich f = new GiaoDich(maTK);
            f.ShowDialog();

            LoadData();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (!KiemTraDaChonGiaoDich("xóa"))
                return;

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa giao dịch này không?\nSố dư ví sẽ được hoàn lại tương ứng.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bool kq = bus.Xoa(maGiaoDich);

                if (kq)
                {
                    MessageBox.Show("Xóa giao dịch thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa giao dịch thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa giao dịch: " + ex.Message);
            }
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private decimal LayGiaTriDecimal(DataRow row, string tenCot)
        {
            if (!row.Table.Columns.Contains(tenCot))
                return 0;

            if (row[tenCot] == DBNull.Value)
                return 0;

            return Convert.ToDecimal(row[tenCot]);
        }

        private string LayGiaTriChuoi(DataRow row, string tenCot)
        {
            if (!row.Table.Columns.Contains(tenCot))
                return "";

            if (row[tenCot] == DBNull.Value)
                return "";

            return row[tenCot].ToString();
        }

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }

        private void ResetChonDong()
        {
            maGiaoDich = -1;
            dgGD.ClearSelection();
        }

        #endregion
    }
}