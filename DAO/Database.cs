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
    public class Database
    {
        private string sCon = "Data Source=.; Initial Catalog=QuanLyHocSinhDB;Integrated Security=True";
        public Database() { }

        // Lấy DataTable (dùng cho SELECT)
        public DataSet XemDanhSach(string sSQL)
        {
            DataSet ds = new DataSet();
            SqlConnection myConnection = new SqlConnection(sCon);
            try
            {
                myConnection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sSQL, myConnection);
                sda.Fill(ds);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi! Chi tiết: " + ex.Message);
                ds = null;
            }

            return ds;
        }
        // Thực thi lệnh INSERT, UPDATE, DELETE
        public int ThucThi(string sSQL)
        {
            int ketQua = 0;
            SqlConnection myConnection = new SqlConnection(sCon);

            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sSQL, myConnection);
                ketQua = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi!\nChi tiết: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
            return ketQua;
        }

        // Lấy 1 giá trị duy nhất (ví dụ: COUNT, MAX, tên học sinh...)
        public object LayGiaTri(string sSQL)
        {
            object ketQua = null;
            SqlConnection myConnection = new SqlConnection(sCon);

            try
            {
                myConnection.Open();
                SqlCommand cmd = new SqlCommand(sSQL, myConnection);
                ketQua = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy giá trị!\nChi tiết: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
            return ketQua;
        }

        // Kiểm tra tồn tại (trả về true/false)
        public bool KiemTraTonTai(string sSQL)
        {
            object ketQua = LayGiaTri(sSQL);
            return ketQua != null && ketQua.ToString() != "0";
        }

    }
}
