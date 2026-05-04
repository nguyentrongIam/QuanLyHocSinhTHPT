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
    public partial class ucPhanCongGiangDay : UserControl
    {
        public ucPhanCongGiangDay()
        {
            InitializeComponent();
        }
        // Khai báo các lớp BUS cần thiết
        PhanCongBUS bus = new PhanCongBUS();
        LopBUS lopBus = new LopBUS();
        MonHocBUS monBus = new MonHocBUS();
        GiaoVienBUS gvBus = new GiaoVienBUS();

        private void ucPhanCongGiangDay_Load(object sender, EventArgs e)
        {
            LoadAllComboBox();
            LoadDataGrid();
        }

        private void LoadAllComboBox()
        {
            try
            {
                // --- 1. Nạp Lớp học ---
                DataTable dtLop = lopBus.LayDanhSach();
                cbb_lop.ValueMember = "MaLopHoc";
                cbb_lop.DisplayMember = "TenLop";
                cbb_lop.DataSource = dtLop;

                // --- 2. Nạp Môn học ) ---
                DataSet dsMon = monBus.GetSubJect();
                if (dsMon != null && dsMon.Tables.Count > 0)
                {
                    cbb_monhoc.ValueMember = "MaMonHoc";
                    cbb_monhoc.DisplayMember = "TenMonHoc";
                   
                    cbb_monhoc.DataSource = dsMon.Tables[0];
                }

                // --- 3. Nạp Giáo viên ---
                DataTable dtGV = gvBus.LayDanhSach();
                cbb_gv.ValueMember = "MaGiaoVien";
                cbb_gv.DisplayMember = "HoTen";
                cbb_gv.DataSource = dtGV;

                // --- 4. Nạp Thứ và Tiết ---
                cbb_thu.Items.Clear();
                cbb_thu.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7" });

                cbb_tiet.Items.Clear();
                for (int i = 1; i <= 10; i++)
                {
                    cbb_tiet.Items.Add(i.ToString());
                }

                // Reset trạng thái ban đầu
                cbb_lop.SelectedIndex = -1;
                cbb_monhoc.SelectedIndex = -1;
                cbb_gv.SelectedIndex = -1;
                cbb_thu.SelectedIndex = -1;
                cbb_tiet.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Binding dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataGrid()
        {
            gridDanhSach.DataSource = bus.LayDanhSach();
        }

        // Sự kiện Click vào bảng để hiện dữ liệu lên các ô nhập liệu[cite: 1]
        private void gridDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];
                txt_mapc.Text = row.Cells["MaPhanCong"].Value.ToString();
                cbb_lop.Text = row.Cells["TenLop"].Value.ToString();
                cbb_monhoc.Text = row.Cells["TenMonHoc"].Value.ToString();
                cbb_gv.Text = row.Cells["TenGiaoVien"].Value.ToString();
                cbb_thu.Text = row.Cells["ThuTrongTuan"].Value.ToString();
                cbb_tiet.Text = row.Cells["TietHoc"].Value.ToString();
            }
        }

        // Nút Thêm (guna2Button2)
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (cbb_lop.SelectedValue == null || cbb_monhoc.SelectedValue == null || cbb_gv.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Lớp, Môn học và Giáo viên!");
                return;
            }

            try
            {
                int maLop = Convert.ToInt32(cbb_lop.SelectedValue);
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int maGV = Convert.ToInt32(cbb_gv.SelectedValue);
                int thu = int.Parse(cbb_thu.Text);
                int tiet = int.Parse(cbb_tiet.Text);

                if (bus.Them(maLop, maMon, maGV, thu, tiet))
                {
                    MessageBox.Show("Thêm phân công thành công!");
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Nút Sửa
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mapc.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa!");
                return;
            }

            try
            {
                int maPC = int.Parse(txt_mapc.Text);
                int maLop = Convert.ToInt32(cbb_lop.SelectedValue);
                int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
                int maGV = Convert.ToInt32(cbb_gv.SelectedValue);
                int thu = int.Parse(cbb_thu.Text);
                int tiet = int.Parse(cbb_tiet.Text);

                if (bus.Sua(maPC, maLop, maMon, maGV, thu, tiet))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        // Nút Xóa
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mapc.Text)) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (bus.Xoa(int.Parse(txt_mapc.Text)))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadDataGrid();
                    txt_mapc.Clear();
                }
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            LoadDataGrid();
            MessageBox.Show("Đã làm mới dữ liệu!");
        }

        private void gridDanhSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridDanhSach.Rows[e.RowIndex];
                txt_mapc.Text = row.Cells["MaPhanCong"].Value.ToString();

                // Dùng SelectedValue để đảm bảo lấy đúng ID
                cbb_lop.SelectedValue = row.Cells["MaLopHoc"].Value;
                cbb_monhoc.SelectedValue = row.Cells["MaMonHoc"].Value;
                cbb_gv.SelectedValue = row.Cells["MaGiaoVien"].Value;

                cbb_thu.Text = row.Cells["ThuTrongTuan"].Value.ToString();
                cbb_tiet.Text = row.Cells["TietHoc"].Value.ToString();
            }
        }
    }
}
