USE [master]
GO
/****** Object:  Database [ProjectsVendors]    Script Date: 01-03-2017 21:21:34 ******/
CREATE DATABASE [ProjectsVendors] ON  PRIMARY 
( NAME = N'ProjectsVendors', FILENAME = N'C:\MYDB\ProjectsVendors.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectsVendors_log', FILENAME = N'C:\MYDB\ProjectsVendors_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectsVendors] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectsVendors].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectsVendors] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectsVendors] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectsVendors] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectsVendors] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectsVendors] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectsVendors] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectsVendors] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectsVendors] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectsVendors] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectsVendors] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectsVendors] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectsVendors] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectsVendors] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectsVendors] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectsVendors] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectsVendors] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectsVendors] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectsVendors] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectsVendors] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectsVendors] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectsVendors] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectsVendors] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectsVendors] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectsVendors] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectsVendors] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectsVendors] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectsVendors', N'ON'
GO
USE [ProjectsVendors]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[DeliveryDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[VendorName] [varchar](50) NOT NULL,
	[VendorContact] [varchar](50) NOT NULL,
	[VendorPhone] [varchar](50) NOT NULL,
	[VendorEmail] [varchar](50) NOT NULL,
	[IsPrimaryVendor] [bit] NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [DeliveryDate]) VALUES (1, N'Test SYNC methods', CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-03-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [DeliveryDate]) VALUES (2, N'Test ASYNC methods', CAST(N'2017-03-08T00:00:00.0000000' AS DateTime2), CAST(N'2017-03-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [DeliveryDate]) VALUES (3, N'Operating LazyLoad', CAST(N'2017-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-01-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [DeliveryDate]) VALUES (4, N'Using LazyGetProperty', CAST(N'2017-02-28T00:00:00.0000000' AS DateTime2), CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Projects] ([ProjectId], [ProjectName], [StartDate], [DeliveryDate]) VALUES (5, N'Vacations', CAST(N'2017-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-06-30T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[Vendors] ON 

INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (1, 1, N'Nicefellow', N'', N'555-2639', N'nicefellow@vendor.com', 1, CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (2, 2, N'Lonestar', N'', N'555-3940', N'lonestar@vendor.com', 0, CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (3, 1, N'Makepeace', N'', N'555-6837', N'makepeace@vendor.com', 0, CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (4, 2, N'Dempsey', N'', N'555-2178', N'dempsey@vendor.com', 1, CAST(N'2017-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (5, 1, N'Lovelace', N'', N'555-2139', N'lovelace@vendor.com', 0, CAST(N'2017-02-27T20:58:25.7589381' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (6, 3, N'Joachim', N'', N'555-9459', N'joachim@vendor.com', 0, CAST(N'2017-02-28T12:16:21.8547547' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (7, 4, N'Jonny', N'', N'555-4726', N'jonny@vendor.com', 1, CAST(N'2017-02-28T12:41:55.8598785' AS DateTime2))
INSERT [dbo].[Vendors] ([VendorId], [ProjectId], [VendorName], [VendorContact], [VendorPhone], [VendorEmail], [IsPrimaryVendor], [LastUpdated]) VALUES (8, 5, N'Mr. Travel', N'Travel Park', N'555 4861', N'travel@vendor.com', 1, CAST(N'2017-02-28T14:49:09.4641163' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Vendors] OFF
ALTER TABLE [dbo].[Vendors]  WITH CHECK ADD  CONSTRAINT [FK_Vendors_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([ProjectId])
GO
ALTER TABLE [dbo].[Vendors] CHECK CONSTRAINT [FK_Vendors_Projects]
GO
/****** Object:  StoredProcedure [dbo].[AddProjectEdit]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddProjectEdit]
    @ProjectId int OUTPUT,
    @ProjectName varchar(50),
    @StartDate datetime2,
    @DeliveryDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Projects */
        INSERT INTO [dbo].[Projects]
        (
            [ProjectName],
            [StartDate],
            [DeliveryDate]
        )
        VALUES
        (
            @ProjectName,
            @StartDate,
            @DeliveryDate
        )

        /* Return new primary key */
        SET @ProjectId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [dbo].[AddVendorItem]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddVendorItem]
    @VendorId int OUTPUT,
    @ProjectId int,
    @VendorName varchar(50),
    @VendorContact varchar(50),
    @VendorPhone varchar(50),
    @VendorEmail varchar(50),
    @IsPrimaryVendor bit,
    @LastUpdated datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Vendors */
        INSERT INTO [dbo].[Vendors]
        (
            [ProjectId],
            [VendorName],
            [VendorContact],
            [VendorPhone],
            [VendorEmail],
            [IsPrimaryVendor],
            [LastUpdated]
        )
        VALUES
        (
            @ProjectId,
            @VendorName,
            @VendorContact,
            @VendorPhone,
            @VendorEmail,
            @IsPrimaryVendor,
            @LastUpdated
        )

        /* Return new primary key */
        SET @VendorId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [dbo].[DeleteProjectEdit]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteProjectEdit]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProjectId] FROM [dbo].[Projects]
            WHERE
                [ProjectId] = @ProjectId
        )
        BEGIN
            RAISERROR ('''dbo.ProjectEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child VendorItem from Vendors */
        DELETE
            [dbo].[Vendors]
        FROM [dbo].[Vendors]
            INNER JOIN [dbo].[Projects] ON [Vendors].[ProjectId] = [Projects].[ProjectId]
        WHERE
            [dbo].[Projects].[ProjectId] = @ProjectId

        /* Delete ProjectEdit object from Projects */
        DELETE
        FROM [dbo].[Projects]
        WHERE
            [dbo].[Projects].[ProjectId] = @ProjectId

    END

GO
/****** Object:  StoredProcedure [dbo].[DeleteVendorItem]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteVendorItem]
    @VendorId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [VendorId] FROM [dbo].[Vendors]
            WHERE
                [VendorId] = @VendorId
        )
        BEGIN
            RAISERROR ('''dbo.VendorItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete VendorItem object from Vendors */
        DELETE
        FROM [dbo].[Vendors]
        WHERE
            [dbo].[Vendors].[VendorId] = @VendorId

    END

GO
/****** Object:  StoredProcedure [dbo].[GetProjectEdit]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProjectEdit]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProjectEdit from table */
        SELECT
            [Projects].[ProjectId],
            [Projects].[ProjectName],
            [Projects].[StartDate],
            [Projects].[DeliveryDate]
        FROM [dbo].[Projects]
        WHERE
            [Projects].[ProjectId] = @ProjectId

    END

GO
/****** Object:  StoredProcedure [dbo].[GetVendorCollection]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetVendorCollection]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get VendorItem from table */
        SELECT
            [Vendors].[VendorId],
            [Vendors].[VendorName],
            [Vendors].[VendorContact],
            [Vendors].[VendorPhone],
            [Vendors].[VendorEmail],
            [Vendors].[IsPrimaryVendor],
            [Vendors].[LastUpdated]
        FROM [dbo].[Vendors]
            INNER JOIN [dbo].[Projects] ON [Vendors].[ProjectId] = [Projects].[ProjectId]
        WHERE
            [Projects].[ProjectId] = @ProjectId

    END

GO
/****** Object:  StoredProcedure [dbo].[UpdateProjectEdit]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProjectEdit]
    @ProjectId int,
    @ProjectName varchar(50),
    @StartDate datetime2,
    @DeliveryDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProjectId] FROM [dbo].[Projects]
            WHERE
                [ProjectId] = @ProjectId
        )
        BEGIN
            RAISERROR ('''dbo.ProjectEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Projects */
        UPDATE [dbo].[Projects]
        SET
            [ProjectName] = @ProjectName,
            [StartDate] = @StartDate,
            [DeliveryDate] = @DeliveryDate
        WHERE
            [ProjectId] = @ProjectId

    END

GO
/****** Object:  StoredProcedure [dbo].[UpdateVendorItem]    Script Date: 01-03-2017 21:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateVendorItem]
    @VendorId int,
    @VendorName varchar(50),
    @VendorContact varchar(50),
    @VendorPhone varchar(50),
    @VendorEmail varchar(50),
    @IsPrimaryVendor bit,
    @LastUpdated datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [VendorId] FROM [dbo].[Vendors]
            WHERE
                [VendorId] = @VendorId
        )
        BEGIN
            RAISERROR ('''dbo.VendorItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Vendors */
        UPDATE [dbo].[Vendors]
        SET
            [VendorName] = @VendorName,
            [VendorContact] = @VendorContact,
            [VendorPhone] = @VendorPhone,
            [VendorEmail] = @VendorEmail,
            [IsPrimaryVendor] = @IsPrimaryVendor,
            [LastUpdated] = @LastUpdated
        WHERE
            [VendorId] = @VendorId

    END

GO
USE [master]
GO
ALTER DATABASE [ProjectsVendors] SET  READ_WRITE 
GO
