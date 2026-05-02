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
    public class HocSinhDAO
    {
        private string connectionString = "Server=.;Database=QuanLyHocSinh_DB;Integrated Security=True;";
        public DataSet XemDanhSachHocSinh(string tenlop, string namhoc)
        {
            DataSet ds;
            //Chuoi truy van csdl
            string sSQL = $" select hs.MaHocSinh,hs.HoTen,hs.NgaySinh,hs.GioiTinh,hs.DiaChi,lh.TenLop,hs.SDTPhuHuynh from HocSinh hs join PhanLopHocSinh plhs on hs.MaHocSinh = plhs.MaHocSinh join LopHoc lh on plhs.MaLopHoc = lh.MaLopHoc join NamHoc nh on lh.MaNamHoc=nh.MaNamHoc where lh.TenLop = '{tenlop}' and nh.TenNamHoc = '{namhoc}'";

            //Khoi tao doi tuong
            Database db = new Database();

            ds = db.XemDanhSach(sSQL);
            if (ds == null)
            {
                MessageBox.Show("Loi truy van ! ");
                return null;
            }
            return ds;
        }
        public int CapNhatDiem(DiemDTO d_dto)
        {

            int kq = 0;//Gia su kq = 0 that bai
            //Chuoi truy van
            string sSQL = $"update Diem\r\nset DiemMieng={d_dto.DiemMieng},Diem15p = {d_dto.Diem15p}, Diem45p = {d_dto.Diem45p}, DiemThi = {d_dto.DiemThi}\r\nwhere mahs='{d_dto.MaHS}'";
            MessageBox.Show(sSQL);
            //Khoi tao doi tuong
            Database db = new Database();
            kq = db.ThucThi(sSQL);
            if (kq == 0)
            {
                MessageBox.Show("Thuc hien cap nhat khong thanh cong !");
                return 0;
            }
            return kq;
        }
        public bool UpdateHocSinh(HocSinhDTO hs)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 1. Cái khay chứa các cột cần sửa
                List<string> updateQueries = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // 2. Nhặt từng món vào khay nếu người dùng có nhập/sửa (khác null)
                if (hs.HoTen != null)
                {
                    updateQueries.Add("HoTen = @HoTen");
                    cmd.Parameters.AddWithValue("@HoTen", hs.HoTen);
                }
                if (hs.NoiSinh != null)
                {
                    updateQueries.Add("NoiSinh = @NoiSinh");
                    cmd.Parameters.AddWithValue("@NoiSinh", hs.NoiSinh);
                }
                if (hs.DiaChi != null)
                {
                    updateQueries.Add("DiaChi = @DiaChi");
                    cmd.Parameters.AddWithValue("@DiaChi", hs.DiaChi);
                }
                if (hs.GioiTinh != null)
                {
                    updateQueries.Add("GioiTinh = @GioiTinh");
                    cmd.Parameters.AddWithValue("@GioiTinh", hs.GioiTinh);
                }
                if (hs.NgaySinh != null)
                {
                    updateQueries.Add("NgaySinh = @NgaySinh");
                    cmd.Parameters.AddWithValue("@NgaySinh", hs.NgaySinh.Value);
                }
                if (hs.TenPH != null)
                {
                    updateQueries.Add("TenPH = @TenPH");
                    cmd.Parameters.AddWithValue("@TenPH", hs.TenPH);
                }
                if (hs.SDTPH != null)
                {
                    updateQueries.Add("SDTPH = @SDTPH");
                    cmd.Parameters.AddWithValue("@SDTPH", hs.SDTPH);
                }

                // Nếu không có gì để sửa thì thoát luôn
                if (updateQueries.Count == 0) return false;

                // 3. Ghép thành câu lệnh UPDATE hoàn chỉnh
              
                string sql = "UPDATE HocSinh SET " + string.Join(", ", updateQueries) + " WHERE MaHocSinh = @MaHS";
                MessageBox.Show(sql);

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@MaHS", hs.MaHS);

                // 4. Thực thi
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }

        }
    }
}
///
