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
        public DataTable LayDanhSachChuaCoDiemBUS(string maLop, int maMon, int hocKy, string namHoc)
        {
            DiemDAO dao = new DiemDAO();
            return dao.LayDanhSachChuaCoDiem(maLop, maMon, hocKy, namHoc);
        }
        public bool ThemDiemBUS(string maHS, string malop, int maMon, int hk, string nam, float diemMieng, float diem15plan1, float diem15plan2, float gk, float ck)
        {
            DiemDAO dao = new DiemDAO();
            return dao.ThemDiem(maHS, malop, maMon, hk, nam, diemMieng, diem15plan1, diem15plan2, gk, ck);
        }
    }
}
