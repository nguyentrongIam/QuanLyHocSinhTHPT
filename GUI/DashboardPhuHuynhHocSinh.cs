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
    public partial class DashboardPhuHuynhHocSinh : Form
    {
        public DashboardPhuHuynhHocSinh()
        {
            InitializeComponent(); // CHỈ gọi duy nhất tại đây[cite: 1]

            // Thiết lập thuộc tính Form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Thiết lập layout cho Panel ngay từ đầu để tránh bị nhảy giao diện
            SetupLayout();
        }
        private void SetupLayout()
        {
            // Sidebar dock bên trái
            pnSidebar.Dock = DockStyle.Left;

            // Body chiếm phần còn lại
            pn_body.Dock = DockStyle.Fill;

            // Quan trọng: Đưa pn_body ra sau cùng để nó không đè lên Sidebar
            // và đảm bảo Sidebar luôn hiển thị
            pn_body.SendToBack();
            pnSidebar.BringToFront();
        }

        private void btn_XemDiemHocKy_Click(object sender, EventArgs e)
        {
            // Kiểm tra Session
            if (Session.TaiKhoanHienTai == null)
            {
                MessageBox.Show("Chưa đăng nhập! Session rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HocSinhBUS hsBus = new HocSinhBUS();
            int maHS = hsBus.LayMaHocSinh(Session.TaiKhoanHienTai.MaTaiKhoan);

            if (maHS == -1)
            {
                MessageBox.Show("Không tìm thấy mã học sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pn_body.Controls.Clear();

            ucXemDiem uc = new ucXemDiem(maHS);
            uc.Dock = DockStyle.Fill;
            pn_body.Controls.Add(uc);

            // KHÔNG gọi pn_body.BringToFront() — sẽ phá layout Dock
        }

        private void DashboardPhuHuynhHocSinh_Load(object sender, EventArgs e)
        {
           
        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
           

        }
    }
}
