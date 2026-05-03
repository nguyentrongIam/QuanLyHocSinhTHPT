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
            string sSQL = $@"SELECT d.MaDiem, hs.MaHocSinh, hs.HoTen, d.DiemMieng, d.Diem15Phut_1, 
                            d.Diem15Phut_2, d.DiemGiuaKy, d.DiemCuoiKy, 
                            mh.TenMonHoc, d.HocKy 
                     FROM Diem d 
                     JOIN MonHoc mh ON d.MaMonHoc = mh.MaMonHoc 
                     JOIN HocSinh hs ON d.MaHocSinh = hs.MaHocSinh 
                     JOIN LopHoc lh ON d.MaLopHoc = lh.MaLopHoc 
                     WHERE mh.TenMonHoc LIKE N'%{tenmonhoc}%' 
                       AND d.NamHoc = '{namhoc}' 
                       AND lh.TenLop LIKE N'{lophoc}' 
                       AND d.HocKy = {hocky}
                     ORDER BY hs.MaHocSinh ASC"; // Thêm dòng này để sắp xếp tăng dần

            Database db = new Database();
            return db.XemDanhSach(sSQL);
        }
        public DataTable LayDanhSachChuaCoDiem(string maLop,int maMon,int hocKy,string namHoc )
        {
            string sSQL = @"SELECT 
                        NULL AS MaDiem, 
                        hs.MaHocSinh, 
                        hs.HoTen, 
                        d.DiemMieng, 
                        d.Diem15Phut_1, 
                        d.Diem15Phut_2, 
                        d.DiemGiuaKy, 
                        d.DiemCuoiKy
                    FROM HocSinh hs
                    JOIN PhanLopHocSinh pl ON hs.MaHocSinh = pl.MaHocSinh
                    LEFT JOIN Diem d ON hs.MaHocSinh = d.MaHocSinh 
                        AND d.MaMonHoc = @MaMon 
                        AND d.HocKy = @HK 
                        AND d.NamHoc = @Nam
                    WHERE pl.MaLopHoc = @MaLop 
                      AND d.MaDiem IS NULL";

            SqlParameter[] sqlParams = {
                new SqlParameter("@MaLop", maLop),
                new SqlParameter("@MaMon", maMon),
                new SqlParameter("@HK", hocKy),
                new SqlParameter("@Nam", namHoc)
            };
            Database db = new Database();
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


    }
}
