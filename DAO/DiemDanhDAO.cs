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
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.DAO
{
    public class DiemDanhDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        Database db = new Database();
        public DataSet LayDanhSachDiemDanh(int maLop, DateTime ngay)
        {
            Database db = new Database();
            // Sử dụng ISNULL để nếu dd.NgayDiemDanh bị NULL thì sẽ lấy giá trị @Ngay truyền vào
            string sql = @"SELECT hs.MaHocSinh, hs.HoTen, 
                          ISNULL(dd.TrangThai, 0) as TrangThai, 
                          ISNULL(dd.NgayDiemDanh, @Ngay) as NgayDiemDanh 
                   FROM HocSinh hs 
                   INNER JOIN PhanLopHocSinh plhs ON hs.MaHocSinh = plhs.MaHocSinh
                   LEFT JOIN DiemDanh dd ON hs.MaHocSinh = dd.MaHocSinh AND dd.NgayDiemDanh = @Ngay
                   WHERE plhs.MaLopHoc = @MaLop";

            SqlParameter[] p = {
        new SqlParameter("@MaLop", SqlDbType.Int) { Value = maLop },
        new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date }
    };

            return db.XemDanhSach2(sql, p);
        }

        public bool LuuDiemDanh(int maHocSinh, int maLopHoc, DateTime ngayDiemDanh, string trangThai, string ghiChu)
        {
            string sSQL = @"
            IF EXISTS (SELECT 1 FROM DiemDanh WHERE MaHocSinh = @MaHocSinh AND NgayDiemDanh = @NgayDiemDanh AND MaLopHoc = @MaLopHoc)
            BEGIN
                UPDATE DiemDanh 
                SET TrangThai = @TrangThai, GhiChu = @GhiChu 
                WHERE MaHocSinh = @MaHocSinh AND NgayDiemDanh = @NgayDiemDanh AND MaLopHoc = @MaLopHoc
            END
            ELSE
            BEGIN
                INSERT INTO DiemDanh (NgayDiemDanh, TrangThai, GhiChu, MaHocSinh, MaLopHoc) 
                VALUES (@NgayDiemDanh, @TrangThai, @GhiChu, @MaHocSinh, @MaLopHoc)
            END";

            SqlParameter[] parameters = {
            new SqlParameter("@MaHocSinh", maHocSinh),
            new SqlParameter("@MaLopHoc", maLopHoc),
            new SqlParameter("@NgayDiemDanh", ngayDiemDanh.Date),
            new SqlParameter("@TrangThai", trangThai),
            new SqlParameter("@GhiChu", ghiChu)
        };

            return db.ThucThiCoThamSo(sSQL, parameters) > 0;
        }
        public bool CapNhatTrangThaiDiemDanh(int maHS, DateTime ngay, string trangThai)
        {
            Database db = new Database();

            // SỬA TẠI ĐÂY: Lấy MaLopHoc từ bảng PhanLopHocSinh
            string sql = @"
        DECLARE @MaLop INT;
        SELECT TOP 1 @MaLop = MaLopHoc FROM PhanLopHocSinh WHERE MaHocSinh = @MaHS;

        IF EXISTS (SELECT * FROM DiemDanh WHERE MaHocSinh = @MaHS AND NgayDiemDanh = @Ngay)
            UPDATE DiemDanh SET TrangThai = @TT WHERE MaHocSinh = @MaHS AND NgayDiemDanh = @Ngay
        ELSE
            INSERT INTO DiemDanh (MaHocSinh, MaLopHoc, NgayDiemDanh, TrangThai) 
            VALUES (@MaHS, @MaLop, @Ngay, @TT)";

            SqlParameter[] p = {
        new SqlParameter("@MaHS", SqlDbType.Int) { Value = maHS },
        new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date },
        new SqlParameter("@TT", SqlDbType.NVarChar) { Value = trangThai }
    };

            return db.ThucThiCoThamSo(sql, p) > 0;
        }

    }
}
