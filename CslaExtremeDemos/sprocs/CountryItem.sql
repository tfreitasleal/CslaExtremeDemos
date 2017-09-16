/****** Object:  StoredProcedure [dbo].[AddCountryItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddCountryItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[AddCountryItem]
GO

CREATE PROCEDURE [dbo].[AddCountryItem]
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

/****** Object:  StoredProcedure [dbo].[UpdateCountryItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCountryItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateCountryItem]
GO

CREATE PROCEDURE [dbo].[UpdateCountryItem]
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

/****** Object:  StoredProcedure [dbo].[DeleteCountryItem] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteCountryItem]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteCountryItem]
GO

CREATE PROCEDURE [dbo].[DeleteCountryItem]
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
