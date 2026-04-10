using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyHocSinhTHPT
{
    public class TaiKhoan
    {
        private string userName {  get; set; }
        private string password { get; set; }
        public string vaiTro { get; set; }
        public TaiKhoan(string uname,string pword,string vtro="") {
            this.userName = uname;
            this.password = pword;
            this.vaiTro = vtro;
        }
        public bool XacMinhDangNhap()
        {
            string sSQL = "SELECT * FROM TaiKhoan WHERE TenDangNhap=N'@userName' AND MatKhau=N'@password' AND VaiTro=N'@vaiTro'";
            sSQL=sSQL.Replace("@userName",this.userName);
            sSQL=sSQL.Replace("@password", this.password);
            sSQL=sSQL.Replace("@vaiTro",this.vaiTro);
            Database db = new Database();
            DataSet data=db.XemDanhSach(sSQL);
            if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count==1) {
                return true;
            }
            return false;
        }
    }
}
