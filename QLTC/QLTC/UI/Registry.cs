using System;
using System.Windows.Forms;

namespace QLTC
{
    public partial class Registry : Form
    {
        private readonly TaiKhoanBUS bus = new TaiKhoanBUS();

        public Registry()
        {
            InitializeComponent();
        }

        #region SỰ KIỆN FORM

        private void cbHTMK_CheckedChanged(object sender, EventArgs e)
        {
            bool hienMatKhau = cbHTMK.Checked;

            tbMK.UseSystemPasswordChar = !hienMatKhau;
            tbNLMK.UseSystemPasswordChar = !hienMatKhau;
        }

        private void btHUY_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ĐĂNG KÝ TÀI KHOẢN

        private void btDK_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = tbTDN.Text.Trim().ToLower();
                string matKhau = tbMK.Text.Trim();
                string nhapLaiMatKhau = tbNLMK.Text.Trim();

                if (!KiemTraDangKy(tenDN, matKhau, nhapLaiMatKhau))
                    return;

                int ketQua = bus.DangKy(tenDN, matKhau);

                XuLyKetQuaDangKy(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void XuLyKetQuaDangKy(int ketQua)
        {
            if (ketQua == 1)
            {
                MessageBox.Show("Đăng ký thành công!");
                ResetForm();
                return;
            }

            if (ketQua == -1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                tbTDN.Focus();
                return;
            }

            MessageBox.Show("Lỗi hệ thống hoặc dữ liệu bị trùng!");
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTraDangKy(string tenDN, string matKhau, string nhapLaiMatKhau)
        {
            if (!KiemTraTenDangNhap(tenDN))
                return false;

            if (!KiemTraMatKhau(matKhau, nhapLaiMatKhau))
                return false;

            return true;
        }

        private bool KiemTraTenDangNhap(string tenDN)
        {
            if (string.IsNullOrWhiteSpace(tenDN))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!");
                tbTDN.Focus();
                return false;
            }

            if (tenDN.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!");
                tbTDN.Focus();
                return false;
            }

            if (tenDN.Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng!");
                tbTDN.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraMatKhau(string matKhau, string nhapLaiMatKhau)
        {
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống!");
                tbMK.Focus();
                return false;
            }

            if (matKhau.Length < 3)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!");
                tbMK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(nhapLaiMatKhau))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                tbNLMK.Focus();
                return false;
            }

            if (matKhau != nhapLaiMatKhau)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                tbNLMK.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private void ResetForm()
        {
            tbTDN.Clear();
            tbMK.Clear();
            tbNLMK.Clear();

            cbHTMK.Checked = false;
            tbTDN.Focus();
        }

        #endregion
    }
}