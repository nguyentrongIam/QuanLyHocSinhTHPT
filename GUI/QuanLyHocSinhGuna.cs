using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyHocSinhTHPT.BUS;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class QuanLyHocSinhGuna : Form
    {
        public QuanLyHocSinhGuna()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            HocSinhBUS hsBUS = new HocSinhBUS();
            DataSet ds;
            ds = hsBUS.LayDanhSachTatCaSinhVien();
            gird_danhsach.DataSource = ds.Tables[0];
        }

        private void guna2HtmlLabel18_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyHocSinhGuna_Load(object sender, EventArgs e)
        {
          
        }

        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            //Kiểm tra xem người dùng đã vào hàng chưa
            if (e.RowIndex >= 0)
            {
                //Lấy hàng vừa click vào
                DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

                //Đổ dữ liệu ra textbox
                txt_mshs.Text = row.Cells[0].Value.ToString();
                txt_hoten.Text = row.Cells[1].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(row.Cells[2].Value);
                txt_ngaysinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                //Kiểm tra giới tính
                if (row.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    tog_nam.Checked = true;
                    tog_nu.Checked = false;
                }
                else
                {
                    tog_nu.Checked = true;
                    tog_nam.Checked = false;

                }
                txt_diachi.Text = row.Cells["DiaChi"].Value.ToString();
                //Lấy điểm trung bình
                //lấy full cột điểm 
                float diemmieng, diem15p, diem1tiet,diemthi;
                diemmieng = float.Parse(row.Cells["DiemMieng"].Value.ToString());
                diem15p = float.Parse(row.Cells["Diem15phut"].Value.ToString());
                diem1tiet = float.Parse(row.Cells["Diem1tiet"].Value.ToString());
                diemthi = float.Parse(row.Cells["Diemthi"].Value.ToString());
                //Công thức tính điểm trung bình
                float diemtrungbinh = ((diemmieng+diem15p)*1+(diem1tiet)*2+(diemthi)*3)/ 7;
                lbl_diemtrungbinh.Text = diemtrungbinh.ToString();


            }
        }

        private void lbl_capnhat_Click(object sender, EventArgs e)
        {

        }
    }
}
