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
    public class DiemDanhBUS
    {
        private DiemDanhDAO dao = new DiemDanhDAO();

        // Trong file DiemDanhBUS.cs
        public DataSet LayDanhSachDiemDanh(int maLop, DateTime ngay)
        {
            // Gọi xuống DAO
            return dao.LayDanhSachDiemDanh(maLop, ngay);
        }

        public bool CapNhatDiemDanh(int maHS, DateTime ngay, string trangThai, string ghiChu)
        {
            // Ở đây bạn có thể thêm logic kiểm tra nếu muốn, ví dụ:
            // if (ngay > DateTime.Now) return false; // Không cho điểm danh ngày tương lai

            // Gọi xuống DAO để thực thi SQL
            return dao.CapNhatTrangThaiDiemDanh(maHS, ngay, trangThai, ghiChu);
        }
    }
}
