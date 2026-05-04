using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;
using System.Data;

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

        public DataSet LayDanhSachTaiKhoan(string timKiem)
        {
            return tkDAO.LayDanhSachTaiKhoan(timKiem);
        }

        // 2. Xử lý Cập nhật
        public string CapNhatTaiKhoan(int maTaiKhoan, string matKhau, int maVaiTro, bool trangThai)
        {
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return "Mật khẩu không được để trống!";
            }

            if (tkDAO.CapNhatTaiKhoan(maTaiKhoan, matKhau, maVaiTro, trangThai))
                return "Thành công";
            else
                return "Cập nhật thất bại. Vui lòng thử lại!";
        }

        // 3. Xử lý Xóa
        public string XoaTaiKhoan(int maTaiKhoan)
        {
            if (tkDAO.XoaTaiKhoan(maTaiKhoan))
                return "Thành công";
            else
                return "Không thể xóa tài khoản này (Tài khoản đang được liên kết với Giáo viên/Học sinh). Lời khuyên: Hãy Khóa tài khoản thay vì xóa!";
        }
    }
}
