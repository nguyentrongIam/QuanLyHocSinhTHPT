using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.BUS;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class ucQuanLyTaiKhoan : UserControl
    {
        private TaiKhoanBUS tkBUS=new TaiKhoanBUS();

        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
            LoadVaiTro();
            pnThongTin.Hide();
        }
        private void LoadVaiTro()
        {
            Dictionary<int, string> dsVaiTro = new Dictionary<int, string>()
            {
                { 1, "Quản trị viên" },
                { 2, "Giáo viên" },
                { 3, "Học sinh" }
            };

            cbbVaiTro.DataSource = new BindingSource(dsVaiTro, null);
            cbbVaiTro.DisplayMember = "Value";
            cbbVaiTro.ValueMember = "Key";
        }

        private void LoadDanhSach()
        {
            string timKiem = txtTimKiem.Text.Trim();
            DataSet ds = tkBUS.LayDanhSachTaiKhoan(timKiem);

            if (ds != null && ds.Tables.Count > 0)
            {
                gridDanhSach.DataSource = ds.Tables[0];
            }
        }

        private void ucQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadDanhSach();
        }

        private void gridDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];

                txtMaTaiKhoan.Text = row.Cells["MaTaiKhoan"].Value.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();

                cbbVaiTro.SelectedValue = Convert.ToInt32(row.Cells["MaVaiTro"].Value);
                togTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);

                pnThongTin.Show();
                pnThongTin.Enabled = false; // Bấm xem thì khóa panel, phải ấn Sửa mới được nhập
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng click chọn một tài khoản dưới danh sách để sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnThongTin.Enabled = true;
            txtMaTaiKhoan.Enabled = false;  // Không được sửa ID
            txtTenDangNhap.Enabled = false; // Không được sửa Tên đăng nhập

            txtMatKhau.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTaiKhoan.Text)) return;

            int maTK = Convert.ToInt32(txtMaTaiKhoan.Text);
            string matKhau = txtMatKhau.Text.Trim();
            int vaiTro = Convert.ToInt32(cbbVaiTro.SelectedValue);
            bool trangThai = togTrangThai.Checked;

            string ketQua = tkBUS.CapNhatTaiKhoan(maTK, matKhau, vaiTro, trangThai);

            if (ketQua == "Thành công")
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnThongTin.Enabled = false;
                LoadDanhSach();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                int maTK = Convert.ToInt32(txtMaTaiKhoan.Text);
                string ketQua = tkBUS.XoaTaiKhoan(maTK);

                if (ketQua == "Thành công")
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnThongTin.Hide();
                    txtMaTaiKhoan.Clear();
                    LoadDanhSach();
                }
                else
                {
                    MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pnThongTin.Enabled = false;
        }
    }
}
