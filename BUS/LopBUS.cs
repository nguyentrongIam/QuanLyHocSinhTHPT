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

namespace QuanLyHocSinhTHPT.BUS
{
    public class LopBUS
    {
        public DataSet GetClassBUS()
        {
            DataSet ds;
            LopDAO lopDAO = new LopDAO();
            ds = lopDAO.GetClassDAO();
            return ds;
        }
    }
}
