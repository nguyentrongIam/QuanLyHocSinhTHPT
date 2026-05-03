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
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.DAO
{
    public class TaiKhoanDAO{
        public TaiKhoanDAO(){}
        public TaiKhoanDTO KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            DataProvider db = new DataProvider();
            TaiKhoanDTO tk = null;

            string sSQL = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap AND MatKhau = @matKhau";

            //tao mang tham so
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tenDangNhap", tenDangNhap),
                new SqlParameter("@matKhau", matKhau)
            };

            DataSet ds = db.XemDanhSach(sSQL, parameters);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                //do du lieu vao dto
                tk = new TaiKhoanDTO();
                tk.MaTaiKhoan = Convert.ToInt32(row["MaTaiKhoan"]);
                tk.TenDangNhap = row["TenDangNhap"].ToString();
                tk.MatKhau = row["MatKhau"].ToString();
                tk.TrangThai = Convert.ToBoolean(row["TrangThai"]);
                tk.MaVaiTro = Convert.ToInt32(row["MaVaiTro"]);
            }
            return tk;
        }

        public bool ThemTaiKhoan(TaiKhoanDTO tk)
        {
            DataProvider db = new DataProvider();
            string sSQL = "INSERT INTO TaiKhoan(TenDangNhap,MatKhau,TrangThai,MaVaiTro) VALUES (@tenDangNhap,@matKkhau,1,@maVaiTro)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@hoTen", tk.TenDangNhap),
                new SqlParameter("@ngaySinh", tk.MatKhau),
                new SqlParameter("@gioiTinh", tk.MaVaiTro)
            };
            return db.ThucThi(sSQL, parameters);
        }


    }
    
}
