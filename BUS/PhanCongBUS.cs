using QuanLyHocSinhTHPT.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.BUS
{
    public class PhanCongBUS
    {
        private PhanCongDAO pcDAO = new PhanCongDAO();

        public DataTable LayDanhSach()
        {
            return pcDAO.LayDanhSachPhanCong();
        }

        public bool Them(int maLop, int maMon, int maGV, int thu, int tiet)
        {
            // Logic: Kiểm tra giáo viên có bị trùng giờ dạy không
            if (pcDAO.KiemTraTrungLich(maGV, thu, tiet))
            {
                MessageBox.Show("Giáo viên này đã có lịch dạy vào Thứ " + thu + " tiết " + tiet + "!", "Thông báo");
                return false;
            }
            return pcDAO.ThemPhanCong(maLop, maMon, maGV, thu, tiet);
        }

        public bool Sua(int maPC, int maLop, int maMon, int maGV, int thu, int tiet)
        {
            // Lưu ý: Khi sửa, cần logic phức tạp hơn để tránh kiểm tra trùng với chính nó.
            // Ở đây mình làm đơn giản là gọi trực tiếp DAO.
            return pcDAO.SuaPhanCong(maPC, maLop, maMon, maGV, thu, tiet);
        }

        public bool Xoa(int maPC)
        {
            return pcDAO.XoaPhanCong(maPC);
        }
     
    }
}
