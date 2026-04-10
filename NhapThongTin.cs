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
    public partial class frm_NhapThongTin : Form
    {
        public string loaiVaiTro { get; set; }
        public frm_NhapThongTin(string vaiTro)
        {
            InitializeComponent();
            lbl_VaiTro.Text = vaiTro;
            this.loaiVaiTro = vaiTro;
        }

        private void lbl_QuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_NhapThongTin_Load(object sender, EventArgs e)
        {
            //mặc định txt mật khẩu ở dạng *****
            txt_MatKhau.PasswordChar = '*';
        }

        private void ckb_HienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_HienThiMatKhau.Checked)
            {
                txt_MatKhau.PasswordChar = '\0'; // Hiện chữ bình thường
            }
            else
            {
                txt_MatKhau.PasswordChar = '*'; // Ẩn đi bằng dấu *
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan ac = new TaiKhoan(txt_TenDangNhap.Text= "GV007", txt_MatKhau.Text="07071991");
            if (this.loaiVaiTro== "Quản trị viên")
                ac.vaiTro = "Admin";
            else if (this.loaiVaiTro == "Phụ huynh / Học sinh")
                ac.vaiTro = "HocSinh";
            else ac.vaiTro = "GiaoVien";
            if (ac.XacMinhDangNhap())
            {
                MessageBox.Show("Đăng nhập thành công!");
                //đăng nhập thành công thì trả về tín hiệu
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
        }
    }
}
