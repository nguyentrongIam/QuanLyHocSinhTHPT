using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;

namespace QuanLyHocSinhTHPT.BUS
{
    
    public class GiaoVienBUS
    {
        private GiaoVienDAO dao=new GiaoVienDAO();
        public GiaoVienBUS() { }
        public GiaoVienDTO LayThongTin(int id)
        {
            GiaoVienDTO gv = null;
            gv=dao.getGiaoVienByAccountID(id);
            return gv;
        }
    }
}
