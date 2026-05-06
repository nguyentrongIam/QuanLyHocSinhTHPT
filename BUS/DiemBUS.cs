using System;
using System.Data;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.DTO;

namespace QuanLyHocSinhTHPT.BUS
{
    public class DiemBUS
    {
        private DiemDAO dao = new DiemDAO();

        public DataSet LayBangDiem(string namHoc, int hocKy, string maLop, int maMon, int maGV)
        {
            return dao.LayBangDiem(namHoc, hocKy, maLop, maMon, maGV);
        }

        public DataTable LayDanhSachChuaCoDiemBUS(string maLop, int maMon, int hocKy, string namHoc)
        {
            return dao.LayDanhSachChuaCoDiem(maLop, maMon, hocKy, namHoc);
        }

        public string LuuDiem(DiemDTO d, bool isUpdate)
        {
            // Kiểm tra ràng buộc điểm số (0 - 10)
            if (!KiemTraDiem(d.DiemMieng) || !KiemTraDiem(d.Diem15p_1) || !KiemTraDiem(d.Diem15p_2) ||
                !KiemTraDiem(d.DiemGiuaKy) || !KiemTraDiem(d.DiemCuoiKy))
            {
                return "Điểm số nhập vào phải nằm trong khoảng từ 0 đến 10!";
            }

            bool kq = isUpdate ? dao.SuaDiem(d) : dao.ThemDiem(d);
            return kq ? "Thành công" : "Lỗi: Không thể lưu vào CSDL. Kiểm tra lại dữ liệu học sinh/lớp!";
        }

        public bool XoaDiemBUS(int maDiem)
        {
            return dao.XoaDiem(maDiem);
        }

        private bool KiemTraDiem(double diem)
        {
            return diem >= 0 && diem <= 10;
        }
        public DataTable LayBangDiemHocSinhBUS(int maHS, string hocKy, string namHoc)
        {
            return dao.LayBangDiemHocSinh(maHS, hocKy, namHoc);
        }

        public DataTable LayDanhSachNamHoc(int maHS)
        {
            return dao.LayDanhSachNamHoc(maHS);
        }   
    }


}