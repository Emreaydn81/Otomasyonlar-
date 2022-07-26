USE [Kütüphane]
GO
/****** Object:  Table [dbo].[Emanet]    Script Date: 4.06.2022 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emanet](
	[Ögr_No] [int] NOT NULL,
	[Üye_Adı] [varchar](50) NULL,
	[Üye_Soyadı] [varchar](50) NULL,
	[Üye_Telefon] [varchar](50) NULL,
	[Kitap_Adı] [varchar](50) NULL,
	[Alış_Tarihi] [date] NULL,
	[Veriş_Tarihi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ögr_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kitaplar]    Script Date: 4.06.2022 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitaplar](
	[Kitap_Kodu] [varchar](50) NOT NULL,
	[Kitap_Adı] [varchar](50) NOT NULL,
	[Kitap_Rafı] [varchar](50) NULL,
	[Yazar] [varchar](50) NULL,
	[Türü] [varchar](50) NULL,
	[Stoklar] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Kitap_Adı] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanıcı]    Script Date: 4.06.2022 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanıcı](
	[Adı] [varchar](50) NOT NULL,
	[Sifre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Adı] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 4.06.2022 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Adı] [varchar](50) NOT NULL,
	[Soyadı] [varchar](50) NULL,
	[Telefon] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Adı] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Üyeler]    Script Date: 4.06.2022 13:05:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Üyeler](
	[Ögr_No] [int] NOT NULL,
	[Adı] [varchar](50) NULL,
	[Soyadı] [varchar](50) NULL,
	[Telefon] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ögr_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Emanet] ([Ögr_No], [Üye_Adı], [Üye_Soyadı], [Üye_Telefon], [Kitap_Adı], [Alış_Tarihi], [Veriş_Tarihi]) VALUES (12341, N'Burak', N'Yılmaz', N'05292982894', N'Bülbülü Öldürmek', CAST(N'2022-03-20' AS Date), CAST(N'2022-04-22' AS Date))
INSERT [dbo].[Emanet] ([Ögr_No], [Üye_Adı], [Üye_Soyadı], [Üye_Telefon], [Kitap_Adı], [Alış_Tarihi], [Veriş_Tarihi]) VALUES (12342, N'Emre', N'Aydın', N'0529295432674', N'Hayatın Sesi', CAST(N'2022-03-20' AS Date), CAST(N'2022-04-22' AS Date))
GO
INSERT [dbo].[Kitaplar] ([Kitap_Kodu], [Kitap_Adı], [Kitap_Rafı], [Yazar], [Türü], [Stoklar]) VALUES (N'12798949', N'Bülbülü Öldürmek', N'2', N'Emre Aydın', N'Macera', N'2')
INSERT [dbo].[Kitaplar] ([Kitap_Kodu], [Kitap_Adı], [Kitap_Rafı], [Yazar], [Türü], [Stoklar]) VALUES (N'12661721', N'Hayatın Sesi', N'1', N'Adem Kaya', N'Roman', N'3')
GO
INSERT [dbo].[Kullanıcı] ([Adı], [Sifre]) VALUES (N'Admin', N'123')
GO
INSERT [dbo].[Personel] ([Adı], [Soyadı], [Telefon]) VALUES (N'Adem', N'Kaya', N'0543 278 9282')
INSERT [dbo].[Personel] ([Adı], [Soyadı], [Telefon]) VALUES (N'Ayfer', N'Acar', N'0534 272 2942')
GO
INSERT [dbo].[Üyeler] ([Ögr_No], [Adı], [Soyadı], [Telefon]) VALUES (12312, N'Burçin', N'Baki', N'0527 127 1781')
INSERT [dbo].[Üyeler] ([Ögr_No], [Adı], [Soyadı], [Telefon]) VALUES (12454, N'Burak', N'Yılmaz', N'0529 298 2892')
GO
