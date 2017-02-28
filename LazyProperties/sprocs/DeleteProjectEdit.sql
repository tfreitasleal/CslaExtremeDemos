/****** Object:  StoredProcedure [dbo].[DeleteProjectEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteProjectEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[DeleteProjectEdit]
GO

CREATE PROCEDURE [dbo].[DeleteProjectEdit]
    @ProjectId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [ProjectId] FROM [dbo].[Projects]
            WHERE
                [ProjectId] = @ProjectId
        )
        BEGIN
            RAISERROR ('''dbo.ProjectEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child VendorItem from Vendors */
        DELETE
            [dbo].[Vendors]
        FROM [dbo].[Vendors]
            INNER JOIN [dbo].[Projects] ON [Vendors].[ProjectId] = [Projects].[ProjectId]
        WHERE
            [dbo].[Projects].[ProjectId] = @ProjectId

        /* Delete ProjectEdit object from Projects */
        DELETE
        FROM [dbo].[Projects]
        WHERE
            [dbo].[Projects].[ProjectId] = @ProjectId

    END
GO