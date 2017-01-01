/****** Object:  StoredProcedure [dbo].[GetUserList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetUserList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetUserList]
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

