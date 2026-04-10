using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinhTHPT
{
    public partial class frm_ThemHocSinh : Form
    {
        public frm_ThemHocSinh()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string message = "Vui lòng nhập";
            if (string.IsNullOrWhiteSpace(txt_MaHocSinh.Text))
            {
                message += " mã học sinh";
                txt_MaHocSinh.Focus();
            }
            if (string.IsNullOrWhiteSpace(txt_MaLop.Text))
            {
                message += " mã lớp";
                MessageBox.Show(message+"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaLop.Focus();
            }
            try
            {
                string sSQL = "INSERT INTO HocSinh(MaHS,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,MaHS) ";
                sSQL += "VALUES(@maHS,@hoTen,@ngaySinh,@gioiTinh,@diaChi,@soDienThoai,@maLop)";
                sSQL = sSQL.Replace("@maHS", txt_MaHocSinh.Text);
                sSQL = sSQL.Replace("hoTen", txt_HoVaTen.Text);
                sSQL = sSQL.Replace("@ngaySinh", dtp_NgaySinh.Text);
                if (rdo_Nam.Checked)
                    sSQL = sSQL.Replace("@gioiTinh", "Nam");
                if (rdo_Nu.Checked)
                    sSQL = sSQL.Replace("@gioiTinh", "Nữ");
                sSQL = sSQL.Replace("@diaChi", txt_DiaChi.Text);
                sSQL = sSQL.Replace("@soDienThoai", txt_SoDienThoai.Text);
                sSQL = sSQL.Replace("@maLop", txt_MaLop.Text);
                Database db = new Database();
                db.ThucThiTruyVan(sSQL);
            }
            catch (Exception ex){ }
                    

        }

        private void lbl_QuayLai_Click(object sender, EventArgs e)
        {

        }

        private void lbl_QuayLai_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
