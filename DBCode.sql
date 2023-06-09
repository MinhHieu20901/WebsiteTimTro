USE [DBWebThueTro1]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiPhong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuDat]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDPhong] [int] NOT NULL,
	[IDUser] [nvarchar](128) NOT NULL,
	[Datetime] [datetime] NOT NULL,
	[TienCoc] [float] NOT NULL
 CONSTRAINT [PK_PhieuDat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phong]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[IDLoaiPhong] [int] NULL,
	[TinhTrang] [nvarchar](100) NULL,
	[TenChuTro] [nvarchar](max) NULL,
	[DienTichPhong] [nvarchar](max) NULL,
	[DonGia] [float] NULL,
	[SDT] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[img] [nvarchar](max) NULL,
	[DiaChiTro] [nvarchar](max) NULL,
 CONSTRAINT [PK_Phong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([UserName])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[PhieuDat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDat_AspNetUser_IDUser] FOREIGN KEY([IDUser])
REFERENCES [dbo].[AspNetUsers] ([UserName])
GO
ALTER TABLE [dbo].[PhieuDat] CHECK CONSTRAINT [FK_PhieuDat_AspNetUser_IDUser]
GO
ALTER TABLE [dbo].[PhieuDat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDat_Phong_IDPhong] FOREIGN KEY([IDPhong])
REFERENCES [dbo].[Phong] ([ID])
GO
ALTER TABLE [dbo].[PhieuDat] CHECK CONSTRAINT [FK_PhieuDat_Phong_IDPhong]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([IDLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([ID])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [FK_Phong_LoaiPhong]
GO
/****** Object:  StoredProcedure [dbo].[P_BaiDang]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------

CREATE PROC [dbo].[P_BaiDang]
AS
    BEGIN            
		SELECT * FROM Phong p WHERE TinhTrang = 'null' or TenChuTro = 'null'
    END

GO
/****** Object:  StoredProcedure [dbo].[P_Order]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------

CREATE PROC [dbo].[P_Order]
AS
    BEGIN            
		SELECT pd.ID,pd.IDUser, p.ID AS IDPhong,pd.Datetime,p.TieuDe, p.IDLoaiPhong,p.TinhTrang,p.DienTichPhong,p.DonGia, p.DiaChiTro,p.SDT,p.TenChuTro FROM Phong p, PhieuDat pd WHERE TinhTrang = 'trong' and p.ID = pd.IDPhong
    END

GO
/****** Object:  StoredProcedure [dbo].[P_Phong]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------------------------------------

CREATE PROC [dbo].[P_Phong]
AS
    BEGIN            
		SELECT * FROM Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null'
            
    END

GO
/****** Object:  StoredProcedure [dbo].[P_Search]    Script Date: 06/04/2022 5:17:57 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----------------------------------------------------------------------------

CREATE PROC [dbo].[P_Search] @Address nvarchar(MAX)
AS
    BEGIN            
		SELECT * FROM Phong WHERE DiaChiTro LIKE '%'+@Address+'%' Or MoTa LIKE '%'+@Address+'%'
            
    END

GO
----------------------------------------------------------------------------
ALTER PROC P_Summary @date1 varchar(100),@date2 varchar(100)
AS
    BEGIN            
		SELECT COUNT (PD.ID) AS SOLUONGGD,COUNT (DISTINCT PD.IDPhong) AS SOLUONGPHONG,SUM(PD.TienCoc) AS TONGTIEN, COUNT(DISTINCT PD.IDUser) AS SOLUONGKHACH FROM PhieuDat PD, Phong P WHERE PD.IDPhong = P.ID AND P.TinhTrang ='dathanhtoan' AND PD.Datetime >= ''+@date1+'' AND PD.Datetime <= ''+@date2+''
    END
GO
----------------------------------------------------------------------------
--CREATE FUNCTION F_Summary (@date1 varchar(100),@date2 varchar(100))
--RETURNS TABLE
--AS
--RETURN
--   SELECT COUNT (PD.ID) AS SOLUONGGD,COUNT (DISTINCT PD.IDPhong) AS SOLUONGPHONG,SUM(TongTien) AS TONGTIEN, COUNT(DISTINCT PD.IDUser) AS SOLUONGKHACH FROM PhieuDat PD, Phong P WHERE PD.IDPhong = P.ID AND P.TinhTrang ='dathanhtoan' AND PD.Datetime >= ''+@date1+'' AND PD.Datetime <= ''+@date2+''
--GO
----------------------------------------------------------------------------
CREATE PROC P_OrderInfo @ten nvarchar(100)
AS
    BEGIN
		SELECT P.TieuDe,P.IDLoaiPhong,P.TinhTrang,P.DienTichPhong,P.DonGia, P.DiaChiTro,p.SDT,p.TenChuTro FROM PhieuDat PD, Phong P WHERE PD.IDPhong = P.ID AND P.TinhTrang ='dathanhtoan' AND p.TenChuTro = @ten
    END
GO
----------------------------------------------------------------------------
CREATE PROC P_SummaryInfo
AS
    BEGIN            
		SELECT pd.ID,pd.IDUser, p.ID AS IDPhong,pd.Datetime,p.TieuDe, p.IDLoaiPhong,p.TinhTrang,p.DienTichPhong,p.DonGia, p.DiaChiTro,p.SDT,p.TenChuTro FROM PhieuDat PD, Phong P WHERE PD.IDPhong = P.ID AND P.TinhTrang ='dathanhtoan'
    END
GO
----------------------------------------------------------------------------

----------------------------------------------------------------------------
alter proc P_Trang @num int,@loai int
as
begin
	if(@loai=0)
	begin
	select top 10 id into trang from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null'

	if @num = 1
	begin
		select * from Phong where id in(select id from trang)
	end

	if @num = 2
	begin
		select top 10 id into trang2 from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null' and id not in (select id from trang)	
		select * from Phong where id in(select id from trang2)
		drop table trang2
	end

	if @num > 2
	begin
		while (@num > 2)
		begin
			begin
				set identity_insert Trang on
			end
			insert into trang(id) select top 10 id from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null' and id not in( select id from trang)
			set @num -= 1
		end
	end
		select top 10 id into trangn from Phong where TinhTrang = 'trong' and TenChuTro != 'null' and id not in ( select id from trang)
		select * from Phong where id in(select id from trangn)
		drop table trangn
	drop table trang
	end
	if(@loai!=0)
	begin
	select top 10 id into trang from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null' and IDLoaiPhong = @loai	

	if @num = 1
	begin
		select * from Phong where id in(select id from trang)
	end

	if @num = 2
	begin
		select top 10 id into trang2 from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null' and id not in (select id from trang) and IDLoaiPhong = @loai			
		select * from Phong where id in(select id from trang2)
		drop table trang2
	end

	if @num > 2
	begin
		while (@num > 2)
		begin
			begin
				set identity_insert Trang on
			end
			insert into trang(id) select top 10 id from Phong WHERE TinhTrang = 'trong' and TenChuTro != 'null' and id not in (select id from trang) and IDLoaiPhong = @loai
			set @num -= 1
		end
		select top 10 id into trangn from Phong where TinhTrang = 'trong' and TenChuTro != 'null' and id not in(select id from trang) and IDLoaiPhong = @loai
		select * from Phong where id in(select id from trangn)
		drop table trangn
	end
	drop table trang
	end
end
go
----------------------------------------------------------------------------
