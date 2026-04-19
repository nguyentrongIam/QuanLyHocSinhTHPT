using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DTO;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class FrmQuanLyHocSinh : Form
    {
        public FrmQuanLyHocSinh()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien();
            gird_danhsach.DataSource = ds.Tables[0];
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            update();
            load();
            
        }
        //Chinh sua diem dua tren textbox
        public void update()
        {
            try
            {
                HocSinhBUS hsBUS = new HocSinhBUS();
                DiemDTO d_dto = new DiemDTO();

                d_dto.MaHS = txt_mssv.Text;
                d_dto.DiemMieng = double.Parse(txt_diemmieng.Text);
                d_dto.Diem15p = double.Parse(txt_diem15p.Text);
                d_dto.Diem45p = double.Parse(txt_diem45p.Text);
                d_dto.DiemThi = double.Parse(txt_diemthi.Text);
                hsBUS.CapNhatDiem(d_dto);
            }
            catch(Exception ex) { }
            
        }
        //Load lại gird sau khi cap nhat
        public void load()
        {
            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien();
            gird_danhsach.DataSource = ds.Tables[0];

        }

        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Kiem tra khong click vao header
            if (e.RowIndex >= 0)
            {
                //Lay 1 dong vua click
                //DataGridViewRow = 1 dòng trong bảng
                DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

                txt_hoten.Text = row.Cells[0].Value.ToString();
                txt_mssv.Text = row.Cells[1].Value.ToString();
                date_ngaysinh.Value = Convert.ToDateTime(row.Cells[2].Value);
                //Kiem tra gioi tinh
                if (row.Cells[3].Value.ToString() == "Nam")
                {
                    rad_nam.Checked = true;
                }
                else
                {
                    rad_nu.Checked = true;
                }
                txt_diachi.Text = row.Cells[4].Value.ToString();
                txt_sdt.Text = row.Cells[5].Value.ToString();
                txt_diemmieng.Text= row.Cells[6].Value.ToString();
                txt_diem15p.Text= row.Cells[7].Value.ToString();
                txt_diem45p.Text= row.Cells[8].Value.ToString();
                txt_diemthi.Text = row.Cells[9].Value.ToString();
                txt_diemtrungbinh.Text= row.Cells[10].Value.ToString();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn muốn thoát chương trình ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dlg == DialogResult.Yes){
                Close();
            }
        }
    }
}
