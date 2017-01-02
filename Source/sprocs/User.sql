/****** Object:  StoredProcedure [dbo].[GetUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetUser]
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

/****** Object:  StoredProcedure [dbo].[AddUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddUser]
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

/****** Object:  StoredProcedure [dbo].[UpdateUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateUser]
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

