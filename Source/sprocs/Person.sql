/****** Object:  StoredProcedure [dbo].[GetPerson] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPerson]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetPerson]
GO

CREATE PROCEDURE [dbo].[GetPerson]
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

/****** Object:  StoredProcedure [dbo].[AddPerson] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddPerson]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddPerson]
GO

CREATE PROCEDURE [dbo].[AddPerson]
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

/****** Object:  StoredProcedure [dbo].[UpdatePerson] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePerson]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdatePerson]
GO

CREATE PROCEDURE [dbo].[UpdatePerson]
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

