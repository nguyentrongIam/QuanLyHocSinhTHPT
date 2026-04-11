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
    public partial class FrmTimKiem : Form
    {
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            string sSQL = "select * from HocSinh where 1=1 ";
            //Khởi tạo đối tượng
            Database db = new Database();
            //Lấy dữ liệu từ textbox
            if (!string.IsNullOrWhiteSpace(txt_mssv.Text))
                sSQL += " and MaHS like N'%" + txt_mssv.Text + "%'";
            if (!string.IsNullOrWhiteSpace(txt_hoten.Text))
                sSQL += " and HoTen like N'%" + txt_hoten.Text + "%'";
            if (!string.IsNullOrWhiteSpace(txt_sdt.Text))
                sSQL += " and SDT like N'%" + txt_sdt.Text + "%'";
            //Lưu dữ liệu vừa truy vấn
            DataSet dts = db.XemDanhSach(sSQL);
            //Hiện lên DataGirdView
            gird_Timkiem.DataSource = dts.Tables[0];
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txt_mssv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_hoten_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
