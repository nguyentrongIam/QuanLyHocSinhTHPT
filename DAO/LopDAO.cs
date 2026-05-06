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
        // Trong file LopHocDAO.cs
        public DataSet LocDanhSachLop(string namHoc, string maGVCN, string tuKhoa)
        {
            // Câu lệnh SQL cơ bản (Join để lấy tên thay vì mã)
            string sql = @"SELECT lh.MaLopHoc, lh.TenLop, nh.TenNamHoc, gv.HoTen AS GVCN
                   FROM LopHoc lh
                   JOIN NamHoc nh ON lh.MaNamHoc = nh.MaNamHoc
                   JOIN GiaoVien gv ON lh.MaGVCN = gv.MaGiaoVien
                   WHERE 1=1 "; // 1=1 để dễ dàng nối thêm AND

            List<SqlParameter> listParams = new List<SqlParameter>();

            // Lọc theo Năm học
            if (!string.IsNullOrEmpty(namHoc))
            {
                sql += " AND lh.MaNamHoc = @MaNamHoc";
                listParams.Add(new SqlParameter("@MaNamHoc", namHoc));
            }

            // Lọc theo Giáo viên chủ nhiệm
            if (!string.IsNullOrEmpty(maGVCN))
            {
                sql += " AND lh.MaGVCN = @MaGVCN";
                listParams.Add(new SqlParameter("@MaGVCN", maGVCN));
            }

            // Lọc theo từ khóa tìm kiếm (Tên lớp)
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                sql += " AND lh.TenLop LIKE @TuKhoa";
                listParams.Add(new SqlParameter("@TuKhoa", "%" + tuKhoa + "%"));
            }

            DataProvider db = new DataProvider();
            return db.XemDanhSach(sql, listParams.ToArray());
        }
    }
}
