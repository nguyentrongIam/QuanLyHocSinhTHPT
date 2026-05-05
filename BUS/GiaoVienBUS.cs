using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DataTable LayDanhSach()
        {
            GiaoVienDAO dao = new GiaoVienDAO();

            // Trả về DataTable để GUI gán vào DataSource của ComboBox
            return dao.LayDS();
        }
        private GiaoVienDAO gvDAO = new GiaoVienDAO();

        // Lấy thông tin giáo viên dựa vào ID tài khoản (dùng khi vừa đăng nhập xong)
        public GiaoVienDTO LayThongTinGiaoVienQuaTaiKhoan(int accountID)
        {
            return gvDAO.getGiaoVienByAccountID(accountID);
        }

        // Lấy danh sách lớp học mà giáo viên đó phụ trách
        public DataSet LayLopHocCuaGiaoVien(int maGV)
        {
            // Có thể thêm logic kiểm tra maGV > 0 ở đây
            return gvDAO.LayLopHocTheoGiaoVien(maGV);
        }

        // Cập nhật thông tin cá nhân của giáo viên
        public bool CapNhatThongTin(GiaoVienDTO gv)
        {
            // Logic nghiệp vụ: Ví dụ không cho phép để trống họ tên
            if (string.IsNullOrEmpty(gv.HoTen))
            {
                return false;
            }
            return gvDAO.SuaGiaoVien(gv);
        }

        // Lấy toàn bộ danh sách giáo viên (cho Admin)
        public DataSet LayTatCaGiaoVien(string query = "")
        {
            return gvDAO.LayDanhSach(query);
        }

        // Kiểm tra xem giáo viên có đang chủ nhiệm hay dạy lớp nào không trước khi xóa
        public bool CoTheXoaGiaoVien(int maGV)
        {
            return !gvDAO.KiemTraPhatSinhDuLieu(maGV);
        }

        public DataSet LayBangDiemTheoLop(string maLop, int maMon, int hocky, string namHoc)
        {
            DiemDAO dao = new DiemDAO();
            // Gọi thẳng sang hàm LayBangDiem mới được tối ưu (truyền -1 để lấy quyền Admin xem tất cả)
            return dao.LayBangDiem(namHoc, hocky, maLop, maMon, -1);
        }
        public int LayMaGVHienTai(int maTK)
        {
            GiaoVienDAO dao = new GiaoVienDAO();
            return dao.LayMaGVTuMaTK(maTK);
        }
    }
}
