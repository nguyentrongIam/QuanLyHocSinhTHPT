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
        private string connectionString = "Server=.;Database=QuanLyHocSinhDB;Integrated Security=True;";
        public DataSet XemDiem(string tenmonhoc,string lophoc,string namhoc,string hocky)
        {
            string sSQL = $"select hs.MaHocSinh,hs.HoTen,d.DiemMieng,d.Diem15Phut_1,d.Diem15Phut_2,d.DiemGiuaKy,d.DiemCuoiKy,mh.TenMonHoc,d.HocKy from Diem d join MonHoc mh on d.MaMonHoc = mh.MaMonHoc join HocSinh hs on d.MaHocSinh = hs.MaHocSinh join PhanLopHocSinh plhs on hs.MaHocSinh=plhs.MaHocSinh join LopHoc on plhs.MaLopHoc= LopHoc.MaLopHoc  where mh.TenMonHoc like N'%{tenmonhoc}%' and d.NamHoc = '{namhoc}' and LopHoc.TenLop like N'{lophoc}' and d.HocKy = {hocky} ";
            DataSet ds;
            Database db = new Database();
            ds = db.XemDanhSach(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Lỗi truy vấn điểm !");
                return null;
            }
            return ds;
        }
        public DataTable LayDanhSachChuaCoDiem(string maLop,int maMon,int hocKy,string namHoc )
        {
            string sSQL = @"SELECT 
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
        
    }
}
