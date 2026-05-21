using System;
using System.Data;
using System.Windows.Forms;

namespace QLTC
{
    public partial class DanhMuc : Form
    {
        private readonly DanhMucBUS bus = new DanhMucBUS();
        private readonly int maTK;

        private int maDanhMuc = -1;

        public DanhMuc(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void DanhMuc_Load(object sender, EventArgs e)
        {
            LoadCombo();
            LoadDanhMuc(-1);
            ResetForm();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadCombo()
        {
            cbLoai.DataSource = new[]
            {
                new { Text = "Thu", Value = 1 },
                new { Text = "Chi", Value = 0 }
            };

            cbLoai.DisplayMember = "Text";
            cbLoai.ValueMember = "Value";
            cbLoai.SelectedIndex = -1;
        }

        private void LoadDanhMuc(int loai)
        {
            try
            {
                dgDM.AutoGenerateColumns = false;

                DataTable dt = bus.LoadDanhMuc(loai, maTK);
                dgDM.DataSource = null;
                dgDM.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        #endregion

        #region LỌC DANH MỤC

        private void btChi_Click(object sender, EventArgs e)
        {
            LoadDanhMuc(0);
        }

        private void btThu_Click(object sender, EventArgs e)
        {
            LoadDanhMuc(1);
        }

        private void btTC_Click(object sender, EventArgs e)
        {
            LoadDanhMuc(-1);
        }

        #endregion

        #region SỰ KIỆN DATAGRIDVIEW

        private void dgDM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgDM.Rows[e.RowIndex];

            if (!LayMaDanhMucDangChon(row))
                return;

            DoDuLieuLenForm(row);
        }

        private bool LayMaDanhMucDangChon(DataGridViewRow row)
        {
            if (!dgDM.Columns.Contains("maDM"))
            {
                MessageBox.Show("Không tìm thấy cột mã danh mục!");
                return false;
            }

            object value = row.Cells["maDM"].Value;

            if (value == null || value == DBNull.Value)
                return false;

            maDanhMuc = Convert.ToInt32(value);
            return true;
        }

        private void DoDuLieuLenForm(DataGridViewRow row)
        {
            tbTDM.Text = LayGiaTriCell(row, "tenDM");
            tbGC.Text = LayGiaTriCell(row, "ghiChu");

            string loaiText = LayGiaTriCell(row, "loai");
            cbLoai.SelectedValue = loaiText == "Thu" ? 1 : 0;
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(tbTDM.Text))
            {
                MessageBox.Show("Tên danh mục không được trống!");
                tbTDM.Focus();
                return false;
            }

            if (cbLoai.SelectedValue == null)
            {
                MessageBox.Show("Chọn loại danh mục!");
                cbLoai.Focus();
                return false;
            }

            return true;
        }

        private int GetLoai()
        {
            if (cbLoai.SelectedValue == null)
                throw new Exception("Chọn loại danh mục!");

            return Convert.ToInt32(cbLoai.SelectedValue);
        }

        private bool KiemTraTrungTen()
        {
            string ten = tbTDM.Text.Trim();

            if (bus.CheckTrung(ten, maTK, maDanhMuc))
            {
                MessageBox.Show("Tên danh mục đã tồn tại!");
                tbTDM.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region THÊM - SỬA - XÓA

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTra())
                    return;

                maDanhMuc = -1;

                if (!KiemTraTrungTen())
                    return;

                bool kq = bus.Them(
                    tbTDM.Text.Trim(),
                    GetLoai(),
                    tbGC.Text.Trim(),
                    maTK
                );

                if (kq)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadDanhMuc(-1);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm danh mục: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maDanhMuc == -1)
                {
                    MessageBox.Show("Chọn danh mục cần sửa!");
                    return;
                }

                if (!KiemTra())
                    return;

                if (!KiemTraTrungTen())
                    return;

                bool kq = bus.Sua(
                    maDanhMuc,
                    tbTDM.Text.Trim(),
                    GetLoai(),
                    tbGC.Text.Trim()
                );

                if (kq)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadDanhMuc(-1);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa danh mục: " + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (maDanhMuc == -1)
                {
                    MessageBox.Show("Chọn danh mục cần xóa!");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn chắc chắn muốn xóa danh mục này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                    return;

                bool kq = bus.Xoa(maDanhMuc);

                if (kq)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDanhMuc(-1);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa danh mục: " + ex.Message);
            }
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private string LayGiaTriCell(DataGridViewRow row, string tenCot)
        {
            if (!dgDM.Columns.Contains(tenCot))
                return "";

            object value = row.Cells[tenCot].Value;

            if (value == null || value == DBNull.Value)
                return "";

            return value.ToString();
        }

        private void ResetForm()
        {
            tbTDM.Clear();
            tbGC.Clear();

            cbLoai.SelectedIndex = -1;
            maDanhMuc = -1;

            dgDM.ClearSelection();
            tbTDM.Focus();
        }

        #endregion
    }
}