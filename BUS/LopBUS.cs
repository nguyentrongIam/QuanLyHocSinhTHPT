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
    public class LopBUS
    {
        public DataSet GetClassBUS(string namhoc)
        {
            DataSet ds;
            LopDAO lopDAO = new LopDAO();
            ds = lopDAO.GetClassDAO(namhoc);
            return ds;
        }
        public DataTable LayDanhSach()
        {
            LopDAO dao = new LopDAO();
            // Gọi hàm LayDS từ LopDAO (hàm đã sửa ở bước trước)
            return dao.LayDS();
        }
        public DataSet GetDanhSachLop(int maGV)
        {
            LopDAO dao = new LopDAO();
            return dao.LayDanhSachLopTheoGV(maGV);
        }

        public DataTable LocDanhSachLop(string namHoc, string maGVCN, string tuKhoa)
        {
            LopDAO dao = new LopDAO();

            DataSet ds = dao.LocDanhSachLop(namHoc, maGVCN, tuKhoa);
            return ds.Tables[0];
        }
    }
}
