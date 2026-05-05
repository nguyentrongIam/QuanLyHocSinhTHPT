using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyHocSinhTHPT.DTO;

namespace QuanLyHocSinhTHPT.DAO
{
    public class DiemDAO
    {
        private Database db = new Database();

        public DataSet LayBangDiem(string namHoc, int hocKy, string maLop, int maMon, int maGV)
        {
            string sql = @"SELECT d.MaDiem, hs.MaHocSinh, hs.HoTen, 
                                  d.DiemMieng, d.Diem15Phut_1, d.Diem15Phut_2, 
                                  d.DiemGiuaKy, d.DiemCuoiKy
                           FROM Diem d
                           INNER JOIN HocSinh hs ON d.MaHocSinh = hs.MaHocSinh
                           INNER JOIN LopHoc lh ON d.MaLopHoc = lh.MaLopHoc
                           WHERE 1=1 ";

            // Xử lý lọc động (bỏ qua điều kiện nếu chọn "Tất cả")
            if (namHoc != "--- Tất cả ---" && !string.IsNullOrEmpty(namHoc))
                sql += " AND REPLACE(d.NamHoc, ' ', '') = @NamHoc ";
            if (hocKy > 0)
                sql += " AND d.HocKy = @HK ";
            if (maLop != "--- Tất cả ---" && !string.IsNullOrEmpty(maLop))
                sql += " AND lh.MaLopHoc = @MaLop ";
            if (maMon > 0)
                sql += " AND d.MaMonHoc = @MaMon ";

            // Phân quyền: Nếu maGV != -1 (là giáo viên), chỉ xem lớp dạy hoặc chủ nhiệm
            if (maGV != -1)
            {
                sql += @" AND (lh.MaLopHoc IN (SELECT MaLopHoc FROM PhanCongGiangDay WHERE MaGiaoVien = @MaGV)
                               OR lh.MaGVCN = @MaGV)";
            }

            SqlParameter[] pars = {
                new SqlParameter("@NamHoc", namHoc.Replace(" ", "")),
                new SqlParameter("@HK", hocKy),
                new SqlParameter("@MaLop", maLop),
                new SqlParameter("@MaMon", maMon),
                new SqlParameter("@MaGV", maGV)
            };

            return db.XemDanhSach2(sql, pars);
        }

        public DataTable LayDanhSachChuaCoDiem(string maLop, int maMon, int hk, string nam)
        {
            string sql = @"SELECT hs.MaHocSinh, hs.HoTen 
                           FROM HocSinh hs
                           JOIN PhanLopHocSinh pl ON hs.MaHocSinh = pl.MaHocSinh
                           WHERE pl.MaLopHoc = @MaLop
                           AND hs.MaHocSinh NOT IN (
                               SELECT MaHocSinh FROM Diem 
                               WHERE MaMonHoc = @MaMon AND HocKy = @HK AND REPLACE(NamHoc,' ','') = @Nam
                           )";
            SqlParameter[] pars = {
                new SqlParameter("@MaLop", maLop),
                new SqlParameter("@MaMon", maMon),
                new SqlParameter("@HK", hk),
                new SqlParameter("@Nam", nam.Replace(" ",""))
            };
            DataSet ds = db.XemDanhSach2(sql, pars);
            if (ds != null && ds.Tables.Count > 0) return ds.Tables[0];
            return null;
        }

        public bool ThemDiem(DiemDTO d)
        {
            string sql = @"INSERT INTO Diem (MaHocSinh, MaLopHoc, MaMonHoc, HocKy, NamHoc, DiemMieng, Diem15Phut_1, Diem15Phut_2, DiemGiuaKy, DiemCuoiKy) 
                           VALUES (@hs, @lop, @mon, @hk, @nam, @m, @p1, @p2, @gk, @ck)";
            SqlParameter[] pars = {
                new SqlParameter("@hs", d.MaHocSinh), new SqlParameter("@lop", d.MaLopHoc),
                new SqlParameter("@mon", d.MaMonHoc), new SqlParameter("@hk", d.HocKy),
                new SqlParameter("@nam", d.NamHoc), new SqlParameter("@m", d.DiemMieng),
                new SqlParameter("@p1", d.Diem15p_1), new SqlParameter("@p2", d.Diem15p_2),
                new SqlParameter("@gk", d.DiemGiuaKy), new SqlParameter("@ck", d.DiemCuoiKy)
            };
            return db.ThucThiCoThamSo(sql, pars) > 0;
        }

        public bool SuaDiem(DiemDTO d)
        {
            string sql = @"UPDATE Diem SET DiemMieng=@m, Diem15Phut_1=@p1, Diem15Phut_2=@p2, DiemGiuaKy=@gk, DiemCuoiKy=@ck 
                           WHERE MaHocSinh=@hs AND MaMonHoc=@mon AND HocKy=@hk AND REPLACE(NamHoc,' ','')=@nam";
            SqlParameter[] pars = {
                new SqlParameter("@m", d.DiemMieng), new SqlParameter("@p1", d.Diem15p_1),
                new SqlParameter("@p2", d.Diem15p_2), new SqlParameter("@gk", d.DiemGiuaKy),
                new SqlParameter("@ck", d.DiemCuoiKy), new SqlParameter("@hs", d.MaHocSinh),
                new SqlParameter("@mon", d.MaMonHoc), new SqlParameter("@hk", d.HocKy),
                new SqlParameter("@nam", d.NamHoc.Replace(" ",""))
            };
            return db.ThucThiCoThamSo(sql, pars) > 0;
        }

        public bool XoaDiem(int maDiem)
        {
            string sql = "DELETE FROM Diem WHERE MaDiem = @ma";
            SqlParameter[] pars = { new SqlParameter("@ma", maDiem) };
            return db.ThucThiCoThamSo(sql, pars) > 0;
        }
    }
}