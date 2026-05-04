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
        public bool SuaDiemBUS(string maHS, string malop, int maMon, int hk, string nam, float m, float p1, float p2, float gk, float ck)
        {
            DiemDAO dao = new DiemDAO();
            return dao.SuaDiem(maHS, malop, maMon, hk, nam, m, p1, p2, gk, ck);
        }
        public bool XoaDiemBUS(int maDiem   )
        {


            DiemDAO dao = new DiemDAO();
            return dao.XoaDiemDAO(maDiem);
        }
        public DataSet LayBangDiemTheoLop(string maLop, int maMon, int hocky, string namHoc)
        {
            DiemDAO dao = new DiemDAO();

            // BUS đóng vai trò trung chuyển, gọi trực tiếp hàm từ DAO
            return dao.LayBangDiemTheoLop(maLop, maMon, hocky, namHoc);
        }
    }
}
