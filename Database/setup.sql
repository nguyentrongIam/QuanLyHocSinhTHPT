CREATE DATABASE QuanLyHocSinhDB;
GO
USE QuanLyHocSinhDB;
GO

-- ==========================================
-- PHẦN 1: TẠO BẢNG & RÀNG BUỘC (DDL)
-- Lệnh tạo bảng phải theo thứ tự để tránh lỗi khóa ngoại
-- ==========================================

-- 1. BẢNG GỐC: Người Dùng (Lưu thông tin chung của tất cả mọi người)
CREATE TABLE NguoiDung (
    MaNguoiDung VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DiaChi NVARCHAR(255),
    SDT VARCHAR(15),
    LoaiNguoiDung VARCHAR(20) CHECK (LoaiNguoiDung IN ('NV', 'HS')) -- NV: Nhân viên, HS: Học sinh
);

-- 2. BẢNG NHÂN VIÊN (Tham chiếu đến NguoiDung)
CREATE TABLE NhanVien (
    MaNV VARCHAR(20) PRIMARY KEY,
    ChucVu NVARCHAR(50), -- 'Hiệu trưởng', 'Hiệu phó', 'Giáo viên'
    TrinhDo NVARCHAR(50),
    FOREIGN KEY (MaNV) REFERENCES NguoiDung(MaNguoiDung)
);

-- 3. BẢNG MÔN HỌC
CREATE TABLE MonHoc (
    MaMon VARCHAR(20) PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL,
    HeSo INT DEFAULT 1 CHECK (HeSo IN (1, 2))
);

-- 4. BẢNG LỚP HỌC (Có GVCN tham chiếu đến NhanVien)
CREATE TABLE Lop (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    MaGVCN VARCHAR(20),
    FOREIGN KEY (MaGVCN) REFERENCES NhanVien(MaNV)
);

-- 5. BẢNG HỌC SINH (Tham chiếu đến NguoiDung và Lop)
CREATE TABLE HocSinh (
    MaHS VARCHAR(20) PRIMARY KEY,
    MaLop VARCHAR(20),
    NienKhoa VARCHAR(20),
    FOREIGN KEY (MaHS) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

-- 6. BẢNG TÀI KHOẢN (Tham chiếu trực tiếp đến NguoiDung)
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(20) PRIMARY KEY,
    MatKhau VARCHAR(50) NOT NULL,
    VaiTro NVARCHAR(20) CHECK (VaiTro IN ('Admin', 'GiaoVien', 'HocSinh')),
    TrangThai BIT DEFAULT 1, -- 1: Hoạt động, 0: Khóa
    FOREIGN KEY (TenDangNhap) REFERENCES NguoiDung(MaNguoiDung)
);

-- 7. BẢNG PHÂN CÔNG GIẢNG DẠY
CREATE TABLE PhanCongGiangDay (
    MaGV VARCHAR(20),
    MaLop VARCHAR(20),
    MaMon VARCHAR(20),
    HocKy INT CHECK (HocKy IN (1, 2)),
    NamHoc VARCHAR(20),
    PRIMARY KEY (MaGV, MaLop, MaMon, HocKy, NamHoc),
    FOREIGN KEY (MaGV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- 8. BẢNG ĐIỂM
CREATE TABLE Diem (
    MaHS VARCHAR(20),
    MaMon VARCHAR(20),
    HocKy INT CHECK (HocKy IN (1, 2)),
    NamHoc VARCHAR(20),
    DiemMieng FLOAT CHECK (DiemMieng >= 0 AND DiemMieng <= 10),
    Diem15p FLOAT CHECK (Diem15p >= 0 AND Diem15p <= 10),
    Diem45p FLOAT CHECK (Diem45p >= 0 AND Diem45p <= 10),
    DiemThi FLOAT CHECK (DiemThi >= 0 AND DiemThi <= 10),
    DiemTB FLOAT CHECK (DiemTB >= 0 AND DiemTB <= 10),
    PRIMARY KEY (MaHS, MaMon, HocKy, NamHoc),
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);
GO

-- ==========================================
-- PHẦN 2: CHÈN DỮ LIỆU MẪU THỦ CÔNG (DML)
-- ==========================================

-- 1. CHÈN NGƯỜI DÙNG (Tất cả BGH, GV, HS phải có mặt ở đây trước)
INSERT INTO NguoiDung (MaNguoiDung, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, LoaiNguoiDung) VALUES 
('AD001', N'Nguyễn Văn An', '1975-05-10', N'Nam', N'Hà Nội', '0912345678', 'NV'),
('AD002', N'Trần Thị Bình', '1980-08-15', N'Nữ', N'Hà Nội', '0912345679', 'NV'),
('GV001', N'Lê Toán', '1985-01-01', N'Nam', N'Hà Nội', '0980000001', 'NV'),
('GV002', N'Phạm Văn', '1986-02-02', N'Nữ', N'Hà Nội', '0980000002', 'NV'),
('GV003', N'Nguyễn Anh', '1987-03-03', N'Nữ', N'Hà Nội', '0980000003', 'NV'),
('GV004', N'Hoàng Lý', '1988-04-04', N'Nam', N'Hà Nội', '0980000004', 'NV'),
('HS001', N'Trần Ngọc A', '2010-01-15', N'Nam', N'Hà Nội', '0331234001', 'HS'),
('HS002', N'Lê Thị B', '2010-02-20', N'Nữ', N'Hà Nội', '0331234002', 'HS'),
('HS003', N'Phạm Văn C', '2010-03-25', N'Nam', N'Hà Nội', '0331234003', 'HS'),
('HS004', N'Hoàng Ngọc D', '2010-04-10', N'Nữ', N'Hà Nội', '0331234004', 'HS'),
('HS005', N'Ngô Tấn E', '2010-05-05', N'Nam', N'Hà Nội', '0331234005', 'HS'),
('HS006', N'Đinh Thị F', '2010-06-12', N'Nữ', N'Hà Nội', '0331234006', 'HS');

-- 2. CHÈN NHÂN VIÊN (Trích xuất từ NguoiDung)
INSERT INTO NhanVien (MaNV, ChucVu, TrinhDo) VALUES 
('AD001', N'Hiệu trưởng', N'Thạc sĩ'),
('AD002', N'Hiệu phó', N'Thạc sĩ'),
('GV001', N'Giáo viên', N'Cử nhân'),
('GV002', N'Giáo viên', N'Cử nhân'),
('GV003', N'Giáo viên', N'Cử nhân'),
('GV004', N'Giáo viên', N'Cử nhân');

-- 3. CHÈN MÔN HỌC
INSERT INTO MonHoc (MaMon, TenMon, HeSo) VALUES 
('TOAN', N'Toán Học', 2), 
('VAN', N'Ngữ Văn', 2), 
('ANH', N'Tiếng Anh', 1), 
('LY', N'Vật Lý', 1);

-- 4. CHÈN LỚP HỌC (Cần có mã GVCN)
INSERT INTO Lop (MaLop, TenLop, MaGVCN) VALUES 
('10A1', N'10A1', 'GV001'), 
('10A2', N'10A2', 'GV002');

-- 5. CHÈN HỌC SINH (Trích xuất từ NguoiDung, ghép với Lop)
INSERT INTO HocSinh (MaHS, MaLop, NienKhoa) VALUES 
('HS001', '10A1', '2025-2028'),
('HS002', '10A1', '2025-2028'),
('HS003', '10A1', '2025-2028'),
('HS004', '10A2', '2025-2028'),
('HS005', '10A2', '2025-2028'),
('HS006', '10A2', '2025-2028');

-- 6. CHÈN TÀI KHOẢN (Cho cả Admin, Giáo viên và Học sinh)
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, TrangThai) VALUES 
('AD001', 'admin123', 'Admin', 1),
('GV001', 'gv123456', 'GiaoVien', 1),
('GV002', 'gv123456', 'GiaoVien', 1),
('HS001', '15012010', 'HocSinh', 1),
('HS002', '20022010', 'HocSinh', 1),
('HS003', '25032010', 'HocSinh', 1);

-- 7. CHÈN PHÂN CÔNG GIẢNG DẠY
INSERT INTO PhanCongGiangDay (MaGV, MaLop, MaMon, HocKy, NamHoc) VALUES 
('GV001', '10A1', 'TOAN', 1, '2025-2026'),
('GV002', '10A1', 'VAN', 1, '2025-2026'),
('GV003', '10A1', 'ANH', 1, '2025-2026'),
('GV004', '10A2', 'LY', 1, '2025-2026');

-- 8. CHÈN ĐIỂM SỐ
INSERT INTO Diem (MaHS, MaMon, HocKy, NamHoc, DiemMieng, Diem15p, Diem45p, DiemThi, DiemTB) VALUES 
('HS001', 'TOAN', 1, '2025-2026', 8.0, 7.5, 8.0, 8.5, 8.1),
('HS001', 'VAN', 1, '2025-2026', 7.0, 7.0, 6.5, 7.0, 6.9),
('HS002', 'TOAN', 1, '2025-2026', 9.0, 8.5, 9.0, 9.5, 9.1),
('HS004', 'TOAN', 1, '2025-2026', 6.0, 6.5, 7.0, 7.5, 7.0);
GO