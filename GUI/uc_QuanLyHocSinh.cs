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

namespace QuanLyHocSinhTHPT
{
    public partial class uc_QuanLyHocSinh : UserControl
    {
        public uc_QuanLyHocSinh()
        {
            InitializeComponent();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            HienDanhSach();
        }
        public void HienDanhSach()
        {
            string tenlop, namhoc;
            tenlop = cbb_lophoc.Text;
            namhoc = cbb_namhoc.Text;
            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien(tenlop, namhoc);
            gird_danhsach.DataSource = ds.Tables[0];
        }
        public void HienComBoBoxTenLop()
        {
            LopBUS bus = new LopBUS();
            DataSet ds = bus.GetClassBUS();
            cbb_lophoc.DisplayMember = "TenLop";
            cbb_lophoc.ValueMember = "MaLopHoc";
            cbb_lophoc.DataSource = ds.Tables[0];
        }
        public void HienComBoBoxNamHoc()
        {
            NamHocBUS bus = new NamHocBUS();
            DataSet ds = bus.GetYearBUS();
            cbb_namhoc.DisplayMember = "TenNamHoc";
            cbb_namhoc.ValueMember = "MaNamHoc";
            cbb_namhoc.DataSource = ds.Tables[0];
        }

        private void uc_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            HienComBoBoxTenLop();
            HienComBoBoxNamHoc();
        }

        private void gird_danhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
