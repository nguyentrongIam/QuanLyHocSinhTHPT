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
    public partial class frmLoginGuna : Form
    {
        public frmLoginGuna()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap=txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            TaiKhoanBUS bus = new TaiKhoanBUS();

            TaiKhoanDTO tkDangNhap;

            string ketQua = bus.DangNhap(tenDangNhap, matKhau,out tkDangNhap);

            if(ketQua=="Thành công")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                if (tkDangNhap.MaVaiTro == 1)
                {
                    frmAdminDashboard frm =new frmAdminDashboard();
                    frm.ShowDialog();
                    Close();
                }
            } 
            else
            {
                MessageBox.Show(ketQua, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }
    }
}
