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
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class DiemDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinhDB;Integrated Security=True;";
        public DataSet XemDiem(string tenmonhoc,string lophoc,string namhoc,string hocky)
        {
            string sSQL = $"select hs.MaHocSinh,hs.HoTen,d.DiemMieng,d.Diem15Phut_1,d.Diem15Phut_2,d.DiemGiuaKy,d.DiemCuoiKy,mh.TenMonHoc,d.HocKy from Diem d join MonHoc mh on d.MaMonHoc = mh.MaMonHoc join HocSinh hs on d.MaHocSinh = hs.MaHocSinh join PhanLopHocSinh plhs on hs.MaHocSinh=plhs.MaHocSinh join LopHoc on plhs.MaLopHoc= LopHoc.MaLopHoc  where mh.TenMonHoc like N'%{tenmonhoc}%' and d.NamHoc = '{namhoc}' and LopHoc.TenLop like N'{lophoc}' and d.HocKy = {hocky} ";
            DataSet ds;
            Database db = new Database();
            ds = db.XemDanhSach(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Lỗi truy vấn điểm !");
                return null;
            }
            return ds;
        }
        
    }
}
