/****** Object:  StoredProcedure [dbo].[UpdateProjectEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProjectEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateProjectEdit]
GO

CREATE PROCEDURE [dbo].[UpdateProjectEdit]
    @ProjectId int,
    @ProjecName varchar(50),
    @StartDate datetime2,
    @DeliveryDate datetime2
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

        /* Update object in dbo.Projects */
        UPDATE [dbo].[Projects]
        SET
            [ProjecName] = @ProjecName,
            [StartDate] = @StartDate,
            [DeliveryDate] = @DeliveryDate
        WHERE
            [ProjectId] = @ProjectId

    END
GO
