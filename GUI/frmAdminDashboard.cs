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
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = false;

            this.FormBorderStyle = FormBorderStyle.Sizable;

            //Tắt thu nhỏ
            this.MaximizeBox = false;
            //this.MinimizeBox = false;

            //Bung toàn màn hình
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
        }
        public void addUserControl(UserControl uc)
        {
            pn_body.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pn_body.Controls.Add(uc);
            uc.BringToFront();
        }
        private void btnXemHoSo_Click(object sender, EventArgs e)
        {
            ucProfile uc = new ucProfile();
            addUserControl(uc);
        }

        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            ucQuanLyHocSinh uc = new ucQuanLyHocSinh();
            addUserControl(uc);
        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            ucQuanLyGiaoVien uc = new ucQuanLyGiaoVien();
            addUserControl(uc);
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
        }

        private void btnPhanCongGiangDay_Click(object sender, EventArgs e)
        {
            ucPhanCongGiangDay uc = new ucPhanCongGiangDay();
            addUserControl(uc);
        }

        private void btnQuanLyDiemSo_Click(object sender, EventArgs e)
        {
            ucQuanLyDiem uc = new ucQuanLyDiem();
            addUserControl(uc);
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dgl = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dgl == DialogResult.Yes)
            {
                //Khoi dong lai app
                Application.Restart();
            }
        }
    }
}
