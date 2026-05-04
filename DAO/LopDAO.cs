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
            ds = db.XemDanhSach(sSQL);
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
            DataSet ds = db.XemDanhSach(sql); 

            // Kiểm tra null và trả về Table đầu tiên
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}
