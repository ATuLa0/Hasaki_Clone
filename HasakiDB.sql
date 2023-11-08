--Lệnh Xóa Mạnh nếu db bị lỗi
USE master;
ALTER DATABASE HasakiDatabase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE HasakiDatabase;

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
    Email VARCHAR(255),
    SoDienThoai VARCHAR(20),
    TenDangNhap VARCHAR(50),
    MatKhau VARCHAR(255)
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
    TenDangNhap VARCHAR(50),
    MatKhau VARCHAR(255)
);




-- Chèn dữ liệu vào bảng DanhMucSanPham
INSERT INTO DanhMucSanPham (DanhMucSanPhamID, TenDanhMuc, MoTa)
VALUES
(1, N'Chăm sóc da', N'Các sản phẩm chăm sóc da mặt và body chính hãng từ các thương hiệu uy tín trên thế giới'),
(2, N'Chăm sóc tóc', N'Các sản phẩm chăm sóc tóc chính hãng từ các thương hiệu uy tín trên thế giới'),
(3, N'Trang điểm', N'Các sản phẩm trang điểm chính hãng từ các thương hiệu uy tín trên thế giới'),
(4, N'Nước hoa', N'Các sản phẩm nước hoa chính hãng từ các thương hiệu uy tín trên thế giới'),
(5, N'Thực phẩm chức năng', N'Các sản phẩm thực phẩm chức năng chính hãng từ các thương hiệu uy tín trên thế giới');

-- Chèn dữ liệu vào bảng ThuongHieu
INSERT INTO ThuongHieu (ThuongHieuID, TenThuongHieu, MoTa)
VALUES
(1, N'La Roche-Posay', N'La Roche-Posay là thương hiệu dược mỹ phẩm hàng đầu thế giới, chuyên về các sản phẩm chăm sóc da dành cho da nhạy cảm và da mụn.'),
(2, N'CeraVe', N'CeraVe là thương hiệu dược mỹ phẩm hàng đầu thế giới, chuyên về các sản phẩm chăm sóc da dành cho da khô và da nhạy cảm.'),
(3, N'Innisfree', N'Innisfree là thương hiệu mỹ phẩm thiên nhiên hàng đầu Hàn Quốc, chuyên về các sản phẩm chăm sóc da và trang điểm được chiết xuất từ các thành phần tự nhiên.'),
(4, N'Mamonde', N'Mamonde là thương hiệu mỹ phẩm thiên nhiên hàng đầu Hàn Quốc, chuyên về các sản phẩm chăm sóc da và trang điểm được chiết xuất từ các thành phần tự nhiên.'),
(5, N'Hada Labo', N'Hada Labo là thương hiệu mỹ phẩm Nhật Bản, chuyên về các sản phẩm chăm sóc da dành cho da khô và da nhạy cảm');

INSERT INTO SanPham (SanPhamID, TenSanPham, HinhAnh, MoTa, Gia, DungTich, ThuongHieu, XuatXu, LoaiDaPhuHop, DoPH, CongDung, ThanhPhanChinh, CachSuDung, LuuY, ThuongHieuID)
VALUES
(2, N'Kem chống nắng Anessa Perfect UV Sunscreen Skincare Milk SPF50+ PA++++', 'https://hasaki.vn/uploads/files/20230808/anessa-perfect-uv-sunscreen-skincare-milk-spf50-pa++++.jpg', N'Kem chống nắng hóa học Anessa Perfect UV Sunscreen Skincare Milk SPF50+ PA++++ là sản phẩm chống nắng phổ rộng, bảo vệ da khỏi tác hại của tia UVA, UVB, tia hồng ngoại và ô nhiễm môi trường, đồng thời chống oxy hóa, ngăn ngừa lão hóa da và duy trì độ ẩm cho da.', 750000, '60ml', N'Anessa', N'Nhật Bản', N'Mọi loại da', 5.5, N'Chống nắng phổ rộng, bảo vệ da khỏi tác hại của tia UVA, UVB, tia hồng ngoại và ô nhiễm môi trường.', N'Tinosorb S, Uvinul A Plus, Titanium Dioxide', N'Lấy một lượng kem vừa đủ ra lòng bàn tay, thoa đều lên mặt và cổ trước khi ra ngoài 20 phút.', N'Bảo quản nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp.', 2),
(3, N'Kem chống nắng hóa học Klairs Midday UV Protection Cream SPF50+ PA++++', 'https://hasaki.vn/uploads/files/20230808/klairs-midday-uv-protection-cream-spf50-pa++++.jpg', N'Kem chống nắng hóa học Klairs Midday UV Protection Cream SPF50+ PA++++ là sản phẩm chống nắng phổ rộng, bảo vệ da khỏi tác hại của tia UVA, UVB, tia hồng ngoại và ô nhiễm môi trường, đồng thời cung cấp độ ẩm, giúp da mềm mịn.', 650000, '50ml', N'Klairs', N'Hàn Quốc', N'Da khô, da nhạy cảm', 5.5, N'Chống nắng phổ rộng, bảo vệ da khỏi tác hại của tia UVA, UVB, tia hồng ngoại và ô nhiễm môi trường.', N'Tinosorb S, Uvinul A Plus, Titanium Dioxide', N'Lấy một lượng kem vừa đủ ra lòng bàn tay, thoa đều lên da mặt sau khi rửa mặt và toner.', N'Bảo quản nơi khô ráo, thoáng mát, tránh ánh nắng trực tiếp.', 3),
(4, N'Serum trị mụn Acnes Scar Care Serum', 'https://hasaki.vn/uploads/files/20230808/acnes-scar-care-serum.jpg', N'Serum trị mụn Acnes Scar Care Serum là sản phẩm giúp giảm mụn, giảm thâm mụn và kích thích tái tạo da, giúp da sáng mịn.', 350000, '30ml', N'Acnes', N'Việt Nam', N'Da mụn, da thâm mụn', 5.5, N'Giảm mụn, giảm thâm mụn và kích thích tái tạo da, giúp da sáng mịn.', N'Niacinamide, Tranexamic Acid', N'Lấy một lượng serum vừa đủ ra lòng bàn tay, thoa đều lên da mặt sau khi rửa mặt và toner.', N'Tránh tiếp xúc với mắt. Nếu sản phẩm dính vào mắt, hãy rửa sạch ngay với nước.', 4);

-- Chèn dữ liệu vào bảng SanPhamDanhMuc
INSERT INTO SanPhamDanhMuc (SanPhamID, DanhMucSanPhamID)
VALUES
(2, 1),
(3, 1),
(4, 2),
(2, 2),
(3, 3),
(4, 3),
(2, 4),
(4, 4),
(3, 5);

-- Chèn dữ liệu vào bảng DichVu
INSERT INTO DichVu (DichVuID, TenDichVu, MoTa, Gia)
VALUES
(1, N'Tẩy trang', N'Dịch vụ tẩy trang chuyên nghiệp giúp loại bỏ hoàn toàn bụi bẩn, dầu thừa và lớp trang điểm trên da, mang lại làn da sạch sẽ và thông thoáng.', 200000),
(2, N'Đắp mặt nạ', N'Dịch vụ đắp mặt nạ chuyên nghiệp giúp cung cấp dưỡng chất và phục hồi làn da, mang lại làn da tươi trẻ và rạng rỡ.', 300000),
(3, N'Massage mặt', N'Dịch vụ massage mặt chuyên nghiệp giúp thư giãn cơ mặt, giảm căng thẳng và cải thiện tuần hoàn máu, mang lại làn da tươi trẻ và rạng rỡ.', 400000);

-- Chèn dữ liệu vào bảng PhieuQuaTang
INSERT INTO PhieuQuaTang (PhieuQuaTangID, KhachHangID, MaGiamGia)
VALUES
(1, 1, 'HASAKI2023'),
(2, 2, 'HASAKI2023'),
(3, 3, 'HASAKI2023');

-- Chèn dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (KhachHangID, TenKhachHang, Email, SoDienThoai, TenDangNhap, MatKhau)
VALUES
(1, N'Nguyễn Văn A', 'nguyenvana@email.com', '1234567890', 'nguyenvana', '15E2B0D3C33891EBB0F1EF609EC419420C20E320CE94C65FBC8C3312448EB225'),
(2, N'Trần Thị B', 'tranthib@email.com', '0987654321', 'tranthib', '15E2B0D3C33891EBB0F1EF609EC419420C20E320CE94C65FBC8C3312448EB225'),
(3, N'Lê Văn C', 'levanc@email.com', '1111111111', 'levanc', '15E2B0D3C33891EBB0F1EF609EC419420C20E320CE94C65FBC8C3312448EB225');


-- Chèn dữ liệu vào bảng DonHang
INSERT INTO DonHang (DonHangID, KhachHangID, NgayDatHang, TongTien)
VALUES
(1, 1, '2023-08-08', 1000000),
(2, 2, '2023-08-09', 2000000),
(3, 3, '2023-08-10', 3000000);

-- Chèn dữ liệu vào bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (DonHangID, SanPhamID, SoLuong)
VALUES
(1, 3, 2),
(1, 2, 1),
(2, 3, 3),
(2, 2, 1),
(3, 2, 1),
(3, 3, 2);

INSERT INTO NhanVien (NhanVienID, TenNhanVien, VaiTro, TenDangNhap, MatKhau)
VALUES
(1, 'Nguyễn Văn A', 'Quản lý', 'nvana', '123456'),
(2, 'Trần Thị B', 'Nhân viên bán hàng', 'ttbb', '123456'),
(3, 'Lê Quang C', 'Nhân viên giao hàng', 'lqc', '123456');
