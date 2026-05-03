using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO tkDAO=new TaiKhoanDAO();
        public TaiKhoanBUS() { }
        public string DangNhap(string tenDangNhap,string matKhau,out TaiKhoanDTO taiKhoan)
        {
            taiKhoan = null;
            //Kiem tra thieu thong tin
            if(string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
            {
                return "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!";
            }

            taiKhoan = tkDAO.KiemTraDangNhap(tenDangNhap, matKhau);

            //Kiem tra tai khoan ton tai
            if(taiKhoan==null)
                return "Tên đăng nhập hoặc mật khẩu không chính xác!";
            //Kiem tra tai khoan bi khoa
            if (taiKhoan.TrangThai == false)
                return "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ Admin!";
            //Thanh cong
            return "Thành công";
        }


        //them tai khoan
        public string ThemTaiKhoan(TaiKhoanDTO tk)
        {
            if (string.IsNullOrWhiteSpace(tk.TenDangNhap) || string.IsNullOrWhiteSpace(tk.MatKhau))
            {
                return "Vui lòng nhập đầy đủ thông tin văn bản";
            }
            TaiKhoanDAO dao=new TaiKhoanDAO();
            int ketQua = dao.ThemTaiKhoan(tk);
            return(ketQua > 0) ? "Thành công" : "Thất bại";
        }

    }
}
