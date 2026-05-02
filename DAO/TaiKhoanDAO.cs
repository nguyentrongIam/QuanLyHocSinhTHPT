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

namespace QuanLyHocSinhTHPT.DAO
{
    public class TaiKhoanDAO{
        public TaiKhoanDAO(){}
        public TaiKhoanDTO KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            Database db = new Database();
            TaiKhoanDTO tk = null;
            string sSQL = $"SELECT * FROM TaiKhoan WHERE TenDangNhap=N'{tenDangNhap}' AND MatKhau=N'{matKhau}'";
            DataSet ds = db.XemDanhSach(sSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                // Đổ dữ liệu từ Database vào DTO
                tk = new TaiKhoanDTO();
                tk.MaTaiKhoan = Convert.ToInt32(row["MaTaiKhoan"]);
                tk.TenDangNhap = row["TenDangNhap"].ToString();
                tk.MatKhau = row["MatKhau"].ToString();
                tk.TrangThai = Convert.ToBoolean(row["TrangThai"]);
                tk.MaVaiTro = Convert.ToInt32(row["MaVaiTro"]);
            }
            return tk;
        }
    }
    
}
