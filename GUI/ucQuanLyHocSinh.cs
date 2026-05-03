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

namespace QuanLyHocSinhTHPT
{
    public partial class ucQuanLyHocSinh : UserControl
    {
        string chucNang = "";
        string hienthi = "";
        public ucQuanLyHocSinh()
        {
            InitializeComponent();
            pnThongTin.Hide();
            
            
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            HienDanhSach();
        }
        public void HienDanhSach()
        {
            
           
            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien();
            gird_danhsach.DataSource = ds.Tables[0];
        }

        private void uc_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            
        }

        private void gird_danhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            HocSinhBUS bus = new HocSinhBUS();
            chucNang = "them";
            pnThongTin.Hide();
            pnThongTin.Show();
            //Vô hiệu hóa textbox mã hs
            txt_mahs.Enabled = false;
            //Resert textbox cũ
            txt_mahs.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_sdt_ph.Clear();
            txt_phuhuynh.Clear();

            //Hiện mã học sinh tiếp theo khi thêm
            txt_mahs.Text = bus.LayMaHocSinhTiepTheo().ToString();



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnThongTin.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            chucNang = "sua";

            pnThongTin.Hide();
            pnThongTin.Show();

            //Ngừng Vô hiệu hóa textbox mã hs
            txt_mahs.Enabled = true;

            //Resert textbox cũ
            txt_mahs.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_sdt_ph.Clear();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int kq;
            if (chucNang=="them")
            {
                //Vô hiệu hóa textbox mã hs
                txt_mahs.Enabled = true;
                HocSinhDTO dto = new HocSinhDTO();
                dto.MaHS = txt_mahs.Text;
                dto.HoTen = txt_hoten.Text;
                dto.NgaySinh = dt_ngaysinh.Value;
                //Kiểm tra giới tính
                if (tog_nam.Checked)
                {
                    dto.GioiTinh = "Nữ";
                }
                else
                {
                    dto.GioiTinh = "Nam";
                }
                dto.DiaChi = txt_diachi.Text;
                dto.TenPH = txt_phuhuynh.Text;
                dto.SDTPH = txt_sdt_ph.Text;
                HocSinhBUS bus = new HocSinhBUS();
                kq = bus.Add_StudentBUS(dto);
                if (kq == 0)
                {
                    MessageBox.Show("Thêm thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm thành công !");
                }


                    MessageBox.Show("Đã ấn nút thêm !");
            }
            if (chucNang == "sua")
            {
                HocSinhDTO dto = new HocSinhDTO();
                //Mã hs bắt buộc nhập
                dto.MaHS = txt_mahs.Text;

                //Cột họ tên not null nên phải kiểm tra
                if (!string.IsNullOrWhiteSpace(txt_hoten.Text))
                {
                    dto.HoTen = txt_hoten.Text;
                }
                else
                {
                    
                   //Giữ nguyên 
                    dto.HoTen = null;
                }
                // Cột có thể NULL (ví dụ: Địa chỉ)
                if (!string.IsNullOrWhiteSpace(txt_diachi.Text))
                    dto.DiaChi = txt_diachi.Text;
                else
                    dto.DiaChi = null;

                // Gọi xuống lớp BUS
                HocSinhBUS bus = new HocSinhBUS();
                if (bus.CapNhatHocSinh(dto))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    // Refresh lại GridView hoặc xóa trắng form nếu cần
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại! (Kiểm tra lại dữ liệu)");
                }

                MessageBox.Show("Đã ấn nút sửa !");

            }
        }

       

        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0)
                {
                    //Lấy hàng vừa click vào
                    DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

                    //Đổ dữ liệu ra textbox
                    txt_mahs.Text = row.Cells[0].Value.ToString();
                    txt_hoten.Text = row.Cells[1].Value.ToString();
                    DateTime ngaysinh = Convert.ToDateTime(row.Cells[2].Value);
                    if (row.Cells[3].Value.ToString() == "Nam")
                    {
                        tog_nam.Checked = false;
                    }
                    else
                    {
                        tog_nam.Checked = true;
                    }
                    txt_diachi.Text = row.Cells[4].Value.ToString();
                    txt_sdt_ph.Text = row.Cells["SDTPhuHuynh"].Value.ToString();
                    txt_phuhuynh.Text = row.Cells["TenPhuHuynh"].Value.ToString();
                }
            }catch(Exception ex)
            {

            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            HocSinhBUS bus = new HocSinhBUS();
            DataSet ds;
            ds = bus.TimKiemHocSinhBUS(txt_timkiem.Text);
            gird_danhsach.DataSource = ds.Tables[0];
        }
    }
}//
