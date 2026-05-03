using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHocSinhTHPT.DAO
{
    public class GiaoVienDAO
    {
        public GiaoVienDAO() { }
        private DataProvider _db = new DataProvider();
        public GiaoVienDTO getGiaoVienByAccountID(int id)
        {
            GiaoVienDTO gv = null;
            string sSQL = $"SELECT * FROM GiaoVien WHERE MaTaiKhoan='{id}'";
            Database db = new Database();
            DataSet ds=db.XemDanhSach(sSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                gv = new GiaoVienDTO();
                gv.MaGiaoVien = Convert.ToInt32(row["MaGiaoVien"]);
                gv.HoTen = row["HoTen"].ToString();
                gv.NgaySinh = Convert.ToDateTime(row["NgaySinh"]);
                gv.GioiTinh = row["GioiTinh"].ToString();
                gv.DiaChi = row["DiaChi"].ToString() ;
                gv.SoDienThoai = row["SoDienThoai"].ToString();
                gv.Email=row["Email"].ToString();
            }    
            return gv;
        }

        
        public DataSet LayDanhSach(string timKiem = "")
        {
            if (string.IsNullOrEmpty(timKiem))
            {
                string sSQL = "SELECT * FROM GiaoVien";
                return _db.XemDanhSach(sSQL);
            }
            else
            {
                string sSQL = "SELECT * FROM GiaoVien WHERE HoTen LIKE @HoTen";

                // Tạo mảng Parameter để truyền vào
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HoTen", "%" + timKiem + "%")
                };

                // Truyền cả câu lệnh và Parameter vào hàm xemdanhsach
                return _db.XemDanhSach(sSQL,parameters);
            }
        }

        public bool ThemGiaoVien(GiaoVienDTO gv)
        {
            string sSQL = "INSERT INTO GiaoVien(HoTen,NgaySinh,GioiTinh,DiaChi,SoDienThoai,Email,MaTaiKhoan) " +
            "VALUES (@hoTen,ngaySinh,@gioiTinh,@diaChi,@soDienThoai,@email,@maTaiKhoan)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@hoTen", gv.HoTen),
                new SqlParameter("@ngaySinh", gv.NgaySinh),     
                new SqlParameter("@gioiTinh", gv.GioiTinh),
                new SqlParameter("@diaChi", gv.DiaChi),
                new SqlParameter("@soDienThoai", gv.SoDienThoai),
                new SqlParameter("@email", gv.Email),
                new SqlParameter("@maTaiKhoan", gv.MaTaiKhoan)
            };
            return _db.ThucThi(sSQL, parameters);
        }
    }
}
