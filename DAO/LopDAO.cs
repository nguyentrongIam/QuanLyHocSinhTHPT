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
        Database db = new Database();
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
            Database db = new Database();
           
            DataSet ds = db.XemDanhSach1("SELECT MaLopHoc, TenLop FROM LopHoc");

           
            if (ds == null || ds.Tables.Count == 0)
            {
                
                return null;
            }

            return ds.Tables[0];
        }



        public DataSet LayDanhSachLopTheoGV(int maGV)
        {
            Database db = new Database();
            // Đã đổi MaGiaoVien thành MaGVCN theo đúng Database của bạn
            string sql = "SELECT MaLopHoc, TenLop FROM LopHoc WHERE MaGVCN = @MaGV";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaGV", SqlDbType.Int);
            sqlParameters[0].Value = maGV;

            // Sử dụng XemDanhSach2 để thực thi lệnh có tham số
            return db.XemDanhSach2(sql, sqlParameters);
        }
    }
}
