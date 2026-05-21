using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLTC
{
    public partial class ThietLapNganSach : Form
    {
        private readonly NganSachBUS bus = new NganSachBUS();

        private readonly int maTK;
        private int maNganSach = -1;

        public ThietLapNganSach(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void ThietLapNganSach_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadData();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadCombo()
        {
            LoadDanhMucChi();
            LoadThangNam();
        }

        private void LoadDanhMucChi()
        {
            cbDMChi.DataSource = bus.LoadDMChi(maTK);
            cbDMChi.DisplayMember = "TenDM";
            cbDMChi.ValueMember = "MaDM";
            cbDMChi.SelectedIndex = -1;
        }

        private void LoadThangNam()
        {
            cbThang.DataSource = Enumerable.Range(1, 12).ToList();
            cbNam.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 10).ToList();

            cbThang.SelectedItem = DateTime.Now.Month;
            cbNam.SelectedItem = DateTime.Now.Year;
        }

        private void LoadData()
        {
            if (!LayThangNam(out int thang, out int nam))
                return;

            try
            {
                dgTLNS.AutoGenerateColumns = false;
                dgTLNS.DataSource = bus.Load(maTK, thang, nam);

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ngân sách: " + ex.Message);
            }
        }

        private void FormatDataGridView()
        {
            if (dgTLNS.Columns.Contains("GioiHan"))
                dgTLNS.Columns["GioiHan"].DefaultCellStyle.Format = "N0";
        }

        #endregion

        #region SỰ KIỆN DATAGRIDVIEW

        private void dgTLNS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgTLNS.Rows[e.RowIndex];

            if (!LayMaNganSachDangChon(row))
                return;

            DoDuLieuLenForm(row);
        }

        private bool LayMaNganSachDangChon(DataGridViewRow row)
        {
            if (!dgTLNS.Columns.Contains("MaNS"))
            {
                MessageBox.Show("Không tìm thấy cột mã ngân sách!");
                return false;
            }

            object value = row.Cells["MaNS"].Value;

            if (value == null || value == DBNull.Value)
                return false;

            maNganSach = Convert.ToInt32(value);
            return true;
        }

        private void DoDuLieuLenForm(DataGridViewRow row)
        {
            tbGH.Text = LayGiaTriCell(row, "GioiHan");

            if (int.TryParse(LayGiaTriCell(row, "Thang"), out int thang))
                cbThang.SelectedItem = thang;

            if (int.TryParse(LayGiaTriCell(row, "Nam"), out int nam))
                cbNam.SelectedItem = nam;

            cbDMChi.Text = LayGiaTriCell(row, "danhMuc");
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTra()
        {
            if (cbDMChi.SelectedValue == null)
            {
                MessageBox.Show("Chọn danh mục!");
                cbDMChi.Focus();
                return false;
            }

            if (!LayGioiHan(out decimal gioiHan))
            {
                MessageBox.Show("Giới hạn không hợp lệ!");
                tbGH.Focus();
                return false;
            }

            if (gioiHan <= 0)
            {
                MessageBox.Show("Giới hạn phải lớn hơn 0!");
                tbGH.Focus();
                return false;
            }

            if (!LayThangNam(out _, out _))
            {
                MessageBox.Show("Chọn tháng và năm!");
                return false;
            }

            return true;
        }

        private bool LayGioiHan(out decimal gioiHan)
        {
            string text = tbGH.Text.Trim();

            // Cho phép nhập: 10000, 10,000, 10.000
            text = text.Replace(",", "").Replace(".", "");

            return decimal.TryParse(text, out gioiHan);
        }

        private bool LayThangNam(out int thang, out int nam)
        {
            thang = 0;
            nam = 0;

            if (cbThang.SelectedItem == null || cbNam.SelectedItem == null)
                return false;

            thang = Convert.ToInt32(cbThang.SelectedItem);
            nam = Convert.ToInt32(cbNam.SelectedItem);

            return true;
        }

        #endregion

        #region THÊM - SỬA - XÓA

        private void btThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra())
                return;

            try
            {
                LayGioiHan(out decimal gioiHan);
                LayThangNam(out int thang, out int nam);

                bus.Them(
                    Convert.ToInt32(cbDMChi.SelectedValue),
                    gioiHan,
                    thang,
                    nam,
                    maTK
                );

                MessageBox.Show("Thêm thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm ngân sách: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (maNganSach == -1)
            {
                MessageBox.Show("Chọn ngân sách cần sửa!");
                return;
            }

            if (!KiemTra())
                return;

            try
            {
                LayGioiHan(out decimal gioiHan);
                LayThangNam(out int thang, out int nam);

                bus.Sua(
                    maNganSach,
                    Convert.ToInt32(cbDMChi.SelectedValue),
                    gioiHan,
                    thang,
                    nam,
                    maTK
                );

                MessageBox.Show("Sửa thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa ngân sách: " + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (maNganSach == -1)
            {
                MessageBox.Show("Chọn ngân sách cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa ngân sách này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bus.Xoa(maNganSach);

                MessageBox.Show("Xóa thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa ngân sách: " + ex.Message);
            }
        }

        #endregion

        #region ĐIỀU HƯỚNG FORM

        private void btQLNS_Click(object sender, EventArgs e)
        {
            NganSach ns = new NganSach(maTK);
            ns.ShowDialog();

            LoadData();
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private string LayGiaTriCell(DataGridViewRow row, string tenCot)
        {
            if (!dgTLNS.Columns.Contains(tenCot))
                return "";

            object value = row.Cells[tenCot].Value;

            if (value == null || value == DBNull.Value)
                return "";

            return value.ToString();
        }

        private void ResetForm()
        {
            cbDMChi.SelectedIndex = -1;
            tbGH.Clear();

            cbThang.SelectedItem = DateTime.Now.Month;
            cbNam.SelectedItem = DateTime.Now.Year;

            maNganSach = -1;

            dgTLNS.ClearSelection();
            cbDMChi.Focus();
        }

        #endregion
    }
}