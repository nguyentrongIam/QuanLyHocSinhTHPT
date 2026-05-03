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
    public class DiemBUS
    {
        public DataSet XemDiem(string tenmonhoc,string lophoc,string namhoc,string hocky)
        {
            DataSet ds;
            DiemDAO dao = new DiemDAO();
            ds = dao.XemDiem(tenmonhoc, lophoc, namhoc, hocky);
            return ds;
        }
    }
}
