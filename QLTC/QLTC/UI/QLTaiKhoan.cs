using System;
using System.Data;
using System.Windows.Forms;

namespace QLTC
{
    public partial class QLTaiKhoan : Form
    {
        private readonly QLTKBUS bus = new QLTKBUS();

        private int maTaiKhoan = -1;

        public QLTaiKhoan()
        {
            InitializeComponent();
        }

        #region FORM LOAD

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadData()
        {
            try
            {
                dgTK.AutoGenerateColumns = false;
                dgTK.DataSource = bus.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản: " + ex.Message);
            }
        }

        private void LoadComboBox()
        {
            cbVT.Items.Clear();

            cbVT.Items.Add("User");
            cbVT.Items.Add("Admin");

            cbVT.SelectedIndex = -1;
        }

        #endregion

        #region SỰ KIỆN DATAGRIDVIEW

        private void dgTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgTK.Rows[e.RowIndex];

            if (!LayMaTaiKhoanDangChon(row))
                return;

            DoDuLieuLenForm(row);
        }

        private bool LayMaTaiKhoanDangChon(DataGridViewRow row)
        {
            if (!dgTK.Columns.Contains("maTK"))
            {
                MessageBox.Show("Không tìm thấy cột mã tài khoản!");
                return false;
            }

            object value = row.Cells["maTK"].Value;

            if (value == null || value == DBNull.Value)
            {
                maTaiKhoan = -1;
                return false;
            }

            maTaiKhoan = Convert.ToInt32(value);
            return true;
        }

        private void DoDuLieuLenForm(DataGridViewRow row)
        {
            tbTDN.Text = LayGiaTriCell(row, "tenDN");
            tbMK.Text = LayGiaTriCell(row, "matKhau");
            cbVT.Text = LayGiaTriCell(row, "vaiTro");
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTra(bool laThem)
        {
            if (string.IsNullOrWhiteSpace(tbTDN.Text))
            {
                MessageBox.Show("Tên đăng nhập không được trống!");
                tbTDN.Focus();
                return false;
            }

            if (tbTDN.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!");
                tbTDN.Focus();
                return false;
            }

            if (tbTDN.Text.Trim().Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng!");
                tbTDN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbMK.Text))
            {
                MessageBox.Show("Mật khẩu không được trống!");
                tbMK.Focus();
                return false;
            }

            if (tbMK.Text.Trim().Length < 3)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!");
                tbMK.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbVT.Text))
            {
                MessageBox.Show("Chọn vai trò tài khoản!");
                cbVT.Focus();
                return false;
            }

            if (cbVT.Text != "User" && cbVT.Text != "Admin")
            {
                MessageBox.Show("Vai trò không hợp lệ!");
                cbVT.Focus();
                return false;
            }

            if (laThem && bus.CheckTrung(tbTDN.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                tbTDN.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region THÊM - SỬA - XÓA

        private void btThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra(true))
                return;

            try
            {
                bus.Them(
                    tbTDN.Text.Trim(),
                    tbMK.Text.Trim(),
                    cbVT.Text.Trim()
                );

                MessageBox.Show("Thêm tài khoản thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (maTaiKhoan == -1)
            {
                MessageBox.Show("Chọn tài khoản cần sửa!");
                return;
            }

            if (!KiemTra(false))
                return;

            try
            {
                bus.Sua(
                    maTaiKhoan,
                    tbMK.Text.Trim(),
                    cbVT.Text.Trim()
                );

                MessageBox.Show("Sửa tài khoản thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa tài khoản: " + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (maTaiKhoan == -1)
            {
                MessageBox.Show("Chọn tài khoản cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa tài khoản này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bus.Xoa(maTaiKhoan);

                MessageBox.Show("Xóa tài khoản thành công!");

                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa tài khoản: " + ex.Message);
            }
        }

        #endregion

        #region TÌM KIẾM - ĐÓNG FORM

        private void btTK_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = tbTK.Text.Trim();

                dgTK.AutoGenerateColumns = false;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dgTK.DataSource = bus.Load();
                    return;
                }

                dgTK.DataSource = bus.Tim(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btTC_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private string LayGiaTriCell(DataGridViewRow row, string tenCot)
        {
            if (!dgTK.Columns.Contains(tenCot))
                return "";

            object value = row.Cells[tenCot].Value;

            if (value == null || value == DBNull.Value)
                return "";

            return value.ToString();
        }

        private void ResetForm()
        {
            maTaiKhoan = -1;

            tbTDN.Clear();
            tbMK.Clear();
            tbTK.Clear();

            cbVT.SelectedIndex = -1;

            dgTK.ClearSelection();
            tbTDN.Focus();
        }

        #endregion
    }
}