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
            string tenlop, namhoc;
            tenlop = cbb_lophoc.Text;
            namhoc = cbb_namhoc.Text;
            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien(tenlop, namhoc);
            gird_danhsach.DataSource = ds.Tables[0];
        }
        public void HienComBoBoxNamHoc()
        {
            NamHocBUS bus = new NamHocBUS();
            DataSet ds = bus.GetYearBUS();
            cbb_namhoc.DisplayMember = "TenNamHoc";
            cbb_namhoc.ValueMember = "MaNamHoc";
            cbb_namhoc.DataSource = ds.Tables[0];
        }
        public void HienComBoBoxTenLop()
        {
            
            //Lấy năm học 
            string namhoc = cbb_namhoc.Text;
            LopBUS bus = new LopBUS();  
            DataSet ds = bus.GetClassBUS(namhoc);
            if (ds == null || ds.Tables[0].Rows.Count==0)
            {
                hienthi = "khong";
                cbb_lophoc.DisplayMember = "";
                cbb_lophoc.ValueMember = "";
                cbb_lophoc.DataSource = null;
                cbb_lophoc.Items.Clear();
            }
            else
            {
                hienthi = "co";

                cbb_lophoc.DisplayMember = "TenLop";
                cbb_lophoc.ValueMember = "MaLopHoc";
                cbb_lophoc.DataSource = ds.Tables[0];
            }
                
        }
       

        private void uc_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            HienComBoBoxNamHoc();
            // Mặc định chọn năm đầu tiên nếu có dữ liệu để kích hoạt load lớp
            if (cbb_namhoc.Items.Count > 0)
            {
                cbb_namhoc.SelectedIndex = 0;
                HienComBoBoxTenLop();
            }
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

        private void cbb_lophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbb_namhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienComBoBoxTenLop();
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
    }
}//
