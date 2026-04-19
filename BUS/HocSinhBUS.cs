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
    public class HocSinhBUS
    {
        public DataSet LayDanhSachTatCaSinhVien()
        {
            DataSet ds;
            HocSinhDAO hsDAO = new HocSinhDAO();
            ds = hsDAO.XemDanhSachHocSinh();
            return ds;
        }
        public int CapNhatDiem(DiemDTO d_dto)
        {
            int kq;
            HocSinhDAO hsDAO = new HocSinhDAO();

            kq = hsDAO.CapNhatDiem(d_dto);
            return kq;
        }
      
    }
}
