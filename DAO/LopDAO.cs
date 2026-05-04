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
    public class LopDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet GetClassDAO(string namhoc)
        {
            DataSet ds;
            //Chuỗi truy vấn
            string sSQL = $"select * from LopHoc join NamHoc on LopHoc.MaNamHoc = NamHoc.MaNamHoc where TenNamHoc = '{namhoc}'";
            //Khởi tạo đối tượng
            Database db = new Database();
            ds = db.XemDanhSach1(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Lỗi truy vấn !");
                return null;
            }
            return ds;
        }
        public DataTable LayDS()
        {
            string sql = "SELECT MaLopHoc, TenLop FROM LopHoc";
            Database db = new Database();
            DataSet ds = db.XemDanhSach1(sql); 

            // Kiểm tra null và trả về Table đầu tiên
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        public DataSet LayDanhSachLopTheoGV(int maGV)
        {
            Database db = new Database();
            // Giả sử bảng Lop có cột MaGiaoVien để biết giáo viên nào dạy lớp nào
            string sql = "SELECT MaLop, TenLop, NamHoc FROM Lop WHERE MaGiaoVien = @MaGV";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaGV", SqlDbType.Int);
            sqlParameters[0].Value = maGV;

            return db.XemDanhSach2(sql, sqlParameters);
        }
    }
}
