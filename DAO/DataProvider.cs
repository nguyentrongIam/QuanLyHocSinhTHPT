using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT.DAO
{
    public class DataProvider
    {
        public string sCon = "Data Source=.; Initial Catalog=QuanLyHocSinh_DB;Integrated Security=True";

        public DataProvider() { }

        // Lấy DataSet (dùng cho SELECT)
        public DataSet XemDanhSach(string query, SqlParameter[] parameters = null)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(sCon))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    // Thêm tham số vào Command nếu có
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        myConnection.Open();
                        sda.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return ds;
        }

        // Thực thi lệnh INSERT, UPDATE, DELETE
        public bool ThucThi(string query, SqlParameter[] parameters = null)
        {
            int ketQua = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(sCon))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    myConnection.Open();
                    ketQua = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                }
                return ketQua > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy 1 giá trị duy nhất (ví dụ: COUNT, MAX, tên học sinh...)
        public object LayGiaTri(string query, SqlParameter[] parameters = null)
        {
            object ketQua = null;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(sCon))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    myConnection.Open();
                    ketQua = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá trị!\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ketQua;
        }

        // Kiểm tra tồn tại (trả về true/false)
        public bool KiemTraTonTai(string query, SqlParameter[] parameters = null)
        {
            object ketQua = LayGiaTri(query, parameters);
            // Thêm kiểm tra DBNull.Value để an toàn hơn với dữ liệu SQL
            return ketQua != null && ketQua != DBNull.Value && ketQua.ToString() != "0";
        }
    }
}
