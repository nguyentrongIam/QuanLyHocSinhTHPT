using QuanLyHocSinhTHPT.BUS;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinhTHPT
{
    public partial class ucXemLichGiangDay : UserControl
    {
        private int _maGV;
        private LichGiangDayBUS bus = new LichGiangDayBUS(); // Khởi tạo BUS
        private DataTable dtLichDay; // Biến tạm lưu toàn bộ lịch để lọc cục bộ (rất tối ưu)

        // Biến cờ để ngăn ComboBox kích hoạt sự kiện lọc khi đang nạp dữ liệu
        private bool isInitializing = true;

        public ucXemLichGiangDay(int maGV)
        {
            InitializeComponent();
            this._maGV = maGV;
            this.Load += ucXemLichGiangDay_Load;
        }

        private void ucXemLichGiangDay_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        // 1. Hàm nạp dữ liệu gốc từ Database
        public void LoadDataFromDatabase()
        {
            try
            {
                isInitializing = true; // Bật cờ ngăn sự kiện SelectedIndexChanged

                DataSet ds = bus.LayLichDayTheoGiaoVien(_maGV);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dtLichDay = ds.Tables[0];
                    gridDanhSach.DataSource = dtLichDay;

                    // Cấu hình Header hiển thị Tiếng Việt
                    if (gridDanhSach.Columns.Contains("TenLop")) gridDanhSach.Columns["TenLop"].HeaderText = "Lớp";
                    if (gridDanhSach.Columns.Contains("TenMonHoc")) gridDanhSach.Columns["TenMonHoc"].HeaderText = "Môn Học";
                    if (gridDanhSach.Columns.Contains("ThuTrongTuan")) gridDanhSach.Columns["ThuTrongTuan"].HeaderText = "Thứ";
                    if (gridDanhSach.Columns.Contains("TietHoc")) gridDanhSach.Columns["TietHoc"].HeaderText = "Tiết";

                    // Nạp dữ liệu vào ComboBox dựa trên DataTable vừa lấy được
                    LoadComboBoxes();
                }
                else
                {
                    gridDanhSach.DataSource = null;
                    MessageBox.Show("Giáo viên này hiện tại chưa có lịch giảng dạy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isInitializing = false; // Tắt cờ, cho phép lọc
                ThucHienLoc(); // Áp dụng lọc ngay với các giá trị index = 0
            }
        }

        // 2. Hàm trích xuất dữ liệu từ DataTable đưa vào ComboBox (Sử dụng LINQ)
        private void LoadComboBoxes()
        {
            if (dtLichDay == null || dtLichDay.Rows.Count == 0) return;

            cbb_thu.Items.Clear();
            cbb_lop.Items.Clear();
            cbb_monhoc.Items.Clear();

            // Thêm option Tất cả cho Thứ
            cbb_thu.Items.Add("--- Tất cả ---");
            var distinctThus = dtLichDay.AsEnumerable()
                                        .Select(r => r["ThuTrongTuan"].ToString())
                                        .Distinct()
                                        .OrderBy(s => s);
            foreach (var thu in distinctThus) cbb_thu.Items.Add(thu);
            cbb_thu.SelectedIndex = 0;

            // Thêm option Tất cả cho Lớp
            cbb_lop.Items.Add("--- Tất cả ---");
            var distinctLops = dtLichDay.AsEnumerable()
                                        .Select(r => r["TenLop"].ToString())
                                        .Distinct()
                                        .OrderBy(s => s);
            foreach (var lop in distinctLops) cbb_lop.Items.Add(lop);
            cbb_lop.SelectedIndex = 0;

            // Thêm option Tất cả cho Môn Học
            cbb_monhoc.Items.Add("--- Tất cả ---");
            var distinctMons = dtLichDay.AsEnumerable()
                                         .Select(r => r["TenMonHoc"].ToString())
                                         .Distinct()
                                         .OrderBy(s => s);
            foreach (var mon in distinctMons) cbb_monhoc.Items.Add(mon);
            cbb_monhoc.SelectedIndex = 0;
        }

        private void ThucHienLoc()
        {
            if (isInitializing || dtLichDay == null) return;

            try
            {
                string filter = "1=1";

                // Chỉ nối thêm chuỗi lọc khi Index > 0 (tức là không chọn "--- Tất cả ---")
                if (cbb_thu.SelectedIndex > 0 && cbb_thu.SelectedItem != null)
                    filter += string.Format(" AND Convert(ThuTrongTuan, 'System.String') = '{0}'", cbb_thu.SelectedItem);

                if (cbb_lop.SelectedIndex > 0 && cbb_lop.SelectedItem != null)
                    filter += string.Format(" AND TenLop = '{0}'", cbb_lop.SelectedItem);

                if (cbb_monhoc.SelectedIndex > 0 && cbb_monhoc.SelectedItem != null)
                    filter += string.Format(" AND TenMonHoc = '{0}'", cbb_monhoc.SelectedItem);

                dtLichDay.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Các sự kiện thay đổi ComboBox (Thay đổi là lưới tự lọc luôn, rất hiện đại)
        private void cbb_thu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void cbb_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void cbb_monhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        // 5. Nút Làm Mới sẽ làm nhiệm vụ lấy lại dữ liệu mới nhất từ CSDL đề phòng có ai đó vừa cập nhật lịch
        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            MessageBox.Show("Đã cập nhật dữ liệu lịch giảng dạy mới nhất!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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