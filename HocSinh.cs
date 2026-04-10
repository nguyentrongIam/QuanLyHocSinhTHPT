using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT
{
    public class HocSinh
    {
        public string maHocSinh {  get; set; }
        public string tenHocSinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public string maLop { set; get; }
        public HocSinh() { }

    }
}
