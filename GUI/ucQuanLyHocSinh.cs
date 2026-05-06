using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyHocSinhTHPT
{
    public partial class ucQuanLyHocSinh : UserControl
    {
        string chucNang = "";
        string hienthi = "";
        public ucQuanLyHocSinh()
        {
            InitializeComponent();
            pnThongTin.Hide();
            HienDanhSach();

        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            HienDanhSach();
        }
        public void HienDanhSach()
        {


            DataSet ds;
            HocSinhBUS hsBUS = new HocSinhBUS();
            ds = hsBUS.LayDanhSachTatCaSinhVien();
            gird_danhsach.DataSource = ds.Tables[0];



        }
        


        private void uc_QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            
        }

        private void gird_danhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            HocSinhBUS bus = new HocSinhBUS();
            chucNang = "them";
            pnThongTin.Hide();
            pnThongTin.Show();
            //Vô hiệu hóa textbox mã hs
            txt_mahs.Enabled = false;
            //Resert textbox cũ
            txt_mahs.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_sdt_ph.Clear();
            txt_phuhuynh.Clear();

            //Hiện mã học sinh tiếp theo khi thêm
            txt_mahs.Text = bus.LayMaHocSinhTiepTheo().ToString();



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pnThongTin.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            chucNang = "sua";

            pnThongTin.Hide();
            pnThongTin.Show();

            //Vô hiệu hóa textbox mã hs
            txt_mahs.Enabled = false;

            //Resert textbox cũ
            txt_mahs.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_sdt_ph.Clear();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            int kq;
            if (chucNang=="them")
            {
                //Vô hiệu hóa textbox mã hs
                txt_mahs.Enabled = true;
                HocSinhDTO dto = new HocSinhDTO();
                dto.MaHS = txt_mahs.Text;
                dto.HoTen = txt_hoten.Text;
                dto.NgaySinh = dt_ngaysinh.Value;
                //Kiểm tra giới tính
                if (tog_nam.Checked)
                {
                    dto.GioiTinh = "Nữ";
                }
                else
                {
                    dto.GioiTinh = "Nam";
                }
                dto.DiaChi = txt_diachi.Text;
                dto.TenPH = txt_phuhuynh.Text;
                dto.SDTPH = txt_sdt_ph.Text;
                HocSinhBUS bus = new HocSinhBUS();
                kq = bus.Add_StudentBUS(dto);
                if (kq == 0)
                {
                    MessageBox.Show("Thêm thất bại !");
                }
                else
                {
                    MessageBox.Show("Thêm thành công !");
                }


                    MessageBox.Show("Đã ấn nút thêm !");
            }
            if (chucNang == "sua")
            {
                HocSinhDTO dto = new HocSinhDTO();
                //Mã hs bắt buộc nhập
                dto.MaHS = txt_mahs.Text;

                //Cột họ tên not null nên phải kiểm tra
                if (!string.IsNullOrWhiteSpace(txt_hoten.Text))
                {
                    dto.HoTen = txt_hoten.Text;
                }
                else
                {
                    
                   //Giữ nguyên 
                    dto.HoTen = null;
                }
                // Cột có thể NULL (ví dụ: Địa chỉ)
                if (!string.IsNullOrWhiteSpace(txt_diachi.Text))
                    dto.DiaChi = txt_diachi.Text;
                else
                    dto.DiaChi = null;

                // Gọi xuống lớp BUS
                HocSinhBUS bus = new HocSinhBUS();
                if (bus.CapNhatHocSinh(dto))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    // Refresh lại GridView hoặc xóa trắng form nếu cần
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại! (Kiểm tra lại dữ liệu)");
                }

                MessageBox.Show("Đã ấn nút sửa !");

            }
        }

       

        private void gird_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0)
                {
                    //Lấy hàng vừa click vào
                    DataGridViewRow row = gird_danhsach.Rows[e.RowIndex];

                    //Đổ dữ liệu ra textbox
                    txt_mahs.Text = row.Cells[0].Value.ToString();
                    txt_hoten.Text = row.Cells[1].Value.ToString();
                    DateTime ngaysinh = Convert.ToDateTime(row.Cells[2].Value);
                    if (row.Cells[3].Value.ToString() == "Nam")
                    {
                        tog_nam.Checked = false;
                    }
                    else
                    {
                        tog_nam.Checked = true;
                    }
                    txt_diachi.Text = row.Cells[4].Value.ToString();
                    txt_sdt_ph.Text = row.Cells["SDTPhuHuynh"].Value.ToString();
                    txt_phuhuynh.Text = row.Cells["TenPhuHuynh"].Value.ToString();
                }
            }catch(Exception ex)
            {

            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            HocSinhBUS bus = new HocSinhBUS();
            DataSet ds;
            ds = bus.TimKiemHocSinhBUS(txt_timkiem.Text);
            gird_danhsach.DataSource = ds.Tables[0];
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem GridView có dữ liệu không
            if (gird_danhsach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "DanhSachHocSinh_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 3. Khởi tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel._Worksheet worksheet = null;

                try
                {
                    worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Danh sách học sinh";

                    // 4. Xuất tiêu đề cột từ DataGridView
                    for (int i = 1; i <= gird_danhsach.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i] = gird_danhsach.Columns[i - 1].HeaderText;
                        // Định dạng tiêu đề (In đậm, màu nền)
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }

                    // 5. Xuất dữ liệu từng hàng
                    for (int i = 0; i < gird_danhsach.Rows.Count; i++)
                    {
                        for (int j = 0; j < gird_danhsach.Columns.Count; j++)
                        {
                            if (gird_danhsach.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = gird_danhsach.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // 6. Tự động giãn chiều rộng cột
                    worksheet.Columns.AutoFit();

                    // 7. Lưu file
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 8. Đóng ứng dụng Excel để không chạy ngầm
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }
    }
}//
