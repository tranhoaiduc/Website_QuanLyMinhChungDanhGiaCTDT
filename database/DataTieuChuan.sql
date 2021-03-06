

USE [Website_QuanLyMinhChungDanhGiaCTDT]
GO
/****** Object:  Table [dbo].[TIEUCHUAN]    Script Date: 3/16/2021 9:36:38 PM ******/
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
