CREATE DATABASE QuanLyHocSinhDB;
GO
USE QuanLyHocSinhDB;
GO

-- 1. BẢNG NHÂN VIÊN (Gồm cả BGH và Giáo viên)
CREATE TABLE NhanVien (
    MaNV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(255),
    SDT VARCHAR(15),
    ChucVu NVARCHAR(50) -- 'Hiệu trưởng', 'Hiệu phó', 'Giáo viên'
);

-- 2. BẢNG LỚP HỌC
CREATE TABLE Lop (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL,
    MaGVCN VARCHAR(20),
    FOREIGN KEY (MaGVCN) REFERENCES NhanVien(MaNV)
);

-- 3. BẢNG HỌC SINH
CREATE TABLE HocSinh (
    MaHS VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(255),
    SDT VARCHAR(15), -- Số điện thoại phụ huynh/học sinh
    MaLop VARCHAR(20),
    FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

-- 4. BẢNG MÔN HỌC (Chương trình 2006)
CREATE TABLE MonHoc (
    MaMon VARCHAR(20) PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL
);

-- 5. BẢNG ĐIỂM
CREATE TABLE Diem (
    MaHS VARCHAR(20),
    MaMon VARCHAR(20),
    HocKy INT,
    NamHoc VARCHAR(20),
    DiemMieng FLOAT,
    Diem15p FLOAT,
    Diem45p FLOAT,
    DiemThi FLOAT,
    PRIMARY KEY (MaHS, MaMon, HocKy, NamHoc),
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- 6. BẢNG TÀI KHOẢN (Dùng để đăng nhập và phân quyền)
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(20) PRIMARY KEY, -- Chính là MaNV hoặc MaHS
    MatKhau VARCHAR(50) NOT NULL,
    VaiTro NVARCHAR(20) -- 'Admin', 'GiaoVien', 'HocSinh'
);
GO
USE QuanLyHocSinhDB;
GO

-- 1. Chèn Ban Giám Hiệu
INSERT INTO NhanVien VALUES ('AD001', N'Nguyễn Văn An', '1975-05-10', N'Nam', N'Hà Nội', '0912345678', N'Hiệu trưởng');
INSERT INTO NhanVien VALUES ('AD002', N'Trần Thị Bình', '1980-08-15', N'Nữ', N'Hà Nội', '0912345679', N'Hiệu phó');

-- 2. Chèn 13 Môn học và 13 Giáo viên tương ứng
INSERT INTO MonHoc VALUES ('TOAN', N'Toán Học'), ('VAN', N'Ngữ Văn'), ('ANH', N'Tiếng Anh'), 
                          ('LY', N'Vật Lý'), ('HOA', N'Hóa Học'), ('SINH', N'Sinh Học'),
                          ('SU', N'Lịch Sử'), ('DIA', N'Địa Lý'), ('GDCD', N'GDCD'),
                          ('TIN', N'Tin Học'), ('CN', N'Công Nghệ'), ('TD', N'Thể Dục'), ('QP', N'Quốc Phòng');

INSERT INTO NhanVien VALUES 
('GV001', N'Lê Toán', '1985-01-01', N'Nam', N'Hà Nội', '098001', N'Giáo viên'),
('GV002', N'Phạm Văn', '1986-02-02', N'Nữ', N'Hà Nội', '098002', N'Giáo viên'),
('GV003', N'Nguyễn Anh', '1987-03-03', N'Nữ', N'Hà Nội', '098003', N'Giáo viên'),
('GV004', N'Hoàng Lý', '1988-04-04', N'Nam', N'Hà Nội', '098004', N'Giáo viên'),
('GV005', N'Ngô Hóa', '1989-05-05', N'Nam', N'Hà Nội', '098005', N'Giáo viên'),
('GV006', N'Vũ Sinh', '1990-06-06', N'Nữ', N'Hà Nội', '098006', N'Giáo viên'),
('GV007', N'Đỗ Sử', '1991-07-07', N'Nam', N'Hà Nội', '098007', N'Giáo viên'),
('GV008', N'Bùi Địa', '1992-08-08', N'Nữ', N'Hà Nội', '098008', N'Giáo viên'),
('GV009', N'Lý Công Dân', '1993-09-09', N'Nam', N'Hà Nội', '098009', N'Giáo viên'),
('GV010', N'Quách Tin', '1994-10-10', N'Nam', N'Hà Nội', '098010', N'Giáo viên'),
('GV011', N'Dương Công Nghệ', '1995-11-11', N'Nữ', N'Hà Nội', '098011', N'Giáo viên'),
('GV012', N'Phan Thể Dục', '1996-12-12', N'Nam', N'Hà Nội', '098012', N'Giáo viên'),
('GV013', N'Trịnh Quốc Phòng', '1997-01-13', N'Nam', N'Hà Nội', '098013', N'Giáo viên');

-- 3. Tạo 3 Lớp học (Lấy 3 giáo viên đầu làm GVCN)
INSERT INTO Lop VALUES ('10A1', N'10A1', 'GV001'), ('10A2', N'10A2', 'GV002'), ('10A3', N'10A3', 'GV003');

-- 4. TỰ ĐỘNG TẠO 120 HỌC SINH (40 em/lớp) VÀ TÀI KHOẢN
DECLARE @i INT = 1;
DECLARE @MaLop VARCHAR(10);
WHILE @i <= 120
BEGIN
    SET @MaLop = CASE 
        WHEN @i <= 40 THEN '10A1'
        WHEN @i <= 80 THEN '10A2'
        ELSE '10A3'
    END;

    DECLARE @MaHS VARCHAR(20) = 'HS' + RIGHT('000' + CAST(@i AS VARCHAR), 3);
    
    INSERT INTO HocSinh (MaHS, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES (@MaHS, N'Học Sinh ' + CAST(@i AS VARCHAR), '2010-01-01', N'Nam', @MaLop);

    -- Tạo tài khoản cho học sinh (Mật khẩu mặc định: 01012010)
    INSERT INTO TaiKhoan VALUES (@MaHS, '01012010', 'HocSinh');

    SET @i = @i + 1;
END;

-- 5. Tạo tài khoản cho Admin và Giáo viên
INSERT INTO TaiKhoan SELECT MaNV, REPLACE(CONVERT(VARCHAR, NgaySinh, 103), '/', ''), 
    CASE WHEN ChucVu LIKE N'%Hiệu%' THEN 'Admin' ELSE 'GiaoVien' END
FROM NhanVien;

select * from TaiKhoan where TenDangNhap='AD001' and MatKhau='10051975'