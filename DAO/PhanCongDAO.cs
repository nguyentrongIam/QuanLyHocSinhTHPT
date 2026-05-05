using QuanLyHocSinhTHPT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.DAO
{
    public class PhanCongDAO
    {
        private DataProvider db = new DataProvider();
        private Database _db = new Database();

        // Lấy danh sách phân công (có JOIN để lấy tên hiển thị trên GUI)
        public DataTable LayDanhSachPhanCong()
        {
            // Bạn phải SELECT cả MaLopHoc, MaMonHoc, MaGiaoVien
            string sql = "SELECT PC.MaPhanCong, PC.MaLopHoc, L.TenLop, PC.MaMonHoc, M.TenMonHoc, " +
                         "PC.MaGiaoVien, GV.HoTen, PC.ThuTrongTuan, PC.TietHoc " +
                         "FROM PhanCongGiangDay PC " +
                         "JOIN LopHoc L ON PC.MaLopHoc = L.MaLopHoc " +
                         "JOIN MonHoc M ON PC.MaMonHoc = M.MaMonHoc " +
                         "JOIN GiaoVien GV ON PC.MaGiaoVien = GV.MaGiaoVien";

            DataSet ds = _db.XemDanhSach1(sql);
            return ds.Tables[0];
}

        // Thêm phân công mới
        public bool ThemPhanCong(int maLop, int maMon, int maGV, int thu, int tiet)
        {
            string sql = "INSERT INTO PhanCongGiangDay (MaLopHoc, MaMonHoc, MaGiaoVien, ThuTrongTuan, TietHoc) " +
                         "VALUES (@maLop, @maMon, @maGV, @thu, @tiet)";

            SqlParameter[] sqlParams = {
                new SqlParameter("@maLop", maLop),
                new SqlParameter("@maMon", maMon),
                new SqlParameter("@maGV", maGV),
                new SqlParameter("@thu", thu),
                new SqlParameter("@tiet", tiet)
            };

            return _db.ThucThiCoThamSo(sql, sqlParams) > 0;
        }

        // Cập nhật phân công
        public bool SuaPhanCong(int maPC, int maLop, int maMon, int maGV, int thu, int tiet)
        {
            string sql = "UPDATE PhanCongGiangDay SET MaLopHoc = @maLop, MaMonHoc = @maMon, " +
                         "MaGiaoVien = @maGV, ThuTrongTuan = @thu, TietHoc = @tiet WHERE MaPhanCong = @maPC";

            SqlParameter[] sqlParams = {
                new SqlParameter("@maPC", maPC),
                new SqlParameter("@maLop", maLop),
                new SqlParameter("@maMon", maMon),
                new SqlParameter("@maGV", maGV),
                new SqlParameter("@thu", thu),
                new SqlParameter("@tiet", tiet)
            };

            return _db.ThucThiCoThamSo(sql, sqlParams) > 0;
        }

        // Xóa phân công
        public bool XoaPhanCong(int maPC)
        {
            string sql = "DELETE FROM PhanCongGiangDay WHERE MaPhanCong = @maPC";

            SqlParameter[] sqlParams = {
                new SqlParameter("@maPC", maPC)
            };

            return _db.ThucThiCoThamSo(sql, sqlParams) > 0;
        }

        // Kiểm tra giáo viên có bị trùng lịch dạy không
        public bool KiemTraTrungLich(int maGV, int thu, int tiet)
        {
            // Sử dụng phương thức KiemTraTonTai có sẵn trong class Database của bạn
            // Lưu ý: LayGiaTri trong class Database của bạn chưa hỗ trợ tham số trực tiếp, 
            // nên ta dùng chuỗi SQL cơ bản hoặc bạn có thể bổ sung LayGiaTriCoThamSo.

            string sql = string.Format("SELECT COUNT(*) FROM PhanCongGiangDay WHERE MaGiaoVien = {0} AND ThuTrongTuan = {1} AND TietHoc = {2}",
                                        maGV, thu, tiet);

            return db.KiemTraTonTai(sql);
        }


        //Xem lich giang day
        public int LayMaGiaoVienTuTaiKhoan(int maTaiKhoan)
        {
            string sql = "SELECT MaGiaoVien FROM GiaoVien WHERE MaTaiKhoan = @maTaiKhoan";
            SqlParameter[] param = { new SqlParameter("@maTaiKhoan", maTaiKhoan) };

            object kq = db.LayGiaTri(sql, param);
            if (kq != null && kq != DBNull.Value)
            {
                return Convert.ToInt32(kq);
            }
            return -1; // Không tìm thấy
        }

        // --- ĐỔI SANG DATASET ---

        public DataSet LayDanhSachThu(int maGV)
        {
            string sql = "SELECT DISTINCT ThuTrongTuan FROM PhanCongGiangDay WHERE MaGiaoVien = @maGV ORDER BY ThuTrongTuan ASC";
            SqlParameter[] param = { new SqlParameter("@maGV", maGV) };
            return db.XemDanhSach(sql, param);
        }

        public DataSet LayDanhSachLop(int maGV)
        {
            string sql = "SELECT DISTINCT PC.MaLopHoc, L.TenLop FROM PhanCongGiangDay PC JOIN LopHoc L ON PC.MaLopHoc = L.MaLopHoc WHERE PC.MaGiaoVien = @maGV";
            SqlParameter[] param = { new SqlParameter("@maGV", maGV) };
            return db.XemDanhSach(sql, param);
        }

        public DataSet LayDanhSachMon(int maGV)
        {
            string sql = "SELECT DISTINCT PC.MaMonHoc, M.TenMonHoc FROM PhanCongGiangDay PC JOIN MonHoc M ON PC.MaMonHoc = M.MaMonHoc WHERE PC.MaGiaoVien = @maGV";
            SqlParameter[] param = { new SqlParameter("@maGV", maGV) };
            return db.XemDanhSach(sql, param);
        }

        public DataSet LayDanhSachTheoDieuKien(PhanCongGiangDayDTO dk)
        {
            string sql = @"SELECT L.TenLop, M.TenMonHoc, PC.ThuTrongTuan, PC.TietHoc, GV.HoTen, PC.MaPhanCong 
                           FROM PhanCongGiangDay PC 
                           JOIN LopHoc L ON PC.MaLopHoc = L.MaLopHoc 
                           JOIN MonHoc M ON PC.MaMonHoc = M.MaMonHoc 
                           JOIN GiaoVien GV ON PC.MaGiaoVien = GV.MaGiaoVien
                           WHERE PC.ThuTrongTuan = @thu 
                             AND PC.MaLopHoc = @maLop 
                             AND PC.MaMonHoc = @maMon 
                             AND PC.MaGiaoVien = @maGV";

            SqlParameter[] sqlParams = {
                new SqlParameter("@thu", dk.ThuTrongTuan),
                new SqlParameter("@maLop", dk.MaLop),
                new SqlParameter("@maMon", dk.MaMon),
                new SqlParameter("@maGV", dk.MaGV)
            };

            return db.XemDanhSach(sql, sqlParams);
        }

    }
}
