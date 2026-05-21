using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTC
{
    public partial class ViTien : Form
    {
        private readonly ViTienBUS bus = new ViTienBUS();

        private readonly int maTK;
        private int maViTien = -1;

        public ViTien(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region        // ===================== FORM LOAD =====================
        private void ViTien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region        // ===================== LOAD DỮ LIỆU =====================
        private void LoadData()
        {
            try
            {
                dgVT.AutoGenerateColumns = false;

                DataTable dt = bus.Load(maTK);
                dgVT.DataSource = dt;

                FormatDataGridView();
                HienThiTongSoDu(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ví tiền: " + ex.Message);
            }
        }

        private void FormatDataGridView()
        {
            if (dgVT.Columns.Contains("soDu"))
                dgVT.Columns["soDu"].DefaultCellStyle.Format = "N0";
        }

        private void HienThiTongSoDu(DataTable dt)
        {
            decimal tongSoDu = 0;

            foreach (DataRow row in dt.Rows)
            {
                tongSoDu += LayGiaTriDecimal(row, "SoDu");
            }

            lbSD.Text = tongSoDu.ToString("N0") + " VND";
        }
        #endregion

        #region        // ===================== SỰ KIỆN DATAGRIDVIEW =====================
        private void dgVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgVT.Rows[e.RowIndex];

            if (!LayMaViDangChon(row))
                return;

            DoDuLieuLenForm(row);
        }

        private bool LayMaViDangChon(DataGridViewRow row)
        {
            if (!dgVT.Columns.Contains("maVi"))
            {
                MessageBox.Show("Không tìm thấy cột mã ví!");
                return false;
            }

            if (row.Cells["maVi"].Value == null || row.Cells["maVi"].Value == DBNull.Value)
                return false;

            maViTien = Convert.ToInt32(row.Cells["maVi"].Value);
            return true;
        }

        private void DoDuLieuLenForm(DataGridViewRow row)
        {
            tbTV.Text = LayGiaTriCell(row, "tenVi");
            tbSD.Text = LayGiaTriCell(row, "soDu");
            tbGC.Text = LayGiaTriCell(row, "ghiChu");
        }
        #endregion

        #region        // ===================== KIỂM TRA DỮ LIỆU =====================

        private bool KiemTra()
        {
            if (string.IsNullOrWhiteSpace(tbTV.Text))
            {
                MessageBox.Show("Tên ví không được trống!");
                tbTV.Focus();
                return false;
            }

            if (!LaySoDu(out decimal soDu))
            {
                MessageBox.Show("Số dư phải là số!");
                tbSD.Focus();
                return false;
            }

            if (soDu < 0)
            {
                MessageBox.Show("Số dư không hợp lệ!");
                tbSD.Focus();
                return false;
            }

            return true;
        }

        private bool LaySoDu(out decimal soDu)
        {
            string text = tbSD.Text.Trim();

            // Cho phép nhập: 10000, 10,000, 10.000
            text = text.Replace(",", "").Replace(".", "");

            return decimal.TryParse(text, out soDu);
        }
        #endregion

        #region        // ===================== THÊM - SỬA - XÓA =====================
        private void btThem_Click(object sender, EventArgs e)
        {
            if (!KiemTra())
                return;

            try
            {
                bus.Them(
                    tbTV.Text.Trim(),
                    LaySoDuHopLe(),
                    tbGC.Text.Trim(),
                    maTK
                );

                MessageBox.Show("Thêm thành công!");
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm ví: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (maViTien == -1)
            {
                MessageBox.Show("Chọn ví cần sửa!");
                return;
            }

            if (!KiemTra())
                return;

            try
            {
                bus.Sua(
                    maViTien,
                    tbTV.Text.Trim(),
                    LaySoDuHopLe(),
                    tbGC.Text.Trim()
                );

                MessageBox.Show("Sửa thành công!");
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa ví: " + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (maViTien == -1)
            {
                MessageBox.Show("Chọn ví cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa ví này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                bus.Xoa(maViTien);

                MessageBox.Show("Xóa thành công!");
                LoadData();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa ví: " + ex.Message);
            }
        }
        #endregion

        #region        // ===================== HÀM DÙNG CHUNG =====================
        private decimal LaySoDuHopLe()
        {
            LaySoDu(out decimal soDu);
            return soDu;
        }

        private decimal LayGiaTriDecimal(DataRow row, string tenCot)
        {
            if (!row.Table.Columns.Contains(tenCot))
                return 0;

            if (row[tenCot] == DBNull.Value)
                return 0;

            return Convert.ToDecimal(row[tenCot]);
        }

        private string LayGiaTriCell(DataGridViewRow row, string tenCot)
        {
            if (!dgVT.Columns.Contains(tenCot))
                return "";

            object value = row.Cells[tenCot].Value;

            if (value == null || value == DBNull.Value)
                return "";

            return value.ToString();
        }

        private void ResetForm()
        {
            tbTV.Clear();
            tbSD.Clear();
            tbGC.Clear();

            maViTien = -1;

            dgVT.ClearSelection();
            tbTV.Focus();
        }
        #endregion
    }
}
