using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DTO;
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
                
                

                try
                {
                    // 2. Lấy dữ liệu từ giao diện
                    string mahs = txt_mahs.Text;
                    string malop = cbb_lophoc.SelectedValue.ToString();
                    int maMon = int.Parse(cbb_monhoc.SelectedValue.ToString());
                    int hocky = int.Parse(cbb_hocky.Text); // Đã sửa dùng .Text để chính xác
                    string nam = cbb_namhoc.Text;

                    // Ép kiểu điểm số
                    float diemmieng = float.Parse(txt_diemmieng.Text);
                    float diem15p1 = float.Parse(txt_diem15p_lan1.Text);
                    float diem15p2 = float.Parse(txt_diem15p_lan2.Text);
                    float diemgiuaky = float.Parse(txt_diemgiuaky.Text);
                    float diemcuoiky = float.Parse(txt_diemcuoiky.Text);

                    // 3. Gọi BUS để thực thi
                    DiemBUS bus = new DiemBUS();
                    bool kq = bus.SuaDiemBUS(mahs, malop, maMon, hocky, nam, diemmieng, diem15p1, diem15p2, diemgiuaky, diemcuoiky);

                    if (kq)
                    {
                        MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btn_lammoi_Click(sender, e); // Tải lại bảng để cập nhật dữ liệu mới nhất
                        chucNang = ""; // Reset trạng thái chức năng
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi dữ liệu: " + ex.Message, "Thông báo lỗi");
                }
            }
            if (chucNang == "xoa")
            {
                // Lấy giá trị từ Tag mà Vinh đã gán ở CellClick
                if (txt_mahs.Tag != null)
                {
                    int maDiemHienTai = int.Parse(txt_mahs.Tag.ToString());

                    // Debug: Xem số này có khớp với cột MaDiem trong image_f0f877.png không
                    MessageBox.Show("ID truyền xuống là: " + maDiemHienTai);

                    DiemBUS bus = new DiemBUS();
                    if (bus.XoaDiemBUS(maDiemHienTai))
                    {
                        MessageBox.Show("Xóa thành công!");
                        btn_lammoi_Click(sender, e);
                        ResetInputDiem();
                    }
                    else
                    {
                        // Nếu vào đây là do db.ThucThi trả về 0 (không tìm thấy ID để xóa)
                        MessageBox.Show("Không tìm thấy dòng điểm này trong hệ thống để xóa!");
                    }
                }
            }

        }
        

        
        private void ResetInputDiem()
        {
            txt_mahs.Clear();
            txt_diemmieng.Clear();
            txt_diem15p_lan1.Clear();
            txt_diem15p_lan2.Clear();
            txt_diemgiuaky.Clear();
            txt_diemcuoiky.Clear();
            lbl_diemtrungbinh.Text = "0.0";
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
            // Sửa thành >= 0 để không bỏ sót dòng đầu tiên
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

             
                if (row.Cells[0].Value != null)
                {
                    txt_mahs.Tag = row.Cells[0].Value.ToString(); // Lưu ID vào Tag

                  
                    txt_mahs.Text = row.Cells["MaHocSinh"].Value?.ToString();
                    txt_diemmieng.Text = row.Cells["DiemMieng"].Value?.ToString();
                   
                }
            }
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
            // Kiểm tra xem đã chọn dòng nào chưa
            if (string.IsNullOrEmpty(txt_mahs.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng điểm trên danh sách để xóa!", "Thông báo");
                return;
            }

            // Xác nhận xóa
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm của học sinh {txt_mahs.Text} không?",
                                                   "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                chucNang = "xoa";
                btn_luu_Click(sender, e); // Gọi sang hàm lưu để thực thi xóa
            }

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
