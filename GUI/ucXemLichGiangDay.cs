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

namespace QuanLyHocSinhTHPT
{
    public partial class ucXemLichGiangDay : UserControl

    {
        private int _maGV;
        LichGiangDayBUS bus = new LichGiangDayBUS();
        DataTable dtLichDay; // Biến tạm lưu toàn bộ lịch để lọc nhanh
        public ucXemLichGiangDay(int maGV)
        {
            InitializeComponent();
            this._maGV = maGV;
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            cbb_thu.SelectedIndex = 0;
            cbb_lop.SelectedIndex = 0;
            cbb_monhoc.SelectedIndex = 0;

            // 2. Tải lại dữ liệu mới nhất từ Database
            LoadData();

            // 3. Cập nhật lại danh sách trong ComboBox (phòng trường hợp lịch dạy vừa thay đổi)
            LoadComboBoxes();

            MessageBox.Show("Đã làm mới dữ liệu lịch giảng dạy!");
        }

        private void ucXemLichGiangDay_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxes();
        }
        public void LoadData()
        {
            DataSet ds = bus.LayLichDayTheoGiaoVien(_maGV);
            if (ds != null && ds.Tables.Count > 0)
            {
                dtLichDay = ds.Tables[0];
                gridDanhSach.DataSource = dtLichDay;

                // Cấu hình Header (Đảm bảo tên cột khớp với image_e80b12.png)
                if (gridDanhSach.Columns.Contains("TenLop")) gridDanhSach.Columns["TenLop"].HeaderText = "Lớp";
                if (gridDanhSach.Columns.Contains("TenMonHoc")) gridDanhSach.Columns["TenMonHoc"].HeaderText = "Môn Học";
                if (gridDanhSach.Columns.Contains("ThuTrongTuan")) gridDanhSach.Columns["ThuTrongTuan"].HeaderText = "Thứ";
                if (gridDanhSach.Columns.Contains("TietHoc")) gridDanhSach.Columns["TietHoc"].HeaderText = "Tiết";
            }
                
        }
        private void LoadComboBoxes()
        {
            if (dtLichDay == null) return;

            // Load Thứ
            cbb_thu.Items.Clear();
            cbb_thu.Items.Add("--- Tất cả ---");
            var distinctThus = dtLichDay.AsEnumerable().Select(r => r["ThuTrongTuan"].ToString()).Distinct().OrderBy(s => s);
            foreach (var thu in distinctThus)
                cbb_thu.Items.Add(thu); // SỬA: cbb_monhoc -> cbb_thu
            cbb_thu.SelectedIndex = 0;

            // Load Lớp
            cbb_lop.Items.Clear();
            cbb_lop.Items.Add("--- Tất cả ---");
            var distinctLops = dtLichDay.AsEnumerable().Select(r => r["TenLop"].ToString()).Distinct();
            foreach (var lop in distinctLops)
                cbb_lop.Items.Add(lop); // SỬA: cbb_monhoc -> cbb_lop
            cbb_lop.SelectedIndex = 0;

            // Load Môn (Phần này bạn đang viết đúng)
            cbb_monhoc.Items.Clear();
            cbb_monhoc.Items.Add("--- Tất cả ---");
            var distinctMons = dtLichDay.AsEnumerable().Select(r => r["TenMonHoc"].ToString()).Distinct();
            foreach (var mon in distinctMons)
                cbb_monhoc.Items.Add(mon);
            cbb_monhoc.SelectedIndex = 0;
        }

        // Hàm thực hiện lọc dữ liệu
        private void ThucHienLoc()
        {
            if (dtLichDay == null) return;

            string filter = "";

            if (cbb_thu.SelectedIndex > 0)
                filter += string.Format("Convert(ThuTrongTuan, 'System.String') = '{0}'", cbb_thu.SelectedItem);

            if (cbb_lop.SelectedIndex > 0)
            {
                if (filter != "") filter += " AND ";
                filter += string.Format("TenLop = '{0}'", cbb_lop.SelectedItem);
            }

            if (cbb_monhoc.SelectedIndex > 0)
            {
                if (filter != "") filter += " AND ";
                filter += string.Format("TenMonHoc = '{0}'", cbb_monhoc.SelectedItem);
            }

            dtLichDay.DefaultView.RowFilter = filter;
        }

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
    }
}
