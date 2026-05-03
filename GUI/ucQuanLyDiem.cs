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
        string chucNang = "";
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
            if (chucNang == "them")
            {
                try
                {
                    bool kq;
                    //Lấy dữ liệu textbox
                    string mahs;
                    float diemmieng, diem15plan1, diem15plan2, diemgiuaky, diemcuoiky;
                    mahs = txt_mahs.Text;

                    string malop = cbb_lophoc.SelectedValue.ToString();
                    int maMon = int.Parse(cbb_monhoc.SelectedValue.ToString());
                    int hocky = Convert.ToInt32(cbb_hocky.Text);
                    string nam = cbb_namhoc.Text;
                    diemmieng = float.Parse(txt_diemmieng.Text);
                    diem15plan1 = float.Parse(txt_diem15p_lan1.Text);
                    diem15plan2 = float.Parse(txt_diem15p_lan2.Text);
                    diemgiuaky = float.Parse(txt_diemgiuaky.Text);
                    diemcuoiky = float.Parse(txt_diemcuoiky.Text);
                    DiemBUS bus = new DiemBUS();
                    kq = bus.ThemDiemBUS(mahs, malop, maMon, hocky, nam, diemmieng, diem15plan1, diem15plan2, diemgiuaky, diemcuoiky);
                    if (kq)
                    {
                        MessageBox.Show("Thêm điểm thành công!", "Thông báo");
                        btn_lammoi_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thêm điểm thất bại. Có thể học sinh đã có điểm môn này!");
                    }


                    MessageBox.Show("Bạn vừa ấn thêm điểm");
                }
                catch(Exception ex) { MessageBox.Show("Lỗi nhập liệu: " + ex.Message); }
                
            }
            if (chucNang == "sua")
            {
                MessageBox.Show("Bạn vừa ấn sửa điểm");

            }
            if (chucNang == "xoa")
            {
                MessageBox.Show("Bạn vừa ấn xóa điểm");
            }

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
                    //txt_hoten.Text = row.Cells[1].Value.ToString();
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            chucNang = "them";
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            chucNang = "sua";

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            chucNang = "xoa";

        }

        private void btn_hocsinhchiacodiem_Click(object sender, EventArgs e)
        {
            DiemBUS bus = new DiemBUS();
            //Lấy dữ liệu combobox
            string malop = cbb_lophoc.SelectedValue.ToString();
            int maMon = Convert.ToInt32(cbb_monhoc.SelectedValue);
            int hocKy = int.Parse(cbb_hocky.Text);
            string namHoc = cbb_namhoc.Text;

            DataTable dt = bus.LayDanhSachChuaCoDiemBUS(malop,maMon,hocKy,namHoc);
            if (dt != null)
            {
                gird_danhsach.DataSource = dt;

            }
        }
    }
}
