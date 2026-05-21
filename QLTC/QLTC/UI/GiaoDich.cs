using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QLTC
{
    public partial class GiaoDich : Form
    {
        private readonly GiaoDichBUS bus = new GiaoDichBUS();
        private readonly int maTK;

        private int loaiGD = -1;

        public GiaoDich(int _maTK)
        {
            InitializeComponent();
            maTK = _maTK;
        }

        #region FORM LOAD

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            LoadCombo();
            ResetForm();
        }

        #endregion

        #region LOAD DỮ LIỆU

        private void LoadCombo()
        {
            LoadComboVi();
            ResetComboDanhMuc();
        }

        private void LoadComboVi()
        {
            cbVi.DataSource = bus.LoadVi(maTK);
            cbVi.DisplayMember = "TenVi";
            cbVi.ValueMember = "MaVi";
            cbVi.SelectedIndex = -1;
        }

        private void LoadDanhMuc()
        {
            if (loaiGD == -1)
            {
                ResetComboDanhMuc();
                return;
            }

            cbDM.DataSource = bus.LoadDanhMuc(loaiGD, maTK);
            cbDM.DisplayMember = "TenDM";
            cbDM.ValueMember = "MaDM";
            cbDM.SelectedIndex = -1;
        }

        private void ResetComboDanhMuc()
        {
            cbDM.DataSource = null;
            cbDM.Items.Clear();
        }

        #endregion

        #region CHỌN LOẠI GIAO DỊCH

        private void btThu_Click(object sender, EventArgs e)
        {
            ChonLoaiGiaoDich(1);
        }

        private void btChi_Click(object sender, EventArgs e)
        {
            ChonLoaiGiaoDich(0);
        }

        private void ChonLoaiGiaoDich(int loai)
        {
            loaiGD = loai;

            CapNhatMauNutLoaiGiaoDich();
            LoadDanhMuc();
        }

        private void CapNhatMauNutLoaiGiaoDich()
        {
            btThu.BackColor = loaiGD == 1 ? Color.Green : Color.LightGray;
            btChi.BackColor = loaiGD == 0 ? Color.Red : Color.LightGray;
        }

        #endregion

        #region KIỂM TRA DỮ LIỆU

        private bool KiemTraDuLieu(out decimal soTien, out int maVi, out int maDM)
        {
            soTien = 0;
            maVi = -1;
            maDM = -1;

            if (loaiGD == -1)
            {
                MessageBox.Show("Chọn Thu hoặc Chi!");
                return false;
            }

            if (!LaySoTien(out soTien))
                return false;

            if (!LayMaVi(out maVi))
                return false;

            if (!LayMaDanhMuc(out maDM))
                return false;

            if (loaiGD == 0 && !KiemTraSoDuKhiChi(maVi, soTien))
                return false;

            return true;
        }

        private bool LaySoTien(out decimal soTien)
        {
            soTien = 0;

            string text = tbSoTien.Text.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Vui lòng nhập số tiền!");
                tbSoTien.Focus();
                return false;
            }

            // Cho phép nhập: 10000, 10,000, 10.000
            text = text.Replace(",", "").Replace(".", "");

            if (!decimal.TryParse(text, out soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                tbSoTien.Focus();
                return false;
            }

            if (soTien <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!");
                tbSoTien.Focus();
                return false;
            }

            return true;
        }

        private bool LayMaVi(out int maVi)
        {
            maVi = -1;

            if (cbVi.SelectedValue == null)
            {
                MessageBox.Show("Chọn ví!");
                cbVi.Focus();
                return false;
            }

            if (!int.TryParse(cbVi.SelectedValue.ToString(), out maVi))
            {
                MessageBox.Show("Ví không hợp lệ!");
                cbVi.Focus();
                return false;
            }

            return true;
        }

        private bool LayMaDanhMuc(out int maDM)
        {
            maDM = -1;

            if (cbDM.SelectedValue == null)
            {
                MessageBox.Show("Chọn danh mục!");
                cbDM.Focus();
                return false;
            }

            if (!int.TryParse(cbDM.SelectedValue.ToString(), out maDM))
            {
                MessageBox.Show("Danh mục không hợp lệ!");
                cbDM.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraSoDuKhiChi(int maVi, decimal soTien)
        {
            decimal soDu = bus.SoDuVi(maVi);

            if (soTien > soDu)
            {
                MessageBox.Show("Số dư ví không đủ để thực hiện giao dịch chi!");
                tbSoTien.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region LƯU GIAO DỊCH

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(out decimal soTien, out int maVi, out int maDM))
                return;

            try
            {
                bool ketQua = bus.Them(
                    soTien,
                    dtGD.Value,
                    tbND.Text.Trim(),
                    loaiGD,
                    maDM,
                    maVi
                );

                if (ketQua)
                {
                    MessageBox.Show("Lưu giao dịch thành công!");
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Lưu giao dịch thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu giao dịch: " + ex.Message);
            }
        }

        #endregion

        #region LÀM MỚI

        private void btLM_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadCombo();
        }

        #endregion

        #region HÀM DÙNG CHUNG

        private void ResetForm()
        {
            tbSoTien.Clear();
            tbND.Clear();

            cbVi.SelectedIndex = -1;
            ResetComboDanhMuc();

            dtGD.Value = DateTime.Now;

            loaiGD = -1;
            CapNhatMauNutLoaiGiaoDich();

            tbSoTien.Focus();
        }

        #endregion
    }
}