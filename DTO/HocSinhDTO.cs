using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocSinhTHPT.DTO;
using QuanLyHocSinhTHPT.DAO;
using QuanLyHocSinhTHPT.BUS;
using QuanLyHocSinhTHPT.GUI;

namespace QuanLyHocSinhTHPT.DTO
{
    public class HocSinhDTO
    {
        // 1. Khóa chính - Luôn cần để biết sửa bản ghi nào
        public string MaHS { get; set; }

    
        public string HoTen { get; set; }

     
        public string NoiSinh { get; set; }

        public string DiaChi { get; set; }

        public string GioiTinh { get; set; }

        // Dùng DateTime? (nullable) để nếu không chọn ngày mới, giá trị sẽ là null
        public DateTime? NgaySinh { get; set; }

     
        public string TenPH { get; set; }

      
        public string SDTPH { get; set; }

        // 4. Thông tin lớp học (Dùng cho hiển thị danh sách hoặc tìm kiếm)
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string NienKhoa { get; set; }
    }
}
//Update
