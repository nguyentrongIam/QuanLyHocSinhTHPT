    using QuanLyHocSinhTHPT.BUS;
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
        public partial class ucQuanLyLopHoc__GV : UserControl
        {
        private int maDiemHienTai = -1; // Khai báo biến để lưu ID điểm đang chọn

        // Khai báo các đối tượng nghiệp vụ
        private GiaoVienBUS busGiaoVien = new GiaoVienBUS();
            private DiemBUS busDiem = new DiemBUS();

            // Biến lưu mã giáo viên hiện tại (Sửa lỗi CS1061)
            private int maGiaoVienHienTai;

            // Constructor nhận mã giáo viên khi đăng nhập
            public ucQuanLyLopHoc__GV(int maGV)
            {
                InitializeComponent();
                this.maGiaoVienHienTai = maGV;
            }

        

            private void ucQuanLyLopHoc_GV_Load(object sender, EventArgs e)
            {
                LoadDanhSachLop();
                LoadDanhSachMonHoc(); // Thêm mới
                LoadDanhSachNamHoc(); // Thêm mới

                // Thiết lập Học kỳ mặc định
                if (cbb_hk.Items.Count == 0)
                {
                    cbb_hk.Items.AddRange(new object[] { "1", "2" });
                    cbb_hk.SelectedIndex = 0; // Chọn sẵn HK 1
                }
            }
        private void LoadDanhSachMonHoc()
        {
            try
            {
                MonHocBUS busMon = new MonHocBUS();
                DataSet ds = busMon.LayMonDayCuaGV(this.maGiaoVienHienTai);

                // Xóa liên kết cũ để tránh giữ lại dữ liệu cũ
                cbb_monhoc.DataSource = null;
                cbb_monhoc.Items.Clear();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cbb_monhoc.DataSource = ds.Tables[0];
                    cbb_monhoc.DisplayMember = "TenMonHoc";
                    cbb_monhoc.ValueMember = "MaMonHoc";
                }
                else
                {
                    // Nếu không có môn nào ở năm/học kỳ này
                    cbb_monhoc.Text = "-- Không có môn --";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadDanhSachNamHoc()
            {
                // Tương tự cho Năm học
                NamHocBUS busNam = new NamHocBUS();
                DataSet ds = busNam.GetYearBUS();

                if (ds != null && ds.Tables.Count > 0)
                {
                    cbb_namhoc.DataSource = ds.Tables[0];
                    cbb_namhoc.DisplayMember = "TenNamHoc";
                    cbb_namhoc.ValueMember = "MaNamHoc";
                }
            }
      
            private void LoadDanhSachLop()
            {
                DataSet ds = busGiaoVien.LayLopHocCuaGiaoVien(this.maGiaoVienHienTai);

                if (ds != null && ds.Tables.Count > 0)
                {
                    cbb_lop.DataSource = ds.Tables[0];
                    cbb_lop.DisplayMember = "TenLop";
                    cbb_lop.ValueMember = "MaLopHoc";
                }
            }

        // Sự kiện Click của nút "Làm mới" (dùng để lọc danh sách)
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            maDiemHienTai = -1;
            // 1. Kiểm tra đầu vào
            if (cbb_lop.SelectedValue == null || cbb_monhoc.SelectedValue == null ||
                cbb_namhoc.SelectedValue == null || string.IsNullOrEmpty(cbb_hk.Text))
            {
                gridDanhSach.DataSource = null;
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo");
                return;
            }

            try
            {
                // Xóa sạch nguồn dữ liệu cũ của Grid trước khi gọi hàm mới
                gridDanhSach.DataSource = null;

                string tenLop = cbb_lop.Text;
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hocKy = Convert.ToInt32(cbb_hk.Text);
                string namHoc = cbb_namhoc.Text;

                MessageBox.Show($"Đang tìm: Lớp='{tenLop}', Môn={maMon}, HK={hocKy}, Năm='{namHoc}'");
                DataSet ds = busDiem.LayBangDiemTheoLop(tenLop, maMon, hocKy, namHoc);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gridDanhSach.DataSource = ds.Tables[0];
                    DinhDangLuoi();
                }
                else
                {
                    // Nếu không có dữ liệu, thông báo rõ ràng cho người dùng
                    MessageBox.Show($"Không có dữ liệu điểm cho năm {namHoc} - Học kỳ {hocKy}", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }

        private void DinhDangLuoi()
        {
            if (gridDanhSach.Columns.Contains("MaHocSinh"))
                gridDanhSach.Columns["MaHocSinh"].HeaderText = "Mã HS";
            if (gridDanhSach.Columns.Contains("HoTen"))
                gridDanhSach.Columns["HoTen"].HeaderText = "Họ Tên";
            if (gridDanhSach.Columns.Contains("DiemMieng"))
                gridDanhSach.Columns["DiemMieng"].HeaderText = "Miệng";

            // Sửa lại cho đúng tên cột từ câu SQL: Diem15phut_1 và Diem15phut_2
            if (gridDanhSach.Columns.Contains("Diem15phut_1"))
                gridDanhSach.Columns["Diem15phut_1"].HeaderText = "15P Lần 1";
            if (gridDanhSach.Columns.Contains("Diem15phut_2"))
                gridDanhSach.Columns["Diem15phut_2"].HeaderText = "15P Lần 2";
            if (gridDanhSach.Columns.Contains("DiemGiuaKy"))
                gridDanhSach.Columns["DiemGiuaKy"].HeaderText = "Giữa Kỳ";
            if (gridDanhSach.Columns.Contains("DiemCuoiKy"))
                gridDanhSach.Columns["DiemCuoiKy"].HeaderText = "Cuối Kỳ";
        }

        private void btn_HienThiLopGiaoVienDay_Click(object sender, EventArgs e)
        {

        }

        private void cbb_namhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDanhSach.DataSource = null; 
            LoadDanhSachMonHoc();
        }

        private void cbb_hk_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetLuoiVaLọcLai();

        }
        private void ResetLuoiVaLọcLai()
        {
            gridDanhSach.DataSource = null;
        }

        private void btn_ChuaCoDiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_lop.SelectedValue == null) return;

                DiemBUS bus = new DiemBUS();
                string malop = cbb_lop.SelectedValue.ToString();
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hocKy = int.Parse(cbb_hk.Text);
                string namHoc = cbb_namhoc.Text;

                DataTable dt = bus.LayDanhSachChuaCoDiemBUS(malop, maMon, hocKy, namHoc);

                gridDanhSach.DataSource = dt;

                // Thêm dòng này để kiểm tra xem có lấy được dòng nào không
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tất cả học sinh lớp này đã có điểm hoặc không có học sinh!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
        }

        private void gridDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];

                // 1. Kiểm tra xem cột "MaDiem" có tồn tại trong Grid không
                if (gridDanhSach.Columns.Contains("MaDiem"))
                {
                    object value = row.Cells["MaDiem"].Value;
                    if (value != null && value != DBNull.Value)
                    {
                        maDiemHienTai = Convert.ToInt32(value);
                    }
                    else
                    {
                        MessageBox.Show("Dòng này có cột MaDiem nhưng giá trị bị trống (NULL)!");
                    }
                }
                else
                {
                    // Nếu chạy vào đây, nghĩa là SQL của Vinh chưa trả về cột tên là "MaDiem"
                    MessageBox.Show("Lỗi: Grid không tìm thấy cột nào tên là 'MaDiem'. Hãy kiểm tra lại câu lệnh SELECT trong DAO!");
                }

                // 2. Đổ dữ liệu ra TextBox (giữ nguyên của Vinh)
                txt_mahs.Text = row.Cells["MaHocSinh"].Value?.ToString();
                txt_diemmieng.Text = row.Cells["DiemMieng"].Value?.ToString();
                txt_diem15p_lan1.Text = row.Cells["Diem15phut_1"].Value?.ToString();
                txt_diem15p_lan2.Text = row.Cells["Diem15phut_2"].Value?.ToString();
                txt_diemgiuaky.Text = row.Cells["DiemGiuaKy"].Value?.ToString();
                txt_diemcuoiky.Text = row.Cells["DiemCuoiKy"].Value?.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra trống
            if (string.IsNullOrEmpty(txt_mahs.Text))
            {
                MessageBox.Show("Vui lòng chọn một học sinh!", "Thông báo");
                return;
            }

            try
            {
                string maHS = txt_mahs.Text;
                string maLop = cbb_lop.SelectedValue.ToString();
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hk = Convert.ToInt32(cbb_hk.Text);
                string nam = cbb_namhoc.Text.Replace(" ", "");

                // Chuyển đổi điểm an toàn (nếu TextBox rỗng thì mặc định là 0)
                float.TryParse(txt_diemmieng.Text, out float diemMieng);
                float.TryParse(txt_diem15p_lan1.Text, out float d15p1);
                float.TryParse(txt_diem15p_lan2.Text, out float d15p2);
                float.TryParse(txt_diemgiuaky.Text, out float dGK);
                float.TryParse(txt_diemcuoiky.Text, out float dCK);

                if (busDiem.ThemDiemBUS(maHS, maLop, maMon, hk, nam, diemMieng, d15p1, d15p2, dGK, dCK))
                {
                    MessageBox.Show("Thêm điểm thành công!", "Thông báo");
                    btn_lammoi_Click(sender, e); // Gọi lại nút Làm mới để load lại danh sách
                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu: " + ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mahs.Text))
            {
                MessageBox.Show("Vui lòng chọn học sinh cần sửa điểm!");
                return;
            }

            try
            {
                // 1. Lấy thông tin định danh
                string maHS = txt_mahs.Text;
                string maLop = cbb_lop.SelectedValue.ToString();
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hk = Convert.ToInt32(cbb_hk.Text);
                string nam = cbb_namhoc.Text.Trim();

                // 2. Ép kiểu điểm số (nếu để trống thì coi như 0)
                float dM = string.IsNullOrEmpty(txt_diemmieng.Text) ? 0 : float.Parse(txt_diemmieng.Text);
                float d15_1 = string.IsNullOrEmpty(txt_diem15p_lan1.Text) ? 0 : float.Parse(txt_diem15p_lan1.Text);
                float d15_2 = string.IsNullOrEmpty(txt_diem15p_lan2.Text) ? 0 : float.Parse(txt_diem15p_lan2.Text);
                float dGK = string.IsNullOrEmpty(txt_diemgiuaky.Text) ? 0 : float.Parse(txt_diemgiuaky.Text);
                float dCK = string.IsNullOrEmpty(txt_diemcuoiky.Text) ? 0 : float.Parse(txt_diemcuoiky.Text);

                // 3. Gọi BUS thực thi
                if (busDiem.SuaDiemBUS(maHS, maLop, maMon, hk, nam, dM, d15_1, d15_2, dGK, dCK))
                {
                    MessageBox.Show("Cập nhật điểm thành công!");
                    btn_lammoi_Click(sender, e); // Load lại lưới để thấy dữ liệu mới
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Kiểm tra lại dữ liệu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi định dạng số: " + ex.Message);
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Nếu biến ID vẫn là -1 hoặc TextBox mã học sinh trống thì báo lỗi
            if (maDiemHienTai == -1 || string.IsNullOrEmpty(txt_mahs.Text))
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách. Vui lòng click chuột vào một dòng trên bảng trước khi bấm Xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm của học sinh {txt_mahs.Text} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                if (busDiem.XoaDiemBUS(maDiemHienTai))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    maDiemHienTai = -1; // Reset
                    txt_mahs.Clear();   // Xóa trắng TextBox sau khi xóa xong
                    btn_lammoi_Click(sender, e); // Load lại lưới
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Có thể do kết nối cơ sở dữ liệu.", "Lỗi");
                }
            }
        }
    }
    }