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
    public class ThoiKhoaBieuBUS
    {
        
        ThoiKhoaBieuDAO dao = new ThoiKhoaBieuDAO();
        public DataTable LayThoiKhoaBieuHocSinhBUS(int maHS, string namHoc, int hocKy)
        {
            return dao.LayThoiKhoaBieuHocSinh(maHS, namHoc, hocKy);
        }
    }
}
