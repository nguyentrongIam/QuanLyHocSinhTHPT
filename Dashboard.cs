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
    public partial class frm_Dashboard : Form
    {
        public string vaiTro;
        public frm_Dashboard(string vaiTro)
        {
            InitializeComponent();
            lbl_ChucVu.Text = vaiTro;
            this.vaiTro = vaiTro;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
