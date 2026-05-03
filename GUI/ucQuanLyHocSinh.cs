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
            cbb_lophoc.SelectedIndex = -1;

        }
        public void HienComBoBoxNamHoc()
        {
            NamHocBUS bus = new NamHocBUS();
            DataSet ds = bus.GetYearBUS();
            cbb_namhoc.DisplayMember = "TenNamHoc";
            cbb_namhoc.ValueMember = "MaNamHoc";
            cbb_namhoc.DataSource = ds.Tables[0];
            cbb_namhoc.SelectedIndex = -1;
        }

        private void uc_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            HienComBoBoxTenLop();
            HienComBoBoxNamHoc();
        }

        private void gird_danhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            chucNang = "them";
            pnThongTin.Hide();
            pnThongTin.Show();
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
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int kq;
            if (chucNang=="them")
            {
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
    }
}//
