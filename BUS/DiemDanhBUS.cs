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

        public bool CapNhatDiemDanh(int maHS, DateTime ngay, string trangThai)
        {
            // Bạn có thể thêm logic kiểm tra ở đây, ví dụ: 
            // Không cho phép điểm danh các ngày trong tương lai
            if (ngay.Date > DateTime.Now.Date)
            {
                return false;
            }

            // Gọi xuống DAO để thực thi lệnh SQL
            return dao.CapNhatTrangThaiDiemDanh(maHS, ngay, trangThai);
        }
    }
}
