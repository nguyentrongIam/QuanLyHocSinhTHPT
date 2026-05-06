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
            // Đã thêm INNER JOIN với bảng PhanLopHocSinh (pl) 
            // và sửa điều kiện WHERE thành pl.MaLopHoc
            string sql = @"
    SELECT 
        hs.MaHocSinh, 
        hs.HoTen, 
        dd.TrangThai, 
        dd.NgayDiemDanh, 
        dd.GhiChu 
    FROM HocSinh hs
    INNER JOIN PhanLopHocSinh pl ON hs.MaHocSinh = pl.MaHocSinh
    LEFT JOIN DiemDanh dd ON hs.MaHocSinh = dd.MaHocSinh AND dd.NgayDiemDanh = @Ngay
    WHERE pl.MaLopHoc = @MaLop";

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
        public bool CapNhatTrangThaiDiemDanh(int maHS, DateTime ngay, string trangThai, string ghiChu)
        {
            Database db = new Database();

            // SQL sử dụng BEGIN...END để phân đoạn rõ ràng, dễ đọc hơn
            string sql = @"
        DECLARE @MaLop INT;
        -- Tìm mã lớp của học sinh từ bảng phân lớp
        SELECT TOP 1 @MaLop = MaLopHoc FROM PhanLopHocSinh WHERE MaHocSinh = @MaHS;

        IF EXISTS (SELECT 1 FROM DiemDanh WHERE MaHocSinh = @MaHS AND NgayDiemDanh = @Ngay)
        BEGIN
            -- Nếu đã có dữ liệu ngày hôm đó: Cập nhật Trạng thái và Ghi chú
            UPDATE DiemDanh 
            SET TrangThai = @TT, 
                GhiChu = @GC 
            WHERE MaHocSinh = @MaHS AND NgayDiemDanh = @Ngay;
        END
        ELSE
        BEGIN
            -- Nếu chưa có: Thêm mới bản ghi điểm danh đầy đủ các cột
            INSERT INTO DiemDanh (MaHocSinh, MaLopHoc, NgayDiemDanh, TrangThai, GhiChu) 
            VALUES (@MaHS, @MaLop, @Ngay, @TT, @GC);
        END";

            SqlParameter[] p = {
        new SqlParameter("@MaHS", SqlDbType.Int) { Value = maHS },
        new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date },
        new SqlParameter("@TT", SqlDbType.NVarChar) { Value = trangThai },
        new SqlParameter("@GC", SqlDbType.NVarChar) { Value = (object)ghiChu ?? DBNull.Value }
    };

            return db.ThucThiCoThamSo(sql, p) > 0;
        }

    }
}
