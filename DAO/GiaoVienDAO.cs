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
        private DataProvider db = new DataProvider();
        public GiaoVienDTO getGiaoVienByAccountID(int id)
        {
            GiaoVienDTO gv = null;
            string sSQL = $"SELECT * FROM GiaoVien WHERE MaTaiKhoan='{id}'";
            Database db = new Database();
            DataSet ds = db.XemDanhSach1(sSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                gv = new GiaoVienDTO();
                gv.MaGiaoVien = Convert.ToInt32(row["MaGiaoVien"]);
                gv.HoTen = row["HoTen"].ToString();
                gv.NgaySinh = Convert.ToDateTime(row["NgaySinh"]);
                gv.GioiTinh = row["GioiTinh"].ToString();
                gv.DiaChi = row["DiaChi"].ToString();
                gv.SoDienThoai = row["SoDienThoai"].ToString();
                gv.Email = row["Email"].ToString();
            }
            return gv;
        }
        public bool SuaGiaoVien(GiaoVienDTO gv)
        {
            string query = @"
                UPDATE GiaoVien 
                SET HoTen = @HoTen, 
                    NgaySinh = @NgaySinh, 
                    GioiTinh = @GioiTinh, 
                    DiaChi = @DiaChi, 
                    SoDienThoai = @SoDienThoai, 
                    Email = @Email 
                WHERE MaGiaoVien = @MaGiaoVien";

            SqlParameter[] pars = new SqlParameter[]
            {
                new SqlParameter("@MaGiaoVien", gv.MaGiaoVien),
                new SqlParameter("@HoTen", gv.HoTen),
                // Xử lý an toàn cho DateTime? (có thể null)
                new SqlParameter("@NgaySinh", gv.NgaySinh.HasValue ? (object)gv.NgaySinh.Value : DBNull.Value),
                new SqlParameter("@GioiTinh", gv.GioiTinh),
                new SqlParameter("@DiaChi", gv.DiaChi),
                new SqlParameter("@SoDienThoai", gv.SoDienThoai),
                new SqlParameter("@Email", gv.Email)
            };

            return db.ThucThi(query, pars);
        }

        public DataSet LayDanhSach(string timKiem = "")
        {
            if (string.IsNullOrEmpty(timKiem))
            {
                string sSQL = "SELECT * FROM GiaoVien";
                return db.XemDanhSach(sSQL);
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
                return db.XemDanhSach(sSQL, parameters);
            }
        }

        public bool ThemGiaoVien(GiaoVienDTO gv)
        {
            string query = @"
        INSERT INTO GiaoVien (HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, MaTaiKhoan)
        VALUES (@HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @MaTK)";

            SqlParameter[] pars = new SqlParameter[]
            {
        new SqlParameter("@HoTen", gv.HoTen),
        new SqlParameter("@NgaySinh", gv.NgaySinh.HasValue ? (object)gv.NgaySinh.Value : DBNull.Value),
        new SqlParameter("@GioiTinh", gv.GioiTinh),
        new SqlParameter("@DiaChi", gv.DiaChi),
        new SqlParameter("@SDT", gv.SoDienThoai),
        new SqlParameter("@Email", gv.Email),
        new SqlParameter("@MaTK", gv.MaTaiKhoan) // Mã này lấy từ TaiKhoanDAO trả về
            };

            return db.ThucThi(query, pars);
        }

        public int LayMaTaiKhoan(int maGiaoVien)
        {
            string query = "SELECT MaTaiKhoan FROM GiaoVien WHERE MaGiaoVien = @MaGV";
            SqlParameter[] pars = { new SqlParameter("@MaGV", maGiaoVien) };

            object result = db.LayGiaTri(query, pars);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToInt32(result);
            }
            return -1; // Trả về -1 nếu không tìm thấy
        }
        public bool KiemTraPhatSinhDuLieu(int maGiaoVien)
        {
            string query = @"
                SELECT 1 
                WHERE EXISTS (SELECT 1 FROM PhanCongGiangDay WHERE MaGiaoVien = @MaGV)
                   OR EXISTS (SELECT 1 FROM LopHoc WHERE MaGVCN = @MaGV)";

            SqlParameter[] pars = { new SqlParameter("@MaGV", maGiaoVien) };
            return db.KiemTraTonTai(query, pars);
        }


        // 3. Xóa cứng (Dành cho Dữ liệu nhập nhầm chưa có lịch sử)
        public bool XoaCungGiaoVienRac(int maGiaoVien)
        {
            string query = @"
                BEGIN TRY
                    BEGIN TRAN;
                    DECLARE @MaTK INT = (SELECT MaTaiKhoan FROM GiaoVien WHERE MaGiaoVien = @MaGV);
                    
                    DELETE FROM GiaoVien WHERE MaGiaoVien = @MaGV;
                    
                    IF @MaTK IS NOT NULL
                    BEGIN
                        DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTK;
                    END
                    COMMIT TRAN;
                END TRY
                BEGIN CATCH
                    ROLLBACK TRAN;
                    THROW;
                END CATCH";

            SqlParameter[] pars = { new SqlParameter("@MaGV", maGiaoVien) };
            return db.ThucThi(query, pars);
        }
        public DataTable LayDS()
        {
            string sql = "SELECT MaGiaoVien, HoTen FROM GiaoVien";
            DataSet ds = db.XemDanhSach(sql); // Hàm gốc của bạn trả về DataSet

            // Sửa lỗi CS0029: Chuyển từ DataSet sang DataTable
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        // Lấy ra các lớp mà giáo viên này được phân công dạy
        public DataSet LayLopHocTheoGiaoVien(int maGV)
        {
            // Sử dụng đối tượng db (DataProvider) đã khai báo ở đầu Class thay vì tạo mới Database db
            string sql = "SELECT DISTINCT pc.MaLopHoc, l.TenLop FROM PhanCongGiangDay pc " +
                         "JOIN LopHoc l ON pc.MaLopHoc = l.MaLopHoc WHERE pc.MaGiaoVien = @maGV";

            SqlParameter[] parameters = {
        new SqlParameter("@maGV", maGV)
    };

            // SỬA TẠI ĐÂY: Dùng XemDanhSach thay vì ThucThiCoThamSo
            return db.XemDanhSach(sql, parameters);
        }
        public int LayMaGVTuMaTK(int maTK)
        {
            Database db = new Database();
            int maGV = -1; // Giá trị mặc định nếu không tìm thấy

            // Câu lệnh SQL chuẩn theo ảnh database của bạn
            string sql = "SELECT MaGiaoVien FROM GiaoVien WHERE MaTaiKhoan = @MaTK";

            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTK", SqlDbType.Int);
            sqlParameters[0].Value = maTK;

            try
            {
                // Gọi hàm XemDanhSach trả về DataSet
                DataSet ds = db.XemDanhSach2(sql, sqlParameters);

                // Kiểm tra DataSet có dữ liệu không trước khi truy cập
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    object result = ds.Tables[0].Rows[0]["MaGiaoVien"];

                    if (result != null && result != DBNull.Value)
                    {
                        maGV = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Bạn có thể dùng MessageBox.Show(ex.Message) ở đây để debug nhanh nếu muốn
                throw ex;
            }

            return maGV; // QUAN TRỌNG: Phải có dòng này để trả về kết quả
        }
       

    }
    }
