using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using System.Data;

namespace QuanLyHocSinhTHPT.BUS
{
    
    public class GiaoVienBUS
    {
        private GiaoVienDAO dao=new GiaoVienDAO();
        public GiaoVienBUS() { }
        public GiaoVienDTO LayThongTin(int id)
        {
            GiaoVienDTO gv = null;
            gv=dao.getGiaoVienByAccountID(id);
            return gv;
        }


        public DataSet LayDanhSach(string timKiem="")
        {
            DataSet ds = null;
            return dao.LayDanhSach(timKiem);
        }
        public string ThemGiaoVien(GiaoVienDTO gv)
        {
            //kiem tra chuoi rong
            if (string.IsNullOrWhiteSpace(gv.HoTen) ||
                string.IsNullOrWhiteSpace(gv.GioiTinh) ||
                string.IsNullOrWhiteSpace(gv.DiaChi) ||
                string.IsNullOrWhiteSpace(gv.SoDienThoai) ||
                string.IsNullOrWhiteSpace(gv.Email))
            {
                return "Vui lòng nhập đầy đủ thông tin văn bản";
            }

            //kiem tra ngay sinh
            if (gv.NgaySinh == DateTime.MinValue || gv.NgaySinh == null)
            {
                return "Vui lòng chọn ngày sinh hợp lệ";
            }

            //kiem tra ma tai khoan
            if (gv.MaTaiKhoan <= 0)
            {
                return "Mã tài khoản không hợp lệ";
            }

            GiaoVienDAO dao = new GiaoVienDAO();
            bool ketQua = dao.ThemGiaoVien(gv);
            return ketQua ? "Thành công" : "Thất bại";
        }
    }
}
