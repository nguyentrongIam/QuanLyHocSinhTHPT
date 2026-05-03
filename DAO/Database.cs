using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.DAO
{
    public class Database
    {
        public string sCon = "Data Source=.; Initial Catalog=QuanLyHocSinh_DB;Integrated Security=True";

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

        //Hàm lấy dữ liệu có tham số
        public DataTable LayDuLieuCoThamSo(string sSQL, SqlParameter[] sqlParams)
        {
            DataTable dt = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(sCon))
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(sSQL, myConnection);
                    if (sqlParams != null)
                    {
                        cmd.Parameters.AddRange(sqlParams); // Nạp các biến @ vào câu lệnh
                    }
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
                    return null;
                }
            }
            return dt;
        }
        public int ThucThiCoThamSo(string sSQL,params SqlParameter[] sqlParams)
        {
            int ketQua = 0;
            using (SqlConnection myConnection = new SqlConnection(sCon))
            {
                try
                {
                    myConnection.Open();
                    SqlCommand cmd = new SqlCommand(sSQL, myConnection);
                    if (sqlParams != null)
                    {
                        cmd.Parameters.AddRange(sqlParams);
                    }
                    ketQua = cmd.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    MessageBox.Show("Lỗi. Chi tiết " + ex.Message);
                }
            }
            return ketQua;
        }

    }
}
