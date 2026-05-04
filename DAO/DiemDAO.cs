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
    public class DiemDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet XemDiem(string tenmonhoc, string lophoc, string namhoc, string hocky)
        {
            string sSQL = $@"SELECT ... 
                     WHERE ...
                       AND REPLACE(d.NamHoc, ' ', '') = '{namhoc.Replace(" ", "")}' 
                       AND WHERE lh.TenLop LIKE N'%' + @tenLop + '%'
                       AND d.HocKy = {hocky}
                     ORDER BY hs.MaHocSinh ASC";

            Database db = new Database();
            return db.XemDanhSach1(sSQL);
        }
        public DataTable LayDanhSachChuaCoDiem(string maLop, int maMon, int hocKy, string namHoc)
        {
            string namHocClean = namHoc.Replace(" ", "").Trim();
            Database db = new Database();

            // Dùng LEFT JOIN để tìm học sinh có trong lớp nhưng KHÔNG có dòng điểm tương ứng
            string sSQL = @"SELECT 
                        NULL AS MaDiem, 
                        hs.MaHocSinh, 
                        hs.HoTen, 
                        NULL AS DiemMieng, 
                        NULL AS Diem15Phut_1, 
                        NULL AS Diem15Phut_2, 
                        NULL AS DiemGiuaKy, 
                        NULL AS DiemCuoiKy
                    FROM HocSinh hs
                    INNER JOIN PhanLopHocSinh pl ON hs.MaHocSinh = pl.MaHocSinh
                    LEFT JOIN Diem d ON hs.MaHocSinh = d.MaHocSinh 
                        AND d.MaMonHoc = @MaMon 
                        AND d.HocKy = @HK 
                        AND REPLACE(CAST(d.NamHoc AS NVARCHAR), ' ', '') = @Nam
                    WHERE pl.MaLopHoc = @MaLop 
                      AND d.MaDiem IS NULL"; // Chỉ lấy những người chưa có mã điểm

            SqlParameter[] sqlParams = {
        new SqlParameter("@MaLop", maLop),
        new SqlParameter("@MaMon", maMon),
        new SqlParameter("@HK", hocKy),
        new SqlParameter("@Nam", namHocClean)
    };

            return db.LayDuLieuCoThamSo(sSQL, sqlParams);
        }
        public bool ThemDiem(string maHS, string malop, int maMon, int hk, string nam, float diemMieng, float diem15plan1, float diem15plan2, float gk, float ck)
        {
            string sSQL = @"insert into Diem (MaHocSinh,MaLopHoc,MaMonHoc,HocKy,NamHoc,
                        DiemMieng,Diem15phut_1,Diem15phut_2,DiemGiuaKy,DiemCuoiKy)
                        values(@hs,@lop,@mon,@HK,@nam,@D1,@D2,@D3,@D4,@D5)";
            SqlParameter[] sqlParams =
            {

            };
            Database db = new Database();
            return db.ThucThiCoThamSo(sSQL,
               new SqlParameter("@hs", maHS),
                new SqlParameter("@lop", malop),
                new SqlParameter("@mon", maMon),
                new SqlParameter("@HK", hk),
                new SqlParameter("@nam", nam),
                new SqlParameter("@D1", diemMieng),
                new SqlParameter("@D2", diem15plan1),
                new SqlParameter("@D3", diem15plan2),
                new SqlParameter("@D4", gk),
                new SqlParameter("@D5", ck)
                ) > 0;
        }
        public bool SuaDiem(string maHS, string malop, int maMon, int hk, string nam, float diemMieng, float diem15plan1, float diem15plan2, float gk, float ck)
        {
            string sSQL = @"UPDATE Diem 
                    SET DiemMieng = @D1, 
                        Diem15phut_1 = @D2, 
                        Diem15phut_2 = @D3, 
                        DiemGiuaKy = @D4, 
                        DiemCuoiKy = @D5 
                    WHERE MaHocSinh = @hs 
                      AND MaMonHoc = @mon 
                      AND MaLopHoc = @lop
                      AND HocKy = @HK 
                      AND NamHoc = @nam";
            Database db = new Database();
            return db.ThucThiCoThamSo(sSQL,
               new SqlParameter("@hs", maHS),
                new SqlParameter("@lop", malop),
                new SqlParameter("@mon", maMon),
                new SqlParameter("@HK",hk),
                new SqlParameter("@nam",nam),
                new SqlParameter("@D1", diemMieng),
                new SqlParameter("@D2", diem15plan1),
                new SqlParameter("@D3", diem15plan2),
                new SqlParameter("@D4", gk),
                new SqlParameter("@D5", ck)
                ) > 0;
        }
        public bool XoaDiemDAO(int maDiem)
        {
            try
            {
                // Sử dụng tham số @ma để đảm bảo an toàn và chính xác kiểu int
                string sql = "DELETE FROM Diem WHERE MaDiem = @ma";

                Database db = new Database();
                // Sử dụng hàm ThucThiCoThamSo giống như hàm ThemDiem/SuaDiem bên trên
                int result = db.ThucThiCoThamSo(sql, new SqlParameter("@ma", maDiem));

                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tại DAO: " + ex.Message);
                return false;
            }
        }
        public DataSet LayBangDiemTheoLop(string tenLop, int maMon, int hocky, string namHoc)
        {
            Database db = new Database();
            // Thêm d.MaDiem vào đầu danh sách SELECT
            string sql = @"SELECT d.MaDiem, hs.MaHocSinh, hs.HoTen, 
                          d.DiemMieng, d.Diem15Phut_1, d.Diem15Phut_2, 
                          d.DiemGiuaKy, d.DiemCuoiKy
                   FROM Diem d
                   INNER JOIN HocSinh hs ON d.MaHocSinh = hs.MaHocSinh
                   INNER JOIN LopHoc lh ON d.MaLopHoc = lh.MaLopHoc
                   WHERE lh.TenLop = @tenLop 
                     AND d.MaMonHoc = @maMon 
                     AND d.HocKy = @hocky 
                     AND REPLACE(CAST(d.NamHoc AS NVARCHAR), ' ', '') = @namHoc";

            SqlParameter[] parameters = {
        new SqlParameter("@tenLop", SqlDbType.NVarChar) { Value = tenLop.Trim() },
        new SqlParameter("@maMon", SqlDbType.Int) { Value = maMon },
        new SqlParameter("@hocky", SqlDbType.Int) { Value = hocky },
        new SqlParameter("@namHoc", SqlDbType.NVarChar) { Value = namHoc.Replace(" ", "").Trim() }
    };

            return db.XemDanhSach2(sql, parameters);
        }


    }
}
