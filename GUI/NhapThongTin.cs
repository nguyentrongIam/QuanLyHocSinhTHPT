using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.GUI
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
            string ten_dang_nhap = txt_TenDangNhap.Text;
            string mat_khau = txt_MatKhau.Text;
            string sSQL = "select * from TaiKhoan";
            sSQL += " where TenDangNhap='" + ten_dang_nhap + "' and MatKhau='" + mat_khau + "'";
            Database db = new Database();
            DataSet ds = db.XemDanhSach(sSQL);
            //kiểm tra rỗng,nếu không rỗng thì kiểm tra xem có đúng 1 hàng không(không trùng tài khoản)
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
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
