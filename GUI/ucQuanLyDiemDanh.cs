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
    public partial class ucQuanLyDiemDanh : UserControl
    {
        // Khai báo lớp BUS
        DiemDanhBUS busDiemDanh = new DiemDanhBUS();
        private int _maGV;
        public ucQuanLyDiemDanh(int maGV)
        {
            InitializeComponent();
            this._maGV = maGV; // Lưu mã giáo viên được truyền vào
        }

        private void txt_diemmieng_TextChanged(object sender, EventArgs e)
        {

        }

        private void ucQuanLyDiemDanh_Load(object sender, EventArgs e)
        {
            dt_NgayDiemDanh.Value = DateTime.Now;

            // Gọi hàm hiển thị lớp lọc theo mã giáo viên đã lưu
            HienThiComBoBoxLop(_maGV);

            cbb_trangthai.Items.Clear();
            cbb_trangthai.Items.Add("Có mặt");
            cbb_trangthai.Items.Add("Vắng có phép");
            cbb_trangthai.Items.Add("Vắng không phép");
            cbb_trangthai.SelectedIndex = 0; // Mặc định chọn cái đầu tiên (Có mặt)

            // Tự động load dữ liệu điểm danh lần đầu
            LoadDataDiemDanh();
        }
        public void HienThiComBoBoxLop(int maGV)
        {
            LopBUS bus = new LopBUS();
            DataSet ds = bus.GetDanhSachLop(maGV);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                cbb_lop.DataSource = dt;
                cbb_lop.DisplayMember = "TenLop";

                // KIỂM TRA TÊN CỘT: 
                // Nếu database của bạn cột là MaLop thì sửa thành "MaLop"
                // Nếu database của bạn cột là MaLopHoc thì sửa thành "MaLopHoc"
                if (dt.Columns.Contains("MaLopHoc"))
                    cbb_lop.ValueMember = "MaLopHoc";
                else if (dt.Columns.Contains("MaLop"))
                    cbb_lop.ValueMember = "MaLop";
            }
        }
        private void LoadDataDiemDanh()
        {
            try
            {
                if (cbb_lop.SelectedValue == null || !(cbb_lop.SelectedValue is int)) return;

                int maLop = (int)cbb_lop.SelectedValue;
                DateTime ngayDiemDanh = dt_NgayDiemDanh.Value.Date;

                DataSet ds = busDiemDanh.LayDanhSachDiemDanh(maLop, ngayDiemDanh);

                if (ds != null && ds.Tables.Count > 0)
                {
                    gridDanhSach.DataSource = ds.Tables[0];

                    if (gridDanhSach.Columns.Contains("MaHocSinh")) gridDanhSach.Columns["MaHocSinh"].ReadOnly = true;
                    if (gridDanhSach.Columns.Contains("HoTen")) gridDanhSach.Columns["HoTen"].ReadOnly = true;
                    if (gridDanhSach.Columns.Contains("TrangThai")) gridDanhSach.Columns["TrangThai"].ReadOnly = true;

                    if (gridDanhSach.Columns.Contains("GhiChu"))
                    {
                        gridDanhSach.Columns["GhiChu"].HeaderText = "Ghi chú";
                        gridDanhSach.Columns["GhiChu"].ReadOnly = true; // Set ReadOnly vì ta sẽ sửa ở Panel bên phải
                    }

                    if (gridDanhSach.Columns.Contains("NgayDiemDanh"))
                    {
                        gridDanhSach.Columns["NgayDiemDanh"].HeaderText = "Ngày Điểm Danh";
                        gridDanhSach.Columns["NgayDiemDanh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                }
                // Xóa đoạn code cũ ghi đè HeaderText = "Vắng mặt" ở phía dưới này nếu có
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        private void cbb_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataDiemDanh();
        }

        private void dt_NgayDiemDanh_ValueChanged(object sender, EventArgs e)
        {
            LoadDataDiemDanh();

        }

        private void gridDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void gridDanhSach_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridDanhSach.IsCurrentCellDirty)
            {
                gridDanhSach.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gridDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];
                txt_mahs.Text = row.Cells["MaHocSinh"].Value.ToString();

                // Lấy giá trị đã được format (là chữ) để gán cho ComboBox
                string trangThaiHienThi = row.Cells["TrangThai"].FormattedValue.ToString();
                cbb_trangthai.Text = trangThaiHienThi;

                if (gridDanhSach.Columns.Contains("GhiChu") && row.Cells["GhiChu"].Value != DBNull.Value)
                {
                    txt_ghichu.Text = row.Cells["GhiChu"].Value.ToString();
                }
                else
                {
                    txt_ghichu.Clear(); // Nếu không có ghi chú thì xóa trắng ô text
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy dữ liệu từ giao diện
                if (string.IsNullOrEmpty(txt_mahs.Text))
                {
                    MessageBox.Show("Vui lòng chọn học sinh cần lưu!");
                    return;
                }

                int maHS = int.Parse(txt_mahs.Text);
                DateTime ngayDiemDanh = dt_NgayDiemDanh.Value.Date;
                string trangThaiChon = cbb_trangthai.Text;

                // Lấy nội dung ghi chú
                string ghiChu = txt_ghichu.Text.Trim();

                // 2. Gọi BUS - BẠN CẦN TRUYỀN THÊM THAM SỐ GHI CHÚ
                if (busDiemDanh.CapNhatDiemDanh(maHS, ngayDiemDanh, trangThaiChon, ghiChu))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDataDiemDanh();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
         
            
        }

        private void gridDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột TrangThai và giá trị không bị NULL
            if (gridDanhSach.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null && e.Value != DBNull.Value)
            {
                string val = e.Value.ToString().Trim();

                // Xử lý các giá trị tương ứng
                if (val == "0" || val.ToLower() == "false" || val == "Có mặt")
                {
                    e.Value = "Có mặt";
                    e.CellStyle.ForeColor = Color.Green;
                    e.FormattingApplied = true;
                }
                else if (val == "1" || val.ToLower() == "true" || val == "Vắng có phép")
                {
                    e.Value = "Vắng có phép";
                    e.CellStyle.ForeColor = Color.Orange;
                    e.FormattingApplied = true;
                }
                else if (val == "2" || val == "Vắng không phép")
                {
                    e.Value = "Vắng không phép";
                    e.CellStyle.ForeColor = Color.Red;
                    e.FormattingApplied = true;
                }
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            // 1. Xóa trắng các thông tin chi tiết bên phải
            txt_mahs.Clear();

            if (cbb_trangthai.Items.Count > 0)
            {
                cbb_trangthai.SelectedIndex = 0; // Đưa về "Có mặt"
            }

           
            LoadDataDiemDanh();
        }
    }
}
