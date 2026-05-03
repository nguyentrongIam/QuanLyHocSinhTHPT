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
    public partial class ucQuanLyDiem : UserControl
    {
        public ucQuanLyDiem()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucQuanLyDiem_Load(object sender, EventArgs e)
        {
            HienThiComBoBoxYear();

        }
        //Hiển thị combobox năm
        public void HienThiComBoBoxYear()
        {
            NamHocBUS bus = new NamHocBUS();
            DataSet ds;
            ds = bus.GetYearBUS();
            cbb_namhoc.DisplayMember = "TenNamHoc";
            cbb_namhoc.ValueMember = "MaNamHoc";
            cbb_namhoc.DataSource = ds.Tables[0];
        }
        //Hiển thị combobox lớp
        public void HienThiComBoBoxClass()
        {
            LopBUS bus = new LopBUS();
            DataSet ds;
            ds = bus.GetClassBUS(cbb_namhoc.Text);
            cbb_lophoc.DisplayMember = "TenLop";
            cbb_lophoc.ValueMember = "MaLopHoc";
            cbb_lophoc.DataSource = ds.Tables[0];
        }
        //Hiển thị combobox Môn học
        public void HienThiComBoBoxObJect()
        {
            MonHocBUS bus = new MonHocBUS();
            DataSet ds = bus.GetSubJect();
            cbb_monhoc.DisplayMember = "TenMonHoc";
            cbb_monhoc.ValueMember = "MaMonHoc";
            cbb_monhoc.DataSource = ds.Tables[0];
        }
        


        private void btn_luu_Click(object sender, EventArgs e)
        {

        }

        private void cbb_namhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ gọi hàm load lớp khi combobox năm học đã có dữ liệu
            if (cbb_namhoc.DataSource != null && cbb_namhoc.SelectedValue != null)
            {
                HienThiComBoBoxClass();
            }
            HienThiComBoBoxObJect();
            //Hiển thị combobox học kỳ
            cbb_hocky.Items.Clear();//Xóa các items cũ nếu có
            cbb_hocky.Items.Add('1');
            cbb_hocky.Items.Add('2');

            //Chọn sẵn học kỳ 1 khi mở form
            cbb_hocky.SelectedIndex = 0;
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu combobox
            string ten_mh, lop_hoc, nam_hoc,hocky;
            ten_mh = cbb_monhoc.Text;
            lop_hoc = cbb_lophoc.Text;
            nam_hoc = cbb_namhoc.Text;
            hocky = cbb_hocky.Text;
            //Khởi tạo lớp Diem
            DiemBUS bus = new DiemBUS();
            DataSet ds;
            ds = bus.XemDiem(ten_mh, lop_hoc, nam_hoc,hocky);

            gird_danhsach.DataSource = ds.Tables[0];
        }

        //Ấn vào dòng trên girdview sẽ hiển thị lên textbox
        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0)
                {
                    //Lấy hàng vừa click vào
                    DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

                    //ĐỔ dữ liệu vào textbox
                    txt_mahs.Text = row.Cells[0].Value.ToString();
                    txt_hoten.Text = row.Cells[1].Value.ToString();
                    txt_diemmieng.Text = row.Cells[2].Value.ToString();
                    txt_diem15p_lan1.Text = row.Cells[3].Value.ToString();
                    txt_diem15p_lan2.Text = row.Cells[4].Value.ToString();
                    txt_diemgiuaky.Text = row.Cells[5].Value.ToString();
                    txt_diemcuoiky.Text = row.Cells[6].Value.ToString();
                    //Lấy điểm ra
                    string diemmieng = row.Cells[2].Value.ToString();
                    string diem15p_lan1= row.Cells[3].Value.ToString();
                    string diem15p_lan2= row.Cells[4].Value.ToString();
                    string diemgiuaky= row.Cells[5].Value.ToString();
                    string diemcuoiky= row.Cells[6].Value.ToString();

                    //Tính điểm trung bình hiển thị
                    try
                    {
                        float diemtrungbinh;
                        diemtrungbinh = (float.Parse(diemmieng) + float.Parse(diem15p_lan1) + float.Parse(diem15p_lan2) + float.Parse(diemgiuaky) * 2 + float.Parse(diemcuoiky) * 3) / 8;
                        lbl_diemtrungbinh.Text = diemtrungbinh.ToString();
                    }
                    catch(Exception ex) { }
                    
                }
            }
            catch(Exception ex) { }
            
        }
    }
}
