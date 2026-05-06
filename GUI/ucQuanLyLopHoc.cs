using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DAO;
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
    public partial class ucQuanLyLopHoc : UserControl
    {
        public ucQuanLyLopHoc()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void btn_lammoi_Click(object sender, EventArgs e)
{
    LopBUS bus = new LopBUS();

    // Lấy Value từ ComboBox (phải kiểm tra null)
    string namHoc = cbb_namhoc.SelectedValue?.ToString() ?? "";
    string gvcn = cbb_gvcn.SelectedValue?.ToString() ?? "";
    string tuKhoa = txt_tiemkiem.Text.Trim();
    
    // Gọi hàm lọc từ BUS
    DataTable dt = bus.LocDanhSachLop(namHoc, gvcn, tuKhoa);

    // Xử lý lọc Khối thủ công nếu cần (vì DB không có cột MaKhoi)
    if (cbb_khoi.SelectedValue != null && dt != null)
    {
        string khoiDuocChon = cbb_khoi.SelectedValue.ToString(); // "10", "11" hoặc "12"
        
        // Lọc DataView dựa trên tên lớp bắt đầu bằng số khối
        DataView dv = dt.DefaultView;
        dv.RowFilter = $"TenLop LIKE '{khoiDuocChon}%'"; 
        gridDanhSach.DataSource = dv.ToTable();
    }
    else
    {
        gridDanhSach.DataSource = dt;
    }
}

        private void ucQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            LoadAllComboBoxes();
        }
        private void LoadAllComboBoxes()
        {
            DataProvider db = new DataProvider();

            // 1. Load Năm học
            DataTable dtNamHoc = db.XemDanhSach("SELECT * FROM NamHoc").Tables[0];
            cbb_namhoc.DataSource = dtNamHoc;
            cbb_namhoc.DisplayMember = "TenNamHoc";
            cbb_namhoc.ValueMember = "MaNamHoc";
            cbb_namhoc.SelectedIndex = -1; // Để trống mặc định

            // 2. Load Giáo viên (Để hiển thị HoTen nhưng lưu MaGiaoVien)
            DataTable dtGV = db.XemDanhSach("SELECT MaGiaoVien, HoTen FROM GiaoVien").Tables[0];
            cbb_gvcn.DataSource = dtGV;
            cbb_gvcn.DisplayMember = "HoTen";
            cbb_gvcn.ValueMember = "MaGiaoVien";
            cbb_gvcn.SelectedIndex = -1;

            // 3. Load Khối (Bạn có thể tự viết thêm BUS/DAO cho Khối)
            // Nếu chưa có bảng Khối, bạn có thể add tạm bằng code:
            var items = new[] {
        new { Text = "Khối 10", Value = "10" },
        new { Text = "Khối 11", Value = "11" },
        new { Text = "Khối 12", Value = "12" }
    };
            cbb_khoi.DataSource = items;
            cbb_khoi.DisplayMember = "Text";
            cbb_khoi.ValueMember = "Value";
            cbb_khoi.SelectedIndex = -1;
        }
    }
}
