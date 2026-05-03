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
    public partial class ucProfile : UserControl
    {
        private GiaoVienDTO GiaoVien=null;
        public ucProfile()
        {
            InitializeComponent();
        }

        private void ucProfile_Load(object sender, EventArgs e)
        {
            GiaoVienBUS bus=new GiaoVienBUS();
            GiaoVien = bus.LayThongTin(Session.TaiKhoanHienTai.MaTaiKhoan);

            //load pn thong tin chi tiet
            lblMa_GiaTri.Text = GiaoVien.MaGiaoVien.ToString();
            lblTen_GiaTri.Text=GiaoVien.HoTen.ToString();
            lblGioiTinh_GiaTri.Text=GiaoVien.GioiTinh.ToString();
            lblNgaySinh_GiaTri.Text=GiaoVien.NgaySinh.ToString();
            lblDiaChi_GiaTri.Text=GiaoVien.DiaChi.ToString();
            lblSoDienThoai_GiaTri.Text=GiaoVien.SoDienThoai.ToString();
            lblEmail_GiaTri.Text=GiaoVien.Email.ToString();

            //Load pn thong tin tai khoan
            lblMaTaiKhoan_GiaTri.Text=Session.TaiKhoanHienTai.MaTaiKhoan.ToString();
            lblTenDangNhap_GiaTri.Text=Session.TaiKhoanHienTai.TenDangNhap.ToString();
            lblTrangThai_GiaTri.Text = (Session.TaiKhoanHienTai.TrangThai == true) ? "Hoạt động" : "Khoá"; 

        }
    }
}
