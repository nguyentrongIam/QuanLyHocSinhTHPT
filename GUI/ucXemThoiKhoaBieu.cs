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
    public partial class ucXemThoiKhoaBieu : UserControl
    {

        private int maHocSinhHienTai;
        DiemBUS diemBus = new DiemBUS();
        HocSinhBUS hsBus = new HocSinhBUS();
        public ucXemThoiKhoaBieu(int MaHS)
        {
            InitializeComponent();
            this.maHocSinhHienTai = MaHS;
        }
        DiemBUS bus = new DiemBUS();

        // Khai báo BUS ở đầu class
        ThoiKhoaBieuBUS tkbBus = new ThoiKhoaBieuBUS();

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            if (cbb_namhoc.SelectedItem == null || string.IsNullOrEmpty(cbb_hocky.Text))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Năm học và Học kỳ!");
                return;
            }

            try
            {
                string namHoc = cbb_namhoc.Text.Trim();
                int hocKy = int.Parse(cbb_hocky.Text.Trim());

                // Gọi BUS để lấy dữ liệu
                DataTable dt = tkbBus.LayThoiKhoaBieuHocSinhBUS(maHocSinhHienTai, namHoc, hocKy);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gird_danhsach.DataSource = dt;
                    FormatGridView(); // Hàm làm đẹp bảng
                }
                else
                {
                    gird_danhsach.DataSource = null;
                    MessageBox.Show("Chưa có thời khóa biểu cho thời gian này.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FormatGridView()
        {
            // Đổi tên cột hiển thị cho thân thiện
            gird_danhsach.Columns["ThuTrongTuan"].HeaderText = "Thứ";
            gird_danhsach.Columns["TietHoc"].HeaderText = "Tiết";
            gird_danhsach.Columns["TenMonHoc"].HeaderText = "Môn Học";
            gird_danhsach.Columns["TenGiaoVien"].HeaderText = "Giáo Viên";
        }

        private void ucXemThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            // 1. Nạp dữ liệu cho Học kỳ (Cố định 1 và 2)
            cbb_hocky.Items.Clear();
            cbb_hocky.Items.Add("1");
            cbb_hocky.Items.Add("2");
            if (cbb_hocky.Items.Count > 0) cbb_hocky.SelectedIndex = 0;

            // 2. Nạp danh sách Năm học từ Database
            try
            {
                // Tận dụng lại hàm lấy năm học dựa trên mã học sinh
                DataTable dtNamHoc = diemBus.LayDanhSachNamHoc(maHocSinhHienTai);

                if (dtNamHoc != null && dtNamHoc.Rows.Count > 0)
                {
                    cbb_namhoc.DataSource = dtNamHoc;
                    cbb_namhoc.DisplayMember = "NamHoc";
                    cbb_namhoc.ValueMember = "NamHoc";
                }
                else
                {
                    // Nếu học sinh mới chưa có dữ liệu trong bảng điểm/phân lớp, thêm mặc định
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
    }
}
