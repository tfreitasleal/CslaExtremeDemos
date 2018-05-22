/****** Object:  StoredProcedure [dbo].[GetProjectList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProjectList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProjectList]
GO

CREATE PROCEDURE [dbo].[GetProjectList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProjectInfo from table */
        SELECT
            [Projects].[ProjectId],
            [Projects].[ProjectName]
        FROM [dbo].[Projects]

    END
GO
