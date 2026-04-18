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

        private void btn_Xemdanhsachlop_Click(object sender, EventArgs e)
        {
            FrmXemDanhSach frm = new FrmXemDanhSach();
            frm.Show();
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            FrmTimKiem frm = new FrmTimKiem();
            frm.Show();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ChonDoiTuong frm =new frm_ChonDoiTuong();
            frm.ShowDialog();
            Close();
        }

        private void frm_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btn_XemThongTinCaNhan_Click(object sender, EventArgs e)
        {

        }
    }
}
