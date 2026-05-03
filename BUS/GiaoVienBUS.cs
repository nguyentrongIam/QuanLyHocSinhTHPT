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
        private GiaoVienDAO gvDao=new GiaoVienDAO();
        private TaiKhoanDAO tkDAO = new TaiKhoanDAO();
        public GiaoVienBUS() { }
        public GiaoVienDTO LayThongTin(int id)
        {
            GiaoVienDTO gv = null;
            gv=gvDao.getGiaoVienByAccountID(id);
            return gv;
        }


        public DataSet LayDanhSach(string timKiem="")
        {
            DataSet ds = null;
            return gvDao.LayDanhSach(timKiem);
        }
        public bool ThemGiaoVienMoi(GiaoVienDTO gv)
        {
            // 1. Tạo DTO Tài khoản từ thông tin Email của giáo viên
            string tenDangNhap = "gv_" + gv.Email.Split('@')[0];
            TaiKhoanDTO tk = new TaiKhoanDTO
            {
                TenDangNhap = tenDangNhap,
                MatKhau = "123456",
                TrangThai = true,
                MaVaiTro = 2
            };

            // 2. Gọi TaiKhoanDAO để tạo tài khoản và lấy MaTaiKhoan về
            int maTKMoi = tkDAO.ThemTaiKhoan(tk);

            if (maTKMoi > 0)
            {
                // 3. Gán mã tài khoản vừa tạo vào đối tượng giáo viên
                gv.MaTaiKhoan = maTKMoi;

                // 4. Gọi GiaoVienDAO để lưu thông tin giáo viên
                return gvDao.ThemGiaoVien(gv);
            }

            return false;
        }

        public bool KiemTraLichSu(int maGV) => gvDao.KiemTraPhatSinhDuLieu(maGV);
        public bool XoaVinhVien(int maGV) => gvDao.XoaCungGiaoVienRac(maGV);
        public bool KhoaGiaoVien(int maGV)
        {
            // Bước 1: Hỏi GiaoVienDAO xem mã tài khoản của ông này là gì?
            int maTK = gvDao.LayMaTaiKhoan(maGV);

            if (maTK > 0)
            {
                // Bước 2: Nhờ TaiKhoanDAO khóa cái mã tài khoản đó lại
                return tkDAO.KhoaTaiKhoan(maTK);
            }

            return false;
        }
        public bool CapNhatGiaoVien(GiaoVienDTO gv)
        {
            return gvDao.SuaGiaoVien(gv);
        }
    }
}
