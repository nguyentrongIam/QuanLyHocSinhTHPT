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
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class FrmQuanLyHocSinhGuna : Form
    {
        public FrmQuanLyHocSinhGuna()
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
            string malop, nienkhoa;
            int sohocsinh;
            malop = cbb_lop.Text;
            nienkhoa = txt_nienkhoa.Text;
            try
            {
                if(txt_nienkhoa.Text != "")
                {
                    HocSinhBUS hsBUS = new HocSinhBUS();
                    DataSet ds;
                    ds = hsBUS.LayDanhSachTatCaSinhVien(malop,nienkhoa);
                    gird_danhsach.DataSource = ds.Tables[0];
                    //Hiển thị lên top
                    lbl_malop_top.Text = malop;
                    lbl_nienkhoa_top.Text = nienkhoa;
                    //Đếm số lượng học sinh
                    sohocsinh = gird_danhsach.Rows.Count-1;
                    lbl_tongsohocsinh.Text = sohocsinh.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập niên khóa !");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi !");
            }
            
        }

        private void guna2HtmlLabel18_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void QuanLyHocSinhGuna_Load(object sender, EventArgs e)
        {
            ////cbb_lop
            //DataSet ds;
            //LopDAO lopDAO = new LopDAO();
            //ds = lopDAO.GetClassDAO();
            //cbb_lop.DisplayMember = "TenLop";
            //cbb_lop.ValueMember = "MaLop";
            //cbb_lop.DataSource = ds.Tables[0];
        }

        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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


                }
            }
            catch(Exception ex) { }

          
        }

        private void lbl_capnhat_Click(object sender, EventArgs e)
        {

        }

        private void pn_sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_nienkhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void gird_danhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
