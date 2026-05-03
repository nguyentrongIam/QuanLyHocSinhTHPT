using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.GUI;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using System.Data;

namespace QuanLyHocSinhTHPT.BUS
{
    public class MonHocBUS
    {
        public DataSet GetSubJect()
        {
            MonHocDAO dao = new MonHocDAO();
            DataSet ds = dao.HienThiMonHoc();
            return ds;
        }
    }
}
