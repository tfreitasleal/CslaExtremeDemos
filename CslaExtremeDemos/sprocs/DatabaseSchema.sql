USE [master]
GO
/****** Object:  Database [CslaExtremeDemos]    Script Date: 10/01/2017 23:17:02 ******/
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
/****** Object:  Table [Countries]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Countries](
	[CountryId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Countries] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Depts]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Depts](
	[DeptId] [smallint] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Depts] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Depts] UNIQUE NONCLUSTERED 
(
	[DeptName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Jobs]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Jobs](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Persons]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[BirthCountryId] [smallint] NOT NULL,
	[GraduationDate] [datetime2](7) NULL,
	[GraduationCollege] [varchar](50) NULL,
	[GraduationCountryId] [smallint] NULL,
	[GraduationDegree] [tinyint] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Persons] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[Gender] ASC,
	[BirthDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Users]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[MaritalStatusId] [tinyint] NOT NULL,
	[RoleId] [tinyint] NULL,
	[DeptId] [smallint] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC,
	[MiddleName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Persons] FOREIGN KEY([PersonId])
REFERENCES [Persons] ([PersonId])
GO
ALTER TABLE [Jobs] CHECK CONSTRAINT [FK_Jobs_Persons]
GO
ALTER TABLE [Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_BirthCountries] FOREIGN KEY([BirthCountryId])
REFERENCES [Countries] ([CountryId])
GO
ALTER TABLE [Persons] CHECK CONSTRAINT [FK_Persons_BirthCountries]
GO
ALTER TABLE [Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_GraduationCountries] FOREIGN KEY([GraduationCountryId])
REFERENCES [Countries] ([CountryId])
GO
ALTER TABLE [Persons] CHECK CONSTRAINT [FK_Persons_GraduationCountries]
GO
ALTER TABLE [Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Depts] FOREIGN KEY([DeptId])
REFERENCES [Depts] ([DeptId])
GO
ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_Depts]
GO
/****** Object:  StoredProcedure [AddCountryItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AddCountryItem]
    @CountryId smallint OUTPUT,
    @Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Countries */
        INSERT INTO [dbo].[Countries]
        (
            [Name]
        )
        VALUES
        (
            @Name
        )

        /* Return new primary key */
        SET @CountryId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [AddDeptItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AddDeptItem]
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
/****** Object:  StoredProcedure [AddJobItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AddJobItem]
    @JobId int OUTPUT,
    @PersonId int,
    @CompanyName varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Jobs */
        INSERT INTO [dbo].[Jobs]
        (
            [PersonId],
            [CompanyName]
        )
        VALUES
        (
            @PersonId,
            @CompanyName
        )

        /* Return new primary key */
        SET @JobId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [AddPerson]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AddPerson]
    @PersonId int OUTPUT,
    @Name varchar(50),
    @Gender tinyint,
    @BirthDate datetime2,
    @BirthCountryId smallint,
    @GraduationDate datetime2,
    @GraduationCollege varchar(50),
    @GraduationCountryId smallint,
    @GraduationDegree tinyint
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into dbo.Persons */
        INSERT INTO [dbo].[Persons]
        (
            [Name],
            [Gender],
            [BirthDate],
            [BirthCountryId],
            [GraduationDate],
            [GraduationCollege],
            [GraduationCountryId],
            [GraduationDegree]
        )
        VALUES
        (
            @Name,
            @Gender,
            @BirthDate,
            @BirthCountryId,
            @GraduationDate,
            @GraduationCollege,
            @GraduationCountryId,
            @GraduationDegree
        )

        /* Return new primary key */
        SET @PersonId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [AddUser]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [AddUser]
    @UserId int OUTPUT,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @MaritalStatusId tinyint,
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
            [MaritalStatusId],
            [RoleId],
            [DeptId]
        )
        VALUES
        (
            @FirstName,
            @MiddleName,
            @LastName,
            @MaritalStatusId,
            @RoleId,
            @DeptId
        )

        /* Return new primary key */
        SET @UserId = SCOPE_IDENTITY()

    END

GO
/****** Object:  StoredProcedure [DeleteCountryItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DeleteCountryItem]
    @CountryId smallint
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CountryId] FROM [dbo].[Countries]
            WHERE
                [CountryId] = @CountryId
        )
        BEGIN
            RAISERROR ('''dbo.CountryItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete CountryItem object from Countries */
        DELETE
        FROM [dbo].[Countries]
        WHERE
            [dbo].[Countries].[CountryId] = @CountryId

    END

GO
/****** Object:  StoredProcedure [DeleteDeptItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DeleteDeptItem]
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
/****** Object:  StoredProcedure [DeleteJobItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DeleteJobItem]
    @JobId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [JobId] FROM [dbo].[Jobs]
            WHERE
                [JobId] = @JobId
        )
        BEGIN
            RAISERROR ('''dbo.JobItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete JobItem object from Jobs */
        DELETE
        FROM [dbo].[Jobs]
        WHERE
            [dbo].[Jobs].[JobId] = @JobId

    END

GO
/****** Object:  StoredProcedure [GetCountryCollection]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetCountryCollection]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CountryItem from table */
        SELECT
            [Countries].[CountryId],
            [Countries].[Name]
        FROM [dbo].[Countries]

    END

GO
/****** Object:  StoredProcedure [GetCountryNVL]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetCountryNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get CountryNVL from table */
        SELECT
            [Countries].[CountryId],
            [Countries].[Name]
        FROM [dbo].[Countries]

    END

GO
/****** Object:  StoredProcedure [GetDeptCollection]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetDeptCollection]
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
/****** Object:  StoredProcedure [GetDeptNVL]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetDeptNVL]
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
/****** Object:  StoredProcedure [GetPerson]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetPerson]
    @PersonId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Person from table */
        SELECT
            [Persons].[PersonId],
            [Persons].[Name],
            [Persons].[Gender],
            [Persons].[BirthDate],
            [Persons].[BirthCountryId],
            [Persons].[GraduationDate],
            [Persons].[GraduationCollege],
            [Persons].[GraduationCountryId],
            [Persons].[GraduationDegree]
        FROM [dbo].[Persons]
        WHERE
            [Persons].[PersonId] = @PersonId

        /* Get JobItem from table */
        SELECT
            [Jobs].[JobId],
            [Jobs].[CompanyName]
        FROM [dbo].[Jobs]
            INNER JOIN [dbo].[Persons] ON [Jobs].[PersonId] = [Persons].[PersonId]
        WHERE
            [Persons].[PersonId] = @PersonId

    END

GO
/****** Object:  StoredProcedure [GetPersonList]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetPersonList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get PersonInfo from table */
        SELECT
            [Persons].[PersonId],
            [Persons].[Name],
            [Persons].[Gender],
            [Persons].[BirthDate],
            [Persons].[BirthCountryId]
        FROM [dbo].[Persons]

    END

GO
/****** Object:  StoredProcedure [GetUser]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetUser]
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
            [Users].[MaritalStatusId],
            [Users].[RoleId],
            [Users].[DeptId]
        FROM [dbo].[Users]
        WHERE
            [Users].[UserId] = @UserId

    END

GO
/****** Object:  StoredProcedure [GetUserList]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GetUserList]
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
/****** Object:  StoredProcedure [UpdateCountryItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateCountryItem]
    @CountryId smallint,
    @Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CountryId] FROM [dbo].[Countries]
            WHERE
                [CountryId] = @CountryId
        )
        BEGIN
            RAISERROR ('''dbo.CountryItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Countries */
        UPDATE [dbo].[Countries]
        SET
            [Name] = @Name
        WHERE
            [CountryId] = @CountryId

    END

GO
/****** Object:  StoredProcedure [UpdateDeptItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateDeptItem]
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
/****** Object:  StoredProcedure [UpdateJobItem]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateJobItem]
    @JobId int,
    @CompanyName varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [JobId] FROM [dbo].[Jobs]
            WHERE
                [JobId] = @JobId
        )
        BEGIN
            RAISERROR ('''dbo.JobItem'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in dbo.Jobs */
        UPDATE [dbo].[Jobs]
        SET
            [CompanyName] = @CompanyName
        WHERE
            [JobId] = @JobId

    END

GO
/****** Object:  StoredProcedure [UpdatePerson]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdatePerson]
    @PersonId int,
    @Name varchar(50),
    @Gender tinyint,
    @BirthDate datetime2,
    @BirthCountryId smallint,
    @GraduationDate datetime2,
    @GraduationCollege varchar(50),
    @GraduationCountryId smallint,
    @GraduationDegree tinyint
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
            [Name] = @Name,
            [Gender] = @Gender,
            [BirthDate] = @BirthDate,
            [BirthCountryId] = @BirthCountryId,
            [GraduationDate] = @GraduationDate,
            [GraduationCollege] = @GraduationCollege,
            [GraduationCountryId] = @GraduationCountryId,
            [GraduationDegree] = @GraduationDegree
        WHERE
            [PersonId] = @PersonId

    END

GO
/****** Object:  StoredProcedure [UpdateUser]    Script Date: 10/01/2017 23:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [UpdateUser]
    @UserId int,
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @MaritalStatusId tinyint,
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
            [MaritalStatusId] = @MaritalStatusId,
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
