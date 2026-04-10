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
    public partial class frm_Dashboard : Form
    {
        public string vaiTro;
        public frm_Dashboard(string vaiTro)
        {
            InitializeComponent();
            lbl_ChucVu.Text = vaiTro;
            this.vaiTro = vaiTro;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_XemThongTinCaNhan_Click(object sender, EventArgs e)
        {

        }

        private void Btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dgl= MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dgl == DialogResult.Yes) {
                this.Hide();
                frm_ChonDoiTuong frm =new frm_ChonDoiTuong();
                frm.ShowDialog();
            }

        }

        private void btn_ThemHocSinh_Click(object sender, EventArgs e)
        {
            frm_ThemHocSinh frm =new frm_ThemHocSinh();
            frm.ShowDialog();
        }
    }
}
