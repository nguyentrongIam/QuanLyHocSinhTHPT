using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class NamHocDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet GetYear()
        {
            DataSet ds;
            //Chuỗi truy vấn
            string sSQL = "select * from NamHoc";
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
    }
}
