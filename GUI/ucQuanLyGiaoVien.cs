using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class ucQuanLyGiaoVien : UserControl
    {
        private bool isAddMode = false;
        public ucQuanLyGiaoVien()
        {
            InitializeComponent();
            pnThongTin.Hide();
            string timKiem = "";
            if (!string.IsNullOrWhiteSpace(txtTenTimKiem.Text))
                timKiem = txtTenTimKiem.Text;
            GiaoVienBUS bus = new GiaoVienBUS();
            DataSet ds = bus.LayDanhSach(timKiem);
            gridDanhSach.DataSource = ds.Tables[0];
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            isAddMode = true;
            ClearTextBox();
            txtMaGiaoVien.Enabled = false;
            pnThongTin.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            txtMaGiaoVien.Enabled = false;
            pnThongTin.Show();
        }


        private void ClearTextBox()
        {
            txtMaGiaoVien.Clear();
            txtMaGiaoVien.Text = "Tự động";
            txtHoVaTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Text = DateTime.Now.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnThongTin.Hide();
            ClearTextBox();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            //load grid data
            string timKiem = "";
            if (!string.IsNullOrWhiteSpace(txtTenTimKiem.Text))
                timKiem= txtTenTimKiem.Text;
            GiaoVienBUS bus=new GiaoVienBUS();
            DataSet ds=bus.LayDanhSach(timKiem);
            gridDanhSach.DataSource = ds.Tables[0];
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (gridDanhSach.CurrentRow != null)
            {
                int maGV = Convert.ToInt32(gridDanhSach.CurrentRow.Cells["MaGiaoVien"].Value);
                string tenGV = gridDanhSach.CurrentRow.Cells["HoTen"].Value.ToString();

                GiaoVienBUS gvBUS = new GiaoVienBUS();

                // BƯỚC 1: Kiểm tra xem giáo viên này đã có lịch sử chưa
                bool coLichSu = gvBUS.KiemTraLichSu(maGV);

                if (coLichSu)
                {
                    // TRƯỜNG HỢP 1: Giáo viên đã từng dạy/chủ nhiệm (Nghỉ việc)
                    DialogResult rs = MessageBox.Show(
                        $"Giáo viên [{tenGV}] đã có dữ liệu giảng dạy trong hệ thống.\nBạn không thể xóa vĩnh viễn để tránh mất lịch sử, nhưng bạn có thể KHÓA TÀI KHOẢN (Đình chỉ/Nghỉ việc).\n\nBạn có muốn khóa giáo viên này không?",
                        "Khóa tài khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rs == DialogResult.Yes)
                    {
                        if (gvBUS.KhoaGiaoVien(maGV))
                        {
                            MessageBox.Show("Đã khóa tài khoản giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Load lại danh sách (Nhớ thêm điều kiện WHERE TaiKhoan.TrangThai = 1 ở hàm LoadDanhSach nhé)
                        }
                    }
                }
                else
                {
                    // TRƯỜNG HỢP 2: Dữ liệu trắng (Nhập nhầm/Dữ liệu rác)
                    DialogResult rs = MessageBox.Show(
                        $"Giáo viên [{tenGV}] chưa có bất kỳ dữ liệu ràng buộc nào.\nBạn có CHẮC CHẮN muốn XÓA VĨNH VIỄN dữ liệu này khỏi hệ thống không?",
                        "Xác nhận xóa gốc", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (rs == DialogResult.Yes)
                    {
                        if (gvBUS.XoaVinhVien(maGV))
                        {
                            MessageBox.Show("Đã xóa vĩnh viễn dữ liệu rác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Load lại danh sách
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giáo viên để xử lý!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            isAddMode = false;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];

                // Gán dữ liệu (Sử dụng toán tử ? để tránh lỗi nếu ô đó bị null)
                txtMaGiaoVien.Text = row.Cells["MaGiaoVien"].Value?.ToString();
                txtHoVaTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();

                // Xử lý Ngày sinh (Bắt lỗi an toàn nếu DB null)
                if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                }

                // Xử lý nút Toggle Giới tính (Mình giả định nút tên là tgGioiTinh)
                // Nếu Checked = true là Nữ, false là Nam
                string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
                tog_nam.Checked = (gioiTinh == "Nữ");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu rỗng (Dùng chung cho cả Thêm và Sửa)
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lỗi! Vui lòng điền đầy đủ các thông tin: Họ Tên, Địa chỉ, SĐT, Email.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Đóng gói dữ liệu chung vào GiaoVienDTO 
            // (Lưu ý: Chưa gán MaGiaoVien ở đây vì Thêm mới không cần truyền Mã)
            GiaoVienDTO gv = new GiaoVienDTO
            {
                HoTen = txtHoVaTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                GioiTinh = tog_nam.Checked ? "Nữ" : "Nam"
            };

            GiaoVienBUS gvBUS = new GiaoVienBUS();

            // ============================================
            // TRƯỜNG HỢP 1: ĐANG Ở CHẾ ĐỘ THÊM MỚI
            // ============================================
            if (isAddMode)
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn thêm giáo viên [{gv.HoTen}] và cấp tài khoản tự động không?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi hàm ThemGiaoVienMoi từ BUS (nó sẽ tự gọi cả 2 DAO)
                    if (gvBUS.ThemGiaoVienMoi(gv))
                    {
                        string tenDangNhap = "gv_" + gv.Email.Split('@')[0];
                        MessageBox.Show($"Thêm giáo viên thành công!\n\nTài khoản đăng nhập: {tenDangNhap}\nMật khẩu mặc định: 123456", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // LoadDanhSachGiaoVien(); // Nhớ mở comment dòng này để load lại DataGridView
                        isAddMode = false; // Xong việc thì tắt cờ Thêm đi
                    }
                    else
                    {
                        MessageBox.Show("Thêm giáo viên thất bại. Có thể email hoặc số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // ============================================
            // TRƯỜNG HỢP 2: ĐANG Ở CHẾ ĐỘ SỬA
            // ============================================
            else
            {
                // Phải kiểm tra xem người dùng đã chọn giáo viên để lấy mã chưa
                if (string.IsNullOrWhiteSpace(txtMaGiaoVien.Text))
                {
                    MessageBox.Show("Vui lòng click chọn một giáo viên bên danh sách trước khi lưu!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Đang sửa nên phải bổ sung Mã Giáo Viên vào DTO để mang xuống DAO
                gv.MaGiaoVien = Convert.ToInt32(txtMaGiaoVien.Text);

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn lưu các thay đổi cho giáo viên [{gv.HoTen}] không?", "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (gvBUS.CapNhatGiaoVien(gv))
                    {
                        MessageBox.Show("Cập nhật thông tin giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // LoadDanhSachGiaoVien(); // Nhớ mở comment dòng này
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không thể cập nhật thông tin. Vui lòng kiểm tra lại Database!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
