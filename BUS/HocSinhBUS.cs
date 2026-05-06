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
        //public int CapNhatDiem(DiemDTO d_dto)
        //{
        //    int kq;
        //    HocSinhDAO hsDAO = new HocSinhDAO();

        //    kq = hsDAO.CapNhatDiem(d_dto);
        //    return kq;
        //}
        public bool CapNhatHocSinh(HocSinhDTO hs)
        {
            HocSinhDAO hsDAO = new HocSinhDAO();
            // 1. Kiểm tra khóa chính (Mã học sinh)
            // Không thể cập nhật nếu không biết cập nhật cho ai
            if (string.IsNullOrEmpty(hs.MaHS))
            {
                return false;
            }

            // 2. Kiểm tra logic cho các cột NOT NULL (như Họ tên)
            // Nếu người dùng gửi dữ liệu Họ tên, nhưng lại là chuỗi rỗng hoặc toàn khoảng trắng
            if (hs.HoTen != null && string.IsNullOrWhiteSpace(hs.HoTen))
            {
                // Thông báo hoặc chặn lại vì Database không cho phép để trống Họ tên
                return false;
            }



            // 4. Nếu mọi thứ hợp lệ, gọi xuống lớp DAO để thực thi
            return hsDAO.UpdateHocSinh(hs);
        }
        public int Add_StudentBUS(HocSinhDTO dto)
        {
            int kq;
            HocSinhDAO dao = new HocSinhDAO();
            kq = dao.ThemHocSinh(dto);
            return kq;
        }
        public int LayMaHocSinhTiepTheo()
        {
            HocSinhDAO dao = new HocSinhDAO();
            int maCuoi = dao.LayMaHSCuoi();
            return maCuoi + 1;


        }
        public DataSet TimKiemHocSinhBUS(string name)
        {
            HocSinhDAO dao = new HocSinhDAO();
            DataSet ds;
            ds = dao.TimKiemHocSinh(name);
            return ds;
        }
        public int LayMaHocSinh(int maTK)
        {
            HocSinhDAO dao = new HocSinhDAO();

            return dao.LayMaHocSinhTuMaTK(maTK);
        }
        public DataTable LayThongTinChiTiet(int maHS)
        {
            HocSinhDAO dao = new HocSinhDAO();

            return dao.LayThongTinChiTiet(maHS);
        }
    }
}
