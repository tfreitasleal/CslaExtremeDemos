/****** Object:  StoredProcedure [dbo].[GetCountryCollection] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCountryCollection]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetCountryCollection]
GO

CREATE PROCEDURE [dbo].[GetCountryCollection]
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

