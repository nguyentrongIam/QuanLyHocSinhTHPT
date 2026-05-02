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
            btnXemHoSo.FillColor = Color.FromArgb(239, 246, 255);
            btnXemHoSo.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnQuanLyHocSinh_Click(object sender, EventArgs e)
        {
            btnQuanLyHocSinh.FillColor = Color.FromArgb(239, 246, 255);
            btnQuanLyHocSinh.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnQuanLyGiaoVien_Click(object sender, EventArgs e)
        {
            btnQuanLyGiaoVien.FillColor = Color.FromArgb(239, 246, 255);
            btnQuanLyGiaoVien.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            btnQuanLyLopHoc.FillColor = Color.FromArgb(239, 246, 255);
            btnQuanLyLopHoc.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnPhanCongGiangDay_Click(object sender, EventArgs e)
        {
            btnPhanCongGiangDay.FillColor = Color.FromArgb(239, 246, 255);
            btnPhanCongGiangDay.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnQuanLyDiemSo_Click(object sender, EventArgs e)
        {
            btnQuanLyDiemSo.FillColor = Color.FromArgb(239, 246, 255);
            btnQuanLyDiemSo.ForeColor = Color.FromArgb(29, 78, 216);
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            btnQuanLyTaiKhoan.FillColor = Color.FromArgb(239, 246, 255);
            btnQuanLyTaiKhoan.ForeColor = Color.FromArgb(29, 78, 216);
        }
    }
}
