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
using System.Windows.Forms;
namespace QuanLyHocSinhTHPT.DAO
{
    public class ThoiKhoaBieuDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        Database db = new Database();
        public DataTable LayThoiKhoaBieuHocSinh(int maHS, string namHoc, int hocKy)
        {
            // Cột HocKy thực tế nằm ở bảng PhanLopHocSinh (pl)
            string sql = @"
        SELECT 
            pc.ThuTrongTuan, 
            pc.TietHoc, 
            mh.TenMonHoc, 
            gv.HoTen AS TenGiaoVien
        FROM PhanLopHocSinh pl
        JOIN LopHoc lh ON pl.MaLopHoc = lh.MaLopHoc
        JOIN NamHoc nh ON lh.MaNamHoc = nh.MaNamHoc
        JOIN PhanCongGiangDay pc ON lh.MaLopHoc = pc.MaLopHoc
        JOIN MonHoc mh ON pc.MaMonHoc = mh.MaMonHoc
        JOIN GiaoVien gv ON pc.MaGiaoVien = gv.MaGiaoVien
        WHERE pl.MaHocSinh = @MaHS 
          AND REPLACE(nh.TenNamHoc, ' ', '') = @NamHoc 
          AND pl.HocKy = @HocKy  -- SỬA TẠI ĐÂY: Dùng pl.HocKy thay vì lh hay nh
        ORDER BY pc.ThuTrongTuan, pc.TietHoc";

            SqlParameter[] sqlParams = {
        new SqlParameter("@MaHS", maHS),
        new SqlParameter("@NamHoc", namHoc.Replace(" ", "")),
        new SqlParameter("@HocKy", hocKy)
    };

            return db.LayDuLieuCoThamSo(sql, sqlParams);
        }
    }
    }
