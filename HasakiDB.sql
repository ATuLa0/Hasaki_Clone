-- Tạo cơ sở dữ liệu
CREATE DATABASE HasakiDatabase;

USE HasakiDatabase;

CREATE TABLE DanhMucSanPham (
    DanhMucSanPhamID INT PRIMARY KEY,
    TenDanhMuc NVARCHAR(255),
    MoTa NVARCHAR(MAX)
);

CREATE TABLE ThuongHieu (
    ThuongHieuID INT PRIMARY KEY,
    TenThuongHieu NVARCHAR(255),
    MoTa NVARCHAR(MAX)
);

CREATE TABLE KhachHang (
    KhachHangID INT PRIMARY KEY,
    TenKhachHang NVARCHAR(255),
    Email NVARCHAR(255),
    SoDienThoai NVARCHAR(20),
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(255)
);

CREATE TABLE SanPham (
    SanPhamID INT PRIMARY KEY,
    TenSanPham NVARCHAR(255),
    HinhAnh VARCHAR(255),
    MoTa NVARCHAR(MAX),
    Gia FLOAT,
    DungTich NVARCHAR(255),
    ThuongHieu NVARCHAR(255),
    XuatXu NVARCHAR(255),
    LoaiDaPhuHop NVARCHAR(255),
    DoPH FLOAT,
    CongDung NVARCHAR(MAX),
    ThanhPhanChinh NVARCHAR(MAX),
    CachSuDung NVARCHAR(MAX),
    LuuY NVARCHAR(MAX),
    ThuongHieuID INT,
    FOREIGN KEY (ThuongHieuID) REFERENCES ThuongHieu(ThuongHieuID)
);


CREATE TABLE SanPhamDanhMuc (
    SanPhamID INT,
    DanhMucSanPhamID INT,
    PRIMARY KEY (SanPhamID, DanhMucSanPhamID),
    FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID),
    FOREIGN KEY (DanhMucSanPhamID) REFERENCES DanhMucSanPham(DanhMucSanPhamID)
);

CREATE TABLE DichVu (
    DichVuID INT PRIMARY KEY,
    TenDichVu NVARCHAR(255),
    MoTa NVARCHAR(MAX),
    Gia FLOAT
);

CREATE TABLE PhieuQuaTang (
    PhieuQuaTangID INT PRIMARY KEY,
    KhachHangID INT,
    MaGiamGia NVARCHAR(20)
);

CREATE TABLE DonHang (
    DonHangID INT PRIMARY KEY,
    KhachHangID INT,
    NgayDatHang DATE,
    TongTien FLOAT,
    FOREIGN KEY (KhachHangID) REFERENCES KhachHang(KhachHangID)
);

CREATE TABLE ChiTietDonHang (
    DonHangID INT,
    SanPhamID INT,
    SoLuong INT,
    FOREIGN KEY (DonHangID) REFERENCES DonHang(DonHangID),
    FOREIGN KEY (SanPhamID) REFERENCES SanPham(SanPhamID),
	PRIMARY KEY(DonHangID, SanPhamID)
);

CREATE TABLE NhanVien (
    NhanVienID INT PRIMARY KEY,
    TenNhanVien NVARCHAR(255),
    VaiTro NVARCHAR(50),
    TenDangNhap NVARCHAR(50),
    MatKhau NVARCHAR(255)
);


USE master;
ALTER DATABASE HasakiDatabase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE HasakiDatabase;
