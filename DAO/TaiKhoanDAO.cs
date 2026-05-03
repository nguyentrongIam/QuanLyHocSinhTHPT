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
        private DataProvider db = new DataProvider();
        public TaiKhoanDAO(){}
        public TaiKhoanDTO KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
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

        public int ThemTaiKhoan(TaiKhoanDTO tk)
        {
            // Truy vấn lấy SCOPE_IDENTITY() để trả về mã tự tăng ngay lập tức
            string query = @"
                INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, MaVaiTro)
                VALUES (@Ten, @MK, @TrangThai, @MaVT);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@Ten", tk.TenDangNhap),
                new SqlParameter("@MK", tk.MatKhau),
                new SqlParameter("@TrangThai", tk.TrangThai),
                new SqlParameter("@MaVT", tk.MaVaiTro)
            };

            // Sử dụng LayGiaTri vì chúng ta muốn nhận lại con số ID
            object result = db.LayGiaTri(query, pars);
            return (result != null) ? Convert.ToInt32(result) : -1;
        }

        public bool KhoaTaiKhoan(int maTaiKhoan)
        {
            string query = "UPDATE TaiKhoan SET TrangThai = 0 WHERE MaTaiKhoan = @MaTK";
            SqlParameter[] pars = { new SqlParameter("@MaTK", maTaiKhoan) };

            return db.ThucThi(query, pars);
        }


    }
    
}
