using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.DTO
{
    public class DiemDTO
    {
        public string MaHS { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string MaMon { get; set; } = string.Empty;
        public string TenMon { get; set; } = string.Empty;
        public int HocKy { get; set; }
        public string NamHoc { get; set; } = string.Empty;

        public double DiemMieng { get; set; }
        public double Diem15p { get; set; }
        public double Diem45p { get; set; }
        public double DiemThi { get; set; }
        public double DiemTB { get; set; }

        // Tính tự động điểm trung bình (nếu chưa có)
        public double TinhDiemTB =>
            (DiemMieng + Diem15p * 2 + Diem45p * 2 + DiemThi * 3) / 7;
    }
}
