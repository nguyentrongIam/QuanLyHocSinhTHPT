using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.DTO
{
    public class PhanCongGiangDayDTO
    {
        public string MaGV { get; set; } = string.Empty;
        public string HoTenGV { get; set; } = string.Empty;
        public string MaLop { get; set; } = string.Empty;
        public string TenLop { get; set; } = string.Empty;
        public string MaMon { get; set; } = string.Empty;
        public string TenMon { get; set; } = string.Empty;
        public int HocKy { get; set; }
        public string NamHoc { get; set; } = string.Empty;
    }
}
