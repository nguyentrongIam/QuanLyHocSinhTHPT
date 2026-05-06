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
using Excel = Microsoft.Office.Interop.Excel;


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

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem GridView có dữ liệu không
            if (gridDanhSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "DanhSachHocSinh_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 3. Khởi tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = null;

                try
                {
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Danh sách học sinh";

                    // 4. Xuất tiêu đề cột từ DataGridView
                    for (int i = 1; i <= gridDanhSach.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i] = gridDanhSach.Columns[i - 1].HeaderText;
                        // Định dạng tiêu đề (In đậm, màu nền)
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // 5. Xuất dữ liệu từng hàng
                    for (int i = 0; i < gridDanhSach.Rows.Count; i++)
                    {
                        for (int j = 0; j < gridDanhSach.Columns.Count; j++)
                        {
                            if (gridDanhSach.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = gridDanhSach.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // 6. Tự động giãn chiều rộng cột
                    worksheet.Columns.AutoFit();

                    // 7. Lưu file
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 8. Đóng ứng dụng Excel để không chạy ngầm
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }
    }
}
