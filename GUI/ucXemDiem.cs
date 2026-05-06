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
    public partial class ucXemDiem : UserControl
    {
        private int maHocSinhHienTai;
        DiemBUS diemBus = new DiemBUS();
        HocSinhBUS hsBus = new HocSinhBUS();
        public ucXemDiem(int MaHS)
        {
            InitializeComponent();
            this.maHocSinhHienTai = MaHS;
        }
        DiemBUS bus=new DiemBUS();
        private void ucXemDiem_Load(object sender, EventArgs e)
        {
            // 1. Load thông tin học sinh (Họ tên, Lớp)
            LoadThongTinHocSinh();

            // 2. Nạp dữ liệu cho Học kỳ (Thường là cố định 1 & 2)
            cbb_hocky.Items.Clear();
            cbb_hocky.Items.Add("1");
            cbb_hocky.Items.Add("2");
            if (cbb_hocky.Items.Count > 0) cbb_hocky.SelectedIndex = 0;

            // 3. Nạp danh sách Năm học từ Database
            try
            {
                DataTable dtNamHoc = diemBus.LayDanhSachNamHoc(maHocSinhHienTai);
                if (dtNamHoc != null && dtNamHoc.Rows.Count > 0)
                {
                    cbb_namhoc.DataSource = dtNamHoc;
                    cbb_namhoc.DisplayMember = "NamHoc"; // Tên cột hiển thị trong DB
                    cbb_namhoc.ValueMember = "NamHoc";   // Giá trị lấy ra khi chọn
                }
                else
                {
                    // Nếu DB chưa có dữ liệu, thêm mặc định để không bị trống
                    cbb_namhoc.DataSource = null;
                    cbb_namhoc.Items.Add("2023-2024");
                    cbb_namhoc.Items.Add("2024-2025");
                    cbb_namhoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải năm học: " + ex.Message);
            }
        }
        private void LoadThongTinHocSinh()
        {
            DataTable dt = hsBus.LayThongTinChiTiet(maHocSinhHienTai);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Hiển thị lên các Label tương ứng trên giao diện của bạn
                lbl_HoTen.Text =  dt.Rows[0]["HoTen"].ToString();
                lbl_Lop.Text =  dt.Rows[0]["TenLop"].ToString();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            if (cbb_namhoc.SelectedValue == null || string.IsNullOrEmpty(cbb_hocky.Text)) return;

            try
            {
                string namHoc = cbb_namhoc.Text.Trim();
                // Chuyển đổi Học kỳ sang kiểu int
                int hocKy = int.Parse(cbb_hocky.Text.Trim());

                DataTable dt = diemBus.LayBangDiemHocSinhBUS(maHocSinhHienTai, hocKy, namHoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gird_danhsach.DataSource = dt;
                    TinhHocLuc();
                }
                else
                {
                    gird_danhsach.DataSource = null;
                    MessageBox.Show($"Không tìm thấy điểm cho Học kỳ {hocKy} - Năm học {namHoc}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void TinhHocLuc()
        {
            double tongDiemCacMon = 0;
            int soLuongMonHoc = 0;

            foreach (DataGridViewRow row in gird_danhsach.Rows)
            {
                // Bỏ qua dòng trống (dòng mới ở cuối grid nếu có)
                if (row.IsNewRow || row.Cells["TenMonHoc"].Value == null) continue;

                try
                {
                    // Lấy giá trị từ các ô điểm (xử lý trường hợp ô trống bằng 0)
                    double mieng = Convert.ToDouble(row.Cells["DiemMieng"].Value ?? 0);
                    double p15_1 = Convert.ToDouble(row.Cells["Diem15Phut_1"].Value ?? 0);
                    double p15_2 = Convert.ToDouble(row.Cells["Diem15Phut_2"].Value ?? 0);
                    double gk = Convert.ToDouble(row.Cells["DiemGiuaKy"].Value ?? 0);
                    double ck = Convert.ToDouble(row.Cells["DiemCuoiKy"].Value ?? 0);

                    // Công thức tính Điểm Trung Bình Môn (Hệ số: Miệng, 15p: hệ số 1; Giữa kỳ: hệ số 2; Cuối kỳ: hệ số 3)
                    // Tổng hệ số = 1 + 1 + 1 + 2 + 3 = 8
                    double dtbMon = (mieng + p15_1 + p15_2 + (gk * 2) + (ck * 3)) / 8;

                    tongDiemCacMon += dtbMon;
                    soLuongMonHoc++;
                }
                catch (Exception ex)
                {
                    // Bỏ qua lỗi định dạng nếu dữ liệu nhập vào không phải là số
                    continue;
                }
            }

            if (soLuongMonHoc > 0)
            {
                // 1. Tính Điểm Trung Bình Học Kỳ
                double dtbHocKy = Math.Round(tongDiemCacMon / soLuongMonHoc, 2);
                lbl_DiemTrungBinh.Text = dtbHocKy.ToString("0.00"); // Hiển thị lên label điểm trung bình

                // 2. Xét học lực và hiển thị lên label học lực
                if (dtbHocKy >= 8.0)
                {
                    lbl_HocLuc.Text = "Giỏi";
                    lbl_HocLuc.ForeColor = Color.DarkGreen;
                }
                else if (dtbHocKy >= 6.5)
                {
                    lbl_HocLuc.Text = "Khá";
                    lbl_HocLuc.ForeColor = Color.Blue;
                }
                else if (dtbHocKy >= 5.0)
                {
                    lbl_HocLuc.Text = "Trung Bình";
                    lbl_HocLuc.ForeColor = Color.Orange;
                }
                else
                {
                    lbl_HocLuc.Text = "Yếu";
                    lbl_HocLuc.ForeColor = Color.Red;
                }
            }
            else
            {
                lbl_DiemTrungBinh.Text = "0.0";
                lbl_HocLuc.Text = "Chưa có dữ liệu";
            }
        }
    }
}
