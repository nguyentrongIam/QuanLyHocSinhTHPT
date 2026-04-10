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
            string sSQL;
            string mahs, hoten, ngaysinh, sdt;

            //Khởi tạo đối tượng
            Database db = new Database();

            //Lấy dữ liệu từ textbox
            mahs = txt_mssv.Text;
            hoten = txt_hoten.Text;
            sdt = txt_sdt.Text;

            sSQL = $"select * from HocSinh where MaHS='{mahs}' or HoTen=N'{hoten}' or SDT='{sdt}'";

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
