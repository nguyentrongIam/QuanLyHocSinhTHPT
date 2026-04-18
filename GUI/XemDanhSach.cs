using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.GUI
{
    public partial class FrmXemDanhSach : Form
    {
        public FrmXemDanhSach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void XemDanhSach_Load(object sender, EventArgs e)
        {
            HienThiComBoBox();
        }
        public void HienThiComBoBox()
        {
            string sSQL;
            //Khởi tạo đối tượng
            Database db = new Database();

            //Lệnh truy vấn
            sSQL = "select distinct MaLop from HocSinh  ";

            //Lưu trữ dữ liệu
            DataSet dts = db.XemDanhSach(sSQL);

            //Đổ dữ liệu vào ComboBox
            cbb_Chonlop.DataSource = dts.Tables[0];

            //Hiển thị
            cbb_Chonlop.DisplayMember = "MaLop";

            //Giá trị
            cbb_Chonlop.ValueMember = "Malop";
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            string sSQL , MaLop;

            //Khởi tạo đối tượng
            Database db = new Database();

            //Lấy mã lớp từ Combobox
            MaLop = cbb_Chonlop.Text;

            //Lệnh truy vấn
            sSQL = $"select * from HocSinh where MaLop = '{MaLop}'";

            //Lưu dữ liệu truy vấn
            DataSet dts = db.XemDanhSach(sSQL);

            //Hiển thị lênh DataGridView
            gird_Danhsach.DataSource = dts.Tables[0];
        }

        private void FrmXemDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void lbl_QuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
