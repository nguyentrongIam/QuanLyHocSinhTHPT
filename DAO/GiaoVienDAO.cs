using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using System.Data;

namespace QuanLyHocSinhTHPT.DAO
{
    public class GiaoVienDAO
    {
        public GiaoVienDAO() { }
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
    }
}
