/****** Object:  StoredProcedure [dbo].[GetCountryNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCountryNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetCountryNVL]
GO

CREATE PROCEDURE [dbo].[GetCountryNVL]
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

