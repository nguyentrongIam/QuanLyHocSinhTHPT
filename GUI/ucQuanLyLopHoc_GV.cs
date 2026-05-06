using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class ucQuanLyLopHoc__GV : UserControl
    {
        private int maDiemHienTai = -1;
        private bool isAdding = false;

        private GiaoVienBUS busGiaoVien = new GiaoVienBUS();
        private DiemBUS busDiem = new DiemBUS();
        private int maGiaoVienHienTai;

        // Mã GV truyền vào: -1 nếu là Admin, > 0 nếu là Giáo viên
        public ucQuanLyLopHoc__GV(int maGV)
        {
            InitializeComponent();
            this.maGiaoVienHienTai = maGV;
        }

        private void ucQuanLyLopHoc_GV_Load(object sender, EventArgs e)
        {
            LoadDanhSachNamHoc();
            LoadDanhSachLop();
            LoadDanhSachMonHoc();

            if (cbb_hk.Items.Count == 0)
            {
                cbb_hk.Items.AddRange(new object[] { "--- Tất cả ---", "1", "2" });
                cbb_hk.SelectedIndex = 0;
            }
        }

        private void LoadDanhSachNamHoc()
        {
            NamHocBUS busNam = new NamHocBUS();
            DataSet ds = busNam.GetYearBUS();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["MaNamHoc"] = 0; // Tùy theo kiểu dữ liệu của bạn
                dr["TenNamHoc"] = "--- Tất cả ---";
                dt.Rows.InsertAt(dr, 0);

                cbb_namhoc.DataSource = dt;
                cbb_namhoc.DisplayMember = "TenNamHoc";
                cbb_namhoc.ValueMember = "TenNamHoc"; // Value dùng Text luôn để dễ query
            }
        }

        private void LoadDanhSachLop()
        {
            // Tạm dùng hàm cũ, nhưng phải sửa bên BUS/DAO trả ra tất cả nếu maGiaoVienHienTai = -1
            DataSet ds = busGiaoVien.LayLopHocCuaGiaoVien(this.maGiaoVienHienTai);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["MaLopHoc"] = -1;
                dr["TenLop"] = "--- Tất cả ---";
                dt.Rows.InsertAt(dr, 0);

                cbb_lop.DataSource = dt;
                cbb_lop.DisplayMember = "TenLop";
                cbb_lop.ValueMember = "MaLopHoc";
            }
        }

        private void LoadDanhSachMonHoc()
        {
            try
            {
                MonHocBUS busMon = new MonHocBUS();
                DataSet ds = busMon.LayMonDayCuaGV(this.maGiaoVienHienTai);

                cbb_monhoc.DataSource = null;
                cbb_monhoc.Items.Clear();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.NewRow();
                    dr["MaMonHoc"] = -1;
                    dr["TenMonHoc"] = "--- Tất cả ---";
                    dt.Rows.InsertAt(dr, 0);

                    cbb_monhoc.DataSource = dt;
                    cbb_monhoc.DisplayMember = "TenMonHoc";
                    cbb_monhoc.ValueMember = "MaMonHoc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            maDiemHienTai = -1;
            gridDanhSach.DataSource = null;

            if (cbb_lop.SelectedValue == null || cbb_monhoc.SelectedValue == null) return;

            try
            {
                string maLop = cbb_lop.SelectedValue.ToString();
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hocKy = cbb_hk.Text == "--- Tất cả ---" ? -1 : Convert.ToInt32(cbb_hk.Text);
                string namHoc = cbb_namhoc.Text;

                DataSet ds = busDiem.LayBangDiem(namHoc, hocKy, maLop, maMon, maGiaoVienHienTai);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gridDanhSach.DataSource = ds.Tables[0];
                    DinhDangLuoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }

        private void DinhDangLuoi()
        {
            if (gridDanhSach.Columns.Contains("MaHocSinh")) gridDanhSach.Columns["MaHocSinh"].HeaderText = "Mã HS";
            if (gridDanhSach.Columns.Contains("HoTen")) gridDanhSach.Columns["HoTen"].HeaderText = "Họ Tên";
            if (gridDanhSach.Columns.Contains("DiemMieng")) gridDanhSach.Columns["DiemMieng"].HeaderText = "Miệng";
            if (gridDanhSach.Columns.Contains("Diem15phut_1")) gridDanhSach.Columns["Diem15phut_1"].HeaderText = "15P Lần 1";
            if (gridDanhSach.Columns.Contains("Diem15phut_2")) gridDanhSach.Columns["Diem15phut_2"].HeaderText = "15P Lần 2";
            if (gridDanhSach.Columns.Contains("DiemGiuaKy")) gridDanhSach.Columns["DiemGiuaKy"].HeaderText = "Giữa Kỳ";
            if (gridDanhSach.Columns.Contains("DiemCuoiKy")) gridDanhSach.Columns["DiemCuoiKy"].HeaderText = "Cuối Kỳ";
        }

        private void btn_ChuaCoDiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbb_lop.SelectedValue == null || cbb_lop.SelectedValue.ToString() == "--- Tất cả ---")
                {
                    MessageBox.Show("Vui lòng chọn 1 Lớp cụ thể để xem danh sách chưa có điểm!"); return;
                }
                if (Convert.ToInt32(cbb_monhoc.SelectedValue) == -1)
                {
                    MessageBox.Show("Vui lòng chọn 1 Môn học cụ thể!"); return;
                }
                if (cbb_hk.Text == "--- Tất cả ---")
                {
                    MessageBox.Show("Vui lòng chọn Học kỳ cụ thể!"); return;
                }

                string malop = cbb_lop.SelectedValue.ToString();
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int hocKy = int.Parse(cbb_hk.Text);
                string namHoc = cbb_namhoc.Text;

                DataTable dt = busDiem.LayDanhSachChuaCoDiemBUS(malop, maMon, hocKy, namHoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridDanhSach.DataSource = dt;
                }
                else
                {
                    gridDanhSach.DataSource = null;
                    MessageBox.Show("Tất cả học sinh lớp này đã có điểm môn học này!");
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

                if (gridDanhSach.Columns.Contains("MaDiem") && row.Cells["MaDiem"].Value != DBNull.Value)
                {
                    maDiemHienTai = Convert.ToInt32(row.Cells["MaDiem"].Value);
                }

                txt_mahs.Text = row.Cells["MaHocSinh"].Value?.ToString();

                // Tránh lỗi null khi ấn vào danh sách chưa có điểm
                if (gridDanhSach.Columns.Contains("DiemMieng"))
                {
                    txt_diemmieng.Text = row.Cells["DiemMieng"].Value?.ToString();
                    txt_diem15p_lan1.Text = row.Cells["Diem15phut_1"].Value?.ToString();
                    txt_diem15p_lan2.Text = row.Cells["Diem15phut_2"].Value?.ToString();
                    txt_diemgiuaky.Text = row.Cells["DiemGiuaKy"].Value?.ToString();
                    txt_diemcuoiky.Text = row.Cells["DiemCuoiKy"].Value?.ToString();
                    TinhVaHienThiDTB(row);
                }
                else
                {
                    txt_diemmieng.Clear(); txt_diem15p_lan1.Clear(); txt_diem15p_lan2.Clear();
                    txt_diemgiuaky.Clear(); txt_diemcuoiky.Clear();
                }
            }
        }
        private void TinhVaHienThiDTB(DataGridViewRow row)
        {
            double tongDiem = 0;
            int tongHeSo = 0;

            // Hàm nhỏ nội bộ để xử lý nhanh việc lấy điểm và cộng hệ số
            //XuLy(tên cột, hệ số)
            void XuLy(string colName, int heSo)
            {
                if (row.Cells[colName].Value != null &&
                    double.TryParse(row.Cells[colName].Value.ToString(), out double diem))
                {
                    tongDiem += diem * heSo;
                    tongHeSo += heSo;
                }
            }

            // Áp dụng tính toán cho từng cột theo hệ số THPT
            if (gridDanhSach.Columns.Contains("DiemMieng"))
            {
                XuLy("DiemMieng", 1);
                XuLy("Diem15phut_1", 1);
                XuLy("Diem15phut_2", 1);
                XuLy("DiemGiuaKy", 2);
                XuLy("DiemCuoiKy", 3);
            }

            // Hiển thị kết quả ra Label
            if (tongHeSo > 0)
            {
                double dtb = tongDiem / tongHeSo;
                lbl_diemtrungbinh.Text = dtb.ToString("0.0"); // Định dạng 1 chữ số thập phân, vd: 8.5
            }
            else
            {
                lbl_diemtrungbinh.Text = "0.0";
            }
        }

        // NÚT THÊM / LƯU
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!isAdding)
            {
                isAdding = true;
                guna2Button2.Text = "Lưu";
                gridDanhSach.Enabled = false;

                txt_mahs.Clear(); txt_diemmieng.Clear(); txt_diem15p_lan1.Clear();
                txt_diem15p_lan2.Clear(); txt_diemgiuaky.Clear(); txt_diemcuoiky.Clear();

                MessageBox.Show("Đã chuyển sang chế độ Thêm. Vui lòng nhập thông tin rồi ấn Lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahs.Focus();
            }
            else
            {
                ThucHienLuuDiem(isUpdate: false);
            }
        }

        // NÚT SỬA
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mahs.Text))
            {
                MessageBox.Show("Vui lòng click chọn học sinh cần sửa điểm trên danh sách!");
                return;
            }
            ThucHienLuuDiem(isUpdate: true);
        }

        private void ThucHienLuuDiem(bool isUpdate)
        {
            // Đã cập nhật lại: Kiểm tra cbb_lop bằng "-1" thay vì chữ "--- Tất cả ---"
            if (cbb_lop.SelectedValue == null || cbb_lop.SelectedValue.ToString() == "-1" ||
                cbb_monhoc.SelectedValue == null || Convert.ToInt32(cbb_monhoc.SelectedValue) == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 Lớp và 1 Môn học cụ thể để nhập/sửa điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Dùng TryParse để ép kiểu an toàn, bắt chính xác ô nào nhập sai định dạng
                int maHS = 0;
                if (!int.TryParse(txt_mahs.Text.Trim(), out maHS)) { MessageBox.Show("Mã Học Sinh không hợp lệ (không phải là số)!"); return; }

                int maLop = 0;
                if (!int.TryParse(cbb_lop.SelectedValue.ToString(), out maLop)) { MessageBox.Show("Lỗi lấy Mã Lớp: Giá trị không phải là số!"); return; }

                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);

                int hk = 0;
                if (!int.TryParse(cbb_hk.Text.Trim(), out hk)) { MessageBox.Show("Học kỳ không hợp lệ!"); return; }

                // 2. Kiểm tra an toàn cho toàn bộ các ô điểm
                double m = 0, p1 = 0, p2 = 0, gk = 0, ck = 0;
                if (!string.IsNullOrWhiteSpace(txt_diemmieng.Text) && !double.TryParse(txt_diemmieng.Text, out m)) { MessageBox.Show("Điểm miệng không hợp lệ (kiểm tra lại dấu phẩy/chấm)!"); return; }
                if (!string.IsNullOrWhiteSpace(txt_diem15p_lan1.Text) && !double.TryParse(txt_diem15p_lan1.Text, out p1)) { MessageBox.Show("Điểm 15 phút lần 1 không hợp lệ!"); return; }
                if (!string.IsNullOrWhiteSpace(txt_diem15p_lan2.Text) && !double.TryParse(txt_diem15p_lan2.Text, out p2)) { MessageBox.Show("Điểm 15 phút lần 2 không hợp lệ!"); return; }
                if (!string.IsNullOrWhiteSpace(txt_diemgiuaky.Text) && !double.TryParse(txt_diemgiuaky.Text, out gk)) { MessageBox.Show("Điểm giữa kỳ không hợp lệ!"); return; }
                if (!string.IsNullOrWhiteSpace(txt_diemcuoiky.Text) && !double.TryParse(txt_diemcuoiky.Text, out ck)) { MessageBox.Show("Điểm cuối kỳ không hợp lệ!"); return; }

                // 3. Sau khi đã qua mọi cửa kiểm duyệt an toàn, mới gán vào đối tượng DTO
                DiemDTO d = new DiemDTO
                {
                    MaHocSinh = maHS,
                    MaLopHoc = maLop,
                    MaMonHoc = maMon,
                    HocKy = hk,
                    NamHoc = cbb_namhoc.Text.Trim(),
                    DiemMieng = m,
                    Diem15p_1 = p1,
                    Diem15p_2 = p2,
                    DiemGiuaKy = gk,
                    DiemCuoiKy = ck
                };

                // Gọi logic lưu xuống Database
                string result = busDiem.LuuDiem(d, isUpdate);
                MessageBox.Show(result, "Thông báo");

                // Nếu thành công thì reset lại form
                if (result == "Thành công")
                {
                    if (isAdding)
                    {
                        isAdding = false;
                        guna2Button2.Text = "Thêm";
                        gridDanhSach.Enabled = true;
                    }
                    btn_lammoi_Click(null, null); // Load lại danh sách lên lưới
                }
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống khác nếu có
                MessageBox.Show("Lỗi nhập liệu hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT XÓA
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (maDiemHienTai == -1)
            {
                MessageBox.Show("Vui lòng click chọn dòng điểm cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busDiem.XoaDiemBUS(maDiemHienTai))
                {
                    MessageBox.Show("Xóa thành công!");
                    maDiemHienTai = -1;
                    txt_mahs.Clear();
                    btn_lammoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // Reset dữ liệu lưới khi đổi combobox
        private void cbb_namhoc_SelectedIndexChanged(object sender, EventArgs e) { gridDanhSach.DataSource = null; }
        private void cbb_hk_SelectedIndexChanged(object sender, EventArgs e) { gridDanhSach.DataSource = null; }
        private void btn_HienThiLopGiaoVienDay_Click(object sender, EventArgs e) { }
        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e) { }
        private void btn_luu_Click(object sender, EventArgs e) { }
    }
}