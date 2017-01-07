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
            [Persons].[FirstName],
            [Persons].[MiddleName],
            [Persons].[LastName],
            [Persons].[MaritalStatusId],
            [Persons].[RoleId],
            [Persons].[DeptId]
        FROM [dbo].[Persons]
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
    @FirstName varchar(50),
    @MiddleName varchar(50),
    @LastName varchar(50),
    @MaritalStatusId tinyint,
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
        SET @PersonId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [dbo].[UpdatePerson] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdatePerson]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdatePerson]
GO

CREATE PROCEDURE [dbo].[UpdatePerson]
    @PersonId int,
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
            [MaritalStatusId] = @MaritalStatusId,
            [RoleId] = @RoleId,
            [DeptId] = @DeptId
        WHERE
            [PersonId] = @PersonId

    END
GO

