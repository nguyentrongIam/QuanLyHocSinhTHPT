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
        public int MaDiem { get; set; } 
        public int MaHocSinh  { get; set; }
        public int MaLopHoc  { get; set; }
        public int MaMonHoc  { get; set; }

        public int HocKy { get; set; }
        public string NamHoc { get; set; } = string.Empty;

        public double DiemMieng { get; set; }
        public double Diem15p_1 { get; set; }
        public double Diem15p_2 { get; set; }
        public double DiemGiuaKy { get; set; }
        public double DiemCuoiKy { get; set; }
       

       
    }
}
