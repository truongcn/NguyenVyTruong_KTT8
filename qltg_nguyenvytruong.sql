
-- Tạo bảng BUUCUC
CREATE TABLE BUUCUC (
    MaBuuCuc CHAR(10) PRIMARY KEY,
    TenBuuCuc NVARCHAR2(50) NOT NULL,
    Diachi NVARCHAR2(50) NOT NULL,
    DienThoai CHAR(15) NOT NULL,
    TinhTP NVARCHAR2(50) NOT NULL
);

-- Tạo bảng TAIKHOAN
CREATE TABLE TAIKHOAN (
    MaTK CHAR(10) PRIMARY KEY,
    HotenKH NVARCHAR2(50) NOT NULL,
    Diachi NVARCHAR2(50) NOT NULL,
    CCCD CHAR(15) UNIQUE NOT NULL,
    MaBuuCuc CHAR(10) NOT NULL,
    NgaymoTK DATE,
    CONSTRAINT FK_TAIKHOAN_BUUCUC FOREIGN KEY (MaBuuCuc) REFERENCES BUUCUC(MaBuuCuc)
);

-- Tạo bảng GIAODICH
CREATE TABLE GIAODICH (
    MaGD CHAR(10) PRIMARY KEY,
    MaTK CHAR(10) NOT NULL,
    MaBuuCuc CHAR(10) NOT NULL,
    NgayGD DATE NOT NULL,
    Sotien INT CHECK (Sotien > 50000) NOT NULL,
    HinhthucGD NVARCHAR2(50) NOT NULL,
    CONSTRAINT FK_GIAODICH_TAIKHOAN FOREIGN KEY (MaTK) REFERENCES TAIKHOAN(MaTK),
    CONSTRAINT FK_GIAODICH_BUUCUC FOREIGN KEY (MaBuuCuc) REFERENCES BUUCUC(MaBuuCuc)
);

-- Nhập dữ liệu vào bảng BUUCUC
INSERT INTO BUUCUC VALUES ('BC01', 'Bưu Cục Cầu Giấy', 'Cầu Giấy', '0328793300', 'Hà Nội');
INSERT INTO BUUCUC VALUES ('BC02', 'Bưu Cục Lê Hồng Phong', 'Lê Hồng Phong', '0328793300', 'Hà Nam');
INSERT INTO BUUCUC VALUES ('BC03', 'Bưu Cục Xuân Trường', 'Xuân Trường', '0328793300', 'Nam Định');
INSERT INTO BUUCUC VALUES ('BC04', 'Bưu Cục Hà Đông', 'Hà Đông', '0328793300', 'Hà Nội');

-- Nhập dữ liệu vào bảng TAIKHOAN
INSERT INTO TAIKHOAN (MaTK, HotenKH, Diachi, CCCD, MaBuuCuc, NgaymoTK) VALUES ('TK01', 'Tống Lan Anh', 'Hà Nội', '035186000123', 'BC01', TO_DATE('2019-08-10', 'YYYY-MM-DD'));
INSERT INTO TAIKHOAN (MaTK, HotenKH, Diachi, CCCD, MaBuuCuc, NgaymoTK) VALUES ('TK02', 'Nguyễn Minh Khang', 'Hà Nam', '035186000121', 'BC02', TO_DATE('2020-09-15', 'YYYY-MM-DD'));
INSERT INTO TAIKHOAN (MaTK, HotenKH, Diachi, CCCD, MaBuuCuc, NgaymoTK) VALUES ('TK03', 'Lê Minh Anh', 'Nam Định', '035186000124', 'BC03', TO_DATE('2015-06-10', 'YYYY-MM-DD'));
INSERT INTO TAIKHOAN (MaTK, HotenKH, Diachi, CCCD, MaBuuCuc, NgaymoTK) VALUES ('TK04', 'Trần Văn Nam', 'Hà Nội', '035186000125', 'BC01', TO_DATE('2021-08-18', 'YYYY-MM-DD'));

-- Nhập dữ liệu vào bảng GIAODICH
INSERT INTO GIAODICH (MaGD, MaTK, MaBuuCuc, NgayGD, Sotien, HinhthucGD) VALUES ('GD01', 'TK01', 'BC01', TO_DATE('2022-09-15', 'YYYY-MM-DD'), 10000000, 'Tiền mặt');
INSERT INTO GIAODICH (MaGD, MaTK, MaBuuCuc, NgayGD, Sotien, HinhthucGD) VALUES ('GD02', 'TK01', 'BC02', TO_DATE('2022-08-10', 'YYYY-MM-DD'), 2000000, 'Chuyển khoản');
INSERT INTO GIAODICH (MaGD, MaTK, MaBuuCuc, NgayGD, Sotien, HinhthucGD) VALUES ('GD03', 'TK02', 'BC03', TO_DATE('2022-10-11', 'YYYY-MM-DD'), 15000000, 'Tiền mặt');
INSERT INTO GIAODICH (MaGD, MaTK, MaBuuCuc, NgayGD, Sotien, HinhthucGD) VALUES ('GD04', 'TK03', 'BC02', TO_DATE('2022-08-20', 'YYYY-MM-DD'), 10000000, 'Chuyển khoản');



--3. Hiển thị danh sách các giao dịch có số tiền gửi lớn hơn 15.000.000
SELECT * FROM GIAODICH  
WHERE Sotien > 10000000;
--4. Danh sách giao dịch tại Bưu cục Cầu Giấy bằng hình thức tiền mặt
SELECT GD.MaGD, TK.HotenKH, BC.TenBuuCuc, GD.Sotien, GD.HinhthucGD  
FROM GIAODICH GD  
JOIN TAIKHOAN TK ON GD.MaTK = TK.MaTK  
JOIN BUUCUC BC ON GD.MaBuuCuc = BC.MaBuuCuc  
WHERE BC.TenBuuCuc = 'Bưu Cục Cầu Giấy'  
AND GD.HinhthucGD = 'Tiền mặt'  
ORDER BY GD.Sotien ASC;
