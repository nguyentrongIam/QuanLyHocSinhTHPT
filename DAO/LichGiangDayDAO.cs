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
    public class LichGiangDayDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        Database db = new Database();
        public DataSet LayLichDayTheoGiaoVien(int maGV)
        {
            // Truy vấn JOIN các bảng dựa trên schema trong image_e80b12.png
            string sql = @"
                SELECT 
                    lh.TenLop, 
                    mh.TenMonHoc, 
                    pc.ThuTrongTuan, 
                    pc.TietHoc
                FROM PhanCongGiangDay pc
                INNER JOIN LopHoc lh ON pc.MaLopHoc = lh.MaLopHoc
                INNER JOIN MonHoc mh ON pc.MaMonHoc = mh.MaMonHoc
                WHERE pc.MaGiaoVien = @MaGV
                ORDER BY pc.ThuTrongTuan, pc.TietHoc";

            SqlParameter[] p = {
                new SqlParameter("@MaGV", SqlDbType.Int) { Value = maGV }
            };

            return db.XemDanhSach2(sql, p);
        }
    }

}
