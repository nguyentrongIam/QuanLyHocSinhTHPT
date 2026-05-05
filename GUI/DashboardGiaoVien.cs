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
    public partial class DashboardGiaoVien : Form
    {
        public DashboardGiaoVien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //Tắt thu nhỏ
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Bung toàn màn hình
            this.WindowState = FormWindowState.Maximized;
        }

        

        private void DashboardGiaoVien_Load(object sender, EventArgs e)
        {
        
            // 1. Tạm dừng vẽ giao diện để sắp xếp ngầm
            this.SuspendLayout();

            InitializeComponent();

            // 2. Thiết lập thứ tự ưu tiên bằng code để đè lên Design
            pn_sidebar.Dock = DockStyle.Left;
            pn_sidebar.BringToFront();

            pn_body.Dock = DockStyle.Fill;
            pn_body.SendToBack();

            // 3. Hoàn tất và vẽ lại toàn bộ một lần duy nhất
            this.ResumeLayout(false);
            this.PerformLayout();
        
    }

        private void btnQuanLyHocSinh_Click_1(object sender, EventArgs e)
        {
            // 1. Xóa các control cũ đang hiển thị trong vùng chứa
            pn_body.Controls.Clear();

            // 2. Khởi tạo User Control
            ucQuanLyHocSinh uc = new ucQuanLyHocSinh();

            // 3. Thiết lập cho UC lấp đầy vùng chứa
            uc.Dock = DockStyle.Fill;

            // 4. Thêm UC vào vùng chứa và đưa lên trên cùng
            pn_body.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnPhanCongGiangDay_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyDiemSo_Click(object sender, EventArgs e)
        {

        }

       

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (Session.TaiKhoanHienTai != null)
            {
                // Lấy MaTaiKhoan (giả sử trong TaiKhoanDTO của bạn có thuộc tính này)
                int maTK = Session.TaiKhoanHienTai.MaTaiKhoan;

                GiaoVienBUS busGV = new GiaoVienBUS();
                int maGV = busGV.LayMaGVHienTai(maTK);

                if (maGV != -1)
                {
                    ucQuanLyLopHoc__GV uc = new ucQuanLyLopHoc__GV(maGV);
                    pn_body.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    pn_body.Controls.Add(uc);
                }
                else
                {
                    MessageBox.Show("Tài khoản này chưa được gán cho giáo viên nào!");
                }
            }

        }

        private void btn_diemdanh_Click(object sender, EventArgs e)
        {
            if (Session.TaiKhoanHienTai != null)
            {
                // Lấy MaTaiKhoan (giả sử trong TaiKhoanDTO của bạn có thuộc tính này)
                int maTK = Session.TaiKhoanHienTai.MaTaiKhoan;

                GiaoVienBUS busGV = new GiaoVienBUS();
                int maGV = busGV.LayMaGVHienTai(maTK);

                if (maGV != -1)
                {
                    ucQuanLyDiemDanh uc = new ucQuanLyDiemDanh(maGV);
                    pn_body.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    pn_body.Controls.Add(uc);
                }
                else
                {
                    MessageBox.Show("Tài khoản này chưa được gán cho giáo viên nào!");
                }
            }
        }

        private void btnXemHoSo_Click(object sender, EventArgs e)
        {
            // 1. Xóa các control cũ đang hiển thị trong vùng chứa
            pn_body.Controls.Clear();

            // 2. Khởi tạo User Control
            ucProfile uc = new ucProfile();

            // 3. Thiết lập cho UC lấp đầy vùng chứa
            uc.Dock = DockStyle.Fill;

            // 4. Thêm UC vào vùng chứa và đưa lên trên cùng
            pn_body.Controls.Add(uc);
            uc.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Session.TaiKhoanHienTai != null)
            {
                // Lấy MaTaiKhoan (giả sử trong TaiKhoanDTO của bạn có thuộc tính này)
                int maTK = Session.TaiKhoanHienTai.MaTaiKhoan;

                GiaoVienBUS busGV = new GiaoVienBUS();
                int maGV = busGV.LayMaGVHienTai(maTK);

                if (maGV != -1)
                {
                    ucXemLichGiangDay uc = new ucXemLichGiangDay(maGV);
                    pn_body.Controls.Clear();
                    uc.Dock = DockStyle.Fill;
                    pn_body.Controls.Add(uc);
                }
                else
                {
                    MessageBox.Show("Tài khoản này chưa được gán cho giáo viên nào!");
                }
            }

        }
    }
}
