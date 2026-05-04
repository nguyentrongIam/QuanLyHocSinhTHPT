using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public DataSet LayMonDayCuaGV(int maGV)
        {
            MonHocDAO dao = new MonHocDAO();

            return dao.LayMonDayCuaGV(maGV);
        }
    }
}
