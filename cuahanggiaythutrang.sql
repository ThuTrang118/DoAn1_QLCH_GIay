CREATE DATABASE cuahanggiaythutrang
GO
USE cuahanggiaythutrang
create table NhanVien
(
	MaNV char(10) primary key not null,
	TenNV nvarchar(50) not null,
	NgaySinh date not null,
	GioiTinh nvarchar(10) not null,
	DiaChi nvarchar(50) not null,
	Email nvarchar(50) not null,
	SDT char(10) not null,
	TK nvarchar(30) not null,
	MK int not null,
)
create table TaiKhoan
(
	MaTK char(10) primary key not null, 
	Quyen nvarchar(50) not null,
	TK nvarchar(30) not null,
	MK nvarchar(30) not null,
	Email nvarchar(50) not null,
)


create table KhachHang
(
	MaKH char(10) primary key not null,
	TenKH nvarchar(50) not null,
	GioiTinh nvarchar(10) not null,
	DiaChi nvarchar(50) not null,
	SDT char(10) not null,
	Email nvarchar(50) not null ,
)

create table Luong
(
	MaLuong char(10) primary key not null,
	MaNV char(10) FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) not null,
	LuongCB decimal not null,
	DoanhSo int not null,
	Thuong decimal  not null,
	ThucLinh decimal  not null,
)
select * from Luong
create table NhaCungCap
(
	MaNCC char(10) primary key  not null,
	TenNCC nvarchar(50)  not null,
	GioiTinh nvarchar(10) not null,
	DiaChiNCC nvarchar(50)  not null,
	SDTNCC char(10)  not null,
	Email nvarchar(50) not null,
)

create table SanPham
(
	MaSP char(10) primary key not null,
	TenSP nvarchar(50) not null,
	Size int not null,
	MauSac nvarchar(30) not null, 
	MaNCC char(10) foreign key(MaNCC) references NhaCungCap(MaNCC) not null,
	GiaNhap decimal not null,
	GiaBan decimal not null,
	SL int not null,
	SLDaBan int not null,
)

CREATE TABLE HoaDonNhap (
    MaHDN CHAR(10) PRIMARY KEY NOT NULL,
    MaNV CHAR(10) foreign key(MaNV) references NhanVien(MaNV) not null,
    TenNV NVARCHAR(50) NOT NULL,
    MaNCC char(10) foreign key(MaNCC) references NhaCungCap(MaNCC) not null,
    TenNCC NVARCHAR(50) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(100) NOT NULL,
    SDT NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    NgayMua DATETIME NOT NULL,
    ThanhTien FLOAT NOT NULL
);
select*from hoadonnhap
CREATE TABLE ChiTietHoaDonNhap (
    MaCTHDN NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaHDN CHAR(10) NOT NULL,
    MaSP CHAR(10) FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) NOT NULL,
    TenSP NVARCHAR(100) NOT NULL,
    SoLuong INT NOT NULL,
    GiaNhap DECIMAL NOT NULL,
    ThanhTien DECIMAL NOT NULL,
    FOREIGN KEY (MaHDN) REFERENCES HoaDonNhap(MaHDN)
);

create table HoaDonBan
(
	MaHDB char(10) primary key not null,
	MaNV char(10) foreign key(MaNV) references NhanVien(MaNV) not null,
	TenNV nvarchar(50) not null, 
	MaKH char(10) foreign key(MaKH) references KhachHang(MaKH) not null,
	TenKH nvarchar(50) not null,
	GioiTinh nvarchar(10) not null,
	DiaChi nvarchar(50) not null,
	SDT char(10) not null,
	Email nvarchar(50) not null,
	NgayMua datetime not null, 
	TongThanhTien decimal not null, 
	KhachTra decimal not null, 
	TienThua decimal not null,
)
create table ChiTietHoaDonBan
( 
	MaCTHDB NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaHDB CHAR(10) NOT NULL,
	MaSP char(10) foreign key (MaSP) references SanPham(MaSP) not null,
	TenSP nvarchar(50) not null,
	SoLuong int not null, 
	GiaBan decimal not null, 
	ThanhTien decimal not null, 
	FOREIGN KEY (MaHDB) REFERENCES HoaDonBan(MaHDB)
);
drop table ChiTietHoaDonNhap
Drop table HoaDonNhap
select*from HoaDonBan
select*from ChiTietHoaDonBan
-----------------------------------
INSERT INTO TaiKhoan (MaTK, Quyen, TK, MK, Email)
VALUES 
    (1, N'QuanTriVIen', 'thutrang', '1119', 'thutrang118@gmail.com'),
	(2, N'NhanVien', 'truong', '123', 'truong@gmail.com'),
	(3, N'NhanVien', 'maianh', '123', 'maianh@gmail.com');
	select*from TaiKhoan
------------------------------------
INSERT INTO NhaCungCap(MaNCC, TenNCC, GioiTinh, DiaChiNCC, SDTNCC, Email)
VALUES
	('NCC1', N'Nhà cung cấp 1', N'Nữ', N'Hà Nội', '0967727589', 'Nhacungcap1@gmail.com'),
	('NCC2', N'Nhà cung cấp 2', N'Nam', N'Hà Nội', '0929117733', 'Nhacungcap2@gmail.com'),
	('NCC3', N'Nhà cung cấp 3', N'Nữ', N'TP Hồ Chí Minh', '0971666172', 'Nhacungcap3@gmail.com'),
	('NCC4', N'Nhà cung cấp 4', N'Nam', N'Đà Nẵng', '0927723366', 'Nhacungcap4@gmail.com'),
	('NCC5', N'Nhà cung cấp 5', N'Nữ', N'TP Hồ Chí Minh', '0929117700', 'Nhacungcap5@gmail.com'),
	('NCC6', N'Nhà cung cấp 6', N'Nam', N'Đà Lạt', '0978221006', 'Nhacungcap6@gmail.com'),
	('NCC7', N'Nhà cung cấp 7', N'Nữ', N'Hà Nội', '0983963079', 'Nhacungcap7@gmail.com'),
	('NCC8', N'Nhà cung cấp 8', N'Nam', N'TP Hồ Chí Minh', '076220766', 'Nhacungcap8@gmail.com'),
	('NCC9', N'Nhà cung cấp 9', N'Nữ', N'Đà Nẵng', '0921227700', 'Nhacungcap9@gmail.com'),
	('NCC10', N'Nhà cung cấp 10', N'Nam', N'Đà Lạt', '0927443366', 'Nhacungcap10@gmail.com');
	select * from NhaCungCap
------------------------------------
INSERT INTO SanPham(MaSP, TenSP, Size, MauSac, MaNCC, GiaNhap, GiaBan, SL, SLDaBan)
VALUES
	('SP1', N'Nhà cung cấp 1', '39', N'Đen', 'NCC1', '200000', '250000', '20','0'),
	('SP2', N'Nhà cung cấp 2', '38', N'Trắng', 'NCC2','200000', '250000', '20','0'),
	('SP3', N'Nhà cung cấp 3', '37', N'Be', 'NCC3', '200000', '250000', '20','0'),
	('SP4', N'Nhà cung cấp 4', '36', N'Đỏ', 'NCC4', '200000', '250000', '20','0'),
	('SP5', N'Nhà cung cấp 5', '38', N'Trắng', 'NCC5','200000', '250000', '20','0'),
	('SP6', N'Nhà cung cấp 6', '39', N'Đen', 'NCC6', '200000', '250000', '20','0'),
	('SP7', N'Nhà cung cấp 7', '38', N'Xanh lam', 'NCC7', '200000', '250000', '20','0'),
	('SP8', N'Nhà cung cấp 8', '39', N'Vàng', 'NCC8', '200000', '250000', '20','0'),
	('SP9', N'Nhà cung cấp 9', '38', N'Trắng', 'NCC9', '200000', '250000', '20','0'),
	('SP10',N'Nhà cung cấp 10', '37', N'Be', 'NCC10', '200000', '250000', '20','0');
	select * from SanPham
----------------------------------------
INSERT INTO NhanVien(MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, Email, SDT, TK, MK)
VALUES
	('NV1', N'Nguyễn Văn Trưởng', '2004-01-19', N'Nam', 'Thái Bình', 'truong@gmail.com', '0369245488', 'truong','123'),
	('NV2', N'Nguyễn Phạm Mai Anh', '2005-10-15', N'Nữ', 'Hưng Yên','maianh@gmail.com', '0928943366', 'maianh','123');
	select * from NhanVien
-------------------------------------------
INSERT INTO Luong (MaNV,LuongCB,DoanhSo,Thuong,	ThucLinh)
VALUES
	('NV1', 2000000, 30, 300000, 2300000);
	select*from Luong