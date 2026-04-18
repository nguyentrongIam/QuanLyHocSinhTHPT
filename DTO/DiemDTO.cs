using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.DTO
{
    internal class DiemDTO
    {
        public string MaHS { get; set; } = string.Empty;
        public string HoTenHS { get; set; } = string.Empty;     // Thêm để hiển thị
        public string MaMon { get; set; } = string.Empty;
        public string TenMon { get; set; } = string.Empty;      // Thêm để hiển thị
        public int HocKy { get; set; }
        public string NamHoc { get; set; } = string.Empty;
        public double DiemMieng { get; set; }
        public double Diem15p { get; set; }
        public double Diem45p { get; set; }
        public double DiemThi { get; set; }

        public double DiemTB => (DiemMieng + Diem15p * 2 + Diem45p * 2 + DiemThi * 3) / 7; // Điểm trung bình môn
    }
}
