using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.BUS
{
    public class NamHocBUS
    {
        public DataSet GetYearBUS()
        {
            DataSet ds;
            NamHocDAO dao = new NamHocDAO();
            ds = dao.GetYear();
            return ds;
        }
    }
}
