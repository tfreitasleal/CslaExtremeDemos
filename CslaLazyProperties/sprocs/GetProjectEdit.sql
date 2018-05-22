/****** Object:  StoredProcedure [dbo].[GetProjectEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetProjectEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[GetProjectEdit]
GO

CREATE PROCEDURE [dbo].[GetProjectEdit]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get ProjectEdit from table */
        SELECT
            [Projects].[ProjectId],
            [Projects].[ProjectName],
            [Projects].[StartDate],
            [Projects].[DeliveryDate]
        FROM [dbo].[Projects]
        WHERE
            [Projects].[ProjectId] = @ProjectId

    END
GO
