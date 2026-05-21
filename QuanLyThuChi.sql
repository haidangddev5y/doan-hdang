/* =========================================================
   DATABASE: QLTC_DaoHaiDang_12524_W1
   PROJECT : Ứng dụng quản lý thu chi cá nhân
   AUTHOR  : Đào Hải Đăng
========================================================= */

CREATE DATABASE QLTC_DaoHaiDang_12524_W1;
GO

USE QLTC_DaoHaiDang_12524_W1;
GO


/* =========================================================
   1. CREATE TABLES
========================================================= */

-- ===================== TÀI KHOẢN =====================

CREATE TABLE TaiKhoan
(
    MaTK INT IDENTITY(1,1) PRIMARY KEY,

    TenDangNhap NVARCHAR(50)  NOT NULL,
    MatKhau     NVARCHAR(100) NOT NULL,
    Email       NVARCHAR(100) NULL,
    SoDienThoai NVARCHAR(15)  NULL,
    VaiTro      NVARCHAR(20)  NOT NULL DEFAULT N'User',

    CONSTRAINT UQ_TaiKhoan_TenDangNhap UNIQUE (TenDangNhap),
    CONSTRAINT UQ_TaiKhoan_Email        UNIQUE (Email),
    CONSTRAINT UQ_TaiKhoan_SoDienThoai  UNIQUE (SoDienThoai),
    CONSTRAINT CK_TaiKhoan_VaiTro       CHECK (VaiTro IN (N'User', N'Admin'))
);
GO


-- ===================== VÍ TIỀN =====================

CREATE TABLE ViTien
(
    MaVi INT IDENTITY(1,1) PRIMARY KEY,

    TenVi  NVARCHAR(100)  NOT NULL,
    SoDu   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(255)  NULL,
    MaTK   INT            NOT NULL,

    CONSTRAINT CK_ViTien_SoDu          CHECK (SoDu >= 0),
    CONSTRAINT FK_ViTien_TaiKhoan      FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK),
    CONSTRAINT UQ_ViTien_TenVi_MaTK    UNIQUE (TenVi, MaTK)
);
GO


-- ===================== DANH MỤC =====================

CREATE TABLE DanhMuc
(
    MaDM INT IDENTITY(1,1) PRIMARY KEY,

    TenDM  NVARCHAR(100) NOT NULL,
    GhiChu NVARCHAR(255) NULL,
    LoaiDM INT           NOT NULL,
    MaTK   INT           NOT NULL,

    CONSTRAINT CK_DanhMuc_LoaiDM       CHECK (LoaiDM IN (0,1)),
    CONSTRAINT FK_DanhMuc_TaiKhoan     FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK),
    CONSTRAINT UQ_DanhMuc_Ten_Loai_TK  UNIQUE (TenDM, LoaiDM, MaTK)
);
GO


-- ===================== GIAO DỊCH =====================

CREATE TABLE GiaoDich
(
    MaGD INT IDENTITY(1,1) PRIMARY KEY,

    SoTien  DECIMAL(18,2) NOT NULL,
    Ngay    DATE          NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    NoiDung NVARCHAR(255) NULL,
    Loai    INT           NOT NULL,
    MaDM    INT           NOT NULL,
    MaVi    INT           NOT NULL,

    CONSTRAINT CK_GiaoDich_SoTien    CHECK (SoTien > 0),
    CONSTRAINT CK_GiaoDich_Loai      CHECK (Loai IN (0,1)),
    CONSTRAINT FK_GiaoDich_DanhMuc   FOREIGN KEY (MaDM) REFERENCES DanhMuc(MaDM),
    CONSTRAINT FK_GiaoDich_ViTien    FOREIGN KEY (MaVi) REFERENCES ViTien(MaVi)
);
GO


-- ===================== NGÂN SÁCH =====================

CREATE TABLE NganSach
(
    MaNS INT IDENTITY(1,1) PRIMARY KEY,

    GioiHan DECIMAL(18,2) NOT NULL,
    Thang   INT           NOT NULL,
    Nam     INT           NOT NULL,
    MaDM    INT           NOT NULL,
    MaTK    INT           NOT NULL,

    CONSTRAINT CK_NganSach_GioiHan  CHECK (GioiHan > 0),
    CONSTRAINT CK_NganSach_Thang    CHECK (Thang BETWEEN 1 AND 12),
    CONSTRAINT CK_NganSach_Nam      CHECK (Nam BETWEEN 2000 AND 2100),
    CONSTRAINT FK_NganSach_DanhMuc  FOREIGN KEY (MaDM) REFERENCES DanhMuc(MaDM),
    CONSTRAINT FK_NganSach_TaiKhoan FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK),
    CONSTRAINT UQ_NganSach          UNIQUE (MaTK, MaDM, Thang, Nam)
);
GO


/* =========================================================
   2. ACCOUNT / LOGIN PROCEDURES
========================================================= */

-- ===================== ĐĂNG NHẬP =====================

CREATE PROC sp_DangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau     NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaTK,
        TenDangNhap,
        VaiTro
    FROM TaiKhoan
    WHERE LOWER(LTRIM(RTRIM(TenDangNhap))) = LOWER(LTRIM(RTRIM(@TenDangNhap)))
      AND MatKhau = @MatKhau;
END
GO


-- ===================== ĐĂNG KÝ =====================

CREATE PROC sp_DangKy
    @TenDangNhap NVARCHAR(50),
    @MatKhau     NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SET @TenDangNhap = LOWER(LTRIM(RTRIM(@TenDangNhap)));

    IF EXISTS
    (
        SELECT 1
        FROM TaiKhoan
        WHERE LOWER(LTRIM(RTRIM(TenDangNhap))) = @TenDangNhap
    )
    BEGIN
        SELECT -1 AS Result;
        RETURN;
    END

    INSERT INTO TaiKhoan(TenDangNhap, MatKhau, VaiTro)
    VALUES (@TenDangNhap, @MatKhau, N'User');

    SELECT 1 AS Result;
END
GO


-- ===================== LOAD TÀI KHOẢN =====================

CREATE PROC sp_LoadTaiKhoan
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaTK,
        TenDangNhap,
        MatKhau,
        VaiTro
    FROM TaiKhoan
    ORDER BY MaTK DESC;
END
GO


-- ===================== CHECK TRÙNG TÊN ĐĂNG NHẬP =====================

CREATE PROC sp_CheckTenDN
    @TenDN NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM TaiKhoan
    WHERE LOWER(LTRIM(RTRIM(TenDangNhap))) = LOWER(LTRIM(RTRIM(@TenDN)));
END
GO


-- ===================== THÊM TÀI KHOẢN =====================

CREATE PROC sp_ThemTaiKhoan
    @TenDN  NVARCHAR(50),
    @MatKhau NVARCHAR(100),
    @VaiTro NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SET @TenDN = LOWER(LTRIM(RTRIM(@TenDN)));

    IF @VaiTro NOT IN (N'User', N'Admin')
    BEGIN
        RAISERROR(N'Vai trò không hợp lệ!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM TaiKhoan
        WHERE LOWER(LTRIM(RTRIM(TenDangNhap))) = @TenDN
    )
    BEGIN
        RAISERROR(N'Tên đăng nhập đã tồn tại!', 16, 1);
        RETURN;
    END

    INSERT INTO TaiKhoan(TenDangNhap, MatKhau, VaiTro)
    VALUES (@TenDN, @MatKhau, @VaiTro);
END
GO


-- ===================== SỬA TÀI KHOẢN =====================

CREATE PROC sp_SuaTaiKhoan
    @MaTK    INT,
    @MatKhau NVARCHAR(100),
    @VaiTro  NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = @MaTK)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        RETURN;
    END

    IF @VaiTro NOT IN (N'User', N'Admin')
    BEGIN
        RAISERROR(N'Vai trò không hợp lệ!', 16, 1);
        RETURN;
    END

    UPDATE TaiKhoan
    SET 
        MatKhau = @MatKhau,
        VaiTro  = @VaiTro
    WHERE MaTK = @MaTK;
END
GO


-- ===================== XÓA TÀI KHOẢN =====================

CREATE PROC sp_XoaTaiKhoan
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = @MaTK)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM GiaoDich gd
        JOIN ViTien vt ON gd.MaVi = vt.MaVi
        WHERE vt.MaTK = @MaTK
    )
    BEGIN
        RAISERROR(N'Không thể xóa tài khoản đã có giao dịch!', 16, 1);
        RETURN;
    END

    DELETE FROM NganSach WHERE MaTK = @MaTK;
    DELETE FROM DanhMuc  WHERE MaTK = @MaTK;
    DELETE FROM ViTien   WHERE MaTK = @MaTK;
    DELETE FROM TaiKhoan WHERE MaTK = @MaTK;
END
GO


-- ===================== TÌM TÀI KHOẢN =====================

CREATE PROC sp_TimTaiKhoan
    @TenDN NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaTK,
        TenDangNhap,
        MatKhau,
        VaiTro
    FROM TaiKhoan
    WHERE TenDangNhap LIKE N'%' + @TenDN + N'%'
    ORDER BY MaTK DESC;
END
GO


-- ===================== LOAD THÔNG TIN CÁ NHÂN =====================

CREATE PROC sp_LoadThongTinTK
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        TenDangNhap,
        Email,
        SoDienThoai,
        TenDangNhap AS HoTen
    FROM TaiKhoan
    WHERE MaTK = @MaTK;
END
GO


-- ===================== CẬP NHẬT THÔNG TIN CÁ NHÂN =====================

CREATE PROC sp_CapNhatThongTinTK
    @MaTK  INT,
    @Email NVARCHAR(100),
    @SDT   NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = @MaTK)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        RETURN;
    END

    IF @Email IS NOT NULL AND LTRIM(RTRIM(@Email)) <> N''
    BEGIN
        IF EXISTS (SELECT 1 FROM TaiKhoan WHERE Email = @Email AND MaTK <> @MaTK)
        BEGIN
            RAISERROR(N'Email đã tồn tại!', 16, 1);
            RETURN;
        END
    END

    IF @SDT IS NOT NULL AND LTRIM(RTRIM(@SDT)) <> N''
    BEGIN
        IF EXISTS (SELECT 1 FROM TaiKhoan WHERE SoDienThoai = @SDT AND MaTK <> @MaTK)
        BEGIN
            RAISERROR(N'Số điện thoại đã tồn tại!', 16, 1);
            RETURN;
        END
    END

    UPDATE TaiKhoan
    SET 
        Email       = NULLIF(LTRIM(RTRIM(@Email)), N''),
        SoDienThoai = NULLIF(LTRIM(RTRIM(@SDT)), N'')
    WHERE MaTK = @MaTK;
END
GO


/* =========================================================
   3. CATEGORY PROCEDURES
========================================================= */

-- ===================== LOAD DANH MỤC =====================

CREATE PROC sp_LoadDanhMuc
    @Loai INT,
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaDM,
        TenDM,
        LoaiDM,
        CASE 
            WHEN LoaiDM = 1 THEN N'Thu'
            ELSE N'Chi'
        END AS loai,
        GhiChu
    FROM DanhMuc
    WHERE MaTK = @MaTK
      AND (@Loai = -1 OR LoaiDM = @Loai)
    ORDER BY LoaiDM DESC, TenDM;
END
GO


-- ===================== LOAD TẤT CẢ DANH MỤC =====================

CREATE PROC sp_LoadTatCaDanhMuc
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaDM,
        TenDM,
        LoaiDM,
        CASE 
            WHEN LoaiDM = 1 THEN N'Thu'
            ELSE N'Chi'
        END AS loai,
        GhiChu
    FROM DanhMuc
    WHERE MaTK = @MaTK
    ORDER BY LoaiDM DESC, TenDM;
END
GO


-- ===================== LOAD DANH MỤC CHI =====================

CREATE PROC sp_LoadDanhMucChi
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaDM,
        TenDM
    FROM DanhMuc
    WHERE LoaiDM = 0 
      AND MaTK = @MaTK
    ORDER BY TenDM;
END
GO


-- ===================== CHECK TRÙNG DANH MỤC =====================

CREATE PROC sp_CheckTrungDanhMuc
    @TenDM NVARCHAR(100),
    @MaTK  INT,
    @MaDM  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM DanhMuc
    WHERE LOWER(LTRIM(RTRIM(TenDM))) = LOWER(LTRIM(RTRIM(@TenDM)))
      AND MaTK = @MaTK
      AND (@MaDM IS NULL OR MaDM <> @MaDM);
END
GO


-- ===================== THÊM DANH MỤC =====================

CREATE PROC sp_ThemDanhMuc
    @TenDM  NVARCHAR(100),
    @LoaiDM INT,
    @GhiChu NVARCHAR(255),
    @MaTK   INT
AS
BEGIN
    SET NOCOUNT ON;

    SET @TenDM = LOWER(LTRIM(RTRIM(@TenDM)));

    IF @TenDM = N''
    BEGIN
        RAISERROR(N'Tên danh mục không được trống!', 16, 1);
        RETURN;
    END

    IF @LoaiDM NOT IN (0,1)
    BEGIN
        RAISERROR(N'Loại danh mục không hợp lệ!', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = @MaTK)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM DanhMuc
        WHERE LOWER(LTRIM(RTRIM(TenDM))) = @TenDM
          AND LoaiDM = @LoaiDM
          AND MaTK = @MaTK
    )
    BEGIN
        RAISERROR(N'Danh mục đã tồn tại!', 16, 1);
        RETURN;
    END

    INSERT INTO DanhMuc(TenDM, LoaiDM, GhiChu, MaTK)
    VALUES (@TenDM, @LoaiDM, @GhiChu, @MaTK);
END
GO


-- ===================== SỬA DANH MỤC =====================

CREATE PROC sp_SuaDanhMuc
    @MaDM   INT,
    @TenDM  NVARCHAR(100),
    @LoaiDM INT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM DanhMuc WHERE MaDM = @MaDM)
    BEGIN
        SELECT 0 AS Result, N'Danh mục không tồn tại!' AS Message;
        RETURN;
    END

    SET @TenDM = LOWER(LTRIM(RTRIM(@TenDM)));

    IF @TenDM = N''
    BEGIN
        SELECT 0 AS Result, N'Tên danh mục không được trống!' AS Message;
        RETURN;
    END

    IF @LoaiDM NOT IN (0,1)
    BEGIN
        SELECT 0 AS Result, N'Loại danh mục không hợp lệ!' AS Message;
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM DanhMuc
        WHERE LOWER(LTRIM(RTRIM(TenDM))) = @TenDM
          AND LoaiDM = @LoaiDM
          AND MaTK = (SELECT MaTK FROM DanhMuc WHERE MaDM = @MaDM)
          AND MaDM <> @MaDM
    )
    BEGIN
        SELECT 0 AS Result, N'Tên danh mục đã tồn tại!' AS Message;
        RETURN;
    END

    UPDATE DanhMuc
    SET 
        TenDM  = @TenDM,
        LoaiDM = @LoaiDM,
        GhiChu = @GhiChu
    WHERE MaDM = @MaDM;

    SELECT 1 AS Result, N'Cập nhật thành công!' AS Message;
END
GO


-- ===================== XÓA DANH MỤC =====================

CREATE PROC sp_XoaDanhMuc
    @MaDM INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM GiaoDich WHERE MaDM = @MaDM)
    BEGIN
        RAISERROR(N'Danh mục đã có giao dịch!', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM NganSach WHERE MaDM = @MaDM)
    BEGIN
        RAISERROR(N'Danh mục đã có ngân sách!', 16, 1);
        RETURN;
    END

    DELETE FROM DanhMuc
    WHERE MaDM = @MaDM;
END
GO


/* =========================================================
   4. WALLET PROCEDURES
========================================================= */

-- ===================== LOAD VÍ =====================

CREATE PROC sp_LoadVi
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MaVi,
        TenVi,
        SoDu,
        GhiChu
    FROM ViTien
    WHERE MaTK = @MaTK
    ORDER BY MaVi DESC;
END
GO


-- ===================== LẤY SỐ DƯ VÍ =====================

CREATE PROC sp_GetSoDuVi
    @MaVi INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT SoDu
    FROM ViTien
    WHERE MaVi = @MaVi;
END
GO


-- ===================== THÊM VÍ TIỀN =====================

CREATE PROC sp_ThemViTien
    @TenVi  NVARCHAR(100),
    @SoDu   DECIMAL(18,2),
    @GhiChu NVARCHAR(255),
    @MaTK   INT
AS
BEGIN
    SET NOCOUNT ON;

    SET @TenVi = LTRIM(RTRIM(@TenVi));

    IF @TenVi = N''
    BEGIN
        RAISERROR(N'Tên ví không được trống!', 16, 1);
        RETURN;
    END

    IF @SoDu < 0
    BEGIN
        RAISERROR(N'Số dư không hợp lệ!', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE MaTK = @MaTK)
    BEGIN
        RAISERROR(N'Tài khoản không tồn tại!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM ViTien
        WHERE LOWER(LTRIM(RTRIM(TenVi))) = LOWER(@TenVi)
          AND MaTK = @MaTK
    )
    BEGIN
        RAISERROR(N'Tên ví đã tồn tại!', 16, 1);
        RETURN;
    END

    INSERT INTO ViTien(TenVi, SoDu, GhiChu, MaTK)
    VALUES (@TenVi, @SoDu, @GhiChu, @MaTK);
END
GO
-- ===================== SỬA VÍ TIỀN =====================

CREATE PROC sp_SuaViTien
    @MaVi   INT,
    @TenVi  NVARCHAR(100),
    @SoDu   DECIMAL(18,2),
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SET @TenVi = LTRIM(RTRIM(@TenVi));

    IF NOT EXISTS (SELECT 1 FROM ViTien WHERE MaVi = @MaVi)
    BEGIN
        RAISERROR(N'Ví không tồn tại!', 16, 1);
        RETURN;
    END

    IF @TenVi = N''
    BEGIN
        RAISERROR(N'Tên ví không được trống!', 16, 1);
        RETURN;
    END

    IF @SoDu < 0
    BEGIN
        RAISERROR(N'Số dư không hợp lệ!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM ViTien
        WHERE LOWER(LTRIM(RTRIM(TenVi))) = LOWER(@TenVi)
          AND MaTK = (SELECT MaTK FROM ViTien WHERE MaVi = @MaVi)
          AND MaVi <> @MaVi
    )
    BEGIN
        RAISERROR(N'Tên ví đã tồn tại!', 16, 1);
        RETURN;
    END

    UPDATE ViTien
    SET 
        TenVi = @TenVi,
        SoDu = @SoDu,
        GhiChu = @GhiChu
    WHERE MaVi = @MaVi;
END
GO


-- ===================== XÓA VÍ TIỀN =====================

CREATE PROC sp_XoaViTien
    @MaVi INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM GiaoDich WHERE MaVi = @MaVi)
    BEGIN
        RAISERROR(N'Ví đã có giao dịch, không thể xóa!', 16, 1);
        RETURN;
    END

    DELETE FROM ViTien
    WHERE MaVi = @MaVi;
END
GO


/* =========================================================
   5. TRANSACTION PROCEDURES
========================================================= */

-- ===================== THÊM GIAO DỊCH =====================

CREATE PROC sp_ThemGiaoDich
    @SoTien  DECIMAL(18,2),
    @Ngay    DATE,
    @NoiDung NVARCHAR(255),
    @Loai    INT,
    @MaDM    INT,
    @MaVi    INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF @SoTien <= 0
        BEGIN
            RAISERROR(N'Số tiền phải lớn hơn 0!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @Loai NOT IN (0, 1)
        BEGIN
            RAISERROR(N'Loại giao dịch không hợp lệ!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF NOT EXISTS
        (
            SELECT 1
            FROM DanhMuc dm
            JOIN ViTien vt ON dm.MaTK = vt.MaTK
            WHERE dm.MaDM = @MaDM
              AND vt.MaVi = @MaVi
              AND dm.LoaiDM = @Loai
        )
        BEGIN
            RAISERROR(N'Danh mục không hợp lệ hoặc không cùng tài khoản với ví!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        DECLARE @SoDu DECIMAL(18,2);

        SELECT @SoDu = SoDu
        FROM ViTien WITH (UPDLOCK, ROWLOCK)
        WHERE MaVi = @MaVi;

        IF @SoDu IS NULL
        BEGIN
            RAISERROR(N'Ví không tồn tại!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        IF @Loai = 0 AND @SoDu < @SoTien
        BEGIN
            RAISERROR(N'Số dư ví không đủ!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO GiaoDich(SoTien, Ngay, NoiDung, Loai, MaDM, MaVi)
        VALUES (@SoTien, @Ngay, @NoiDung, @Loai, @MaDM, @MaVi);

        IF @Loai = 1
        BEGIN
            UPDATE ViTien
            SET SoDu = SoDu + @SoTien
            WHERE MaVi = @MaVi;
        END
        ELSE
        BEGIN
            UPDATE ViTien
            SET SoDu = SoDu - @SoTien
            WHERE MaVi = @MaVi;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END
GO


-- ===================== LOAD GIAO DỊCH =====================

CREATE PROC sp_LoadGiaoDich
    @TuNgay DATE,
    @DenNgay DATE,
    @Loai   INT = -1,
    @MaVi   INT = -1,
    @MaTK   INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        gd.MaGD,
        gd.Ngay,
        gd.NoiDung,
        CASE 
            WHEN gd.Loai = 1 THEN N'Thu'
            ELSE N'Chi'
        END AS Loai,
        dm.TenDM AS danhMuc,
        vt.TenVi AS vi,
        gd.SoTien
    FROM GiaoDich gd
    JOIN DanhMuc dm ON gd.MaDM = dm.MaDM
    JOIN ViTien vt ON gd.MaVi = vt.MaVi
    WHERE vt.MaTK = @MaTK
      AND gd.Ngay BETWEEN @TuNgay AND @DenNgay
      AND (@Loai = -1 OR gd.Loai = @Loai)
      AND (@MaVi = -1 OR gd.MaVi = @MaVi)
    ORDER BY gd.Ngay DESC, gd.MaGD DESC;
END
GO


/* =========================================================
   6. BUDGET PROCEDURES
========================================================= */

-- ===================== CHECK TRÙNG NGÂN SÁCH =====================

CREATE PROC sp_CheckTrungNganSach
    @MaDM  INT,
    @Thang INT,
    @Nam   INT,
    @MaTK  INT,
    @MaNS  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*)
    FROM NganSach
    WHERE MaDM = @MaDM
      AND Thang = @Thang
      AND Nam = @Nam
      AND MaTK = @MaTK
      AND (@MaNS IS NULL OR MaNS <> @MaNS);
END
GO


-- ===================== THÊM NGÂN SÁCH =====================

CREATE PROC sp_ThemNganSach
    @MaDM    INT,
    @GioiHan DECIMAL(18,2),
    @Thang   INT,
    @Nam     INT,
    @MaTK    INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @GioiHan <= 0
    BEGIN
        RAISERROR(N'Giới hạn phải lớn hơn 0!', 16, 1);
        RETURN;
    END

    IF @Thang NOT BETWEEN 1 AND 12
    BEGIN
        RAISERROR(N'Tháng không hợp lệ!', 16, 1);
        RETURN;
    END

    IF @Nam NOT BETWEEN 2000 AND 2100
    BEGIN
        RAISERROR(N'Năm không hợp lệ!', 16, 1);
        RETURN;
    END

    IF NOT EXISTS
    (
        SELECT 1
        FROM DanhMuc
        WHERE MaDM = @MaDM
          AND MaTK = @MaTK
          AND LoaiDM = 0
    )
    BEGIN
        RAISERROR(N'Danh mục chi không hợp lệ!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM NganSach
        WHERE MaTK = @MaTK
          AND MaDM = @MaDM
          AND Thang = @Thang
          AND Nam = @Nam
    )
    BEGIN
        RAISERROR(N'Ngân sách này đã tồn tại!', 16, 1);
        RETURN;
    END

    INSERT INTO NganSach(MaDM, GioiHan, Thang, Nam, MaTK)
    VALUES (@MaDM, @GioiHan, @Thang, @Nam, @MaTK);
END
GO

-- ===================== SỬA NGÂN SÁCH =====================

CREATE PROC sp_SuaNganSach
    @MaNS    INT,
    @MaDM    INT,
    @GioiHan DECIMAL(18,2),
    @Thang   INT,
    @Nam     INT,
    @MaTK    INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM NganSach
        WHERE MaNS = @MaNS
          AND MaTK = @MaTK
    )
    BEGIN
        RAISERROR(N'Ngân sách không tồn tại!', 16, 1);
        RETURN;
    END

    IF @GioiHan <= 0
    BEGIN
        RAISERROR(N'Giới hạn không hợp lệ!', 16, 1);
        RETURN;
    END

    IF @Thang NOT BETWEEN 1 AND 12
    BEGIN
        RAISERROR(N'Tháng không hợp lệ!', 16, 1);
        RETURN;
    END

    IF @Nam NOT BETWEEN 2000 AND 2100
    BEGIN
        RAISERROR(N'Năm không hợp lệ!', 16, 1);
        RETURN;
    END

    IF NOT EXISTS
    (
        SELECT 1
        FROM DanhMuc
        WHERE MaDM = @MaDM
          AND MaTK = @MaTK
          AND LoaiDM = 0
    )
    BEGIN
        RAISERROR(N'Danh mục chi không hợp lệ!', 16, 1);
        RETURN;
    END

    IF EXISTS
    (
        SELECT 1
        FROM NganSach
        WHERE MaDM = @MaDM
          AND Thang = @Thang
          AND Nam = @Nam
          AND MaTK = @MaTK
          AND MaNS <> @MaNS
    )
    BEGIN
        RAISERROR(N'Trùng ngân sách!', 16, 1);
        RETURN;
    END

    UPDATE NganSach
    SET 
        MaDM = @MaDM,
        GioiHan = @GioiHan,
        Thang = @Thang,
        Nam = @Nam
    WHERE MaNS = @MaNS
      AND MaTK = @MaTK;
END
GO
-- ===================== XÓA NGÂN SÁCH =====================

CREATE PROC sp_XoaNganSach
    @MaNS INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM NganSach
    WHERE MaNS = @MaNS;
END
GO


-- ===================== LOAD NGÂN SÁCH =====================

CREATE PROC sp_LoadNganSach
    @MaTK  INT,
    @Thang INT = NULL,
    @Nam   INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ns.MaNS,
        dm.TenDM AS danhMuc,
        ns.GioiHan,
        ns.Thang,
        ns.Nam,
        ns.MaDM,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS Chi,

        ns.GioiHan - ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS conLai

    FROM NganSach ns
    JOIN DanhMuc dm 
        ON ns.MaDM = dm.MaDM

    LEFT JOIN GiaoDich gd 
        ON gd.MaDM = ns.MaDM
        AND MONTH(gd.Ngay) = ns.Thang
        AND YEAR(gd.Ngay) = ns.Nam
        AND gd.MaVi IN 
        (
            SELECT MaVi 
            FROM ViTien 
            WHERE MaTK = @MaTK
        )

    WHERE ns.MaTK = @MaTK
      AND (@Thang IS NULL OR ns.Thang = @Thang)
      AND (@Nam IS NULL OR ns.Nam = @Nam)

    GROUP BY
        ns.MaNS,
        dm.TenDM,
        ns.GioiHan,
        ns.Thang,
        ns.Nam,
        ns.MaDM

    ORDER BY 
        ns.Nam DESC,
        ns.Thang DESC,
        dm.TenDM;
END
GO


-- ===================== THỐNG KÊ NGÂN SÁCH =====================

CREATE PROC sp_ThongKeNganSach
    @MaTK  INT,
    @Thang INT,
    @Nam   INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dm.TenDM AS danhMuc,
        ns.GioiHan AS gioiHan,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS Chi,

        ns.GioiHan - ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS conLai

    FROM NganSach ns
    JOIN DanhMuc dm 
        ON ns.MaDM = dm.MaDM

    LEFT JOIN GiaoDich gd 
        ON gd.MaDM = ns.MaDM
        AND MONTH(gd.Ngay) = ns.Thang
        AND YEAR(gd.Ngay) = ns.Nam
        AND gd.MaVi IN 
        (
            SELECT MaVi 
            FROM ViTien 
            WHERE MaTK = @MaTK
        )

    WHERE ns.MaTK = @MaTK
      AND ns.Thang = @Thang
      AND ns.Nam = @Nam

    GROUP BY 
        dm.TenDM,
        ns.GioiHan;
END
GO


/* =========================================================
   7. REPORT PROCEDURES
========================================================= */

-- ===================== THỐNG KÊ THEO NGÀY =====================

CREATE PROC sp_ThongKeTheoNgay
    @Thang INT,
    @Nam   INT,
    @MaTK  INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        DAY(gd.Ngay) AS Ngay,

        SUM
        (
            CASE 
                WHEN gd.Loai = 1 THEN gd.SoTien 
                ELSE 0 
            END
        ) AS Thu,

        SUM
        (
            CASE 
                WHEN gd.Loai = 0 THEN gd.SoTien 
                ELSE 0 
            END
        ) AS Chi

    FROM GiaoDich gd
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE MONTH(gd.Ngay) = @Thang
      AND YEAR(gd.Ngay) = @Nam
      AND v.MaTK = @MaTK

    GROUP BY DAY(gd.Ngay)
    ORDER BY Ngay;
END
GO


-- ===================== THỐNG KÊ THEO THÁNG/NĂM - TẤT CẢ =====================

CREATE PROC sp_ThongKeTheoNgay_All
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CONVERT(VARCHAR(7), gd.Ngay, 120) AS ThangNam,

        SUM
        (
            CASE 
                WHEN gd.Loai = 1 THEN gd.SoTien 
                ELSE 0 
            END
        ) AS Thu,

        SUM
        (
            CASE 
                WHEN gd.Loai = 0 THEN gd.SoTien 
                ELSE 0 
            END
        ) AS Chi

    FROM GiaoDich gd
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE v.MaTK = @MaTK

    GROUP BY CONVERT(VARCHAR(7), gd.Ngay, 120)
    ORDER BY ThangNam;
END
GO


-- ===================== THỐNG KÊ CHI THEO DANH MỤC =====================

CREATE PROC sp_ThongKeDanhMuc
    @Thang INT,
    @Nam   INT,
    @MaTK  INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dm.TenDM,
        SUM(gd.SoTien) AS TongChi

    FROM GiaoDich gd
    JOIN DanhMuc dm 
        ON gd.MaDM = dm.MaDM
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE gd.Loai = 0
      AND MONTH(gd.Ngay) = @Thang
      AND YEAR(gd.Ngay) = @Nam
      AND v.MaTK = @MaTK

    GROUP BY dm.TenDM
    ORDER BY TongChi DESC;
END
GO


-- ===================== THỐNG KÊ CHI THEO DANH MỤC - TẤT CẢ =====================

CREATE PROC sp_ThongKeDanhMuc_All
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dm.TenDM,
        SUM(gd.SoTien) AS TongChi

    FROM GiaoDich gd
    JOIN DanhMuc dm 
        ON gd.MaDM = dm.MaDM
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE gd.Loai = 0
      AND v.MaTK = @MaTK

    GROUP BY dm.TenDM
    ORDER BY TongChi DESC;
END
GO


-- ===================== TỔNG THU CHI THEO THÁNG/NĂM =====================

CREATE PROC sp_TongThuChi
    @Thang INT,
    @Nam   INT,
    @MaTK  INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 1 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS TongThu,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS TongChi

    FROM GiaoDich gd
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE MONTH(gd.Ngay) = @Thang
      AND YEAR(gd.Ngay) = @Nam
      AND v.MaTK = @MaTK;
END
GO


-- ===================== TỔNG THU CHI - TẤT CẢ =====================

CREATE PROC sp_TongThuChi_All
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 1 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS TongThu,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS TongChi

    FROM GiaoDich gd
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE v.MaTK = @MaTK;
END
GO


/* =========================================================
   8. OVERVIEW PROCEDURES
========================================================= */

-- ===================== THU CHI 6 THÁNG GẦN NHẤT =====================

CREATE PROC sp_TQ_6ThangGanNhat
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        MONTH(gd.Ngay) AS ThangSo,
        YEAR(gd.Ngay) AS Nam,

        RIGHT('0' + CAST(MONTH(gd.Ngay) AS VARCHAR), 2)
        + '/'
        + CAST(YEAR(gd.Ngay) AS VARCHAR) AS Thang,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 1 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS Thu,

        ISNULL
        (
            SUM
            (
                CASE 
                    WHEN gd.Loai = 0 THEN gd.SoTien 
                    ELSE 0 
                END
            ), 
            0
        ) AS Chi

    FROM GiaoDich gd
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE v.MaTK = @MaTK
      AND gd.Ngay >= DATEADD(MONTH, -5, CAST(GETDATE() AS DATE))

    GROUP BY 
        MONTH(gd.Ngay),
        YEAR(gd.Ngay)

    ORDER BY 
        YEAR(gd.Ngay),
        MONTH(gd.Ngay);
END
GO


-- ===================== TỶ LỆ CHI THEO DANH MỤC =====================

CREATE PROC sp_TQ_TyLeDanhMuc
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dm.TenDM,
        SUM(gd.SoTien) AS TongChi

    FROM GiaoDich gd
    JOIN DanhMuc dm 
        ON gd.MaDM = dm.MaDM
    JOIN ViTien v 
        ON gd.MaVi = v.MaVi

    WHERE gd.Loai = 0
      AND v.MaTK = @MaTK

    GROUP BY dm.TenDM
    ORDER BY TongChi DESC;
END
GO


-- ===================== TỔNG QUAN TRANG CHỦ =====================

CREATE PROC sp_TQ_TongQuan
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ISNULL
        (
            (
                SELECT SUM(SoDu)
                FROM ViTien
                WHERE MaTK = @MaTK
            ), 
            0
        ) AS TongSoDu,

        ISNULL
        (
            (
                SELECT SUM(gd.SoTien)
                FROM GiaoDich gd
                JOIN ViTien v 
                    ON gd.MaVi = v.MaVi
                WHERE gd.Loai = 1
                  AND MONTH(gd.Ngay) = MONTH(GETDATE())
                  AND YEAR(gd.Ngay) = YEAR(GETDATE())
                  AND v.MaTK = @MaTK
            ), 
            0
        ) AS TongThuThang,

        ISNULL
        (
            (
                SELECT SUM(gd.SoTien)
                FROM GiaoDich gd
                JOIN ViTien v 
                    ON gd.MaVi = v.MaVi
                WHERE gd.Loai = 0
                  AND MONTH(gd.Ngay) = MONTH(GETDATE())
                  AND YEAR(gd.Ngay) = YEAR(GETDATE())
                  AND v.MaTK = @MaTK
            ), 
            0
        ) AS TongChiThang;
END
GO


-- ===================== GIAO DỊCH GẦN ĐÂY =====================

CREATE PROC sp_TQ_GiaoDichGanDay
    @MaTK INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 10
        gd.Ngay,
        gd.NoiDung,

        CASE 
            WHEN gd.Loai = 1 THEN N'Thu'
            ELSE N'Chi'
        END AS Loai,

        dm.TenDM AS danhMuc,
        vt.TenVi AS vi,
        gd.SoTien

    FROM GiaoDich gd
    JOIN DanhMuc dm 
        ON gd.MaDM = dm.MaDM
    JOIN ViTien vt 
        ON gd.MaVi = vt.MaVi

    WHERE vt.MaTK = @MaTK

    ORDER BY 
        gd.Ngay DESC,
        gd.MaGD DESC;
END
GO