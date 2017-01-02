USE [master]
GO
/****** Object:  Database [CslaExtremeDemos]    Script Date: 02/01/2017 00:43:20 ******/
CREATE DATABASE [CslaExtremeDemos] ON  PRIMARY 
( NAME = N'CslaExtremeDemos', FILENAME = N'C:\MYDB\CslaExtremeDemos.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CslaExtremeDemos_log', FILENAME = N'C:\MYDB\CslaExtremeDemos_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CslaExtremeDemos] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CslaExtremeDemos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CslaExtremeDemos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET ARITHABORT OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CslaExtremeDemos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CslaExtremeDemos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CslaExtremeDemos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CslaExtremeDemos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CslaExtremeDemos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CslaExtremeDemos] SET  MULTI_USER 
GO
ALTER DATABASE [CslaExtremeDemos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CslaExtremeDemos] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CslaExtremeDemos', N'ON'
GO
USE [CslaExtremeDemos]
GO
/****** Object:  Table [dbo].[Depts]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depts](
	[DeptId] [smallint] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Depts] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[CivilStateId] [tinyint] NOT NULL,
	[RoleId] [tinyint] NULL,
	[DeptId] [smallint] NULL,
 CONSTRAINT [PK_Persons_1] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[CivilStateId] [tinyint] NOT NULL,
	[RoleId] [tinyint] NULL,
	[DeptId] [smallint] NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Depts] ON 

INSERT [dbo].[Depts] ([DeptId], [DeptName], [IsActive]) VALUES (1, N'Human Resources', 1)
INSERT [dbo].[Depts] ([DeptId], [DeptName], [IsActive]) VALUES (2, N'Finance', 1)
INSERT [dbo].[Depts] ([DeptId], [DeptName], [IsActive]) VALUES (3, N'Sales', 1)
INSERT [dbo].[Depts] ([DeptId], [DeptName], [IsActive]) VALUES (4, N'IT', 1)
INSERT [dbo].[Depts] ([DeptId], [DeptName], [IsActive]) VALUES (5, N'Procurement', 1)
SET IDENTITY_INSERT [dbo].[Depts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [MiddleName], [LastName], [CivilStateId], [RoleId], [DeptId]) VALUES (1, N'Freddy', NULL, N'Mars', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [MiddleName], [LastName], [CivilStateId], [RoleId], [DeptId]) VALUES (1, N'Johnny', NULL, N'Sullivan', 3, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Depts] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Depts] ([DeptId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Depts]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Depts] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Depts] ([DeptId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Depts]
GO
/****** Object:  StoredProcedure [dbo].[AddDeptItem]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddDeptItem]
    @DeptId smallint OUTPUT,
    @DeptName varchar(50),
    @IsActive bit
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Depts */
        INSERT INTO [dbo].[Depts]
        (
            [DeptName],
            [IsActive]
        )
        VALUES
        (
            @DeptName,
            @IsActive
        )

        /* Return new primary key */
        SET @DeptId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [dbo].[AddPerson]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddPerson]
    @PersonId int OUTPUT,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @CivilStateId tinyint,
    @RoleId tinyint,
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Persons */
        INSERT INTO [dbo].[Persons]
        (
            [FirstName],
            [MiddleName],
            [LastName],
            [CivilStateId],
            [RoleId],
            [DeptId]
        )
        VALUES
        (
            @FirstName,
            @MiddleName,
            @LastName,
            @CivilStateId,
            @RoleId,
            @DeptId
        )

        /* Return new primary key */
        SET @PersonId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
    @UserId int OUTPUT,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @CivilStateId tinyint,
    @RoleId tinyint,
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Users */
        INSERT INTO [dbo].[Users]
        (
            [FirstName],
            [MiddleName],
            [LastName],
            [CivilStateId],
            [RoleId],
            [DeptId]
        )
        VALUES
        (
            @FirstName,
            @MiddleName,
            @LastName,
            @CivilStateId,
            @RoleId,
            @DeptId
        )

        /* Return new primary key */
        SET @UserId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [dbo].[DeleteDeptItem]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteDeptItem]
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DeptId] FROM [dbo].[Depts]
            WHERE
                [DeptId] = @DeptId
            /* Ignore filter option is on */
        )
        BEGIN
            RAISERROR ('''dbo.DeptItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DeptItem object as not active */
        UPDATE [dbo].[Depts]
        SET    [IsActive] = 'false'
        WHERE
            [dbo].[Depts].[DeptId] = @DeptId

    END

GO
/****** Object:  StoredProcedure [dbo].[GetDeptCollection]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDeptCollection]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DeptItem from table */
        SELECT
            [Depts].[DeptId],
            [Depts].[DeptName],
            [Depts].[IsActive]
        FROM [dbo].[Depts]

    END

GO
/****** Object:  StoredProcedure [dbo].[GetDeptNVL]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetDeptNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DeptNVL from table */
        SELECT
            [Depts].[DeptId],
            [Depts].[DeptName]
        FROM [dbo].[Depts]
        WHERE
            [Depts].[IsActive] = 'true'

    END

GO
/****** Object:  StoredProcedure [dbo].[GetPerson]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPerson]
    @PersonId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Person from table */
        SELECT
            [Persons].[PersonId],
            [Persons].[FirstName],
            [Persons].[MiddleName],
            [Persons].[LastName],
            [Persons].[CivilStateId],
            [Persons].[RoleId],
            [Persons].[DeptId]
        FROM [dbo].[Persons]
        WHERE
            [Persons].[PersonId] = @PersonId

    END

GO
/****** Object:  StoredProcedure [dbo].[GetPersonList]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPersonList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get PersonInfo from table */
        SELECT
            [Persons].[PersonId],
            [Persons].[FirstName],
            [Persons].[MiddleName],
            [Persons].[LastName]
        FROM [dbo].[Persons]

    END

GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
    @UserId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get User from table */
        SELECT
            [Users].[UserId],
            [Users].[FirstName],
            [Users].[MiddleName],
            [Users].[LastName],
            [Users].[CivilStateId],
            [Users].[RoleId],
            [Users].[DeptId]
        FROM [dbo].[Users]
        WHERE
            [Users].[UserId] = @UserId

    END

GO
/****** Object:  StoredProcedure [dbo].[GetUserList]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get UserInfo from table */
        SELECT
            [Users].[UserId],
            [Users].[FirstName],
            [Users].[MiddleName],
            [Users].[LastName]
        FROM [dbo].[Users]

    END

GO
/****** Object:  StoredProcedure [dbo].[UpdateDeptItem]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateDeptItem]
    @DeptId smallint,
    @DeptName varchar(50),
    @IsActive bit
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DeptId] FROM [dbo].[Depts]
            WHERE
                [DeptId] = @DeptId
        )
        BEGIN
            RAISERROR ('''dbo.DeptItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Depts */
        UPDATE [dbo].[Depts]
        SET
            [DeptName] = @DeptName,
            [IsActive] = @IsActive
        WHERE
            [DeptId] = @DeptId

    END

GO
/****** Object:  StoredProcedure [dbo].[UpdatePerson]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePerson]
    @PersonId int,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @CivilStateId tinyint,
    @RoleId tinyint,
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [PersonId] FROM [dbo].[Persons]
            WHERE
                [PersonId] = @PersonId
        )
        BEGIN
            RAISERROR ('''dbo.Person'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Persons */
        UPDATE [dbo].[Persons]
        SET
            [FirstName] = @FirstName,
            [MiddleName] = @MiddleName,
            [LastName] = @LastName,
            [CivilStateId] = @CivilStateId,
            [RoleId] = @RoleId,
            [DeptId] = @DeptId
        WHERE
            [PersonId] = @PersonId

    END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 02/01/2017 00:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
    @UserId int,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @CivilStateId tinyint,
    @RoleId tinyint,
    @DeptId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [UserId] FROM [dbo].[Users]
            WHERE
                [UserId] = @UserId
        )
        BEGIN
            RAISERROR ('''dbo.User'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Users */
        UPDATE [dbo].[Users]
        SET
            [FirstName] = @FirstName,
            [MiddleName] = @MiddleName,
            [LastName] = @LastName,
            [CivilStateId] = @CivilStateId,
            [RoleId] = @RoleId,
            [DeptId] = @DeptId
        WHERE
            [UserId] = @UserId

    END

GO
USE [master]
GO
ALTER DATABASE [CslaExtremeDemos] SET  READ_WRITE 
GO
