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
    public partial class frm_ChonDoiTuong : Form
    {
        public frm_ChonDoiTuong()
        {
            InitializeComponent();
        }
        private void MoFormNhapThongTin(string vaiTro)
        {
            //ẩn frm chọn đối tượng
            this.Hide();
            //tạo fmr nhập tt và hiển thị,frm chọn đối tượng sẽ tạm dừng
            frm_NhapThongTin frm = new frm_NhapThongTin(vaiTro);
            //đợi kết quả từ frm đăng nhập
            DialogResult ketQua = frm.ShowDialog();
            if (ketQua == DialogResult.OK)
            {
                //Đăng nhập thành công
                frm_Dashboard fDashboard = new frm_Dashboard(vaiTro);

                //Khi tắt Dashboard thì tắt luôn chương trình
                fDashboard.FormClosed += delegate { this.Close(); };
                fDashboard.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void btn_PhuHuynh_HocSinh_Click(object sender, EventArgs e)
        {
            //khởi tạo frm đăng nhập với vai trò là "Phụ huynh / Học sinh"
            MoFormNhapThongTin("Phụ huynh / Học sinh");
        }

        private void btn_GiaoVien_Click(object sender, EventArgs e)
        {
            //khởi tạo frm đăng nhập với vai trò là "Giáo viên"
            MoFormNhapThongTin("Giáo viên");
        }

        private void btn_QuanTriVien_Click(object sender, EventArgs e)
        {
            //khởi tạo frm đăng nhập với vai trò là "Quản trị viên"
            MoFormNhapThongTin("Quản trị viên");
        }

        private void frm_ChonDoiTuong_Load(object sender, EventArgs e)
        {

        }
    }
}
