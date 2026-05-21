using System;
using System.Data;
using System.Windows.Forms;

namespace QLTC
{
    public partial class fLogin : Form
    {
        private readonly TaiKhoanBUS bus = new TaiKhoanBUS();

        private int maTK = -1;

        public fLogin()
        {
            InitializeComponent();
        }

        #region SỰ KIỆN FORM

        private void cbHTMK_CheckedChanged(object sender, EventArgs e)
        {
            tbMK.UseSystemPasswordChar = !cbHTMK.Checked;
        }

        private void llDK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registry f = new Registry();
            f.ShowDialog();

            tbTDN.Focus();
        }

        #endregion

        #region ĐĂNG NHẬP

        private void btDN_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDN = tbTDN.Text.Trim();
                string matKhau = tbMK.Text.Trim();

                if (!KiemTraDangNhap(tenDN, matKhau))
                    return;

                DataTable dt = bus.DangNhap(tenDN, matKhau);

                XuLyKetQuaDangNhap(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void XuLyKetQuaDangNhap(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                tbMK.Clear();
                tbMK.Focus();
                return;
            }

            DataRow row = dt.Rows[0];

            maTK = Convert.ToInt32(row["MaTK"]);
            string vaiTro = row["VaiTro"].ToString();

            MessageBox.Show("Đăng nhập thành công!");

            TongQuan f = new TongQuan(maTK, vaiTro);
            f.Show();

            Hide();
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTraDangNhap(string tenDN, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDN))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!");
                tbTDN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống!");
                tbMK.Focus();
                return false;
            }

            if (tenDN.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!");
                tbTDN.Focus();
                return false;
            }

            if (matKhau.Length < 3)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!");
                tbMK.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}