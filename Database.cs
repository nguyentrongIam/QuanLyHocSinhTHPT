using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT
{
    public class Database
    {
        private string sCon = "Data Source=.; Initial Catalog=QuanLyHocSinhDB;Integrated Security=True";
        public Database() { }
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

    }
}
