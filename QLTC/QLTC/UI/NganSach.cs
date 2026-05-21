using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLTC
{
    public partial class NganSach : Form
    {
        private readonly QLNganSachBUS bus = new QLNganSachBUS();
        private readonly int maTK;

        private bool isLoaded = false;

        public NganSach(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void NganSach_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            CauHinhDataGridView();

            isLoaded = true;

            LoadData();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadComboBox()
        {
            cbThang.DataSource = Enumerable.Range(1, 12).ToList();
            cbNam.DataSource = Enumerable.Range(DateTime.Now.Year - 5, 10).ToList();

            cbThang.SelectedItem = DateTime.Now.Month;
            cbNam.SelectedItem = DateTime.Now.Year;
        }

        private void CauHinhDataGridView()
        {
            dgQLNS.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            if (!isLoaded)
                return;

            if (!LayThangNam(out int thang, out int nam))
                return;

            try
            {
                DataTable dt = bus.Load(maTK, thang, nam);

                HienThiDanhSachNganSach(dt);
                TinhTongNganSach(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ngân sách: " + ex.Message);
            }
        }

        private void HienThiDanhSachNganSach(DataTable dt)
        {
            dgQLNS.DataSource = null;
            dgQLNS.DataSource = dt;

            FormatDataGridView();
            dgQLNS.Refresh();
        }

        private void FormatDataGridView()
        {
            if (dgQLNS.Columns.Contains("gioiHan"))
                dgQLNS.Columns["gioiHan"].DefaultCellStyle.Format = "N0";

            if (dgQLNS.Columns.Contains("chi"))
                dgQLNS.Columns["chi"].DefaultCellStyle.Format = "N0";

            if (dgQLNS.Columns.Contains("conLai"))
                dgQLNS.Columns["conLai"].DefaultCellStyle.Format = "N0";
        }

        #endregion

        #region TÍNH TỔNG

        private void TinhTongNganSach(DataTable dt)
        {
            decimal tongNganSach = 0;
            decimal tongDaChi = 0;
            decimal tongConLai = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongNganSach += LayGiaTriDecimal(row, "gioiHan");
                tongDaChi += LayGiaTriDecimal(row, "Chi");
                tongConLai += LayGiaTriDecimal(row, "conLai");
            }

            lbTNS.Text = DinhDangTien(tongNganSach);
            lbChi.Text = DinhDangTien(tongDaChi);

            // Label này đang dùng để hiển thị tổng còn lại
            lbThu.Text = DinhDangTien(tongConLai);
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

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

        #region SỰ KIỆN FORM

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Close();
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

        private string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }

        #endregion
    }
}