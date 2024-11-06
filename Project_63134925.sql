CREATE DATABASE Project_63134295
USE Project_63134295
GO
CREATE TABLE Account
(
	Email NVARCHAR(150) primary key,
	MK VARCHAR(150),
	TenHienThi NVARCHAR(150),
	RoleID  INT, -- Vai tro 
	CreateDate DATETIME -- Ngay tao tk
)
GO
create table KhachHang
(
	MaKH varchar(6) primary key
	, HoKH nvarchar(50) not null
	, TenKH nvarchar(50) not null
	, DiaChi nvarchar(60) not null
	, SoDT varchar(15)
	, NgaySinh date
	, GioiTinh bit default(1)
	, Email varchar(40) not null unique
)

create table NhanVien
(
	MaNV varchar(6) primary key
	, HoNV nvarchar(50) not null
	, TenNV nvarchar(50) not null
	, SoDT varchar(15)
	, Email varchar(40) not null unique
	, GioiTinh bit
	, DiaChi nvarchar(60)
	, ChucVu nvarchar(60)
	, ngaysinh date
)
create table GoiTap
(
    MaGoi char(6) primary key,
    TenGoi nvarchar(50) not null,
    MoTa nvarchar(100),
    Gia float,
)
GO
CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,
	MaKH varchar(6),
    TenKH NVARCHAR(255),
    ghichu NVARCHAR(255),
	ngaydat DATE,
	email NVARCHAR(50),
   diachi NVARCHAR(255),
   FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)  
)
Create Table ChiTietDonHang(
	MaCTDH INT IDENTITY(1,1) PRIMARY KEY,
	MaDH INT,
	MaGoi char(6),
	soluong INT,
	tong Int,
	FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH),
	FOREIGN KEY (MaGoi) REFERENCES GoiTap(MaGoi)
);

create table LichTrinhTap
(
    MaLichTrinh int primary key,
    MaKH varchar(6) not null foreign key references KhachHang(MaKH),
    MaGoi char(6) not null foreign key references GoiTap(MaGoi),
    NgayBatDau date not null,
    NgayKetThuc date not null
)
INSERT INTO Account(Email, MK, TenHienThi, RoleID, CreateDate)
Values(N'khangnp@gmail.com', 'khang2003', N'Nguyễn Phước Khang', 1, '2023-11-20'),
(N'npkhang@gmail.com', 'khang0301', N'Nguyễn Thị Phước Khang', 1, '2023-11-12');

-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (MaKH, HoKH, TenKH, SoDT,DiaChi, NgaySinh, GioiTinh, Email)
VALUES
    ('KH001', N'Nguyễn', N'Văn An', '0123456789',N'Hà Nội', '1990-01-01', 1, 'nguyenvanan@gmail.com' ),
    ('KH002', N'Trần', N'Thị Bình', '0987654321',N'Hồ Chí Minh', '1995-05-10', 0, 'tranthib@gmail.com'),
    ('KH003', N'Lê', N'Tuấn Cường', '0369876543', N'Đà Nẵng','1988-09-20', 1, 'letuancuong@gmail.com'),
    ('KH004', N'Phạm', N'Minh Dung','0909090909',N'Hải Phòng', '1992-03-15', 1, 'phamminhdung@gmail.com'),
    ('KH005', N'Hoàng', N'Trần Em','0776677777', N'Bà Rịa', '2000-12-31', 0, 'hoangtranem@gmail.com'),
	('KH006', N'Võ', N'Văn Đức','0712777777', N'Rạch Miễu', '2001-12-31', 1, 'vovanduc@gmail.com'),
	('KH007', N'Nguyễn', N'Tuấn Giang','0777734777', N'Cần Thơ', '1998-1-31', 1, 'nguyentuangiang@gmail.com'),
	('KH008', N'Trần', N'Thị Hà','0777789777', N'Bến Tre', '1997-12-30', 0, 'tranthiha@gmail.com'),
	('KH009', N'Hoàng', N'Trần Mủ','08177777777', N'Biên Hòa', '1990-12-31', 1, 'hoangtranmu@gmail.com'),
	('KH010', N'Lê', N'Thị Lành','0777770977', N'Nha Trang', '1998-12-31', 0, 'nguyenthilanh@gmail.com'),
	('KH011', N'Đỗ', N'Duy Khánh','0123999291', N'Bắc Ninh', '1996-12-31', 0, 'doduykhanh@gmail.com'),
	('KH012', N'Lê', N'Sang Hiếc','0124359291', N'Hồ Chí Minh', '1996-10-31', 1, 'lesanghiec@gmail.com'),
	('KH013', N'Phan', N'Anh Kha','0213459291', N'Cửa Bé', '2003-04-28', 1, 'phananhkha@gmail.com'),
	('KH014', N'Trần', N'Văn Né','0123759291', N'An Giang', '1996-12-30', 1, 'tranvanne@gmail.com'),
	('KH015', N'Lê', N'Văn Cường','03323459291', N'An Giang', '1996-04-31', 1, 'levancuong@gmail.com'),
	('KH016', N'Nguyễn', N'Văn Quang','0967524271', N'Khánh Hòa', '1970-11-20', 1, 'nguyenvangquang@gmail.com'),
	('KH017', N'Nguyễn', N'Phước Sang','012345977', N'Khánh Hòa', '1996-03-04', 1, 'nguyenphuocsang@gmail.com'),
	('KH018', N'Nguyễn', N'Phước Khang','0865379410', N'Khánh Hòa', '2003-01-03', 1, 'nguyenphuockhang@gmail.com'),
	('KH019', N'Lê', N'Văn Linh','0122159291', N'Ninh Hòa', '1996-12-31', 1, 'levanlinh@gmail.com'),
	('KH020', N'Lê', N'Quang Huy','0123459658', N'Cam Ranh', '2003-03-21', 1, 'lequanghuy@gmail.com'),
	('KH021', N'Nguyễn', N'Ngọc Bảo Trâm','0321459797', N'Nha Trang', '2003-05-15', 0, 'nnbtram@gmail.com'),
	('KH022', N'Trần', N'Minh Quang','0123159797', N'Nha Trang', '2003-12-02', 1, 'tranminhquang@gmail.com'),
	('KH023', N'Trần', N'Trọng Hòa','0123459722', N'Nha Trang', '2003-11-02', 1, 'lequochuy@gmail.com'),
	('KH024', N'Sam', N'Sulek','0123459797', N'California', '2003-11-02', 1, 'samsulek@gmail.com'),
	('KH025', N'Mike', N'OHern','0123459797', N'Florida', '2003-11-03', 1, 'mikeohearn@gmail.com'),
	('KH026', N'Phan', N'Minh Đạt','0126559797', N'Nha Trang', '2003-03-02', 1, 'phanminhdat@gmail.com'),
	('KH027', N'Đỗ', N'Tuấn Kiệt','0223459797', N'Nha Trang', '2000-12-04', 1, 'dotuankiet@gmail.com'),
	('KH028', N'Trần', N'Văn Mạnh','0123999797', N'Hải Phòng', '2003-06-02', 1, 'tranvanmanh@gmail.com'),
	('KH029', N'Lê', N'Quốc Dũng','0121459797', N'Nha Trang', '2003-11-02', 1, 'lequocdung@gmail.com'),
	('KH030', N'Lê', N'Thị Thanh Thắm','0155459797', N'Hà Nội', '2002-11-02', 0, 'ltttham@gmail.com');

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNV, HoNV, TenNV, SoDT, Email, GioiTinh, DiaChi,  ngaysinh, ChucVu)
VALUES
    ('NV001', N'Trần', N'Thị A', '0123456789', 'tranthia@gmail.com', 0, N'Hà Nội', '1990-06-15',N'Thu Ngân'),
    ('NV002', N'Nguyễn', N'Văn B', '0987654321', 'nguyenvanb@gmail.com', 1, N'Hồ Chí Minh', '1995-03-10',N'Quản Lí'),
    ('NV003', N'Lê', N'Tuấn C', '0369876543', 'letuanc@gmail.com', 1, N'Đà Nẵng','1992-09-20',N'Giảng Viên'),
    ('NV004', N'Phạm', N'Minh D', '0909090909', 'phamminhd@gmail.com', 0, N'Hải Phòng', '1998-02-28',N'Kỹ Thuật Viên'),
    ('NV005', N'Hoàng', N'Thị E', '0777777777', 'hoangthie@gmail.com', 0, N'Cần Thơ','1994-12-31',N'Chăm Sóc Khách Hàng'),
	('NV006', N'Nguyễn', N'Hữu Việt Dũng', '0123556789', 'nhvdung@gmail.com', 1, N'Hà Nội', '1990-02-15',N'Huấn Luyện Viên'),
	('NV007', N'Nguyễn', N'Văn Hùng', '0123444789', 'nguyenvanhung@gmail.com', 1, N'Nha Trang', '1990-07-15',N'Huấn Luyện Viên'),
	('NV008', N'Lê', N'Huỳnh Đức', '0121225679', 'lehuynhduc@gmail.com', 1, N'Hồ Chính Minh', '1995-06-15',N'Huấn Luyện Viên'),
	 ('NV009', N'Trần', N'Ngọc Trúc', '0123456982', 'tranngotruc@gmail.com', 0, N'Hà Nội', '1980-06-17',N'Huấn Luyện Viên'),
	 ('NV010', N'Lê', N'Như', '0887456789', 'lenhu@gmail.com', 0, N'Hà Nội', '1990-01-15',N'Huấn Luyện Viên')

-- Thêm dữ liệu vào bảng GoiTap
INSERT INTO GoiTap (MaGoi, TenGoi, MoTa, Gia)
VALUES
    ('GT001', N'Gói Tập Cá Nhân', N'Tập riêng cho một người', 1500000 ),
    ('GT002', N'Gói Tập Nhóm', N'Tập cùng nhóm bạn', 1200000),
    ('GT003', N'Gói Tập Yoga', N'Tập Yoga hàng tuần', 900000 ),
    ('GT004', N'Gói Tập Aerobic', N'Tập Aerobic 3 lần/tuần',800000 ),
    ('GT005', N'Gói Tập Thể Dục Mẹ Bầu', N'Tập cho các bà bầu',1000000),
	('GT007', N'Gói Tập Dài Hạn', N'Đăng ký một lần , tập nguyên 1 năm', 3000000 ),
	('GT008', N'Gói Tập Cho Người Cao Tuổi', N'người già đi tập', 250000 ),
	('GT009', N'Gói Tập Hỗn Hợp', N'Muốn tập gì tập', 4000000),
	('GT011', N'Gói Tập Kickboxing', N'1 cước là nằm', 2500000),
	('GT012', N'Gói Tập Bootcamp', N'Chạy bộ, leo trèo, xoay người', 5000000 )

-- Thêm dữ liệuvào bảng LichTrinhTap
INSERT INTO LichTrinhTap (MaLichTrinh, MaKH, MaGoi, NgayBatDau, NgayKetThuc)
VALUES
    (1, 'KH001', 'GT001', '2023-01-01', '2023-03-31'),
    (2, 'KH002', 'GT002', '2023-02-15', '2023-05-15'),
    (3, 'KH003', 'GT003', '2023-03-01', '2023-06-30'),
    (4, 'KH004', 'GT004', '2023-04-10', '2023-07-10'),
    (5, 'KH005', 'GT005', '2023-05-01', '2023-08-01');
GO
CREATE PROCEDURE KhachHang_TimKiem
    @MaKH varchar(8)=NULL,
	@HoTen nvarchar(40)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM KhachHang
       WHERE  (1=1)
       '
IF @MaKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaKH LIKE ''%'+@MaKH+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoKH+'' ''+TenKH LIKE ''%'+@HoTen+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

exec KhachHang_TimKiem

 GO
CREATE PROCEDURE NhanVien_TimKiem
    @MaNV varchar(8)=NULL,
	@HoTen nvarchar(40)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NHANVIEN
       WHERE  (1=1)
       '
IF @MaNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaNV LIKE ''%'+@MaNV+'%'')
              '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoNV+'' ''+TenNV LIKE ''%'+@HoTen+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
GO
CREATE PROCEDURE GoiTap_TimKiem
    @MaGoi varchar(8)=NULL,
	@TenGoi nvarchar(40)=NULL,
	@GiaMin varchar(30)=NULL,
	@GiaMax varchar(30)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM GOITAP
       WHERE  (1=1)
       '
IF @MaGoi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaGoi LIKE ''%'+@MaGoi+'%'')
              '
IF @TenGoi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (TenGoi LIKE ''%'+@TenGoi+'%'')
              '
IF @GiaMin IS NOT NULL and @GiaMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (Gia Between Convert(int,'''+@GiaMin+''') AND Convert(int, '''+@GiaMax+'''))
			 '
	EXEC SP_EXECUTESQL @SqlStr
END
