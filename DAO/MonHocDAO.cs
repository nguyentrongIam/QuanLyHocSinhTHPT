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
    public class MonHocDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet HienThiMonHoc()
        {
            //Chuỗi truy vấn SQL
            string sSQL = "select * from MonHoc";
            Database db = new Database();
            DataSet ds = db.XemDanhSach(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Truy vấn môn học thất bại !");
                return null;
            }
            return ds;
        }
    }
}
