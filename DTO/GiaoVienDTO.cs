using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.DTO
{
    public class GiaoVienDTO
    {
        public int MaGiaoVien { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; } // Dấu ? cho phép giá trị null
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public int? MaTaiKhoan { get; set; }
    }
}
