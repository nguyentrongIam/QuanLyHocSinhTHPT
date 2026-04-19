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
        private string connectionString = "Server=.;Database=QuanLyHocSinhDB;Integrated Security=True;";
        public DataSet XemDanhSachHocSinh()
        {
            DataSet ds;
            //Chuoi truy van csdl
            string sSQL= "select HoTen,d.MaHS,NgaySinh,GioiTinh,DiaChi,SDT,DiemMieng,Diem15p,Diem45p,DiemThi,DiemTB from NguoiDung ng join HocSinh hs on ng.MaNguoiDung = hs.MaHS join Diem d on hs.MaHS = d.MaHS ";
            
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

    }
}
