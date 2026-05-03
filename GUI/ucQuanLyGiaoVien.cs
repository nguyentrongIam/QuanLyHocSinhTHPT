using QuanLyHocSinhTHPT.BUS;
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
    public partial class ucQuanLyGiaoVien : UserControl
    {
        public ucQuanLyGiaoVien()
        {
            InitializeComponent();
            pnThongTin.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            txtMaGiaoVien.Enabled = false;
            pnThongTin.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            txtMaGiaoVien.Enabled = true;
            pnThongTin.Show();
        }


        private void ClearTextBox()
        {
            txtMaGiaoVien.Clear();
            txtHoVaTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Text = DateTime.Now.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnThongTin.Hide();
            ClearTextBox();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            //load grid data
            string timKiem = "";
            if (!string.IsNullOrWhiteSpace(txtTenTimKiem.Text))
                timKiem= txtTenTimKiem.Text;
            GiaoVienBUS bus=new GiaoVienBUS();
            DataSet ds=bus.LayDanhSach(timKiem);
            gridDanhSach.DataSource = ds.Tables[0];
        }
    }
}
