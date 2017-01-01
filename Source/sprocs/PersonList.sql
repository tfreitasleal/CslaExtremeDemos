/****** Object:  StoredProcedure [dbo].[GetPersonList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetPersonList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetPersonList]
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

