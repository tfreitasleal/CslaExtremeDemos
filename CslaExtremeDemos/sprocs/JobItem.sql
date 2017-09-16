/****** Object:  StoredProcedure [dbo].[AddJobItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddJobItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddJobItem]
GO

CREATE PROCEDURE [dbo].[AddJobItem]
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

/****** Object:  StoredProcedure [dbo].[UpdateJobItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateJobItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateJobItem]
GO

CREATE PROCEDURE [dbo].[UpdateJobItem]
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

/****** Object:  StoredProcedure [dbo].[DeleteJobItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteJobItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteJobItem]
GO

CREATE PROCEDURE [dbo].[DeleteJobItem]
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
