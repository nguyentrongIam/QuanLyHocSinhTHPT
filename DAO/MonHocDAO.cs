using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class MonHocDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet HienThiMonHoc()
        {
            //Chuỗi truy vấn SQL
            string sSQL = "select * from MonHoc";
            Database db = new Database();
            DataSet ds = db.XemDanhSach1(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Truy vấn môn học thất bại !");
                return null;
            }
            return ds;
        }
        public DataSet LayMonDayCuaGV(int maGV)
        {
            Database db = new Database();
            // Thay 'PhanCongGiangDay' bằng tên bạn vừa tìm thấy trong SQL
            string sql = @"SELECT DISTINCT mh.MaMonHoc, mh.TenMonHoc 
                   FROM MonHoc mh
                   JOIN PhanCongGiangDay pc ON mh.MaMonHoc = pc.MaMonHoc
                   WHERE pc.MaGiaoVien = @maGV";

            SqlParameter[] p = { new SqlParameter("@maGV", maGV) };
            return db.XemDanhSach2(sql, p);
        }
    }
}
