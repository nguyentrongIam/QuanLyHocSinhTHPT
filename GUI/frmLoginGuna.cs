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


        //xu li dang nhap va luu tai khoan
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //lay ten dang nhap, mat khau tu textbox
            string tenDangNhap=txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            TaiKhoanBUS bus = new TaiKhoanBUS();

            //tao dto de lay du lieu
            TaiKhoanDTO tkDangNhap;

            string ketQua = bus.DangNhap(tenDangNhap, matKhau,out tkDangNhap);

            if(ketQua=="Thành công")
            {
                //luu thong tin tai khoan vao bien toan cuc
                Session.TaiKhoanHienTai=tkDangNhap;

                MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                //dua vao ma vai tro de mo frm tuong ung
                if (tkDangNhap.MaVaiTro == 1)
                {
                    this.Hide();
                    frmAdminDashboard frm =new frmAdminDashboard();
                    frm.ShowDialog();
                    Close();
                    
                }
                if (tkDangNhap.MaVaiTro == 2)
                {
                    this.Hide();
                    DashboardGiaoVien frm = new DashboardGiaoVien();
                    frm.ShowDialog();
                    Close();
                }
            } 
            else
            {
                MessageBox.Show(ketQua, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //xu li an/hien mat khau
        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
                txtMatKhau.PasswordChar = '\0';
            else
                txtMatKhau.PasswordChar = '*';
        }
    }
}
