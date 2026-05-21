using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QLTC
{
    public partial class TaiKhoan : Form
    {
        private readonly TTTaiKhoanBUS bus = new TTTaiKhoanBUS();
        private readonly int maTK;

        public TaiKhoan(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadData()
        {
            try
            {
                DataTable dt = bus.Load(maTK);

                if (dt == null || dt.Rows.Count == 0)
                {
                    HienThiMacDinh();
                    MessageBox.Show("Không có dữ liệu tài khoản!");
                    return;
                }

                HienThiThongTinTaiKhoan(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin tài khoản: " + ex.Message);
            }
        }

        private void HienThiThongTinTaiKhoan(DataRow row)
        {
            tbTDN.Text = LayGiaTri(row, "TenDangNhap");
            tbEmail.Text = LayGiaTri(row, "Email");
            tbSDT.Text = LayGiaTri(row, "SoDienThoai");

            CapNhatLabelThongTin();
        }

        private void HienThiMacDinh()
        {
            tbTDN.Clear();
            tbEmail.Clear();
            tbSDT.Clear();

            lbTTK.Text = "";
            lbEmail.Text = "Email";
            lbSDT.Text = "SDT";
        }

        private void CapNhatLabelThongTin()
        {
            lbTTK.Text = tbTDN.Text.Trim();

            lbEmail.Text = string.IsNullOrWhiteSpace(tbEmail.Text)
                ? "Email"
                : tbEmail.Text.Trim();

            lbSDT.Text = string.IsNullOrWhiteSpace(tbSDT.Text)
                ? "SDT"
                : tbSDT.Text.Trim();
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTra()
        {
            string email = tbEmail.Text.Trim();
            string sdt = tbSDT.Text.Trim();

            if (!KiemTraEmail(email))
                return false;

            if (!KiemTraSoDienThoai(sdt))
                return false;

            return true;
        }

        private bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return true;

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!");
                tbEmail.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraSoDienThoai(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                return true;

            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show("SĐT phải là số!");
                tbSDT.Focus();
                return false;
            }

            if (sdt.Length < 9 || sdt.Length > 11)
            {
                MessageBox.Show("SĐT phải có từ 9 đến 11 chữ số!");
                tbSDT.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region CẬP NHẬT THÔNG TIN

        private void btCNTT_Click(object sender, EventArgs e)
        {
            if (!KiemTra())
                return;

            try
            {
                bool kq = bus.CapNhat(
                    maTK,
                    tbEmail.Text.Trim(),
                    tbSDT.Text.Trim()
                );

                if (!kq)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật thông tin: " + ex.Message);
            }
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private string LayGiaTri(DataRow row, string tenCot)
        {
            if (!row.Table.Columns.Contains(tenCot))
                return "";

            if (row[tenCot] == null || row[tenCot] == DBNull.Value)
                return "";

            return row[tenCot].ToString();
        }

        #endregion
    }
}