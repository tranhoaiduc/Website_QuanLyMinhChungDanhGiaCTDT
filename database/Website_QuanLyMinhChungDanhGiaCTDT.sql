USE [Website_QuanLyMinhChungDanhGiaCTDT]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYROLE]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYROLE](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_IDENTITYROLE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYROLECLAIMS]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYROLECLAIMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_IDENTITYROLECLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYUSER]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYUSER](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [date] NULL,
	[Address] [nvarchar](500) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_IDENTITYUSER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYUSERCLAIMS]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYUSERCLAIMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_IDENTITYUSERCLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYUSERLOGIN]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYUSERLOGIN](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_IDENTITYUSERLOGIN] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYUSERROLE]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYUSERROLE](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_IDENTITYUSERROLE] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IDENTITYUSERTOKEN]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IDENTITYUSERTOKEN](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_IDENTITYUSERTOKEN] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MINHCHUNG]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MINHCHUNG](
	[MaMinhChung] [nvarchar](450) NOT NULL,
	[SoKyHieu] [varchar](200) NOT NULL,
	[TrichYeu] [nvarchar](max) NOT NULL,
	[CoQuanBanHanh] [nvarchar](200) NOT NULL,
	[NoiNhanCacVanBan] [nvarchar](200) NOT NULL,
	[NoiLuuBanChinh] [nvarchar](200) NOT NULL,
	[MucDo] [int] NOT NULL,
	[NguoiKyVanBan] [nvarchar](200) NOT NULL,
	[SoPhatHanh] [varchar](200) NOT NULL,
	[LinhVucVanBan] [nvarchar](200) NOT NULL,
	[LoaiVanBan] [nvarchar](200) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[NgayLuu] [date] NOT NULL,
	[MaNguoiTao] [varchar](200) NOT NULL,
	[MaTieuChi] [nvarchar](450) NULL,
	[MaTieuChuan] [nvarchar](450) NULL,
 CONSTRAINT [PK_MINHCHUNG] PRIMARY KEY CLUSTERED 
(
	[MaMinhChung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEPTIN]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEPTIN](
	[MaTepTin] [nvarchar](450) NOT NULL,
	[TenTepTin] [nvarchar](max) NOT NULL,
	[ThoiGianTao] [date] NOT NULL,
	[DuongDan] [nvarchar](max) NOT NULL,
	[MaTieuChi] [nvarchar](450) NULL,
	[MaTieuChuan] [nvarchar](450) NULL,
	[MaMinhChung] [nvarchar](450) NULL,
 CONSTRAINT [PK_TEPTIN] PRIMARY KEY CLUSTERED 
(
	[MaTepTin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIEUCHI]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIEUCHI](
	[MaTieuChi] [nvarchar](450) NOT NULL,
	[TenTieuChi] [nvarchar](max) NOT NULL,
	[YeuCauCuaTieuChi] [nvarchar](max) NOT NULL,
	[MocChuanThamChieuDeDanhGiaTieuChiDatMucBon] [nvarchar](max) NOT NULL,
	[GoiYNguonMinhChung] [nvarchar](max) NOT NULL,
	[MaTieuChuan] [nvarchar](450) NULL,
 CONSTRAINT [PK_TIEUCHI] PRIMARY KEY CLUSTERED 
(
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIEUCHUAN]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIEUCHUAN](
	[MaTieuChuan] [nvarchar](450) NOT NULL,
	[TenTieuChuan] [nvarchar](500) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[SoHopMinhChung] [int] NOT NULL,
 CONSTRAINT [PK_TIEUCHUAN] PRIMARY KEY CLUSTERED 
(
	[MaTieuChuan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210318173110_InitialEFDbContext', N'5.0.4')
GO
INSERT [dbo].[TIEUCHI] ([MaTieuChi], [TenTieuChi], [YeuCauCuaTieuChi], [MocChuanThamChieuDeDanhGiaTieuChiDatMucBon], [GoiYNguonMinhChung], [MaTieuChuan]) VALUES (N'1', N'Mục tiêu của CTĐT được xác định rõ ràng, phù hợp với sứ mạng và tầm nhìn của CSGD đại học, phù hợp với mục tiêu của giáo dục đại học quy định tại Luật giáo dục đại học.', N'<ol><li>Mục tiêu của CTĐT được xác định rõ ràng.</li><li>Mục tiêu của CTĐT phù hợp với sứ mạng và tầm nhìn của CSGD.</li><li>Mục tiêu của CTĐT phù hợp với mục tiêu của giáo dục đại học quy định tại Luật giáo dục đại học.</li></ol>', N'<ol><li>Mục tiêu của CTĐT được xác định rõ ràng.</li><li>Mục tiêu của CTĐT phù hợp với sứ mạng và tầm nhìn của CSGD.</li><li>Mục tiêu của CTĐT phù hợp với mục tiêu của giáo dục đại học quy định tại Luật giáo dục đại học.</li></ol>', N'<ul><li>Văn bản chính thức phát biểu về tầm nhìn, sứ mạng của CSGD*.</li><li>Quyết định ban hành CTĐT*.&nbsp;</li><li>Bản mô tả/đề cương CTĐT và bản mô tả/đề cương môn học/học phần*.</li><li>Ma trận kỹ năng*.</li><li>Tài liệu khảo sát về nhu cầu của thị trường lao động liên quan đến CTĐT trong vòng 5 năm tính đến thời điểm đánh giá*.</li><li>Biên bản họp lấy ý kiến của các bên liên quan về CTĐT*.</li><li>Trang thông tin điện tử của CSGD/khoa có đề cập đến CTĐT.</li><li>Các báo cáo kết quả KĐCLGD và đối sánh.</li></ul>', N'1')
GO
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'1', N'Mục Tiêu Và Chuẩn Đầu Ra Của Chương Trình Đào Tạo', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'10', N'Nâng Cao Chất Lượng', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'11', N'Kết Quả Đầu Ra', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'2', N'Bản Mô Tả Chương Trình Đào Tạo', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'3', N'Cấu Trúc Và Nội Dung Chương Trình Dạy Học', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'4', N'Phương Pháp Tiếp Cận Trong Dạy Và Học', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'5', N'Đánh Giá Kết Quả Học Tập Của Người Học', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'6', N'Đội Ngũ Giảng Viên, Nghiên Cứu Viên', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'7', N'Đội Ngũ Nhân Viên', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'8', N'Người Học Và Hoạt Động Hỗ Trợ Người Học', N'', 1)
INSERT [dbo].[TIEUCHUAN] ([MaTieuChuan], [TenTieuChuan], [MoTa], [SoHopMinhChung]) VALUES (N'9', N'Cơ Sở Vật Chất Và Trang Thiết Bị', N'', 1)
GO
ALTER TABLE [dbo].[MINHCHUNG]  WITH CHECK ADD  CONSTRAINT [FK_MINHCHUNG_TIEUCHI_MaTieuChi] FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TIEUCHI] ([MaTieuChi])
GO
ALTER TABLE [dbo].[MINHCHUNG] CHECK CONSTRAINT [FK_MINHCHUNG_TIEUCHI_MaTieuChi]
GO
ALTER TABLE [dbo].[MINHCHUNG]  WITH CHECK ADD  CONSTRAINT [FK_MINHCHUNG_TIEUCHUAN_MaTieuChuan] FOREIGN KEY([MaTieuChuan])
REFERENCES [dbo].[TIEUCHUAN] ([MaTieuChuan])
GO
ALTER TABLE [dbo].[MINHCHUNG] CHECK CONSTRAINT [FK_MINHCHUNG_TIEUCHUAN_MaTieuChuan]
GO
ALTER TABLE [dbo].[TEPTIN]  WITH CHECK ADD  CONSTRAINT [FK_TEPTIN_MINHCHUNG_MaMinhChung] FOREIGN KEY([MaMinhChung])
REFERENCES [dbo].[MINHCHUNG] ([MaMinhChung])
GO
ALTER TABLE [dbo].[TEPTIN] CHECK CONSTRAINT [FK_TEPTIN_MINHCHUNG_MaMinhChung]
GO
ALTER TABLE [dbo].[TEPTIN]  WITH CHECK ADD  CONSTRAINT [FK_TEPTIN_TIEUCHI_MaTieuChi] FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TIEUCHI] ([MaTieuChi])
GO
ALTER TABLE [dbo].[TEPTIN] CHECK CONSTRAINT [FK_TEPTIN_TIEUCHI_MaTieuChi]
GO
ALTER TABLE [dbo].[TEPTIN]  WITH CHECK ADD  CONSTRAINT [FK_TEPTIN_TIEUCHUAN_MaTieuChuan] FOREIGN KEY([MaTieuChuan])
REFERENCES [dbo].[TIEUCHUAN] ([MaTieuChuan])
GO
ALTER TABLE [dbo].[TEPTIN] CHECK CONSTRAINT [FK_TEPTIN_TIEUCHUAN_MaTieuChuan]
GO
ALTER TABLE [dbo].[TIEUCHI]  WITH CHECK ADD  CONSTRAINT [FK_TIEUCHI_TIEUCHUAN_MaTieuChuan] FOREIGN KEY([MaTieuChuan])
REFERENCES [dbo].[TIEUCHUAN] ([MaTieuChuan])
GO
ALTER TABLE [dbo].[TIEUCHI] CHECK CONSTRAINT [FK_TIEUCHI_TIEUCHUAN_MaTieuChuan]
GO
/****** Object:  StoredProcedure [dbo].[CapNhatMinhChung]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CapNhatMinhChung](@MaMinhChung VARCHAR(450), @SoKyHieu NVARCHAR(200), @TrichYeu NVARCHAR(MAX), @CoQuanBanHanh NVARCHAR(200), @NoiNhanCacVanBan NVARCHAR(200), @NoiLuuBanChinh NVARCHAR(200), @MucDo INTEGER, @NguoiKyVanBan NVARCHAR(200), @SoPhatHanh VARCHAR(200), @LinhVucVanBan NVARCHAR(200), @LoaiVanBan NVARCHAR(200), @NgayLuu DATE, @MaTieuChuan NVARCHAR(450), @MaTieuChi NVARCHAR(450)) 
	AS
	BEGIN
	    UPDATE dbo.MINHCHUNG SET SoKyHieu=@SoKyHieu, TrichYeu=@TrichYeu, CoQuanBanHanh=@CoQuanBanHanh, NoiNhanCacVanBan=@NoiNhanCacVanBan, NoiLuuBanChinh=@NoiLuuBanChinh, MucDo=@MucDo, NguoiKyVanBan=@NguoiKyVanBan, SoPhatHanh=@SoPhatHanh,
		 LinhVucVanBan=@LinhVucVanBan, @LoaiVanBan=@LoaiVanBan,NgayLuu=@NgayLuu, MaTieuChuan=@MaTieuChuan, MaTieuChi=@MaTieuChi WHERE MaMinhChung=@MaMinhChung
	END
GO
/****** Object:  StoredProcedure [dbo].[CapNhatTieuChi]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CapNhatTieuChi](@MaTieuChi VARCHAR(100), @TenTieuChi NVARCHAR(500), @YeuCauCuaTieuChi NVARCHAR(MAX), @MocChuanThamChieuDeDanhGiaTieuChiDatMucBon NVARCHAR(MAX), @GoiYNguonMinhChung NVARCHAR(MAX), @MaTieuChuan NVARCHAR(450))
	AS
	BEGIN
	    UPDATE dbo.TIEUCHI SET TenTieuChi=@TenTieuChi, YeuCauCuaTieuChi=@YeuCauCuaTieuChi, MocChuanThamChieuDeDanhGiaTieuChiDatMucBon=@MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, GoiYNguonMinhChung=@GoiYNguonMinhChung, MaTieuChuan=@MaTieuChuan WHERE MaTieuChi=@MaTieuChi
	END
GO
/****** Object:  StoredProcedure [dbo].[CapNhatTieuChuan]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CapNhatTieuChuan](@MaTieuChuan VARCHAR(100), @TenTieuChuan NVARCHAR(500), @MoTa NVARCHAR(MAX), @SoHopMinhChung INTEGER)
	AS
	BEGIN
	    UPDATE dbo.TIEUCHUAN SET TenTieuChuan=@TenTieuChuan, MoTa=@MoTa, SoHopMinhChung=@SoHopMinhChung WHERE MaTieuChuan=@MaTieuChuan
	END
GO
/****** Object:  StoredProcedure [dbo].[LayDanhSachMinhChung]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayDanhSachMinhChung]
	AS
	BEGIN
	    SELECT dbo.MINHCHUNG.MaMinhChung, dbo.MINHCHUNG.SoKyHieu, dbo.MINHCHUNG.TrichYeu, dbo.MINHCHUNG.CoQuanBanHanh, dbo.MINHCHUNG.NoiNhanCacVanBan, dbo.MINHCHUNG.NoiLuuBanChinh, dbo.MINHCHUNG.MucDo, dbo.MINHCHUNG.NguoiKyVanBan, dbo.MINHCHUNG.SoPhatHanh, dbo.MINHCHUNG.LinhVucVanBan, dbo.MINHCHUNG.LoaiVanBan, dbo.MINHCHUNG.NgayTao, dbo.MINHCHUNG.NgayLuu, NguoiDung.Id AS [Mã người tạo], NguoiDung.FullName AS [Họ tên người tạo],
		dbo.TIEUCHUAN.TenTieuChuan, dbo.TIEUCHUAN.MaTieuChuan, dbo.TIEUCHI.TenTieuChi, dbo.TIEUCHI.MaTieuChi
		FROM dbo.MINHCHUNG, dbo.TIEUCHUAN, dbo.TIEUCHI, dbo.IDENTITYUSER AS NguoiDung WHERE dbo.MINHCHUNG.MaNguoiTao=NguoiDung.Id AND dbo.MINHCHUNG.MaTieuChuan=dbo.TIEUCHUAN.MaTieuChuan AND dbo.MINHCHUNG.MaTieuChi=dbo.TIEUCHI.MaTieuChi
	END
GO
/****** Object:  StoredProcedure [dbo].[LayDanhSachTieuChi]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayDanhSachTieuChi]
	AS
    BEGIN
        SELECT dbo.TIEUCHI.MaTieuChi, dbo.TIEUCHI.TenTieuChi, dbo.TIEUCHI.YeuCauCuaTieuChi, dbo.TIEUCHI.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, dbo.TIEUCHI.GoiYNguonMinhChung, dbo.TIEUCHUAN.MaTieuChuan, dbo.TIEUCHUAN.TenTieuChuan, dbo.TIEUCHUAN.SoHopMinhChung FROM dbo.TIEUCHI, dbo.TIEUCHUAN WHERE dbo.TIEUCHI.MaTieuChuan=dbo.TIEUCHUAN.MaTieuChuan ORDER BY MaTieuChi ASC
    END
GO
/****** Object:  StoredProcedure [dbo].[LayDanhSachTieuChuan]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayDanhSachTieuChuan]
	AS
    BEGIN
        SELECT TC.MaTieuChuan, TC.TenTieuChuan, TC.MoTa, TC.SoHopMinhChung FROM dbo.TIEUCHUAN AS TC ORDER BY CONVERT(INTEGER, TC.MaTieuChuan) ASC
    END
GO
/****** Object:  StoredProcedure [dbo].[LayMinhChungTheoMa]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayMinhChungTheoMa](@MaMinhChung NVARCHAR(100))
	AS
	BEGIN
	    SELECT dbo.MINHCHUNG.MaMinhChung, dbo.MINHCHUNG.SoKyHieu, dbo.MINHCHUNG.TrichYeu, dbo.MINHCHUNG.CoQuanBanHanh, dbo.MINHCHUNG.NoiNhanCacVanBan, dbo.MINHCHUNG.NoiLuuBanChinh, dbo.MINHCHUNG.MucDo, dbo.MINHCHUNG.NguoiKyVanBan, dbo.MINHCHUNG.SoPhatHanh, dbo.MINHCHUNG.LinhVucVanBan, dbo.MINHCHUNG.LoaiVanBan, dbo.MINHCHUNG.NgayTao, dbo.MINHCHUNG.NgayLuu, NguoiDung.Id AS [Mã người tạo], NguoiDung.FullName AS [Họ tên người tạo],
		dbo.TIEUCHUAN.TenTieuChuan, dbo.TIEUCHUAN.MaTieuChuan, dbo.TIEUCHI.TenTieuChi, dbo.TIEUCHI.MaTieuChi
		FROM dbo.MINHCHUNG, dbo.TIEUCHUAN, dbo.TIEUCHI, dbo.IDENTITYUSER AS NguoiDung WHERE dbo.MINHCHUNG.MaNguoiTao=NguoiDung.Id AND dbo.MINHCHUNG.MaTieuChuan=dbo.TIEUCHUAN.MaTieuChuan AND dbo.MINHCHUNG.MaTieuChi=dbo.TIEUCHI.MaTieuChi AND MaMinhChung=@MaMinhChung
	END
GO
/****** Object:  StoredProcedure [dbo].[LayTieuChiTheoMa]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayTieuChiTheoMa](@MaTieuChi NVARCHAR(450))
	AS
    BEGIN
         SELECT dbo.TIEUCHI.MaTieuChi, dbo.TIEUCHI.TenTieuChi, dbo.TIEUCHI.YeuCauCuaTieuChi, dbo.TIEUCHI.MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, dbo.TIEUCHI.GoiYNguonMinhChung, dbo.TIEUCHUAN.MaTieuChuan, dbo.TIEUCHUAN.TenTieuChuan FROM dbo.TIEUCHI, dbo.TIEUCHUAN WHERE dbo.TIEUCHI.MaTieuChuan=dbo.TIEUCHUAN.MaTieuChuan AND dbo.TIEUCHI.MaTieuChi=@MaTieuChi
    END
GO
/****** Object:  StoredProcedure [dbo].[LayTieuChuanTheoMa]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayTieuChuanTheoMa](@MaTieuChuan NVARCHAR(100))
	AS
    BEGIN
        SELECT TC.MaTieuChuan, TC.TenTieuChuan, TC.MoTa, TC.SoHopMinhChung FROM dbo.TIEUCHUAN AS TC WHERE TC.MaTieuChuan=@MaTieuChuan
    END
GO
/****** Object:  StoredProcedure [dbo].[TaoMinhChung]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TaoMinhChung](@MaMinhChung VARCHAR(450), @SoKyHieu NVARCHAR(200), @TrichYeu NVARCHAR(MAX), @CoQuanBanHanh NVARCHAR(200), @NoiNhanCacVanBan NVARCHAR(200), @NoiLuuBanChinh NVARCHAR(200), @MucDo INTEGER, @NguoiKyVanBan NVARCHAR(200), @SoPhatHanh VARCHAR(200), @LinhVucVanBan NVARCHAR(200), @LoaiVanBan NVARCHAR(200), @NgayTao DATE, @NgayLuu DATE, @MaNguoiTao VARCHAR(200), @MaTieuChuan NVARCHAR(450), @MaTieuChi NVARCHAR(450))
	AS
	BEGIN
	    INSERT INTO dbo.MINHCHUNG
	    (
	        MaMinhChung,
	        SoKyHieu,
	        TrichYeu,
	        CoQuanBanHanh,
	        NoiNhanCacVanBan,
	        NoiLuuBanChinh,
	        MucDo,
	        NguoiKyVanBan,
	        SoPhatHanh,
	        LinhVucVanBan,
	        LoaiVanBan,
	        NgayTao,
	        NgayLuu,
	        MaNguoiTao,
	        MaTieuChi,
	        MaTieuChuan
	    )
	    VALUES
	    (   @MaMinhChung,       -- MaMinhChung - nvarchar(450)
	        @SoKyHieu,        -- SoKyHieu - varchar(200)
	        @TrichYeu,       -- TrichYeu - nvarchar(max)
	        @CoQuanBanHanh,       -- CoQuanBanHanh - nvarchar(200)
	        @NoiNhanCacVanBan,       -- NoiNhanCacVanBan - nvarchar(200)
	        @NoiLuuBanChinh,       -- NoiLuuBanChinh - nvarchar(200)
	        @MucDo,         -- MucDo - int
	        @NguoiKyVanBan,       -- NguoiKyVanBan - nvarchar(200)
	        @SoPhatHanh,        -- SoPhatHanh - varchar(200)
	        @LinhVucVanBan,       -- LinhVucVanBan - nvarchar(200)
	        @LoaiVanBan,       -- LoaiVanBan - nvarchar(200)
	        @NgayTao, -- NgayTao - date
	        @NgayLuu, -- NgayLuu - date
	        @MaNguoiTao,        -- MaNguoiTao - varchar(200)
	        @MaTieuChi,       -- MaTieuChi - nvarchar(450)
	        @MaTieuChuan        -- MaTieuChuan - nvarchar(450)
	    )
	END
GO
/****** Object:  StoredProcedure [dbo].[TaoTieuChi]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TaoTieuChi](@MaTieuChi VARCHAR(100), @TenTieuChi NVARCHAR(500), @YeuCauCuaTieuChi NVARCHAR(MAX), @MocChuanThamChieuDeDanhGiaTieuChiDatMucBon NVARCHAR(MAX), @GoiYNguonMinhChung NVARCHAR(MAX), @MaTieuChuan NVARCHAR(450))
	AS
	BEGIN
	    INSERT INTO dbo.TIEUCHI
	    (
	        MaTieuChi,
	        TenTieuChi,
	        YeuCauCuaTieuChi,
	        MocChuanThamChieuDeDanhGiaTieuChiDatMucBon,
	        GoiYNguonMinhChung,
	        MaTieuChuan
	    )
	    VALUES
	    (   @MaTieuChi, -- MaTieuChi - nvarchar(450)
	        @TenTieuChi, -- TenTieuChi - nvarchar(500)
	        @YeuCauCuaTieuChi, -- YeuCauCuaTieuChi - nvarchar(max)
	        @MocChuanThamChieuDeDanhGiaTieuChiDatMucBon, -- MocChuanThamChieuDeDanhGiaTieuChiDatMucBon - nvarchar(max)
	        @GoiYNguonMinhChung, -- GoiYNguonMinhChung - nvarchar(max)
	        @MaTieuChuan  -- MaTieuChuan - nvarchar(450)
		)
	END
GO
/****** Object:  StoredProcedure [dbo].[TaoTieuChuan]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TaoTieuChuan](@MaTieuChuan VARCHAR(100), @TenTieuChuan NVARCHAR(500), @MoTa NVARCHAR(MAX), @SoHopMinhChung INTEGER)
	AS
	BEGIN
	    INSERT INTO dbo.TIEUCHUAN
	    (
	        MaTieuChuan,
	        TenTieuChuan,
	        MoTa,
	        SoHopMinhChung
	    )
	    VALUES
	    (   @MaTieuChuan, -- MaTieuChuan - nvarchar(450)
	        @TenTieuChuan, -- TenTieuChuan - nvarchar(500)
	        @MoTa, -- MoTa - nvarchar(max)
	        @SoHopMinhChung    -- SoHopMinhChung - int
	    )
	END
GO
/****** Object:  StoredProcedure [dbo].[XoaMinhChung]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaMinhChung] (@MaMinhChung VARCHAR(450))
	AS
	BEGIN
	    DELETE dbo.MINHCHUNG WHERE MaMinhChung=@MaMinhChung
	END
GO
/****** Object:  StoredProcedure [dbo].[XoaTieuChi]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[XoaTieuChi](@MaTieuChi NVARCHAR(450))
	AS
	BEGIN
		DELETE dbo.TIEUCHI WHERE MaTieuChi=@MaTieuChi
	END
GO
/****** Object:  StoredProcedure [dbo].[XoaTieuChuan]    Script Date: 3/19/2021 1:47:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC	[dbo].[XoaTieuChuan](@MaTieuChuan VARCHAR(100))
	AS
	BEGIN
		DELETE dbo.TIEUCHUAN WHERE MaTieuChuan=@MaTieuChuan
	END
GO
